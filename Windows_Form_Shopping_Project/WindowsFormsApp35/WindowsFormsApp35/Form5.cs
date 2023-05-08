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

namespace WindowsFormsApp35
{
    public partial class Form5 : Form //urun tedarigi yapacak oldugmuz formumuz
    {
        List<Urunler> tedarikurun = new List<Urunler>();
        public Form5()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //sipariş ver butonu
        {
            if (string.IsNullOrEmpty(comboBox1.Text) || (radioButton1.Checked==false && radioButton2.Checked==false && radioButton3.Checked==false) || string.IsNullOrEmpty(comboBox2.Text) ||textBox1.Text=="" )
            {
                MessageBox.Show("Lütfen tüm bilgileri eksiksiz giriniz");  //urun bilgilerinin eksiksiz oldugundan emin olduktan sonra islemlerimize baslıyoruz

            }
        else
            {
                Random rnd = new Random();
                Random rnd1 = new Random();
                double rand=0;
                double toplam=0;

                double mydeger=0;  //urunlere rastgele bir fiyat vermek uzere random sayılar turetiyoruz
                double onrnd=0;
              string  sayi=String.Empty;
      
              if ( radioButton1.Checked==true)  //urunlerin hedeflerine gore siparisleri aliyoruz
               {
                    TextWriter mytw = new StreamWriter("stok.txt", append: true);
                    TextWriter twtd = new StreamWriter("tedarik.txt", append: true);
                    for (int i = 0; i < Convert.ToInt32(textBox1.Text); i++)
                    {

                        rand = rnd.Next(10, 99);
                         onrnd = rnd.Next(9, 99);
                        sayi = rand.ToString() + "," + onrnd.ToString();
                        mydeger = Convert.ToDouble(sayi);
                        tedarikurun.Add(new Urunler(comboBox2.Text, mydeger,"erkek"));
                        listBox1.Items.Add(comboBox1.Text+" " +comboBox2.Text+" "+ mydeger+" "+ "erkek");
                        toplam += mydeger;
                        mytw.WriteLine(comboBox2.Text + mydeger + "erkek");
                        twtd.WriteLine(comboBox1.Text + comboBox2.Text + " " + mydeger + " " + "erkek");
                    }
                    mytw.Close();
                    label6.Text = toplam.ToString();
                    twtd.Close();

              }

                if (radioButton2.Checked == true)
                {
                    TextWriter mytw = new StreamWriter("stok.txt", append: true);
                    TextWriter twtd = new StreamWriter("tedarik.txt", append: true);
                    for (int i = 0; i < Convert.ToInt32(textBox1.Text); i++)
                    {

                        rand = rnd.Next(10, 99);
                        onrnd = rnd.Next(9, 99);
                        sayi = rand.ToString() + "," + onrnd.ToString();
                        mydeger = Convert.ToDouble(sayi);
                        tedarikurun.Add(new Urunler(comboBox2.Text, mydeger, "kadın"));
                        listBox1.Items.Add(comboBox1.Text +" "+ comboBox2.Text + " " + mydeger + " " + "kadın");
                        toplam += mydeger;
                        mytw.WriteLine(comboBox2.Text + mydeger + "kadın");
                        twtd.WriteLine(comboBox1.Text + comboBox2.Text + " " + mydeger + " " + "kadın");
                    }
                    mytw.Close();
                    label6.Text = toplam.ToString();
                    twtd.Close();

                }

                if (radioButton3.Checked == true)
                {
                    TextWriter mytw = new StreamWriter("stok.txt", append: true);
                    TextWriter twtd = new StreamWriter("tedarik.txt", append: true);
                    for (int i = 0; i < Convert.ToInt32(textBox1.Text); i++)
                    {

                        rand = rnd.Next(10, 99);
                        onrnd = rnd.Next(9, 99);
                        sayi = rand.ToString() + "," + onrnd.ToString();
                        mydeger = Convert.ToDouble(sayi);
                        tedarikurun.Add(new Urunler(comboBox2.Text, mydeger, "cocuk"));
                        listBox1.Items.Add(comboBox1.Text+" " + comboBox2.Text + " " + mydeger + " " + "cocuk");
                        toplam += mydeger;
                        mytw.WriteLine(comboBox2.Text + mydeger + "cocuk");
                        twtd.WriteLine(comboBox1.Text + comboBox2.Text + " " + mydeger + " " + "cocuk");
                    }
                    mytw.Close();
                    label6.Text = toplam.ToString();
                    twtd.Close();

                }








            }





        }

        private void Form5_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            label6.Text = "";
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;
            textBox1.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
        }
    }
}
