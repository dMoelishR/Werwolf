﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Werwolf.Inhalt;
using Werwolf.Karten;

using Assistment.Drawing.LinearAlgebra;
using Assistment.Texts;
using Assistment.form;
using Assistment.Extensions;

namespace Werwolf.Forms
{
    public class ElementAuswahlButton<T> : UserControl where T : XmlElement, new()
    {
        public T Element { get; set; }
        private ElementMenge<T> ElementMenge;
        private Karte Karte;

        private ButtonReihe Buttons = new ButtonReihe(false, "Auswählen", "Bearbeiten", "Klonen", "Entfernen");
        private Label Label = new Label();
        private GroupBox GroupBox = new GroupBox();

        public event EventHandler Ausgewahlt = delegate { };
        public event EventHandler Bearbeitet = delegate { };
        public event EventHandler Entfernt = delegate { };
        public event EventHandler Geklont = delegate { };

        public ElementAuswahlButton(T Element, Karte Karte, ElementMenge<T> ElementMenge)
        {
            this.Element = Element;
            this.ElementMenge = ElementMenge;
            this.Karte = Karte;
            BuildUp();
        }
        private void BuildUp()
        {
            this.GroupBox.Text = Element.Schreibname;
            this.GroupBox.Height = 160;

            Element.AdaptToCard(Karte);
            this.Label.Image = Karte.GetImageByHeight(140);
            this.Label.Size = Label.Image.Size;

            this.GroupBox.Controls.Add(Label);
            this.GroupBox.Controls.Add(Buttons);
            this.Controls.Add(GroupBox);

            Label.Location = new Point(10, 15);
            Buttons.Location = new Point(Label.Right + 5, 15);
            GroupBox.Width = Label.Width + 23 + Buttons.Width;

            this.AutoSize = true;

            Buttons.Enable(ElementMenge.Standard != Element, "Entfernen");
            Buttons.ButtonClick += new EventHandler(Buttons_ButtonClick);
        }

        private void Buttons_ButtonClick(object sender, EventArgs e)
        {
            switch (Buttons.Message)
            {
                case "Auswählen":
                    OnAuswahlen(sender, e);
                    break;
                case "Entfernen":
                    OnEntfernen(sender, e);
                    break;
                case "Bearbeiten":
                    OnBearbeiten(sender, e);
                    break;
                case "Klonen":
                    OnKlonen(sender, e);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
        public override void Refresh()
        {
            base.Refresh();
            this.GroupBox.Text = Element.Schreibname;

            Element.AdaptToCard(Karte);
            this.Label.Image = Karte.GetImageByHeight(140);
            this.Label.Size = Label.Image.Size;

            Buttons.Location = new Point(Label.Right + 5, 15);
            GroupBox.Width = Label.Width + 23 + Buttons.Width;
        }

        protected virtual void OnAuswahlen(object sender, EventArgs e)
        {
            Ausgewahlt(this, e);
        }
        protected virtual void OnBearbeiten(object sender, EventArgs e)
        {
            Bearbeitet(this, e);
        }
        protected virtual void OnEntfernen(object sender, EventArgs e)
        {
            Entfernt(this, e);
        }
        protected virtual void OnKlonen(object sender, EventArgs e)
        {
            Geklont(this, e);
        }
    }
}