using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Werwolf.Inhalt
{
    public class Bild
    {
        public Image Image { get; private set; }
        public string Artist { get; private set; }
        /// <summary>
        /// Größe in Millimeter
        /// </summary>
        public SizeF Size { get; private set; }
    }
}
