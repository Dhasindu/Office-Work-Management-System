using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homepageproject
{
    internal class DataGridViewProgressColumn : DataGridViewColumn
    {
        public DataGridViewProgressColumn()
        {
            this.CellTemplate = new DataGridViewProgressCell();
        }
    }

    public class DataGridViewProgressCell : DataGridViewTextBoxCell
    {
        protected override void Paint(Graphics g, Rectangle clipBounds,
            Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState,
            object value, object formattedValue, string errorText,
            DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            // Paint the base content
            base.Paint(g, clipBounds, cellBounds, rowIndex, cellState, value,
                formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);

            if (value != null)
            {
                int progressVal = Convert.ToInt32(value);

                // Progress bar bounds
                Rectangle progressBounds = new Rectangle(
                    cellBounds.X + 2,
                    cellBounds.Y + 2,
                    cellBounds.Width + 12,
                    cellBounds.Height - 5);

                // Draw progress bar background
                g.FillRectangle(Brushes.LightGray, progressBounds);

                // Draw progress
                int width = (int)((progressBounds.Width * progressVal) / 100.0);
                if (width > 0)
                {
                    // Choose color based on progress value
                    Color progressColor = progressVal < 30 ? Color.Red :
                                        progressVal < 60 ? Color.Orange :
                                        Color.Green;

                    Rectangle progressRect = new Rectangle(
                        progressBounds.X,
                        progressBounds.Y,
                        width,
                        progressBounds.Height);

                    g.FillRectangle(new SolidBrush(progressColor), progressRect);
                }

                // Draw progress text
                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    g.DrawString(progressVal.ToString() + "%",
                        cellStyle.Font,
                        Brushes.Black,
                        progressBounds,
                        sf);
                }
            }
        }
    }
}
