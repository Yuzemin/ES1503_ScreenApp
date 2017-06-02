using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace ShouldPadMachine.ShouldPadMachineUI
{
    class AddCtrlStr
    {
        public void AddString(Graphics g, string Str, Control btn, Font font, SolidBrush drawBrush)
        {
            SizeF StrSize = new SizeF();
            SizeF MinPos = new SizeF(btn.Location.X + btn.Size.Width / 2, btn.Location.Y + btn.Size.Height);

            StrSize = g.MeasureString(Str, font);
            RectangleF drawRect = new RectangleF(MinPos.Width - StrSize.Width / 2, MinPos.Height, StrSize.Width, StrSize.Height);

            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Center;
            drawFormat.LineAlignment = StringAlignment.Center;

            g.DrawString(Str, font, drawBrush, drawRect, drawFormat);
        }
    }
}
