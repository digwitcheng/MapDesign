using System.Drawing;
using System.IO;

namespace AGV_V1._0.Util
{
    class DrawUtil
    {
        /// 图片转换成字节流 
        /// </summary> 
        /// <param name="img">要转换的Image对象</param> 
        /// <returns>转换后返回的字节流</returns> 
        public static byte[] ImgToByt(Image img)
        {
            MemoryStream ms = new MemoryStream();
            byte[] imagedata = null;
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            imagedata = ms.GetBuffer();
            return imagedata;
        }
        /// <summary> 
        /// 字节流转换成图片 
        /// </summary> 
        /// <param name="byt">要转换的字节流</param> 
        /// <returns>转换得到的Image对象</returns> 
        public static Image BytToImg(byte[] byt)
        {
            MemoryStream ms = new MemoryStream(byt);
            Image img = Image.FromStream(ms);
            return img;
        }

        public static void FillEllipse(Graphics g, Color color, int x, int y, int width, int height)
        {
            g.FillEllipse(new SolidBrush(color), new Rectangle(x, y, width, height));
        }
        public static void FillRectangle(Graphics g, Color color, int x, int y, int width, int height)
        {
            g.FillRectangle(new SolidBrush(color), new Rectangle(x, y, width,height));            
        }
        public static void FillRectangle(Graphics g, Color color, Rectangle rect)
        {
            g.FillRectangle(new SolidBrush(color), rect);
        }
       
        public static void DrawString(Graphics g, int context, float fontSize, Color fontColor, int x, int y)
        {
            DrawString(g, context+"", fontSize, fontColor, x, y);
        }
        

        public static void DrawString(Graphics g, string context, float fontSize, Color fontColor, int x, int y)
        {
            DrawString(g, context, fontSize, fontColor, new PointF(x, y));
        }

        public static void DrawString(Graphics g, int context, float fontSize, Color fontColor, PointF pf)
        {
            DrawString(g, context + "", fontSize, fontColor, pf);
        }
        public static void DrawString(Graphics g, string context, float fontSize, Color fontColor, PointF pf)
        {
            Font font = new Font(new System.Drawing.FontFamily("宋体"), fontSize);
            Brush brush = new SolidBrush(fontColor);
            g.DrawString(context + "", font, brush, pf);
        }
    }
}
