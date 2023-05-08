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

namespace WindowsFormsApp35 // satılan urunlerimizi raporlayan formumuz 
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

            TextReader mstr = new StreamReader("musterisatis.txt");
            TextReader musteri = new StreamReader("musteri.txt");

            string muskod;
            string firstcode = string.Empty;
            string secondcode = string.Empty;
            int musterikodu=0;
            string müssat;
            int musterisatiskodu=0;
            while ((muskod = musteri.ReadLine()) != null) //musteri dosyasından musteri bilgilerimizi alıyoruz
            {

                firstcode = String.Empty;
                    musterikodu = 0;
                for (int i = 0; i < muskod.Length; i++) //musterimizin kodunu alıyoruz
                {
                    if (Char.IsDigit(muskod[i]))
                        firstcode += muskod[i];
                    else
                        break;
                }
                    


                    label2.Text = firstcode;


                   

                 musterikodu = Convert.ToInt32(firstcode);

                    listBox1.Items.Add(muskod);
                      while((müssat=mstr.ReadLine())!=null) //musterisatis dosyasından musterilerimiz aldıgı urunleri alıyoruz kodu eslesen urunleri yazdırıyoruz
                      {

                              for (int i = 0; i < müssat.Length; i++)
                              {
                                     if (Char.IsDigit(müssat[i]))
                                        secondcode += müssat[i];
                                    else
                                         break;
                              }
                          

                            label2.Text = secondcode;
                                  musterisatiskodu = Convert.ToInt32(secondcode);
                            if (musterikodu == musterisatiskodu)
                            {

                                listBox1.Items.Add(müssat);


                            }

                                 secondcode = string.Empty;
                                 musterisatiskodu = 0;

                   
                      



                      }

                
            }
            mstr.Close();
            musteri.Close();
        }
    }
}
