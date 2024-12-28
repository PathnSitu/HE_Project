using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace HematoxinandEosin.togs
{
    class toggsss : CheckBox
    {
      
        public toggsss()
        {
            this.MinimumSize = new Size(150, 22);
            //this.FlatAppearance.BorderSize =50;
            //this.FlatAppearance.BorderRadius = 20;
            
            
        }
        private int borderSize = 0;
        private int borderRadius = 40;
        //private Color borderColor = Color.PaleVioletRed;

        private Color onBackColor = Color.MediumSlateBlue;
        private Color onToggleColor = Color.WhiteSmoke;
        private Color offBackColor = Color.Gray;
        private Color offToggleColor = Color.Gainsboro;
        private bool solidStyle = true;

        [Category("RJ Code Advace")]
        public Color OnBackColor
        {
            get
            {
                return onBackColor;
            }
            set
            {
                onBackColor = value;
                this.Invalidate();
            }
        }
        public Color OnToggleColor
        {
            get
            {
                return onToggleColor;
            }
            set
            {
                onToggleColor = value;
                this.Invalidate();
            }
        }
        public Color OffBackColor
        {
            get
            {
                return offBackColor;
            }
            set
            {
                offBackColor = value;
                this.Invalidate();
            }
        }
        public Color OffToggleColor
        {
            get
            {
                return offToggleColor;
            }
            set
            {
                offToggleColor = value;
                this.Invalidate();
            }
        }


        public override string Text { get { return base.Text; } set { } }

        [DefaultValue(true)]
        public bool SolidStyle { get { return solidStyle; } set { solidStyle = value; this.Invalidate(); } }

        public int BorderSize { get { return borderSize; } set { borderSize = value; this.Invalidate(); } }
        public int BorderRadius { get { return borderRadius; } set { borderRadius = value; this.Invalidate(); } }

        //public Color BorderColor {
        //    get { return borderColor; } set { borderColor = value; this.Invalidate(); } }

        private GraphicsPath GetFigurePath()
        {
            int arcsize =this.Height-1 ;
            Rectangle leftArc = new Rectangle(this.Width, 0,  arcsize, arcsize);
            Rectangle rightArc = new Rectangle(this.Width  , 0, arcsize, arcsize);
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(leftArc, 90, 180);
            path.AddArc(rightArc,270, 180);
            path.CloseFigure();
            return path;
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            int toggleSize = this.Height-5 ;
            // using(Pen penBorder=new Pen(borderColor,borderSize))
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.Clear(this.Parent.BackColor);
           // RectangleF rectSurface = new RectangleF(0, 0, this.Width, this.Height);
            if (this.Checked)
            {
                if (solidStyle)
                    pevent.Graphics.FillPath(new SolidBrush(onBackColor), GetFigurePath());
                else pevent.Graphics.DrawPath(new Pen(onBackColor, 2), GetFigurePath());
                pevent.Graphics.FillRectangle(new SolidBrush(onToggleColor), new Rectangle(this.Width - this.Height + 1, 2, toggleSize, toggleSize));

            }
            else
            {
                if (solidStyle)
                    pevent.Graphics.FillPath(new SolidBrush(offBackColor), GetFigurePath());
                else pevent.Graphics.DrawPath(new Pen(offBackColor, 2), GetFigurePath());
                pevent.Graphics.FillRectangle(new SolidBrush(offToggleColor), new Rectangle(2, 2, toggleSize, toggleSize));

            }
           
        }
    }
}
