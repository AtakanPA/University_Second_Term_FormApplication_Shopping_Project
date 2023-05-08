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

namespace WindowsFormsApp35 //gelir gider tablosunu raporlayacak olan formumuz
{
    public partial class Form4 : Form
    {   
        public Form1 GetToplam { get; set; }


        public Form4()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            
       }

        private void Form4_Load(object sender, EventArgs e)
        {
            int topgider;


            Pgid.Text = "200";
            Egid.Text = "100";
            Ygid.Text = "75";
            Mgit.Text = "30";
            Igid.Text = "60";
            topgider = Convert.ToInt16(Pgid.Text) + Convert.ToInt16(Egid.Text) + Convert.ToInt16(Ygid.Text) + Convert.ToInt16(Mgit.Text) + Convert.ToInt16(Igid.Text);
            Topgid.Text = Convert.ToString(topgider);
            TextReader gtr = new StreamReader("gelir.txt");
            string topgelir;
            double doubopgelir=0;
            double strsevir;
            while((topgelir=gtr.ReadLine())!=null)
            {
                strsevir = Convert.ToDouble(topgelir);
                doubopgelir += strsevir;



            }


            Nsonuc.Text =Convert.ToString( doubopgelir - topgider);
         Mgelir.Text=Convert.ToString(doubopgelir);

        }
    }
}
