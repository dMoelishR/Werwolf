using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Werwolf.Inhalt
{
    public abstract class Manifest : Element
    {
        public Aufgabe Aufgaben { get; private set; }

        public Manifest(string XmlName) : base(XmlName, false) 
        {

        }
    }
}
