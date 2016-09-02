﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Assistment.Drawing.LinearAlgebra;
using Assistment.Texts;
using Assistment.form;
using Assistment.Extensions;

using Werwolf.Inhalt;
using Werwolf.Karten;

namespace Werwolf.Forms
{
    public class InfoDarstellungForm : DarstellungForm<InfoDarstellung>
    {
        public InfoDarstellungForm(Karte Karte)
            : base(Karte)
        {

        }

        public override void BuildWerteListe()
        {
            base.BuildWerteListe();
            UpdatingWerteListe = true;
            WerteListe.AddChainedSizeFBox(new SizeF(), "Randgröße in mm");
            WerteListe.AddColorBox(Color.White, "Hintergrundfarbe");
            //WerteListe.AddColorBox(Color.Black, "Textfarbe");
            WerteListe.AddFontBox(new Font("Calibri", 4), "Font");
            UpdatingWerteListe = false;
            WerteListe.Setup();
        }
        public override void UpdateWerteListe()
        {
            base.UpdateWerteListe();
            UpdatingWerteListe = true;
            WerteListe.SetValue("Randgröße in mm", element.Rand);
            WerteListe.SetValue("Hintergrundfarbe", element.Farbe);
            //WerteListe.SetValue("Textfarbe", element.TextFarbe);
            WerteListe.SetValue("Font", element.Font);
            UpdatingWerteListe = false;
        }
        public override void UpdateElement()
        {
            if (UpdatingWerteListe)
                return;
            base.UpdateElement();
            element.Rand = WerteListe.GetValue<SizeF>("Randgröße in mm");
            element.Farbe = WerteListe.GetValue<Color>("Hintergrundfarbe");
            //element.TextFarbe = WerteListe.GetValue<Color>("Textfarbe");
            element.Font = WerteListe.GetValue<Font>("Font");
        }
    }
}
