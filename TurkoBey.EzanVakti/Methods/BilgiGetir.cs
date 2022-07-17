using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TurkoBey.EzanVakti.Cities;

namespace TurkoBey.EzanVakti.Methods
{
    public class BilgiGetir
    {
        public string Imsak, Gunes, Ogle, Ikindi, Aksam, Yatsi, MiladiTarih, HicriTarih, Saat, KibleAcisi, KibleZamani, AstronomikGunesDogus, AstronomikGunesBatis, lblEzanaKalanSure;

        List<DataVakit> DataVakitListesi = new List<DataVakit>();

        public void SehirVeriCek(string siteID)
        {
            try
            {
                var site = "https://namazvakitleri.diyanet.gov.tr/tr-TR/" + siteID + "/ ";

                List<Vakit> VakitListesi = new List<Vakit>();
                HtmlWeb web = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument document = web.Load(site);
                DateTime dateTime = DateTime.Now;
                var VakitXpath = "//div[@class='ramaining-time-wrapper']";
                var VakitX = document.DocumentNode.SelectNodes(VakitXpath);

                foreach (var Vakit in VakitX)
                {
                    VeriyiCek(VakitListesi, dateTime, Vakit);
                }
                VeriyiEkranaGonder(VakitListesi);
                VeriyiEkranaGonder2(DataVakitListesi);
            }

            catch (Exception mesaj)
            {
                MessageBox.Show(mesaj.Message, "Başlık", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        public void VeriyiCek(List<Vakit> VakitListesi, DateTime dateTime, HtmlNode Vakit)
        {
            for (int i = 0; i < 1; i++)
            {
                string gelenImsak = Vakit.SelectSingleNode("/html/body/div[4]/div[2]/div[2]/div/div[1]/div/div[2]").InnerText;
                string gelenGunes = Vakit.SelectSingleNode("/html/body/div[4]/div[2]/div[2]/div/div[2]/div/div[2]").InnerText;
                string gelenOgle = Vakit.SelectSingleNode("/html/body/div[4]/div[2]/div[2]/div/div[3]/div/div[2]").InnerText;
                string gelenIkindi = Vakit.SelectSingleNode("/html/body/div[4]/div[2]/div[2]/div/div[4]/div/div[2]").InnerText;
                string gelenAksam = Vakit.SelectSingleNode("/html/body/div[4]/div[2]/div[2]/div/div[5]/div/div[2]").InnerText;
                string gelenYatsi = Vakit.SelectSingleNode("/html/body/div[4]/div[2]/div[2]/div/div[6]/div/div[2]").InnerText;

                string gelenSaat = dateTime.ToString("HH:mm");

                string gelenMiladi = Vakit.SelectSingleNode("/html/body/div[4]/div[2]/div[1]/div[1]/div[1]/div/div[1]/div[1]").InnerText;
                string gelenHicri = Vakit.SelectSingleNode("/html/body/div[4]/div[2]/div[1]/div[1]/div[1]/div/div[1]/div[3]").InnerText;

                string gelenKibleAcisi = Vakit.SelectSingleNode("/html/body/div[4]/div[2]/div[4]/div/div/div[2]/div/div[1]/div/div[2]").InnerText;
                string gelenKibleZamani = Vakit.SelectSingleNode("/html/body/div[4]/div[2]/div[4]/div/div/div[2]/div/div[2]/div/div[2]").InnerText;
                string gelenAstronomikGunesDogus = Vakit.SelectSingleNode("/html/body/div[4]/div[2]/div[4]/div/div/div[2]/div/div[3]/div/div[2]").InnerText;
                string gelenAstronomikGunesBatis = Vakit.SelectSingleNode("/html/body/div[4]/div[2]/div[4]/div/div/div[2]/div/div[4]/div/div[2]").InnerText;

                VakitListesi.Add(new Vakit()
                {
                    Imsak = gelenImsak,
                    Gunes = gelenGunes,
                    Ogle = gelenOgle,
                    Ikindi = gelenIkindi,
                    Aksam = gelenAksam,
                    Yatsi = gelenYatsi,
                    MiladiTarih = gelenMiladi,
                    HicriTarih = gelenHicri,
                    Saat = gelenSaat,
                    KibleAcisi = gelenKibleAcisi,
                    KibleZamani = gelenKibleZamani,
                    AstronomikGunesDogus = gelenAstronomikGunesDogus,
                    AstronomikGunesBatis = gelenAstronomikGunesBatis
                });
            }
        }
        public List<DataVakit> VeriyiEkranaGonder(List<Vakit> VakitListesi)
        {
            foreach (var Vakit in VakitListesi)
            {
                DataVakitListesi.Add(new DataVakit()
                {
                    Imsak = Parcala(Vakit.Imsak)[0] + " : " + Parcala(Vakit.Imsak)[1],
                    Gunes = Parcala(Vakit.Gunes)[0] + " : " + Parcala(Vakit.Gunes)[1],
                    Ogle = Parcala(Vakit.Ogle)[0] + " : " + Parcala(Vakit.Ogle)[1],
                    Ikindi = Parcala(Vakit.Ikindi)[0] + " : " + Parcala(Vakit.Ikindi)[1],
                    Aksam = Parcala(Vakit.Aksam)[0] + " : " + Parcala(Vakit.Aksam)[1],
                    Yatsi = Parcala(Vakit.Yatsi)[0] + " : " + Parcala(Vakit.Yatsi)[1],
                    MiladiTarih = Vakit.MiladiTarih,
                    HicriTarih = Vakit.HicriTarih,
                    Saat = Parcala(Vakit.Saat)[0] + " : " + Parcala(Vakit.Saat)[1],
                    KibleAcisi = Vakit.KibleAcisi,
                    KibleZamani = Parcala(Vakit.KibleZamani)[0] + " : " + Parcala(Vakit.KibleZamani)[1],
                    AstronomikGunesDogus = Parcala(Vakit.AstronomikGunesDogus)[0] + " : " + Parcala(Vakit.AstronomikGunesDogus)[1],
                    AstronomikGunesBatis = Parcala(Vakit.AstronomikGunesBatis)[0] + " : " + Parcala(Vakit.AstronomikGunesBatis)[1]
                });
                EzanKalanSureGonder(Vakit);
            }
            return DataVakitListesi;
        }

        private void EzanKalanSureGonder(Vakit Vakit)
        {
            if (Parcala(SaatHesapla(Vakit))[0].ToCharArray()[0] == '-')
            {
                lblEzanaKalanSure = Parcala(SaatHesapla(Vakit))[0].Trim('-') + " : " + Parcala(SaatHesapla(Vakit))[1] + " : " + Parcala(SaatHesapla(Vakit))[2];
            }
            else
            {
                lblEzanaKalanSure = Parcala(SaatHesapla(Vakit))[0] + " : " + Parcala(SaatHesapla(Vakit))[1] + " : " + Parcala(SaatHesapla(Vakit))[2];
            }
        }

        private string SaatHesapla(Vakit Vakit)
        {
            if (true)
            {
                TimeSpan girisCikisFarki = DateTime.Parse(Vakit.Saat).Subtract(DateTime.Parse(Vakit.Gunes));
                string calismaSuresi = girisCikisFarki.ToString();
                return calismaSuresi;
            }
        }
        private static string[] Parcala(string imsak)
        {
            return imsak.Split(':');
        }
        private string VeriyiEkranaGonder2(List<DataVakit> DataVakitListesi)
        {
            foreach (var Vakit in DataVakitListesi)
            {
                Imsak = Vakit.Imsak;
                Gunes = Vakit.Gunes;
                Ogle = Vakit.Ogle;
                Ikindi = Vakit.Ikindi;
                Aksam = Vakit.Aksam;
                Yatsi = Vakit.Yatsi;
                MiladiTarih = Vakit.MiladiTarih;
                HicriTarih = Vakit.HicriTarih;
                Saat = Vakit.Saat;
                KibleAcisi = Vakit.KibleAcisi;
                KibleZamani = Vakit.KibleZamani;
                AstronomikGunesDogus = Vakit.AstronomikGunesDogus;
                AstronomikGunesBatis = Vakit.AstronomikGunesBatis;
            }

            return Imsak + Gunes + Ogle + Ikindi + Aksam + Yatsi + MiladiTarih + HicriTarih + Saat + KibleAcisi + KibleZamani + AstronomikGunesDogus + AstronomikGunesBatis;
        }



        //Çekilen Verileri Ekrana Yazdırır
        #region EkranaVeriYazdır
        public static void EkranaYazdir(BilgiGetir bilgiGetir, Label labelImsak, Label labelGunes, Label labelOgle, Label labelIkindi, Label labelAksam, Label labelYatsi,
            Label labelMiladi, Label labelHicri, Label labelKibleAcisi, Label labelKibleZamani, Label labelastronomikGunesDogus, Label labelastronomikGunesBatis,
            Label labelSaat, Label labelFormTitle, ComboBox comboBoxIl, ComboBox comboBoxIlce, Label labelEzanaKalanSure)
        {
            labelImsak.Text = bilgiGetir.Imsak;
            labelGunes.Text = bilgiGetir.Gunes;
            labelOgle.Text = bilgiGetir.Ogle;
            labelIkindi.Text = bilgiGetir.Ikindi;
            labelAksam.Text = bilgiGetir.Aksam;
            labelYatsi.Text = bilgiGetir.Yatsi;

            labelMiladi.Text = bilgiGetir.MiladiTarih;
            labelHicri.Text = bilgiGetir.HicriTarih;

            labelKibleAcisi.Text = bilgiGetir.KibleAcisi;
            labelKibleZamani.Text = bilgiGetir.KibleZamani;
            labelastronomikGunesDogus.Text = bilgiGetir.AstronomikGunesDogus;
            labelastronomikGunesBatis.Text = bilgiGetir.AstronomikGunesBatis;

            labelSaat.Text = bilgiGetir.Saat;

            if (comboBoxIl.SelectedItem != null)
            {
                labelFormTitle.Text = Metinler.Title + " [ " + comboBoxIl.SelectedItem.ToString() + " - " + comboBoxIlce.SelectedItem.ToString() + " ]";
            }
            else
            {
                labelFormTitle.Text = Metinler.Title + " [ ISTANBUL - ISTANBUL ]";
            }
            labelEzanaKalanSure.Text = bilgiGetir.lblEzanaKalanSure;
        }
        #endregion
    }
}
