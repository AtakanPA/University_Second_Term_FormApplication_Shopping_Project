/****************************************************************************
**					SAKARYA ÜNİVERSİTESİ
**				BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**				    BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**				   NESNEYE DAYALI PROGRAMLAMA DERSİ
**					2014-2015 BAHAR DÖNEMİ
**	
**				ÖDEV NUMARASI..........:1.Proje Ödevi
**				ÖĞRENCİ ADI............:Atakan Paşalı   
**				ÖĞRENCİ NUMARASI.......:g201210054
**              DERSİN ALINDIĞI GRUP...:2. Ogretim C Grubu
****************************************************************************/




using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp35 //stok raporu yapan formumuz
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        List<Urunler> stok = new List<Urunler>();
        private void Form2_Load(object sender, EventArgs e)
        {
            string al = string.Empty;
            string skat = string.Empty;
            string sfiy = string.Empty;
            string shed = string.Empty;
            TextReader tr = new StreamReader("stok.txt"); //stoklarımızı okuyoruz 
            while ((al = tr.ReadLine()) != null)
            {

                skat = string.Empty;
                sfiy = string.Empty;
                shed = string.Empty;
                double dblfyt = 0;
                for (int i = 0; i < al.Length; i++) //stoklarımızın kategorisini alıyoruz
                {
                    if (Char.IsDigit(al[i]))
                    {
                        break;
                    }
                    else
                    {

                        skat += al[i];


                    }
                }

                for (int i = 0; i < al.Length; i++) //fiyatını alıyoruz
                {
                    if (Char.IsDigit(al[i]))
                    {
                        sfiy += al[i];
                    }

                }
                label7.Text = sfiy;
                if (sfiy.Length < 3)
                {
                    sfiy = sfiy + "00";


                }
                else if (sfiy.Length < 4)
                {
                    sfiy = sfiy + "0";


                }
                dblfyt = Convert.ToDouble(sfiy) / 100;

                shed = al.Substring(al.Length - 5);
                stok.Add(new Urunler(skat, dblfyt, shed));

                al = string.Empty;
            }
            tr.Close();
            int emont = 0;  // stok adedlerini tutacak degiskenlerimiz
            int epantolon = 0;
            int eetek = 0;
            int eceket = 0;
            int ehirka = 0;
            int eayakkabi = 0;
            int etisort = 0;
            int esapka = 0;
            int kmont = 0;
            int kpantolon = 0;
            int ketek = 0;
            int kceket = 0;
            int khirka = 0;
            int kayakkabi = 0;
            int ktisort = 0;
            int ksapka = 0;
            int cmont = 0;
            int cpantolon = 0;
            int cetek = 0;
            int cceket = 0;
            int chirka = 0;
            int cayakkabi = 0;
            int ctisort = 0;
            int csapka = 0;
            label2.Text = Convert.ToString(stok.Count);
            foreach (Urunler urun in stok)
            {
                if (urun.hedef == "erkek") //erkeklere ait urunlerin stok sayısı
                {
                    if (urun.kategori == "Mont")
                    {
                        emont++;

                    }
                    if (urun.kategori == "Pantolon")
                    {
                        epantolon++;
                    }
                    if (urun.kategori == "Etek")
                    {
                        eetek++;
                    }
                    if (urun.kategori == "Ceket")
                    {
                        eceket++;
                    }
                    if (urun.kategori == "Hırka")
                    {
                        ehirka++;
                    }
                    if (urun.kategori == "Ayakkabı")
                    {
                        eayakkabi++;
                    }
                    if (urun.kategori == "Tişört" || urun.kategori == "Tişort")
                    {
                        etisort++;
                    }
                    if (urun.kategori == "Şapka")
                    {
                        esapka++;
                    }

                }
                if (urun.hedef == "kadın") //kadınlara ait urunlerin stok sayısı
                {
                    if (urun.kategori == "Mont")
                    {
                        kmont++;

                    }
                    if (urun.kategori == "Pantolon")
                    {
                        kpantolon++;
                    }
                    if (urun.kategori == "Etek")
                    {
                        ketek++;
                    }
                    if (urun.kategori == "Ceket")
                    {
                        kceket++;
                    }
                    if (urun.kategori == "Hırka")
                    {
                        khirka++;
                    }
                    if (urun.kategori == "Ayakkabı")
                    {
                        kayakkabi++;
                    }
                    if (urun.kategori == "Tişört" || urun.kategori == "Tişort")
                    {
                        ktisort++;
                    }
                    if (urun.kategori == "Şapka")
                    {
                        ksapka++;
                    }

                }
                if (urun.hedef == "cocuk") //cocuklara ait urunlerin stok sayısı
                {
                    if (urun.kategori == "Mont")
                    {
                        cmont++;

                    }
                    if (urun.kategori == "Pantolon")
                    {
                        cpantolon++;
                    }
                    if (urun.kategori == "Etek")
                    {
                        cetek++;
                    }
                    if (urun.kategori == "Ceket")
                    {
                        cceket++;
                    }
                    if (urun.kategori == "Hırka")
                    {
                        chirka++;
                    }
                    if (urun.kategori == "Ayakkabı")
                    {
                        cayakkabi++;
                    }
                    if (urun.kategori == "Tişört" || urun.kategori == "Tişort")
                    {
                        ctisort++;
                    }
                    if (urun.kategori == "Şapka")
                    {
                        csapka++;
                    }

                }


            }


            label14.Text = Convert.ToString(emont);
            label15.Text = Convert.ToString(kmont);
            label16.Text = Convert.ToString(cmont);
            label17.Text = Convert.ToString(epantolon);
            label18.Text = Convert.ToString(kpantolon);
            label19.Text = Convert.ToString(cpantolon);
            label20.Text = Convert.ToString(eetek);
            label21.Text = Convert.ToString(ketek);
            label22.Text = Convert.ToString(cetek);
            label23.Text = Convert.ToString(eceket);
            label24.Text = Convert.ToString(kceket);
            label25.Text = Convert.ToString(cceket);
            label26.Text = Convert.ToString(ehirka);
            label27.Text = Convert.ToString(khirka);
            label28.Text = Convert.ToString(chirka);
            label29.Text = Convert.ToString(eayakkabi);
            label30.Text = Convert.ToString(kayakkabi);
            label31.Text = Convert.ToString(cayakkabi);
            label32.Text = Convert.ToString(etisort);
            label33.Text = Convert.ToString(ktisort);
            label34.Text = Convert.ToString(ctisort);
            label35.Text = Convert.ToString(esapka);
            label36.Text = Convert.ToString(ksapka);
            label37.Text = Convert.ToString(csapka);


        }
    }
}
