using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Werwolf.Inhalt
{
    public class  Fraktion : Element
    {
        public Bild Hintergrundbild { get; private set; }
        public Aufgabe StandardAufgaben { get; private set; }

        public Fraktion() : base("Fraktion", true)
        {

        }
    }
}
