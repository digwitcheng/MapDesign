//#define moni


using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AGV_V1._0.Properties;
using AGV_V1._0.Algorithm;
using AGV_V1._0.NLog;
using AGV_V1._0.Util;
using System.Collections.Concurrent;
using AGV_V1._0.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Tcp;
using AGV_V1._0.DesignCommand;
using AGV_V1._0.Agv;

namespace AGV_V1._0
{
    public partial class Form1 : Form
    {
        public const float PANEL_RADIO = 0.7f;   //界面布局，中间场地占屏比
        public const float ENLARGER_RADIO = 1.2f;//每次放大的比率
        public const float NARROW_RADIO = 0.8f; //每次缩小的比率
        public const int FONT_SISE = 10; //消息显示面板字体大小
        public const int ROW_BOARD = 4;  //消息显示上下行空白大小
        public static int g_MapWidth = (int)(FORM_WIDTH * PANEL_RADIO);
        public static int g_MapHeight = (int)(FORM_HEIGHT);
        public static readonly int FORM_WIDTH = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;   //框体的宽度
        public static readonly int FORM_HEIGHT = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;    //框体的长度  

        private Bitmap surface = null;
        private Graphics g = null;
        //private Graphics gg = null;
        public static Random rand = new Random(5);//5,/4/4 //((int)DateTime.Now.Ticks);//随机数，随机产生坐标
        
        private System.Threading.Timer timer;
        private ElecMap Elc;
        private RouteRemoteObject remotableObject;

        public const int Up = (1 << 3);
        public const int Down = (1 << 2);
        public const int Left = (1 << 1);
        public const int Right = (1 << 0);
        private static readonly Dictionary<int, Image> IMAGE_DICT = new Dictionary<int, Image>{
        {15,Resources.all_white},              //1111   15
        {7 ,Resources.besides_up_white},       //0111   7
        {11,Resources.besides_down_white},     //1011   11
        {13,Resources.besides_left_white},     //1101   13
        {14,Resources.besides_right_white},    //1110   14
        {10,Resources.up_left_white},          //1010   10
        {9 ,Resources.up_right_white},         //1001   9
        {6 ,Resources.down_left_white},        //0110   6
        {5 ,Resources.down_right_white},       //0101   5
        {12,Resources.up_down_white },         //1100  12
        {3,Resources.left_right_white },       //0011   3
        {8 ,Resources.up_white},               //1000   8
        {4 ,Resources.down_white},             //0100   4
        {2 ,Resources.left_white},             //0010   2
        {1 ,Resources.right_white},            //0001   1
        {-1 ,Resources.obstacle_white},        //0000   0
        {0,Resources.empty_white}              //ffff   -1
        };


        private MapControl mapControl = null;

        public Form1()
        {
            InitializeComponent();
             InitUiView(ConstDefine.MAP_PATH);//绘制界面

        }


