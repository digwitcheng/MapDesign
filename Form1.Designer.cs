namespace AGV_V1._0
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.distanceTotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.finishCountLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.picShow = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pic = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.colComBox = new System.Windows.Forms.ComboBox();
            this.rowComBox = new System.Windows.Forms.ComboBox();
            this.colBtn = new System.Windows.Forms.Button();
            this.rowBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.colTxt = new System.Windows.Forms.TextBox();
            this.rowTxt = new System.Windows.Forms.TextBox();
            this.moveBtn = new System.Windows.Forms.RadioButton();
            this.removeDireBtn = new System.Windows.Forms.RadioButton();
            this.addDireBtn = new System.Windows.Forms.RadioButton();
            this.roadBtn = new System.Windows.Forms.RadioButton();
            this.observeBtn = new System.Windows.Forms.RadioButton();
            this.button10 = new System.Windows.Forms.Button();
            this.cancelUndoBtn = new System.Windows.Forms.Button();
            this.undoBtn = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.emptyRoadBtn = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picShow)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(746, 6);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Gray;
            this.splitContainer1.Panel1.Controls.Add(this.distanceTotal);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.finishCountLabel);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.picShow);
            this.splitContainer1.Size = new System.Drawing.Size(263, 549);
            this.splitContainer1.SplitterDistance = 265;
            this.splitContainer1.TabIndex = 36;
            // 
            // distanceTotal
            // 
            this.distanceTotal.AutoSize = true;
            this.distanceTotal.Location = new System.Drawing.Point(95, 152);
            this.distanceTotal.Name = "distanceTotal";
            this.distanceTotal.Size = new System.Drawing.Size(41, 12);
            this.distanceTotal.TabIndex = 5;
            this.distanceTotal.Text = "label5";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "总里程：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "完成任务：";
            // 
            // finishCountLabel
            // 
            this.finishCountLabel.AutoSize = true;
            this.finishCountLabel.Location = new System.Drawing.Point(83, 123);
            this.finishCountLabel.Name = "finishCountLabel";
            this.finishCountLabel.Size = new System.Drawing.Size(11, 12);
            this.finishCountLabel.TabIndex = 2;
            this.finishCountLabel.Text = "0";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(3, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Gray;
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(41, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // picShow
            // 
            this.picShow.BackColor = System.Drawing.Color.Gray;
            this.picShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picShow.Location = new System.Drawing.Point(0, 0);
            this.picShow.Name = "picShow";
            this.picShow.Size = new System.Drawing.Size(261, 278);
            this.picShow.TabIndex = 0;
            this.picShow.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.pic);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(367, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(370, 549);
            this.panel1.TabIndex = 35;
            // 
            // pic
            // 
            this.pic.Location = new System.Drawing.Point(27, 18);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(100, 50);
            this.pic.TabIndex = 0;
            this.pic.TabStop = false;
            this.pic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pic_MouseDown);
            this.pic.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pic_MouseMove);
            this.pic.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pic_MouseUp);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Controls.Add(this.emptyRoadBtn);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.colComBox);
            this.panel2.Controls.Add(this.rowComBox);
            this.panel2.Controls.Add(this.colBtn);
            this.panel2.Controls.Add(this.rowBtn);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.colTxt);
            this.panel2.Controls.Add(this.rowTxt);
            this.panel2.Controls.Add(this.moveBtn);
            this.panel2.Controls.Add(this.removeDireBtn);
            this.panel2.Controls.Add(this.addDireBtn);
            this.panel2.Controls.Add(this.roadBtn);
            this.panel2.Controls.Add(this.observeBtn);
            this.panel2.Controls.Add(this.button10);
            this.panel2.Controls.Add(this.cancelUndoBtn);
            this.panel2.Controls.Add(this.undoBtn);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(352, 549);
            this.panel2.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(42, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 29);
            this.button1.TabIndex = 58;
            this.button1.Text = "载入模板...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(105, 342);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 57;
            this.label8.Text = "方向：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(103, 320);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 56;
            this.label7.Text = "方向：";
            // 
            // colComBox
            // 
            this.colComBox.FormattingEnabled = true;
            this.colComBox.Items.AddRange(new object[] {
            "上",
            "下",
            "左",
            "右"});
            this.colComBox.Location = new System.Drawing.Point(157, 338);
            this.colComBox.Name = "colComBox";
            this.colComBox.Size = new System.Drawing.Size(70, 20);
            this.colComBox.TabIndex = 55;
            // 
            // rowComBox
            // 
            this.rowComBox.FormattingEnabled = true;
            this.rowComBox.Items.AddRange(new object[] {
            "上",
            "下",
            "左",
            "右"});
            this.rowComBox.Location = new System.Drawing.Point(157, 312);
            this.rowComBox.Name = "rowComBox";
            this.rowComBox.Size = new System.Drawing.Size(70, 20);
            this.rowComBox.TabIndex = 54;
            // 
            // colBtn
            // 
            this.colBtn.Location = new System.Drawing.Point(233, 339);
            this.colBtn.Name = "colBtn";
            this.colBtn.Size = new System.Drawing.Size(54, 23);
            this.colBtn.TabIndex = 53;
            this.colBtn.Text = "确定";
            this.colBtn.UseVisualStyleBackColor = true;
            this.colBtn.Click += new System.EventHandler(this.colBtn_Click);
            // 
            // rowBtn
            // 
            this.rowBtn.Location = new System.Drawing.Point(233, 310);
            this.rowBtn.Name = "rowBtn";
            this.rowBtn.Size = new System.Drawing.Size(54, 23);
            this.rowBtn.TabIndex = 52;
            this.rowBtn.Text = "确定";
            this.rowBtn.UseVisualStyleBackColor = true;
            this.rowBtn.Click += new System.EventHandler(this.rowBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(-2, 342);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 51;
            this.label6.Text = "第几列：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(-2, 315);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 50;
            this.label5.Text = "第几行：";
            // 
            // colTxt
            // 
            this.colTxt.Location = new System.Drawing.Point(57, 339);
            this.colTxt.Name = "colTxt";
            this.colTxt.Size = new System.Drawing.Size(39, 21);
            this.colTxt.TabIndex = 49;
            // 
            // rowTxt
            // 
            this.rowTxt.Location = new System.Drawing.Point(57, 312);
            this.rowTxt.Name = "rowTxt";
            this.rowTxt.Size = new System.Drawing.Size(39, 21);
            this.rowTxt.TabIndex = 48;
            // 
            // moveBtn
            // 
            this.moveBtn.AutoSize = true;
            this.moveBtn.Location = new System.Drawing.Point(34, 161);
            this.moveBtn.Name = "moveBtn";
            this.moveBtn.Size = new System.Drawing.Size(47, 16);
            this.moveBtn.TabIndex = 47;
            this.moveBtn.TabStop = true;
            this.moveBtn.Text = "移动";
            this.moveBtn.UseVisualStyleBackColor = true;
            // 
            // removeDireBtn
            // 
            this.removeDireBtn.AutoSize = true;
            this.removeDireBtn.Location = new System.Drawing.Point(34, 270);
            this.removeDireBtn.Name = "removeDireBtn";
            this.removeDireBtn.Size = new System.Drawing.Size(71, 16);
            this.removeDireBtn.TabIndex = 46;
            this.removeDireBtn.TabStop = true;
            this.removeDireBtn.Text = "删除方向";
            this.removeDireBtn.UseVisualStyleBackColor = true;
            // 
            // addDireBtn
            // 
            this.addDireBtn.AutoSize = true;
            this.addDireBtn.Location = new System.Drawing.Point(34, 248);
            this.addDireBtn.Name = "addDireBtn";
            this.addDireBtn.Size = new System.Drawing.Size(71, 16);
            this.addDireBtn.TabIndex = 45;
            this.addDireBtn.TabStop = true;
            this.addDireBtn.Text = "增加方向";
            this.addDireBtn.UseVisualStyleBackColor = true;
            // 
            // roadBtn
            // 
            this.roadBtn.AutoSize = true;
            this.roadBtn.Location = new System.Drawing.Point(34, 205);
            this.roadBtn.Name = "roadBtn";
            this.roadBtn.Size = new System.Drawing.Size(95, 16);
            this.roadBtn.TabIndex = 44;
            this.roadBtn.TabStop = true;
            this.roadBtn.Text = "有四方向道路";
            this.roadBtn.UseVisualStyleBackColor = true;
            // 
            // observeBtn
            // 
            this.observeBtn.AutoSize = true;
            this.observeBtn.Location = new System.Drawing.Point(34, 183);
            this.observeBtn.Name = "observeBtn";
            this.observeBtn.Size = new System.Drawing.Size(47, 16);
            this.observeBtn.TabIndex = 43;
            this.observeBtn.TabStop = true;
            this.observeBtn.Text = "障碍";
            this.observeBtn.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(6, 486);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 33);
            this.button10.TabIndex = 42;
            this.button10.Text = "保存";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // cancelUndoBtn
            // 
            this.cancelUndoBtn.Location = new System.Drawing.Point(111, 372);
            this.cancelUndoBtn.Name = "cancelUndoBtn";
            this.cancelUndoBtn.Size = new System.Drawing.Size(116, 28);
            this.cancelUndoBtn.TabIndex = 41;
            this.cancelUndoBtn.Text = "反撤销(ctrl+Y)";
            this.cancelUndoBtn.UseVisualStyleBackColor = true;
            this.cancelUndoBtn.Click += new System.EventHandler(this.cancelUndoBtn_Click);
            // 
            // undoBtn
            // 
            this.undoBtn.Location = new System.Drawing.Point(6, 372);
            this.undoBtn.Name = "undoBtn";
            this.undoBtn.Size = new System.Drawing.Size(99, 28);
            this.undoBtn.TabIndex = 40;
            this.undoBtn.Text = "撤销(ctrl+Z)";
            this.undoBtn.UseVisualStyleBackColor = true;
            this.undoBtn.Click += new System.EventHandler(this.undoBtn_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(42, 41);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 35;
            this.button5.Text = "正常大小";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(42, 65);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 25);
            this.button2.TabIndex = 8;
            this.button2.Text = "放大";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(42, 96);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 25);
            this.button3.TabIndex = 9;
            this.button3.Text = "缩小";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Gray;
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.77075F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.54941F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.77866F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1015, 561);
            this.tableLayoutPanel1.TabIndex = 38;
            // 
            // emptyRoadBtn
            // 
            this.emptyRoadBtn.AutoSize = true;
            this.emptyRoadBtn.Location = new System.Drawing.Point(34, 226);
            this.emptyRoadBtn.Name = "emptyRoadBtn";
            this.emptyRoadBtn.Size = new System.Drawing.Size(83, 16);
            this.emptyRoadBtn.TabIndex = 59;
            this.emptyRoadBtn.TabStop = true;
            this.emptyRoadBtn.Text = "无方向道路";
            this.emptyRoadBtn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1015, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(1, 1);
            this.MinimumSize = new System.Drawing.Size(800, 497);
            this.Name = "Form1";
            this.Text = "AGV系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picShow)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label distanceTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label finishCountLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picShow;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button cancelUndoBtn;
        private System.Windows.Forms.Button undoBtn;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RadioButton removeDireBtn;
        private System.Windows.Forms.RadioButton addDireBtn;
        private System.Windows.Forms.RadioButton roadBtn;
        private System.Windows.Forms.RadioButton observeBtn;
        private System.Windows.Forms.RadioButton moveBtn;
        private System.Windows.Forms.Button colBtn;
        private System.Windows.Forms.Button rowBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox colTxt;
        private System.Windows.Forms.TextBox rowTxt;
        private System.Windows.Forms.ComboBox colComBox;
        private System.Windows.Forms.ComboBox rowComBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton emptyRoadBtn;
    }
}

