using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Componentes
{
    internal class RoundedButton : Button
    {
        private Color _backgroundColor;
        private int _radius;
        internal RoundedButton(string text, int width, int height, int radius)
        {
            this.Cursor = Cursors.Hand;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            _radius = radius;
            _backgroundColor = ColorTranslator.FromHtml("#B1C9FC");
            Size = new Size(width, height);
            BackColor = Color.Transparent;
            Text = text;
            ForeColor = ColorTranslator.FromHtml("#7DA5FA");
            Font = new System.Drawing.Font("Ubuntu", 16, FontStyle.Regular);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            using (var path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                path.AddArc(new Rectangle(0, 0, _radius, _radius), 180, 90);
                path.AddArc(new Rectangle(Width - _radius - 1, 0, _radius, _radius), -90, 90);
                path.AddArc(new Rectangle(Width - _radius - 1, Height - _radius - 1, _radius, _radius), 0, 90);
                path.AddArc(new Rectangle(0, Height - _radius - 1, _radius, _radius), 90, 90);
                path.CloseAllFigures();

                e.Graphics.FillPath(new SolidBrush(_backgroundColor), path);

                e.Graphics.DrawPath(new Pen(_backgroundColor, 1), path);

                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor),
                    new Rectangle(0, 0, Width, Height), sf);
            }
        }
    }
}
