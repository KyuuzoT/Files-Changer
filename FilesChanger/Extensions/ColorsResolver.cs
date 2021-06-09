using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FilesChanger.Extensions
{
    public class ColorsResolver
    {
        private string pattern = @"(#(?:[0-9a-fA-F]{2}){2,4}|(#[0-9a-fA-F]{3})|\?)";
        internal Color ResolveColor(StandartColors color)
        {
            switch (color)
            {
                case StandartColors.Red:
                    return Color.Red;
                case StandartColors.White:
                    return Color.White;
                case StandartColors.Black:
                    return Color.Black;
                case StandartColors.Gray:
                    return Color.Gray;
                case StandartColors.Blue:
                    return Color.Blue;
                case StandartColors.Magenta:
                    return Color.Magenta;
                case StandartColors.Yellow:
                    return Color.Yellow;
                case StandartColors.Green:
                    return Color.Green;
                case StandartColors.Cyan:
                    return Color.Cyan;
                default:
                    return SystemColors.Window;
            }
        }

        internal Color ResolveColor(string argbColor)
        {
            Color color = SystemColors.Window;
            ColorConverter converter = new ColorConverter();

            try
            {
                if (Regex.IsMatch(argbColor, pattern))
                {
                    color = (Color)converter.ConvertFromString(argbColor);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Color converter error occured. Apparently, trying to pass wrong string as color", ex);
            }

            return color;
        }
    }
}