        private void StartRemoteServer()
        {
            remotableObject = new RouteRemoteObject();
            TcpChannel channel = new TcpChannel(ConstDefine.REMOTE_PORT);
            ChannelServices.RegisterChannel(channel);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RouteRemoteObject), ConstDefine.REMOTE_NAME, WellKnownObjectMode.Singleton);


        }

        private void ConnectDataBase()
        {
            //SqlManager.Instance.Connect2DataBase();
        }

        private int MAX_NODE_LENGTH;
        private int MIN_NODE_LENGTH;
        void InitUiView(string path)
        {
            Elc = new ElecMap();
            Elc.InitialElc(path);
            this.WindowState = FormWindowState.Maximized;
            this.tableLayoutPanel1.ColumnStyles[0].Width = (int)FORM_WIDTH * (1 - PANEL_RADIO) / 2;
            this.tableLayoutPanel1.ColumnStyles[1].Width = (int)FORM_WIDTH * (PANEL_RADIO);
            this.tableLayoutPanel1.ColumnStyles[2].Width = (int)FORM_WIDTH * (1 - PANEL_RADIO) / 2;

            ConstDefine.g_NodeLength = (int)(FORM_WIDTH * PANEL_RADIO) / ConstDefine.g_WidthNum;
            MAX_NODE_LENGTH = ConstDefine.g_NodeLength * 3;
            MIN_NODE_LENGTH = ConstDefine.g_NodeLength *2/3;

            ////设置滚动条滚动的区域
            //this.AutoScrollMinSize = new Size(ConstDefine.WIDTH + ConstDefine.BEGIN_X, ConstDefine.HEIGHT);

            mapControl = new MapControl(Elc);
            rowComBox.SelectedIndex = 0;
            colComBox.SelectedIndex = 0;
            SetMapView();

        }        
        void SetMapView()
        {
            pic.Location = Point.Empty;
            int w = ConstDefine.g_NodeLength * (ConstDefine.g_WidthNum + 2);
            int h = ConstDefine.g_NodeLength * (ConstDefine.g_HeightNum + 2);
            //设置滚动条滚动的区域
            panel1.AutoScrollMinSize = new Size(w, h);
            pic.Size = new Size(w, h);
            surface = new Bitmap(w, h);
            g = Graphics.FromImage(surface);
            pic.Image = newSurface;
            pic.BackColor = Color.FromArgb(100, 0, 0, 0);


            //Point point = Cursor.Position;
            //Point midPoint = new Point(FORM_WIDTH / 2, FORM_HEIGHT / 2);
            ////panel1.AutoScrollPosition = new Point(panel1.HorizontalScroll.Value + (int)(point.X - midPoint.X), panel1.VerticalScroll.Value + (int)(point.Y - midPoint.Y));
            //panel1.AutoScrollOffset = new Point( (int)(midPoint.X-point.X ),(int)(midPoint.Y-point.Y));
                      
            SetMapLocation();
            

        }
        void SetMapLocation()
        {
            //横纵坐标的控制变量
            int point_x, point_y;
            //节点类型
            point_x = 0;
            point_y = ConstDefine.g_NodeLength;

            for (int i = 0; i < Elc.HeightNum; i++)
            {
                point_x = ConstDefine.g_NodeLength;
                for (int j = 0; j < Elc.WidthNum; j++)
                {
                    //Elc.mapnode[i, j] = new MapNode(point_x, point_y, Node_number, point_type);
                    Elc.mapnode[i, j].X = point_x;
                    Elc.mapnode[i, j].Y = point_y;
                    point_x += ConstDefine.g_NodeLength;

                }
                point_y += ConstDefine.g_NodeLength;
            }
            DrawMap();
        }
        public void DrawMap()
        {
            for (int i = 0; i < Elc.HeightNum; i++)
            {
                for (int j = 0; j < Elc.WidthNum; j++)
                {
                    drawArrow(i, j);
                    //绘制标尺
                    if (i == 0 || i == Elc.HeightNum - 1)
                    {
                        int Y = (i == 0 ? 0 : Elc.mapnode[i, j].Y + ConstDefine.g_NodeLength);
                        DrawUtil.DrawString(g, j, ConstDefine.g_NodeLength / 2, Color.Yellow, Elc.mapnode[i, j].X - 1, Y);
                    }
                    if (j == 0 || j == Elc.WidthNum - 1)
                    {
                        int X = (j == 0 ? 0 : Elc.mapnode[i, j].X + ConstDefine.g_NodeLength);
                        DrawUtil.DrawString(g, i, ConstDefine.g_NodeLength / 2, Color.Yellow, X, Elc.mapnode[i, j].Y - 1);
                    }
                    //绘制图标
                    DrawIcon(i,j);
                }
            }
        }
        void DrawIcon(int i,int j)
        {
            switch (Elc.mapnode[i, j].Type)
            {
                case MapNodeType.scanner:
                    DrawUtil.DrawString(g, j, ConstDefine.g_NodeLength / 2, Color.FromArgb(), Elc.mapnode[i, j].X - 1, Elc.mapnode[i, j].X - 1);
                    break;
            }

        }

        Bitmap newSurface;
        /// <summary>
        /// 绘制电子地图
        /// </summary>
        /// <param name="e"></param>
        public void Draw(Graphics g)
        {
            newSurface = new Bitmap(surface);
            Graphics gg = Graphics.FromImage(newSurface);
            //绘制探测节点
            pic.Image = newSurface;
        }


        void drawArrow(int y, int x)
        {
            //模拟地图
            int dir = 0;
            if (Elc.mapnode[y, x].RightDifficulty < MapNode.MAX_ABLE_PASS)
            {
                dir |= Right;
            }
            if (Elc.mapnode[y, x].LeftDifficulty < MapNode.MAX_ABLE_PASS)
            {
                dir |= Left;
            }
            if (Elc.mapnode[y, x].DownDifficulty < MapNode.MAX_ABLE_PASS)
            {
                dir |= Down;
            }
            if (Elc.mapnode[y, x].UpDifficulty < MapNode.MAX_ABLE_PASS)
            {
                dir |= Up;
            }
            if (Elc.mapnode[y, x].IsAbleCross == false)
            {
                dir = -1;
            }
            else
            {
                dir = 15;
            }
            Image img = IMAGE_DICT[dir];
            if (img != null)
            {
                g.DrawImage(img, new Rectangle(Elc.mapnode[y, x].X - 1, Elc.mapnode[y, x].Y - 1, ConstDefine.g_NodeLength, ConstDefine.g_NodeLength));

            }
        }

        #region  待整理...
        /// <summary>
        /// 定时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            Draw(g);
            //this.Invalidate();
        }
       

        void ShowFinishCount(string str)
        {
            finishCountLabel.Text = str;
        }
       
        void ShowDistanceCount(string str)
        {
            distanceTotal.Text = str;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.MouseWheel += Form1_MouseWheel;
            this.moveBtn.Checked = true;
        }

        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (ConstDefine.g_NodeLength < MAX_NODE_LENGTH)
                {
                    ConstDefine.g_NodeLength += (int)e.Delta / 20;
                    SetMapView();
                    this.Invalidate();
                }
            }
            else
            {
                if (ConstDefine.g_NodeLength > MIN_NODE_LENGTH)
                {
                    ConstDefine.g_NodeLength += (int)e.Delta / 20;
                    SetMapView();
                    this.Invalidate();
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Environment.Exit(0); 

            if (MessageBox.Show("是否保存？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                FileUtil.SaveDesignedMap(Elc);
            }            

        }
       
        #endregion

        /// <summary>
        /// 放大键触发的函数
        /// Stack没有获取栈顶元素的函数，所以先弹出栈顶元素，然后弹出第二个元素并获取，然后将第二个元素压入栈
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (ConstDefine.g_NodeLength < MAX_NODE_LENGTH)
            {
                ConstDefine.g_NodeLength = (int)(ConstDefine.g_NodeLength * ENLARGER_RADIO);
                SetMapView();
               this.Invalidate();
            }
        }

        /// <summary>
        /// 缩小键触发的函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (ConstDefine.g_NodeLength > MIN_NODE_LENGTH && ConstDefine.g_NodeLength > 1)
            {
                ConstDefine.g_NodeLength = (int)(ConstDefine.g_NodeLength * NARROW_RADIO);
                //  Elc.InitialElc(); //初始化电子地图
                SetMapView();
                this.Invalidate();
            }
        }

        /// <summary>
        /// 正常大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click_1(object sender, EventArgs e)
        {
            ConstDefine.g_NodeLength = (int)(FORM_WIDTH * PANEL_RADIO) / ConstDefine.g_WidthNum;
            //Elc.InitialElc(); //初始化电子地图
            SetMapView();
            this.Invalidate();
        }
        private void EndRemoteServer()
        {
            RemotingServices.Disconnect(remotableObject);
        }
        private Point startLocation = Point.Empty;
        private Point endLocation = Point.Empty;
        bool moveLeftClick;
        Point oldPoint;

        private void pic_MouseDown(object sender, MouseEventArgs e)
        {
            startLocation = e.Location;
            Point p= this.pic.Location;
            if (e.Button == MouseButtons.Left&&this.moveBtn.Checked)
            {
                oldPoint = pic.PointToClient(Control.MousePosition);
                moveLeftClick = true;
            }
        }
        private void pic_MouseMove(object sender, MouseEventArgs e)
        {
            if (moveLeftClick)
            {
                Point nowPoint = pic.PointToClient(Control.MousePosition);
                Point p = new Point(nowPoint.X - oldPoint.X, nowPoint.Y - oldPoint.Y);
                panel1.AutoScrollPosition = new Point( panel1.HorizontalScroll.Value-p.X,panel1.VerticalScroll.Value-p.Y);
            }
        }       
        private void pic_MouseUp(object sender, MouseEventArgs e)
        {
            if (moveLeftClick)
            {
                moveLeftClick = false;
                return;
            }
            endLocation = e.Location;

            MyPoint start = GetMyPoint(startLocation);
            MyPoint end = GetMyPoint(endLocation);
            int xDistance = end.X - start.X;
            int yDistance = end.Y - start.Y;
            List<BaseCommand> commands = new List<BaseCommand>();

            if (xDistance == 0 && yDistance == 0)//一个节点的设计命令
            {
                float xDistanceLocation = endLocation.X - startLocation.X;
                float yDistanceLocation = endLocation.Y - startLocation.Y;
                if (Math.Abs(xDistanceLocation) < Math.Abs(yDistanceLocation))
                {
                    BaseCommand command = GetCurrentCommand(start.X, start.Y);
                    command.Dir = yDistanceLocation > 0 ? Direction.Down : Direction.Up;
                    commands.Add(command);
                }
                else
                {
                    BaseCommand command = GetCurrentCommand(end.X, end.Y);
                    command.Dir = xDistanceLocation > 0 ? Direction.Right : Direction.Left;
                    commands.Add(command);
                }
            }
            else if (Math.Abs(xDistance) >= Math.Abs(yDistance))
            {
                for (int i = 0; i <= Math.Abs(xDistance); i++)
                {
                    int x = start.X + xDistance * i / Math.Abs(xDistance);
                    BaseCommand command = GetCurrentCommand(x, start.Y);
                    command.Dir = xDistance > 0 ? Direction.Down : Direction.Up;
                    commands.Add(command);
                }
            }
            else
            {
                for (int i = 0; i <= Math.Abs(yDistance); i++)
                {
                    int y = start.Y + yDistance * i / Math.Abs(yDistance);
                    BaseCommand command = GetCurrentCommand(start.X, y);
                    command.Dir = yDistance > 0 ? Direction.Right : Direction.Left;
                    commands.Add(command);
                }
            }
            mapControl.ExcuteCommand(commands);
            DrawMap(commands);
        }
        void DrawMap(List<BaseCommand> commands)
        {
            if (commands == null) return;
            foreach(BaseCommand bc in commands)
            {
                drawArrow(bc.X, bc.Y);
            }
        }
        MyPoint GetMyPoint(Point p)
        {
            int x = p.Y / ConstDefine.g_NodeLength - 1;
            int y = p.X / ConstDefine.g_NodeLength - 1;
            if (x > Elc.HeightNum - 1)
            {
                x = Elc.HeightNum - 1;
            }
            if (x < 0)
            {
                x = 0;
            }
            if (y > Elc.WidthNum - 1)
            {
                y = Elc.WidthNum - 1;
            }
            if (y < 0)
            {
                y = 0;
            }
            return new MyPoint(x, y);
        }
        BaseCommand GetCurrentCommand(int x, int y)
        {
            if (this.moveBtn.Checked)
            {
                return new MoveCommand(x, y);
            }
            else if (this.addDireBtn.Checked)
            {
                return new AddDireCommand(x, y);
            }
            else if (this.removeDireBtn.Checked)
            {
                return new RemoveDireCommand(x, y);
            }
            else if (this.observeBtn.Checked)
            {
                return new ObserveCommand(x, y);
            }
            else if (this.roadBtn.Checked)
            {
                return new RoadCommand(x, y);
            }else if (this.emptyRoadBtn.Checked)
            {
                return new EmptyRoadCommand(x,y);
            }
            return new NoneCommand(x, y);
        }

       

        private void rowBtn_Click(object sender, EventArgs e)
        {
            string row = rowTxt.Text.ToString().Trim();
            if (row.Equals(""))
            {
                return;
            }
            int rowNum = Int32.Parse(row);
            if (rowNum < 0 || rowNum > Elc.HeightNum)
            {
                MessageBox.Show("输入的行不合法!");
                return;
            }
            RowCommands(rowNum, rowNum);
        }

        private void colBtn_Click(object sender, EventArgs e)
        {
            string col = colTxt.Text.ToString().Trim();
            if (col.Equals(""))
            {
                return;
            }
            int colNum = Int32.Parse(col);
            if (colNum < 0 || colNum > Elc.WidthNum)
            {
                MessageBox.Show("输入的列不合法!");
                return;
            }
            ColCommands(colNum,colNum);
           
        }
        private void rowBtnDest_Click(object sender, EventArgs e)
        {
            string row = rowTxt.Text.ToString().Trim();
            string torow = rowDest.Text.ToString().Trim();
            if (row.Equals("") || torow.Equals(""))
            {
                return;
            }
            int rowNum = Int32.Parse(row);
            int toRowNum = Int32.Parse(torow);
            if (rowNum < 0 || rowNum > Elc.HeightNum || toRowNum < 0 || toRowNum > Elc.HeightNum)
            {
                MessageBox.Show("输入的列不合法!");
                return;
            }
            RowCommands(rowNum, toRowNum);
            
        }

        private void colBtnDest_Click(object sender, EventArgs e)
        {
            string col = colTxt.Text.ToString().Trim();
            string toCol = colDest.Text.ToString().Trim();
            if (col.Equals("")||toCol.Equals(""))
            {
                return;
            }
            int colNum = Int32.Parse(col);
            int toColNum = Int32.Parse(toCol);
            if (colNum < 0 || colNum > Elc.WidthNum|| toColNum < 0 || toColNum > Elc.WidthNum)
            {
                MessageBox.Show("输入的列不合法!");
                return;
            }
            ColCommands(colNum, toColNum);
            
        }
        void RowCommands(int rowNum,int toRowNum)
        {
            List<BaseCommand> commands = new List<BaseCommand>();
            for (int j = Math.Min(rowNum, toRowNum); j <= Math.Max(rowNum, toRowNum); j++)
            {
                for (int i = 0; i < Elc.WidthNum; i++)
                {
                    BaseCommand command = GetCurrentCommand(j, i);
                    command.Dir = GetComBoxDirection(rowComBox);
                    commands.Add(command);
                }
            }
            mapControl.ExcuteCommand(commands);
            DrawMap(commands);
        }
        void ColCommands(int colNum,int toColNum)
        {
            List<BaseCommand> commands = new List<BaseCommand>();

            for (int j = Math.Min(colNum, toColNum); j <= Math.Max(colNum, toColNum); j++)
            {
                for (int i = 0; i < Elc.HeightNum; i++)
                {
                    BaseCommand command = GetCurrentCommand(i, j);
                    command.Dir = GetComBoxDirection(colComBox);
                    commands.Add(command);
                }
            }
            mapControl.ExcuteCommand(commands);
            DrawMap(commands);
        }
        Direction GetComBoxDirection(ComboBox cb)
        {
            switch (cb.SelectedItem)
            {
                case "上": return Direction.Up;
                case "下":
                    return Direction.Down;
                case "左":
                    return Direction.Left;
                case "右":
                    return Direction.Right;
                default:
                    return Direction.Right;
            }
        }

        private void undoBtn_Click(object sender, EventArgs e)
        {
            List<BaseCommand> commands= mapControl.UndoCommand();
            DrawMap(commands);
        }

        private void cancelUndoBtn_Click(object sender, EventArgs e)
        {
            List<BaseCommand> commands = mapControl.CancelUndoCommand();
            DrawMap(commands);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Z && e.Control)
            {
                undoBtn.PerformClick(); 
            }
            if (e.KeyCode == Keys.Y && e.Control)
            {
                cancelUndoBtn.PerformClick();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FileUtil.SaveDesignedMap(Elc);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path= FileUtil.LoadTemplateMap();
            if (path == "")
            {
                return;
            }
            InitUiView(path);
        }

       
    }
}
