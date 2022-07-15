using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurkoBey.EzanVakti.Methods
{
    public static class GununAyetHadisDuaGetir
    {
        public static void GununAyetHadisDua(string metin, string baslik, string mesajBaslik)
        {
            var gununVeri = new HtmlWeb().Load("https://www.diyanet.gov.tr/tr-TR/");
            string gelenMetin = KarakterDuzelt.Degistir(gununVeri.DocumentNode.SelectSingleNode(metin).InnerText).Trim();
            string gelenMetinBaslik = KarakterDuzelt.Degistir(gununVeri.DocumentNode.SelectSingleNode(baslik).InnerText);

            if (DialogResult.OK == MessageBox.Show(gelenMetin + "\n" + gelenMetinBaslik + "\n\n\n Metni kopyalamak için \" OK \" tuşuna basınız.", mesajBaslik, MessageBoxButtons.OK, MessageBoxIcon.Information))
            {
                Clipboard.SetText(gelenMetin + " " + gelenMetinBaslik);
            }
        }
    }
}
