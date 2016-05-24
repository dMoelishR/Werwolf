using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Werwolf.Inhalt
{
    public abstract class Element
    {
        /// <summary>
        /// Mit Underlines statt Whitespaces
        /// </summary>
        public string Name { get; private set; }
        public string Schreibname
        {
            get
            {
                return Name.Replace('_', ' ');
            }
        }
        public string Desc { get; private set; }
        public Image Bild { get; private set; }
    }
}
