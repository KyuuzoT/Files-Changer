using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilesChanger.Extensions
{
    public class ColoredCheckedListBox : CheckedListBox
    {
        private ColorsResolver resolver = new ColorsResolver();
        private Color color;

        internal void SetTextColor(string textColor)
        {
            color = resolver.ResolveColor(textColor);
        }
        
        internal void SetTextColor(StandartColors textColor)
        {
            color = resolver.ResolveColor(textColor);
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            DrawItemEventArgs newEvent = new DrawItemEventArgs
                (
                    e.Graphics, 
                    e.Font, 
                    new Rectangle(e.Bounds.Location, e.Bounds.Size),
                    e.Index,
                    e.State,
                    this.CheckedIndices.Contains(e.Index) ? color : SystemColors.Window,
                    e.BackColor
                );
            base.OnDrawItem(newEvent);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }
}
