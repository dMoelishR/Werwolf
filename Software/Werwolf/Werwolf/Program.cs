using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace Werwolf
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Image img = Image.FromFile("C:/Users/msi/Desktop/Bild.jpg");
            Image img2 = Image.FromFile("C:/Users/msi/Desktop/Bild.jpg");

            MessageBox.Show(img.PropertyIdList.Length + " , " + img.PropertyItems.Length);

            PropertyItem p = img2.GetPropertyItem(0x5091);
            p.Id = 0x013B;
            p.Len = 64;
            p.Type = 2;
            Encoding enc = Encoding.ASCII;
            p.Value = enc.GetBytes("Boris");

            img2.Dispose();

            img.SetPropertyItem(p);

            string s = "";
            for (int i = 0; i < img.PropertyIdList.Length; i++)
            {
                s += img.PropertyIdList[i];
                s += " -> " + img.PropertyItems[i].Id.ToString("x") + ", " + img.PropertyItems[i].Len + ", " + img.PropertyItems[i].Type + ", " + img.PropertyItems[i].Value.Length;
                s += Environment.NewLine;
            }
            MessageBox.Show(s);
        }
    }
}
