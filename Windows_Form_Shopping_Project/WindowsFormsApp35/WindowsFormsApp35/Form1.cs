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
    public partial class Form1 : Form
    {
        public double toplam = 0;
  
    
        public Form1()
        {
            InitializeComponent();
     
        }
        List<Urunler> CMagaza = new List<Urunler>(); //stoktaki urunleri tutmak uzere list
        int eb = 0;
        double sayi;
        private void Form1_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();

            double rand = rnd.Next(5, 10);       
          
            string degeral;
                double onrnd = rnd.Next(0, 99);    
                sayi = 10 + (onrnd / 100);
            musterisayac = 0;
            TextReader mstr = new StreamReader("musterisayac.txt"); //musteri sayisini tutmak icin bir txt dosyası olusturuyoruz bu osyalar arası baglantiyi saglayacak
            while((degeral=mstr.ReadLine())!=null)  // musteri sayısını alırken en son musterinin kodunu alıyour ki yeni musteri kaydederken kodu 1 arttıralım 
            {
                int sayi1;
                sayi1= Convert.ToInt32(degeral);
               
                if(eb<sayi)
                {
                    eb = sayi1;

                }
                

            }
            mstr.Close();

            musterisayac = eb;
     
            string al=string.Empty;
            string skat=string.Empty;
            string sfiy=string.Empty;
            string shed=string.Empty;
            TextReader tr = new StreamReader("stok.txt"); //stok dosyasından urunlerimizi okuyoruz
            while ((al=tr.ReadLine()) != null)
            {
                
                 skat = string.Empty;
                sfiy = string.Empty;
                shed = string.Empty;
                double dblfyt = 0;
                for (int i = 0; i < al.Length; i++) //urunlerimiz fiyatını alabilmek icin digit olanları bir stringte tutuyourz ve onları doubleye ceviriyoruz
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

                for (int i = 0; i < al.Length; i++)
                {
                    if (Char.IsDigit(al[i]))
                    {
                        sfiy += al[i];
                    }
                
                }
               
                if(sfiy.Length<3)
                {
                    sfiy = sfiy + "00";


                }
                else if(sfiy.Length<4)
                {
                    sfiy = sfiy + "0";


                }
                dblfyt = Convert.ToDouble(sfiy) / 100;

                shed=al.Substring(al.Length - 5);
                CMagaza.Add(new Urunler(skat,dblfyt, shed)); //stok dosyasından okudugumuz urunlerimizi listimize atıyoruz
               
                al = string.Empty;
            }



            tr.Close();







            foreach (Urunler item in CMagaza)
            {
                listBox1.Items.Add(item.kategori+" " + item.fiyat+" YTL "  + item.hedef);  //urunlerimizi musteri kısmındaki urun raflarına atıyoruz
            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
       
        }

        private void button1_Click(object sender, EventArgs e) //filtreleme islemi yapan butonumuz
        {
            if(radioButton3.Checked) // aranacak urunun erkek mi kadın mı cocuk mu oldugunu kullanıcıdan alıyoruz
            {

                listBox1.Items.Clear();
                foreach (Urunler item in CMagaza)
                {

                    if (item.kategori == comboBox1.Text && item.hedef =="erkek") //sectigimiz katogeriye gore urunleri listeliyoruz
                    {

                        listBox1.Items.Add(item.kategori + " " + item.fiyat + " YTL " + item.hedef);


                    }

                }




            }
            if (radioButton4.Checked)
            {

                listBox1.Items.Clear();
                foreach (Urunler item in CMagaza)
                {

                    if (item.kategori == comboBox1.Text && item.hedef == "kadın")
                    {

                        listBox1.Items.Add(item.kategori + " " + item.fiyat + " YTL " + item.hedef);


                    }

                }




            }
            if (radioButton5.Checked)
            {

                listBox1.Items.Clear();
                foreach (Urunler item in CMagaza)
                {

                    if (item.kategori == comboBox1.Text && item.hedef == "cocuk")
                    {

                        listBox1.Items.Add(item.kategori + " " + item.fiyat + " YTL " + item.hedef);


                    }

                }




            }

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            
        }
       
        int itemadded = 0;
            int itemremoved = 0;
        string listkatagori;
        string listhedef;
        string listurun;
        double fiyatlist;
        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e) //burası raf listboxı double click yapınca urunu sepete atacagız
        {
            if (textBox1.Text == "" || maskedTextBox1 == null||!radioButton1.Checked&&!radioButton2.Checked) //ilk once musteri bilgileri girilmis mi kotrol ediyoruz
            {

                MessageBox.Show("Lütfen İlk Önce Bilgilerinizi Giriniz");


            }
            else //eger bilgiler girilmisse islemimize basliyoruz
            {

                itemadded++;
                listBox2.Items.Add(listBox1.SelectedItem);
                string secilenurun;
                secilenurun = Convert.ToString(listBox1.SelectedItem);
                string tempfyt = String.Empty;
                 
              listkatagori=String.Empty;
                 listhedef=string.Empty;
              listurun=String.Empty;
                listurun = Convert.ToString(listBox1.SelectedItem);
                for (int i = 0; i < listurun.Length; i++) //sectigimiz urunun hangi katagoreyie ait oldugunu alıyoruz (mont vs)
                {
                    if (Char.IsWhiteSpace(listurun[i]))
                    {
                        break;
                    }
                    else
                        listkatagori += listurun[i];


                }
                listhedef=listurun.Substring(listurun.Length-5);

               

                for (int i = 0; i < secilenurun.Length; i++) //urunumuzun fiyatını alıyoruz
                {
                    if (Char.IsDigit(secilenurun[i]))
                    {
                        tempfyt += secilenurun[i];
                    }
                }
                if (tempfyt.Length < 3)
                {
                    tempfyt = tempfyt + "00";


                }

                else if (tempfyt.Length < 4)
                {
                    tempfyt = tempfyt + "0";


                }


                fiyatlist = Convert.ToDouble(tempfyt); //sectigimiz urunlerin tamamının fiyatını hesaplıyoruz
                toplam += (fiyatlist / 100);
             

                label6.Text = Convert.ToString(toplam)+" YTL";
                for(int i=0;i<CMagaza.Count;i++)
                {
                   if(CMagaza[i].kategori==listkatagori&&CMagaza[i].fiyat==(fiyatlist/100)&&CMagaza[i].hedef==listhedef) //sectigimiz urunu list teki urunler karsilastiriyoruz eslesen urunu listten cikariyoruz
                    {
                        CMagaza.RemoveAt(i);
                     

                    }



                    

                }  



                listBox1.Items.Remove(listBox1.SelectedItem);

            }
        }

        private void listBox2_MouseDoubleClick(object sender, MouseEventArgs e)  //burasi sepet islemlerinin yapildigi listboxımız double clik yapinca urun sepetten cikacak
        {
            itemremoved++;
            listBox1.Items.Add(listBox2.SelectedItem); 
            string secilenurun;
            secilenurun = Convert.ToString(listBox2.SelectedItem);
            string tempfyt = String.Empty;
            double fiyat;
            listkatagori = String.Empty;
            listhedef = string.Empty;
            listurun = String.Empty;
            listurun = Convert.ToString(listBox2.SelectedItem);
            for (int i = 0; i < listurun.Length; i++)
            {
                if (Char.IsWhiteSpace(listurun[i]))
                {
                    break;
                }
                else
                    listkatagori += listurun[i];


            }
            listhedef = listurun.Substring(listurun.Length - 5);


            for (int i = 0; i < secilenurun.Length; i++)
            {
                if (Char.IsDigit(secilenurun[i]))
                {
                    tempfyt += secilenurun[i];
                }
            }
            if (tempfyt.Length < 3)
            {
                tempfyt = tempfyt + ".00";


            }
            else if (tempfyt.Length < 4)
            {
                tempfyt = tempfyt + "0";


            }
          

            fiyat = Convert.ToDouble(tempfyt);
            toplam -= (fiyat / 100);

            label6.Text = Convert.ToString(toplam)+" YTL";
            CMagaza.Add(new Urunler(listkatagori, fiyat, listhedef));
          
            listBox2.Items.Remove(listBox2.SelectedItem);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        double toplamgelir;
        int musterisayac;
        private void button6_Click(object sender, EventArgs e) //sepeti onayla butonumuzun işlemleri 
        {
            
            string items=string.Empty;
            label6.Text = "";
            string items1 = string.Empty;

            if ((itemadded - itemremoved) <= 0) //urun eklenip eklenmedigini kontrol ediyoruz eger eklenmiise devam ediypruz
            {
                MessageBox.Show("Lütfen İlk Öne Ürün Ekleyiniz");


            }

            else
            {
                musterisayac++;
                
                TextWriter mbtw = new StreamWriter("musterisatis.txt", append: true); //sepetteki urunleri musterisatis dosyasına atiyoruz 
                
                for (int i = 0; i < (itemadded - itemremoved); i++)
                {
                    items += "\n" + listBox2.Items[i].ToString();
                   
                    
                    mbtw.WriteLine(musterisayac + listBox2.Items[i].ToString());
                  

                }
                mbtw.Close();
                MessageBox.Show("Alınan ürünler :" + items + "\n Tutar:" + toplam); //musterinin aldıgı urunleri ve tutarını ekrana yansıtıyoruz

                TextWriter mstw = new StreamWriter("musterisayac.txt", append: true); //musteriyi kayıt ediyoruz
                mstw.WriteLine(musterisayac);
                mstw.Close();
                listBox2.Items.Clear(); //sepeti temizliyoruz
                toplamgelir += toplam;
                itemadded = 0;
                itemremoved = 0;
                   TextWriter gelirtw = new StreamWriter("gelir.txt"); //en son kazandıgımız gelirimizi tutmak uzere gelir dosyamız
                gelirtw.WriteLine(toplam);
                gelirtw.Close();
                toplam = 0;
              
             
                TextWriter tw = new StreamWriter("stok.txt"); //sepeti onaylaya basınca stokları tutan cmagaza listesinden stok dosyamıza urunleri tekrar yazdırıyoruz
                foreach (Urunler urun in CMagaza)
                {

                    tw.WriteLine(urun.kategori + urun.fiyat + urun.hedef);

                }
                tw.Close();

                TextWriter mtw = new StreamWriter("musteri.txt", append: true); //musteri bilgilerini musteri.txt dosyasında tutuyoruz
                if (radioButton1.Checked)
                {
                    mtw.WriteLine(musterisayac+","+ textBox1.Text + "," + maskedTextBox1.Text + "," + "Erkek");


                }
                else if (radioButton2.Checked)
                {

                    mtw.WriteLine(musterisayac + "," + textBox1.Text + "," + maskedTextBox1.Text + "," + "Erkek");


                }
                mtw.Close();
             
                textBox1.Text = "";
                maskedTextBox1.Clear();
                radioButton1.Checked = false;
                radioButton2.Checked = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Form5 frm5 = new Form5();
            frm5.Show();
         

           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form6 frm6 = new Form6();
            frm6.Show();
        }

        private void button8_Click(object sender, EventArgs e) //yaptıgımız filtrelemeyi temizliyoruz
        {
            listBox1.Items.Clear();
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            comboBox1.SelectedItem = null;
            foreach (Urunler item in CMagaza)
            {
                listBox1.Items.Add(item.kategori + " " + item.fiyat + " YTL " + item.hedef);
            }
        }
    }
}
