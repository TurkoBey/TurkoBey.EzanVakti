using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using TurkoBey.EzanVakti.Cities;
using TurkoBey.EzanVakti.Methods;

namespace TurkoBey.EzanVakti.Forms
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
        }

        //Ayet Hadis Dua İşlemleri
        #region Ayet-Hadis-Dua-Buton
        private void btngununAyet_Click(object sender, EventArgs e)
        {
            string duaXpath = "/html/body/div[2]/div/div[10]/div[1]/div[1]/a/p";
            string duaBaslikXpath = "/html/body/div[2]/div/div[10]/div[1]/div[2]/p";
            string mesajBaslik = "Günün Ayeti";
            GununAyetHadisDuaGetir.GununAyetHadisDua(duaXpath, duaBaslikXpath, mesajBaslik);
        }
        private void btngununHadis_Click(object sender, EventArgs e)
        {
            string duaXpath = "/html/body/div[2]/div/div[10]/div[2]/div[1]/a/p";
            string duaBaslikXpath = "/html/body/div[2]/div/div[10]/div[2]/div[2]/p";
            string mesajBaslik = "Günün Hadisi";
            GununAyetHadisDuaGetir.GununAyetHadisDua(duaXpath, duaBaslikXpath, mesajBaslik);
        }
        private void btngununDua_Click(object sender, EventArgs e)
        {
            string duaXpath = "/html/body/div[2]/div/div[10]/div[3]/div/a/p";
            string duaBaslikXpath = "/html/body/div[2]/div/div[10]/div[3]/div/div/p";
            string mesajBaslik = "Günün Duası";
            GununAyetHadisDuaGetir.GununAyetHadisDua(duaXpath, duaBaslikXpath, mesajBaslik);
        }

        #endregion

        //Açılış
        #region FormLoad
        private void HomeForm_Load(object sender, EventArgs e)
        {
            try
            {
                BilgiGetir bilgiGetir = new BilgiGetir();
                bilgiGetir.SehirVeriCek("9541");
                Yazdir(bilgiGetir);
            }
            catch (Exception mesaj)
            {
                MessageBox.Show(mesaj.Message, "Başlık", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        #endregion

        //Çekilen Verileri Ekrana Yazdırır
        #region EkranaVeriYazdır
        private void Yazdir(BilgiGetir bilgiGetir)
        {
            lblgelenImsak.Text = bilgiGetir.Imsak;
            lblgelenGunes.Text = bilgiGetir.Gunes;
            lblgelenOgle.Text = bilgiGetir.Ogle;
            lblgelenIkindi.Text = bilgiGetir.Ikindi;
            lblgelenAksam.Text = bilgiGetir.Aksam;
            lblgelenYatsi.Text = bilgiGetir.Yatsi;

            lblgelenMiladi.Text = bilgiGetir.MiladiTarih;
            lblgelenHicri.Text = bilgiGetir.HicriTarih;

            lblKibleAcisi.Text = bilgiGetir.KibleAcisi;
            lblKibleZamani.Text = bilgiGetir.KibleZamani;
            lblastronomikGunesDogus.Text = bilgiGetir.AstronomikGunesDogus;
            lblastronomikGunesBatis.Text = bilgiGetir.AstronomikGunesBatis;

            lblSaat.Text = bilgiGetir.Saat;
            lblgelenGunes.Text = bilgiGetir.Gunes;

            if (cBoxIl.SelectedItem != null)
            {
                this.Text = Metinler.Title + " [ " + cBoxIl.SelectedItem.ToString() + " - " + cBoxIlce.SelectedItem.ToString() + " ]";
            }
            else
            {
                this.Text = Metinler.Title + " [ ISTANBUL - ISTANBUL ]";
            }
            //lblEzanaKalanSure.Text = bilgiGetir.lblEzanaKalanSure;
        }
        #endregion

        // Ayarlar - Github Butonları
        #region EnAltButonlar
        private void btnGithub_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/TurkoBey");
        }

        private void btnAyarlar_Click(object sender, EventArgs e)
        {

        }
        #endregion

        // İl İlçe Seçim İşlemleri
        #region Il-Ilce
        private void cBoxIlce_SelectedIndexChanged(object sender, EventArgs e)
        {
            SehirSec();
        }
        private void cBoxIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            cBoxIlce.Items.Clear();
            cBoxIlce.Text = "İLÇE SEÇİMİ YAPINIZ..";

            if (cBoxIl.Text == "ANKARA")
            {
                foreach (string item in Ankara.IlceIsimleri)
                {
                    cBoxIlce.Items.Add(item.ToString());
                }
            }
            else if (cBoxIl.Text == "ISTANBUL")
            {
                foreach (string item in Istanbul.IlceIsimleri)
                {
                    cBoxIlce.Items.Add(item.ToString());
                }
            }
            else if (cBoxIl.Text == "IZMIR")
            {
                foreach (string item in Izmir.IlceIsimleri)
                {
                    cBoxIlce.Items.Add(item.ToString());
                }
            }
            else
            {
                MessageBox.Show("Namaz vakitlerini göstermek istediğiniz il ve ilçe adını seçiniz. ", "Bilgilendirme..!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void SehirSec()
        {
            BilgiGetir bilgiGetir = new BilgiGetir();
            if (cBoxIl.SelectedItem.ToString() == "ANKARA")
            {
                if (cBoxIlce.SelectedItem.ToString() == "AKYURT") { bilgiGetir.SehirVeriCek("9205"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "ANKARA") { bilgiGetir.SehirVeriCek("9206"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "AYAS") { bilgiGetir.SehirVeriCek("9207"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "BALA") { bilgiGetir.SehirVeriCek("9208"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "BEYPAZARI") { bilgiGetir.SehirVeriCek("9209"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "CAMLIDERE") { bilgiGetir.SehirVeriCek("9210"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "CUBUK") { bilgiGetir.SehirVeriCek("9211"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "ELMADAG") { bilgiGetir.SehirVeriCek("9212"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "EVREN") { bilgiGetir.SehirVeriCek("9213"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "GUDUL") { bilgiGetir.SehirVeriCek("9214"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "HAYMANA") { bilgiGetir.SehirVeriCek("9215"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "KALECIK") { bilgiGetir.SehirVeriCek("9216"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "KAHRAMANKAZAN") { bilgiGetir.SehirVeriCek("9217"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "KIZILCAHAMAM") { bilgiGetir.SehirVeriCek("9218"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "NALLIHAN") { bilgiGetir.SehirVeriCek("9219"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "POLATLI") { bilgiGetir.SehirVeriCek("9220"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "SEREFLIKOCHISAR") { bilgiGetir.SehirVeriCek("9221"); Yazdir(bilgiGetir); }
            }
            else if (cBoxIl.SelectedItem.ToString() == "ISTANBUL")
            {
                if (cBoxIlce.SelectedItem.ToString() == "ARNAVUTKOY") { bilgiGetir.SehirVeriCek("9535"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "BEYLIKDUZU") { bilgiGetir.SehirVeriCek("9536"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "BUYUKCEKMECE") { bilgiGetir.SehirVeriCek("9537"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "CATALCA") { bilgiGetir.SehirVeriCek("9538"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "CEKMEKOY") { bilgiGetir.SehirVeriCek("9539"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "ESENYURT") { bilgiGetir.SehirVeriCek("9540"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "ISTANBUL") { bilgiGetir.SehirVeriCek("9541"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "KARTAL") { bilgiGetir.SehirVeriCek("9542"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "KUCUKCEKMECE") { bilgiGetir.SehirVeriCek("9543"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "MALTEPE") { bilgiGetir.SehirVeriCek("9544"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "PENDIK") { bilgiGetir.SehirVeriCek("9545"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "SANCAKTEPE") { bilgiGetir.SehirVeriCek("9546"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "SILE") { bilgiGetir.SehirVeriCek("9547"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "SILIVRI") { bilgiGetir.SehirVeriCek("9548"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "SULTANBEYLI") { bilgiGetir.SehirVeriCek("9549"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "SULTANGAZI") { bilgiGetir.SehirVeriCek("9550"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "TUZLA") { bilgiGetir.SehirVeriCek("9551"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "AVCILAR") { bilgiGetir.SehirVeriCek("17865"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "BAŞAKŞEHİR") { bilgiGetir.SehirVeriCek("17866"); Yazdir(bilgiGetir); }
            }
            else if (cBoxIl.SelectedItem.ToString() == "IZMIR")
            {
                if (cBoxIlce.SelectedItem.ToString() == "ALIAGA") { bilgiGetir.SehirVeriCek("9552"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "BAYINDIR") { bilgiGetir.SehirVeriCek("9553"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "BERGAMA") { bilgiGetir.SehirVeriCek("9554"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "BEYDAG") { bilgiGetir.SehirVeriCek("9555"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "CESME") { bilgiGetir.SehirVeriCek("9556"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "DIKILI") { bilgiGetir.SehirVeriCek("9557"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "FOCA") { bilgiGetir.SehirVeriCek("9558"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "GUZELBAHCE") { bilgiGetir.SehirVeriCek("9559"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "IZMIR") { bilgiGetir.SehirVeriCek("9560"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "KARABURUN") { bilgiGetir.SehirVeriCek("9561"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "KEMALPASA") { bilgiGetir.SehirVeriCek("9562"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "KINIK") { bilgiGetir.SehirVeriCek("9563"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "KIRAZ") { bilgiGetir.SehirVeriCek("9564"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "ODEMIS") { bilgiGetir.SehirVeriCek("9565"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "SEFERIHISAR") { bilgiGetir.SehirVeriCek("9566"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "SELCUK") { bilgiGetir.SehirVeriCek("9567"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "TIRE") { bilgiGetir.SehirVeriCek("9568"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "TORBALI") { bilgiGetir.SehirVeriCek("9569"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "URLA") { bilgiGetir.SehirVeriCek("9570"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "MENDERES") { bilgiGetir.SehirVeriCek("17868"); Yazdir(bilgiGetir); }
                else if (cBoxIlce.SelectedItem.ToString() == "MENEMEN") { bilgiGetir.SehirVeriCek("17869"); Yazdir(bilgiGetir); }
            }
            else
            {
                MessageBox.Show("Şeihr", "Başlık", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            lblSehir.Text = cBoxIl.SelectedItem.ToString();
        }

        #endregion
    }
}

