﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.IO;
using Assistment.Extensions;
using Assistment.Texts;
using Assistment.Drawing.Geometries;
using Assistment.Drawing.LinearAlgebra;
//using Assistment.Drawing;

using Werwolf.Generating;
using Werwolf.Karten;
using Werwolf.Forms;
using Werwolf.Inhalt;

namespace Werwolf
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Universe Universe = new Universe(@"D:\CSArbeiten\Github\Werwolf\WH40K\Universe.xml");

            foreach (var item in Universe.Bilder.Values)
            {
                item.Zentrum = new PointF(0.5f, 0.5f);
                item.Size = new SizeF(10, item.Image.Height * 10f / item.Image.Width);
            }
            Universe.Save(@"D:\CSArbeiten\Github\Werwolf\WH40K\Universe.xml");

            //IKartenmacher kk = new KartenEinzelbildMacher();
            //kk.MakeKarten(Universe, @"D:\CSArbeiten\Github\Werwolf\WH40K\Karten\", 3);

        }
        public static void MakeUniverser()
        {
            Universe Universe = new Universe();
            Universe.Name = "Warhammer40K,_Kampf_der_Götter";
            Universe.MakePfade(@"D:\CSArbeiten\Github\Werwolf\WH40K\");

            Universe.Bilder.Add(new Bild("Imperialer_Bürger", "Imperialer Bürger.jpg", "", Universe));
            Universe.Bilder.Add(new Bild("Grenadier", "Grenadier.jpg", "", Universe));
            Universe.Bilder.Add(new Bild("Gardist", "Gardist.jpg", "", Universe));
            Universe.Bilder.Add(new Bild("Kommissar", "Kommissar.jpg", "", Universe));
            Universe.Bilder.Add(new Bild("Frater", "Frater.jpg", "", Universe));
            Universe.Bilder.Add(new Bild("Priester", "Priester.jpg", "", Universe));
            Universe.Bilder.Add(new Bild("Inquisitor", "Inquisitor.jpg", "", Universe));

            Universe.Bilder.Add(new Bild("Tech-Priester", "Tech-Priester.jpg", "", Universe));

            Universe.Bilder.Add(new Bild("Häretiker", "Häretiker.jpg", "", Universe));
            Universe.Bilder.Add(new Bild("Chaos-Kultist", "Chaos-Kultist.png", "", Universe));
            Universe.Bilder.Add(new Bild("Khorne-Berserker", "Khorne-Berserker.jpg", "", Universe));
            Universe.Bilder.Add(new Bild("Verführer", "Verführer.jpg", "", Universe));
            Universe.Bilder.Add(new Bild("Psioniker", "Psioniker.jpg", "", Universe));
            Universe.Bilder.Add(new Bild("Dämonenbeschwörer", "Dämonenbeschwörer.jpg", "", Universe));
            Universe.Bilder.Add(new Bild("Hexer", "Hexer.jpg", "", Universe));

            Universe.Save(@"D:\CSArbeiten\Github\Werwolf\WH40K\Universe.xml");
        }
        public static void MakeKarte()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            PreForm<BildDarstellung> p = new UnterDarstellungForm<BildDarstellung>();
            p.Element = new BildDarstellung();

            Karte Karte = new Karte();
            Karte.Darstellung = new Darstellung();
            Karte.Aufgaben = new Aufgabe("adsasdasd\r\n\r\nassadad");
            Karte.Darstellung.Text.BalkenDicke = 1;
            Karte.Darstellung.Text.Existiert = true;
            Karte.Darstellung.Text.Font = new Font("Calibri", 11);
            Karte.Darstellung.Text.HatRand = true;
            Karte.Darstellung.Text.InnenRadius = 1;
            Karte.Darstellung.Text.Rand = new SizeF(5, 5);
            Karte.Darstellung.Hintergrund.Existiert = true;
            Karte.Darstellung.Hintergrund.HatRand = true;
            Karte.Darstellung.Hintergrund.Rand = new SizeF(4, 4);
            Karte.Darstellung.Size = new SizeF(50, 70);

            Pipeline pp = new Pipeline(Karte);
            pp.createImage("test");

            Application.Run(p);

            //TestTitel();
            //HintergrundErsteller he = new HintergrundErsteller();
        }
        public static void MakeFraktionen()
        {
            ElementMenge<Fraktion> Fraktionen = new ElementMenge<Fraktion>("Fraktionen", null);
            //Fraktionen.Add(new Fraktion(
        }
        public static Fraktion GetFraktion()
        {
            Fraktion f = new Fraktion();
            //f.Hintergrundbild = new Inhalt.Bild(
            return f;
        }
        public static void TestLayer()
        {
            //int c = 100;
            //Bitmap b = new Bitmap(c * 20, c * 28);
            //Graphics g = b.GetHighGraphics();
            //g.Clear(Color.Black);

            //PointF Mittelpunkt = new PointF(10 * c, 14 * c);
            //OrientierbarerWeg ow = OrientierbarerWeg.Spirale(c * 10, 10);
            //ow += Mittelpunkt;


            //Schema s = Schema.WithTeeth(1);
            //s.sampleRate = 10;
            //s.strings *= 10;
            //s.hohe = t => 100;
            //s.burst = c;

            //Shadex.chaosWeg(g, ow, s);

            //g.FillRectangle(new SolidBrush(Color.FromArgb(50, 255, 255, 255)), 0, 0, 20 * c, 28 * c);

            //b.Save("test.png");


            LayerBox lb = new LayerBox();
            float w = 1000;
            lb.addImage(Image.FromFile("test.png"), w, w * 1.4f);

            Text te = new Text();
            te.preferedFont = new FontMeasurer("Exocet", 30);
            te.alignment = 0.5f;
            te.addRegex(@"Gutschein für eine Rollenspielrunde");
            te.addAbsatz();
            te.addWhitespace(1000, 100, true);

            te.preferedFont = new FontMeasurer("Calibri", 20);
            te.addRegex(@"Hey, David! Alles Gute zum Geburtstag. Als Geschenk erhätst Du von mir einen Gutschein für ein Rollenspielszenario, das wir in den Semesterferien spielen können, sobald die Klausurenphase bei allen Beteiligten vorbei ist.
Ich kann jetzt noch nicht sagen, wie das Szenario genau ausschauen wird, weil das alles top secret ist, aber hier ein paar Eckdaten:");
            te.addAbsatz();

            DrawList dl = new DrawList();
            dl.preferedFont = new FontMeasurer("Calibri", 20);
            dl.add(new Text(@"- Ausgelegt soll das ganze auf einen Abend sein.
Eventuell sogar, falls sich genügend Menschenmaterial findet, einen Indoor-Abend und einen LARP-Teil an einem anderen Tag, oder vielleicht sogar nur eine LARP-Session.", dl.preferedFont));
            dl.addWhitespace(0, 10, false);
            dl.add(new Text(@"- Die Spieler werden voraussichtlich aus Dir und vier weiteren Mitspielern bestehen.", dl.preferedFont));
            dl.addWhitespace(0, 10, false);
            dl.add(new Text(@"- Es soll möglichst surreal und Mistery mit ganz viel Pseudo-Kafka- und Pseudo-Lynch-Shit und deutlich weniger Logik sein.", dl.preferedFont));
            dl.addWhitespace(0, 10, false);
            dl.add(new Text(@"- Es soll (nahezu) keine Kämpfe oder spieltechnische Regeln geben.", dl.preferedFont));
            dl.addWhitespace(0, 10, false);
            dl.add(new Text(@"- Es wird vermutlich in dieser Zeit in Karlsruhe spielen, in einer Welt, in der es (nahezu) keine Magie oder Ähnliches gibt.", dl.preferedFont));
            dl.addWhitespace(0, 10, false);
            dl.addWhitespace(800f);

            te.add(dl.Geometry(100, 10, 100, 10));
            te.addAbsatz();
            te.addRegex(@"Alles Gute auf Deinem weiteren Lebensweg und Deinen Welteroberungsplänen wünscht");
            te.addAbsatz();
            te.addWhitespace(10, 20, true);
            te.addWhitespace(10, 20, true);
            te.preferedFont = new FontMeasurer("PlainGermanica", 30);
            te.addWort("Dein Ruestue");

            lb.add(te.Geometry(30));
            lb.createPDF("Karte");

        }
        public static void TestTitel()
        {
            Text t = new Text();
            t.preferedFont = new FontMeasurer("Exocet", 12);
            #region Text
            t.addWort(@"Test  -- Dankeschön");
            #endregion
            t.alignment = 0.5f;

            FontMeasurer f = new FontMeasurer("Exocet", 12);

            float RandHohe = 10;

            Pen p = new Pen(Color.Black, 1);
            p.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;

            Titel[] ts = new Titel[] {
            new RunderTitel(new Text("RunderTitel",f), RandHohe, p, Brushes.Red),
            new StachelTitel(new Text("StachelTitel",f), RandHohe, p, Brushes.Red),
            new ZahnTitel(new Text("ZahnTitel",f), RandHohe, p, Brushes.Red),
            new WellenTitel(new Text("WellenTitel",f), RandHohe, p, Brushes.Red),
            new SagezahnTitel(new Text("SagezahnTitel",f), RandHohe, p, Brushes.Red),
            new VierStufenTitel(new Text("VierStufenTitel",f), RandHohe, p, Brushes.Red),
            new KonigTitel(new Text("KonigTitel",f), RandHohe, p, Brushes.Red),
            new ChaosTitel(new Text("ChaosTitel",f), RandHohe, p, Brushes.Red),
            new KreuzTitel(new Text("KreuzTitel",f), RandHohe, p, Brushes.Red),
            new TriskelenTitel(new Text("TriskelenTitel",f), RandHohe, p, Brushes.Red),
            new PikTitel(new Text("PikTitel",f), RandHohe, p, Brushes.Red),
            new BlitzTitel(new Text("BlitzTitel",f), RandHohe, p, Brushes.Red)
            };
            CString cs = new CString();
            foreach (Titel tit in ts)
            {
                DrawList l = new DrawList();
                for (int i = 1; i <= 10; i++)
                {
                    Titel tt = (Titel)tit.clone();
                    tt.Scaling = i;
                    l.add(tt);
                }
                cs.add(l);
            }

            //cs.createImage("test", 1000, float.MaxValue);
            cs.Geometry(50).createPDF("test");
        }
        public static void MakeArtist(string directory)
        {
            //Image img = Image.FromFile("C:/Users/msi/Desktop/Bild.jpg");
            //Image img2 = Image.FromFile("C:/Users/msi/Desktop/Bild.jpg");

            //MessageBox.Show(img.PropertyIdList.Length + " , " + img.PropertyItems.Length);

            //PropertyItem p = img2.GetPropertyItem(0x5091);
            //p.Id = 0x013B;
            //p.Len = 64;
            //p.Type = 2;
            //Encoding enc = Encoding.ASCII;
            //p.Value = enc.GetBytes("Boris");

            //img2.Dispose();

            //img.SetPropertyItem(p);

            //string s = "";
            //for (int i = 0; i < img.PropertyIdList.Length; i++)
            //{
            //    s += img.PropertyIdList[i];
            //    s += " -> " + img.PropertyItems[i].Id.ToString("x") + ", " + img.PropertyItems[i].Len + ", " + img.PropertyItems[i].Type + ", " + img.PropertyItems[i].Value.Length;
            //    s += Environment.NewLine;
            //}
            //MessageBox.Show(s);
            //MakeArtist("D:/CSArbeiten/Github/Werwolf/Bilder");

            Image img = Image.FromFile("C:/Users/msi/Desktop/Bild.jpg");

            PropertyItem p = img.GetPropertyItem(0x5091);
            p.Id = 0x013B;
            p.Type = 2;
            Encoding enc = Encoding.ASCII;
            p.Value = enc.GetBytes("Boris");
            img.Dispose();

            foreach (var item in Directory.GetDirectories(directory))
            {
                string artist = ((item + "/").Ordner());
                p.Value = enc.GetBytes(artist);
                foreach (var file in Directory.GetFiles(item))
                {
                    FileStream fs = new FileStream(file, FileMode.Open);
                    img = new Bitmap(fs);
                    fs.Close();
                    img.SetPropertyItem(p);
                    img.Save(file);
                }
            }

            foreach (var item in Directory.GetDirectories(directory))
            {
                string s = "";
                foreach (var file in Directory.GetFiles(item))
                {
                    img = Image.FromFile(file);
                    s += file + ": " + enc.GetString(img.GetPropertyItem(0x013B).Value);
                    s += Environment.NewLine;
                }
                MessageBox.Show(s);
            }
        }
    }
}
