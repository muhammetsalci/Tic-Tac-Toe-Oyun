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

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int sayac=0; //oyunun berabere bittiğini gösteren kod için sayaç oluşturduk.
        string a="X"; //label2 de yazan ilk değeri tutmak için değişken oluşturup ilk değerini X yapıyoruz.
        private void Form1_Load(object sender, EventArgs e)
        {
            string yazi;

            string dosya_yolu = @".\veriler.txt"; //dosyayı programın bulunduğu dizinde oluşturuyoruz.

            FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Read); //dosya yoksa oluşturuyoruz, varsa açıyoruz.

            StreamReader sw = new StreamReader(fs);

            yazi = sw.ReadLine(); //dosyadaki değerleri yazi değişkenine atıyoruz.
            label2.Text = yazi; //yazi değişkenindeki değeri label2 de yazdırıyoruz.

            fs.Close(); //dosyayı kapatıyoruz.

            if (label2.Text == "")
            {
                label2.Text = "X";
            }
            //eğer dosyanın içinde bir değer yazmıyorsa label2 ye X değerini atıyoruz.
        }

        private void yeniOyunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(a=="X")
            {
                a = "O";
            }
            else if(a=="O")
            {
                a = "X";
            }
            //yeni oyuna basıldığı zaman dosyada X varsa O yapıyoruz, O varsa X yapıyoruz.

            FileStream fm = new FileStream(".\\veriler.txt", FileMode.Create); //dosyayı oluşturuyoruz.
            StreamWriter sm = new StreamWriter(fm);
            sm.WriteLine(a); //a değişkeninin değerini dosyaya atıyoruz.
            sm.Flush();
            fm.Close();

            string yazi;

            string dosya_yolu = @".\veriler.txt";

            FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);

            StreamReader sw = new StreamReader(fs);

            yazi = sw.ReadLine();
            a = yazi;

            fs.Close();
            //dosyadaki ifadeyi a değişkenine atıyoruz.

            label2.Text = a; //a değişkenindeki değeri label2 de yazdırıyoruz.

            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button11.Enabled = true;
            button12.Enabled = true;
            button13.Enabled = true;
            button21.Enabled = true;
            button22.Enabled = true;
            button23.Enabled = true;
            //bütün butonları aktifleştiriyoruz.

            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button11.Text = "";
            button12.Text = "";
            button13.Text = "";
            button21.Text = "";
            button22.Text = "";
            button23.Text = "";
            //bütün butonların içindeki değeri boş yapıyoruz.
            

        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //butonların hepsinin içinin boş olduğu bir koşul oluşturuyoruz.
            if(button1.Text == "" && button2.Text == "" && button3.Text == "" &&
               button11.Text == "" && button12.Text == "" && button13.Text == "" &&
               button21.Text == "" && button22.Text == "" && button23.Text == "")
            {
                FileStream fm = new FileStream(".\\veriler.txt", FileMode.Create);
                StreamWriter sm = new StreamWriter(fm);
                sm.WriteLine(label2.Text); //hiçbir butona basılmadığı için uygulama kapatılıp açılınca label2 de yazan kullanıcı oyuna başlasın diye label2 yi dosyaya gönderiyoruz.
                sm.Flush();
                fm.Close();

                this.Close(); //programı kapatıyoruz.
            }

            else
            {
                string yazi;

                string dosya_yolu = @".\veriler.txt";

                FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);

                StreamReader sw = new StreamReader(fs);

                yazi = sw.ReadLine();
                a = yazi;

                fs.Close();
                //çıkışa bastığımız zaman önce dosyadaki değeri alıyoruz.

                if (a == "X")
                {
                    a = "O";
                }
                else if (a == "O")
                {
                    a = "X";
                }
                else
                {
                    a = "O";
                }
                //dosyadaki değeri tersine çeviriyoruz.

                FileStream fm = new FileStream(".\\veriler.txt", FileMode.Create);
                StreamWriter sm = new StreamWriter(fm);
                sm.WriteLine(a);
                sm.Flush();
                fm.Close();
                //tekrardan a değişkenini dosyaya kaydediyoruz.

                this.Close(); //programı kapatıyoruz.
            }
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = label2.Text; //button1 e basınca label2 deki değeri button1 e yazdırıyoruz.
            button1.Enabled = false; //button1 i devredışı bırakıyoruz.
            if (label2.Text == "X")
            {
                label2.Text = "O";
            }
            else if(label2.Text=="O")
            {
                label2.Text = "X";
            }
            //label2 deki değeri tersine çeviriyoruz.

            if ((button1.Text == button2.Text)&&(button1.Text==button3.Text)||(button1.Text==button11.Text)&&(button1.Text==button21.Text)||(button1.Text==button12.Text)&&(button1.Text==button23.Text))
            {
                MessageBox.Show(button1.Text + " Kazandı.");
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button11.Enabled = false;
                button12.Enabled = false;
                button13.Enabled = false;
                button21.Enabled = false;
                button22.Enabled = false;
                button23.Enabled = false;
                sayac++;
            }
            //kazandığını belirten kodu yazıp sayacı 1 arttırıyoruz.

            if (sayac == 0 && button1.Enabled == false && button2.Enabled == false && button3.Enabled == false && button11.Enabled == false && button12.Enabled == false && button13.Enabled == false && button21.Enabled == false && button22.Enabled == false && button23.Enabled == false)
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
                button13.Enabled = true;
                button21.Enabled = true;
                button22.Enabled = true;
                button23.Enabled = true;

                button1.Text = "";
                button2.Text = "";
                button3.Text = "";
                button11.Text = "";
                button12.Text = "";
                button13.Text = "";
                button21.Text = "";
                button22.Text = "";
                button23.Text = "";
            }
            //sayac değişkeni 0 ise ve bütün butonlar devredışı ise oyun berabere bitmiştir ve butonları aktifleştirip içlerini boşaltıyoruz.
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Text = label2.Text; //button2 ye basınca label2 deki değeri button2 ye yazdırıyoruz.
            button2.Enabled = false; //button2 yi devredışı bırakıyoruz.
            if (label2.Text == "X")
            {
                label2.Text = "O";
            }
            else if (label2.Text == "O")
            {
                label2.Text = "X";
            }
            //label2 deki değeri tersine çeviriyoruz.

            if ((button1.Text == button2.Text) && (button2.Text == button3.Text) || (button2.Text == button12.Text) && (button2.Text == button22.Text))
            {
                MessageBox.Show(button2.Text + " Kazandı.");
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button11.Enabled = false;
                button12.Enabled = false;
                button13.Enabled = false;
                button21.Enabled = false;
                button22.Enabled = false;
                button23.Enabled = false;
                sayac++;
            }
            //kazandığını belirten kodu yazıp sayacı 1 arttırıyoruz.

            if (sayac == 0 && button1.Enabled == false && button2.Enabled == false && button3.Enabled == false && button11.Enabled == false && button12.Enabled == false && button13.Enabled == false && button21.Enabled == false && button22.Enabled == false && button23.Enabled == false)
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
                button13.Enabled = true;
                button21.Enabled = true;
                button22.Enabled = true;
                button23.Enabled = true;

                button1.Text = "";
                button2.Text = "";
                button3.Text = "";
                button11.Text = "";
                button12.Text = "";
                button13.Text = "";
                button21.Text = "";
                button22.Text = "";
                button23.Text = "";
            }
            //sayac değişkeni 0 ise ve bütün butonlar devredışı ise oyun berabere bitmiştir ve butonları aktifleştirip içlerini boşaltıyoruz
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Text = label2.Text; //button3 e basınca label2 deki değeri button3 e yazdırıyoruz.
            button3.Enabled = false; //button3 ü devredışı bırakıyoruz.
            if (label2.Text == "X")
            {
                label2.Text = "O";
            }
            else if (label2.Text == "O")
            {
                label2.Text = "X";
            }
            //label2 deki değeri tersine çeviriyoruz.

            if ((button3.Text == button1.Text) && (button3.Text == button2.Text) || (button3.Text == button13.Text) && (button3.Text == button23.Text) || (button3.Text == button12.Text) && (button3.Text == button21.Text))
            {
                MessageBox.Show(button3.Text+" Kazandı.");
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button11.Enabled = false;
                button12.Enabled = false;
                button13.Enabled = false;
                button21.Enabled = false;
                button22.Enabled = false;
                button23.Enabled = false;
                sayac++;
            }
            //kazandığını belirten kodu yazıp sayacı 1 arttırıyoruz.

            if (sayac == 0 && button1.Enabled == false && button2.Enabled == false && button3.Enabled == false && button11.Enabled == false && button12.Enabled == false && button13.Enabled == false && button21.Enabled == false && button22.Enabled == false && button23.Enabled == false)
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
                button13.Enabled = true;
                button21.Enabled = true;
                button22.Enabled = true;
                button23.Enabled = true;

                button1.Text = "";
                button2.Text = "";
                button3.Text = "";
                button11.Text = "";
                button12.Text = "";
                button13.Text = "";
                button21.Text = "";
                button22.Text = "";
                button23.Text = "";
            }
            //sayac değişkeni 0 ise ve bütün butonlar devredışı ise oyun berabere bitmiştir ve butonları aktifleştirip içlerini boşaltıyoruz
        }

        private void button11_Click(object sender, EventArgs e)
        {
            button11.Text = label2.Text; //button11 e basınca label2 deki değeri button11 e yazdırıyoruz.
            button11.Enabled = false; //button11 i devredışı bırakıyoruz.
            if (label2.Text == "X")
            {
                label2.Text = "O";
            }
            else if (label2.Text == "O")
            {
                label2.Text = "X";
            }
            //label2 deki değeri tersine çeviriyoruz.

            if ((button11.Text == button1.Text) && (button11.Text == button21.Text) || (button11.Text == button12.Text) && (button11.Text == button13.Text))
            {
                MessageBox.Show(button11.Text + " Kazandı.");
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button11.Enabled = false;
                button12.Enabled = false;
                button13.Enabled = false;
                button21.Enabled = false;
                button22.Enabled = false;
                button23.Enabled = false;
                sayac++;
            }
            //kazandığını belirten kodu yazıp sayacı 1 arttırıyoruz.

            if (sayac == 0 && button1.Enabled == false && button2.Enabled == false && button3.Enabled == false && button11.Enabled == false && button12.Enabled == false && button13.Enabled == false && button21.Enabled == false && button22.Enabled == false && button23.Enabled == false)
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
                button13.Enabled = true;
                button21.Enabled = true;
                button22.Enabled = true;
                button23.Enabled = true;

                button1.Text = "";
                button2.Text = "";
                button3.Text = "";
                button11.Text = "";
                button12.Text = "";
                button13.Text = "";
                button21.Text = "";
                button22.Text = "";
                button23.Text = "";
            }
            //sayac değişkeni 0 ise ve bütün butonlar devredışı ise oyun berabere bitmiştir ve butonları aktifleştirip içlerini boşaltıyoruz
        }

        private void button12_Click(object sender, EventArgs e)
        {
            button12.Text = label2.Text; //button12 ye basınca label2 deki değeri button12 ye yazdırıyoruz.
            button12.Enabled = false; //button12 yi devredışı bırakıyoruz.
            if (label2.Text == "X")
            {
                label2.Text = "O";
            }
            else if (label2.Text == "O")
            {
                label2.Text = "X";
            }
            //label2 deki değeri tersine çeviriyoruz.

            if ((button12.Text == button1.Text) && (button12.Text == button23.Text) || (button12.Text == button2.Text) && (button12.Text == button22.Text) || (button12.Text == button3.Text) && (button12.Text == button21.Text)|| (button12.Text == button11.Text) && (button12.Text == button13.Text))
            {
                MessageBox.Show(button12.Text + " Kazandı.");
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button11.Enabled = false;
                button12.Enabled = false;
                button13.Enabled = false;
                button21.Enabled = false;
                button22.Enabled = false;
                button23.Enabled = false;
                sayac++;
            }
            //kazandığını belirten kodu yazıp sayacı 1 arttırıyoruz.

            if (sayac == 0 && button1.Enabled == false && button2.Enabled == false && button3.Enabled == false && button11.Enabled == false && button12.Enabled == false && button13.Enabled == false && button21.Enabled == false && button22.Enabled == false && button23.Enabled == false)
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
                button13.Enabled = true;
                button21.Enabled = true;
                button22.Enabled = true;
                button23.Enabled = true;

                button1.Text = "";
                button2.Text = "";
                button3.Text = "";
                button11.Text = "";
                button12.Text = "";
                button13.Text = "";
                button21.Text = "";
                button22.Text = "";
                button23.Text = "";
            }
            //sayac değişkeni 0 ise ve bütün butonlar devredışı ise oyun berabere bitmiştir ve butonları aktifleştirip içlerini boşaltıyoruz
        }

        private void button13_Click(object sender, EventArgs e)
        {
            button13.Text = label2.Text; //button13 e basınca label2 deki değeri button13 e yazdırıyoruz.
            button13.Enabled = false; //button13 ü devredışı bırakıyoruz.
            if (label2.Text == "X")
            {
                label2.Text = "O";
            }
            else if (label2.Text == "O")
            {
                label2.Text = "X";
            }
            //label2 deki değeri tersine çeviriyoruz.

            if ((button13.Text == button3.Text) && (button13.Text == button23.Text) || (button13.Text == button12.Text) && (button13.Text == button11.Text))
            {
                MessageBox.Show(button13.Text + " Kazandı.");
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button11.Enabled = false;
                button12.Enabled = false;
                button13.Enabled = false;
                button21.Enabled = false;
                button22.Enabled = false;
                button23.Enabled = false;
                sayac++;
            }
            //kazandığını belirten kodu yazıp sayacı 1 arttırıyoruz.

            if (sayac == 0 && button1.Enabled == false && button2.Enabled == false && button3.Enabled == false && button11.Enabled == false && button12.Enabled == false && button13.Enabled == false && button21.Enabled == false && button22.Enabled == false && button23.Enabled == false)
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
                button13.Enabled = true;
                button21.Enabled = true;
                button22.Enabled = true;
                button23.Enabled = true;

                button1.Text = "";
                button2.Text = "";
                button3.Text = "";
                button11.Text = "";
                button12.Text = "";
                button13.Text = "";
                button21.Text = "";
                button22.Text = "";
                button23.Text = "";
            }
            //sayac değişkeni 0 ise ve bütün butonlar devredışı ise oyun berabere bitmiştir ve butonları aktifleştirip içlerini boşaltıyoruz
        }

        private void button21_Click(object sender, EventArgs e)
        {
            button21.Text = label2.Text; //button21 e basınca label2 deki değeri button21 e yazdırıyoruz.
            button21.Enabled = false; //button21 i devredışı bırakıyoruz.
            if (label2.Text == "X")
            {
                label2.Text = "O";
            }
            else if (label2.Text == "O")
            {
                label2.Text = "X";
            }
            //label2 deki değeri tersine çeviriyoruz.

            if ((button21.Text == button11.Text) && (button21.Text == button1.Text) || (button21.Text == button12.Text) && (button21.Text == button3.Text) || (button21.Text == button22.Text) && (button21.Text == button23.Text))
            {
                MessageBox.Show(button21.Text + " Kazandı.");
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button11.Enabled = false;
                button12.Enabled = false;
                button13.Enabled = false;
                button21.Enabled = false;
                button22.Enabled = false;
                button23.Enabled = false;
                sayac++;
            }
            //kazandığını belirten kodu yazıp sayacı 1 arttırıyoruz.

            if (sayac == 0 && button1.Enabled == false && button2.Enabled == false && button3.Enabled == false && button11.Enabled == false && button12.Enabled == false && button13.Enabled == false && button21.Enabled == false && button22.Enabled == false && button23.Enabled == false)
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
                button13.Enabled = true;
                button21.Enabled = true;
                button22.Enabled = true;
                button23.Enabled = true;

                button1.Text = "";
                button2.Text = "";
                button3.Text = "";
                button11.Text = "";
                button12.Text = "";
                button13.Text = "";
                button21.Text = "";
                button22.Text = "";
                button23.Text = "";
            }
            //sayac değişkeni 0 ise ve bütün butonlar devredışı ise oyun berabere bitmiştir ve butonları aktifleştirip içlerini boşaltıyoruz
        }

        private void button22_Click(object sender, EventArgs e)
        {
            button22.Text = label2.Text; //button22 ye basınca label2 deki değeri button22 ye yazdırıyoruz.
            button22.Enabled = false; //button22 yi devredışı bırakıyoruz.
            if (label2.Text == "X")
            {
                label2.Text = "O";
            }
            else if (label2.Text == "O")
            {
                label2.Text = "X";
            }
            //label2 deki değeri tersine çeviriyoruz.

            if ((button22.Text == button12.Text) && (button22.Text == button2.Text) || (button22.Text == button21.Text) && (button22.Text == button23.Text))
            {
                MessageBox.Show(button22.Text + " Kazandı.");
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button11.Enabled = false;
                button12.Enabled = false;
                button13.Enabled = false;
                button21.Enabled = false;
                button22.Enabled = false;
                button23.Enabled = false;
                sayac++;
            }
            //kazandığını belirten kodu yazıp sayacı 1 arttırıyoruz.

            if (sayac == 0 && button1.Enabled == false && button2.Enabled == false && button3.Enabled == false && button11.Enabled == false && button12.Enabled == false && button13.Enabled == false && button21.Enabled == false && button22.Enabled == false && button23.Enabled == false)
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
                button13.Enabled = true;
                button21.Enabled = true;
                button22.Enabled = true;
                button23.Enabled = true;

                button1.Text = "";
                button2.Text = "";
                button3.Text = "";
                button11.Text = "";
                button12.Text = "";
                button13.Text = "";
                button21.Text = "";
                button22.Text = "";
                button23.Text = "";
            }
            //sayac değişkeni 0 ise ve bütün butonlar devredışı ise oyun berabere bitmiştir ve butonları aktifleştirip içlerini boşaltıyoruz
        }

        private void button23_Click(object sender, EventArgs e)
        {
            button23.Text = label2.Text; //button23 e basınca label2 deki değeri button23 e yazdırıyoruz.
            button23.Enabled = false; //button23 ü devredışı bırakıyoruz.
            if (label2.Text == "X")
            {
                label2.Text = "O";
            }
            else if (label2.Text == "O")
            {
                label2.Text = "X";
            }
            //label2 deki değeri tersine çeviriyoruz.

            if ((button23.Text == button13.Text) && (button23.Text == button3.Text) || (button23.Text == button12.Text) && (button23.Text == button1.Text) || (button23.Text == button22.Text) && (button23.Text == button21.Text))
            {
                MessageBox.Show(button23.Text + " Kazandı.");
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button11.Enabled = false;
                button12.Enabled = false;
                button13.Enabled = false;
                button21.Enabled = false;
                button22.Enabled = false;
                button23.Enabled = false;
                sayac++;
            }
            //kazandığını belirten kodu yazıp sayacı 1 arttırıyoruz.

            if (sayac == 0 && button1.Enabled == false && button2.Enabled == false && button3.Enabled == false && button11.Enabled == false && button12.Enabled == false && button13.Enabled == false && button21.Enabled == false && button22.Enabled == false && button23.Enabled == false)
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
                button13.Enabled = true;
                button21.Enabled = true;
                button22.Enabled = true;
                button23.Enabled = true;

                button1.Text = "";
                button2.Text = "";
                button3.Text = "";
                button11.Text = "";
                button12.Text = "";
                button13.Text = "";
                button21.Text = "";
                button22.Text = "";
                button23.Text = "";
            }
            //sayac değişkeni 0 ise ve bütün butonlar devredışı ise oyun berabere bitmiştir ve butonları aktifleştirip içlerini boşaltıyoruz
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Geliştirici: Bilgisayar Mühendisi"); //hakkındaya basınca ekrana yansıtılacak mesajı yazıyoruz.
        }
    }
}
