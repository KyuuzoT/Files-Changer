using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesChanger.View.CustomViewElements
{
    public class RoundedButton : Button
    {
        /// <summary>
        /// The starting angle of the arc, measured in degrees clockwise from the x-axis.
        /// </summary>
        private readonly float StartAngle = 90;
        /// <summary>
        /// Angle between startAngle and the end of the arc
        /// </summary>
        private readonly float SweepAngle = 90;

        private bool IsRoundingEnabled = false;
        [Category("Layout")]
        [Description("Turn rounding on/off")]
        public bool RoundingEnabled
        {
            get => IsRoundingEnabled;
            set 
            {
                IsRoundingEnabled = value;
                Refresh();
            }
        }

        private float Rounding = 100;
        [Category("Layout")]
        [DisplayName("Rounding [%]")]
        [Description("Set the percentage of rounding amount from 0% to 100%")]
        [Range(0.0f, 100.0f)]
        [DefaultValue(100f)]
        public float RoundingAmountPercentage
        {
            get => Rounding;
            set
            {
                if(value >= 0 && value <= 100)
                {
                    Rounding = value;
                    Refresh();
                }
            }
        }

        private SmoothingMode smoothing = SmoothingMode.Default;
        [Category("Layout")]
        [Description("Set smoothing mode for component")]
        [DefaultValue(SmoothingMode.Default)]
        public SmoothingMode Smoothing
        {
            get => smoothing;
            set => smoothing = value;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.HighQuality;

            var rect = new Rectangle(0, 0, Width-1, Height-1);

            float roundingValue = 0.1f;
            if(IsRoundingEnabled && Rounding > 0)
            {
                roundingValue = Height / 100f * Rounding;
            }

            var roundedRectPath = RoundedRectangleDrawer(rect, roundingValue);

            Region = new Region(roundedRectPath);

            graphics.DrawPath(new Pen(BackColor,2.0f), roundedRectPath);
            

            base.OnPaint(e);
        }

        private GraphicsPath RoundedRectangleDrawer(Rectangle rect, float roundSize)
        {
            var gpath = new GraphicsPath();

            gpath.AddArc(rect.X, rect.Y, roundSize, roundSize, StartAngle * 2, SweepAngle);
            gpath.AddArc(rect.X + rect.Width - roundSize, rect.Y, roundSize, roundSize, StartAngle * 3, SweepAngle);
            gpath.AddArc(rect.X + rect.Width - roundSize, rect.Y + rect.Height - roundSize, roundSize, roundSize, StartAngle * 0, SweepAngle);
            gpath.AddArc(rect.X, rect.Y + rect.Height - roundSize, roundSize, roundSize, StartAngle, SweepAngle);

            gpath.CloseFigure();


            return gpath;
        }
    }
}
