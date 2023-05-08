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

namespace WindowsFormsApp35 //tedarik ettigimiz urunleri listelemek icin olan formumuz
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            TextReader mytr = new StreamReader("tedarik.txt");
            string tedarik=string.Empty;
            while((tedarik=mytr.ReadLine())!=null)
            {


                listBox1.Items.Add(tedarik);






            }



        }
    }
}
