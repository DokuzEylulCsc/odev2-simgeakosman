using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Converter
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                Convert.ToInt32(textBox1.Text);
                if (Convert.ToInt32(textBox1.Text) <= 3999 && Convert.ToInt32(textBox1.Text) > 0)
                {
                    ConvertRoman(Convert.ToInt32(textBox1.Text));
                }
                else MessageBox.Show("Sayı Limitini aştınız");
                textBox1.Clear();

            }
            catch
            {
                if(textBox1.Text.Contains('ı'))
                textBox1.Text.Replace('ı', 'i');
                textBox1.CharacterCasing = CharacterCasing.Upper;

                string[] red = new string[7]
                {
                "IIII",
                "VVVV",
                "XXXX",
                "LLLL",
                "CCCC",
                "MMMM",
                "DDDD"
                };

                for (int i = 0; i < red.Length; i++)
                {
                    if (textBox1.Text.Contains(red[i]))
                    {
                        MessageBox.Show("Yan yana en fazla 3 Karakter girebilirsiniz");
                        textBox1.Clear();

                    }
                }
                if ((ConvertDecimal(textBox1.Text)) != 0)
                    MessageBox.Show(ConvertDecimal(textBox1.Text).ToString());
                textBox1.Clear();

            }

        }
        public int ConvertDecimal(string rom)
        {
            char[] textkarakter = new char[rom.Length];
            textkarakter = rom.ToCharArray();
            int result = 0;
            for (int i = 0; i < rom.Length; i++)
            {
                if (i + 1 < rom.Length)
                {
                    if ((RomeenListe(textkarakter[i].ToString())) == 0)
                    {
                        
                        textBox1.Clear();
                        result = 0;
                        goto end_;
                    }
                    //Hatalı Giriş sebebleri
                    //Sadece I, X ve C rakamları, kendinin en fazla 10 katı büyük bir rakamdan önce yazılabilir
                    // (Örneğin V den önce I veya X'den önce I yazılabilir. C'den önce I olmaz.)xıc olmamalı. Olması gereken cıx
                    //Soldaki deger sagdaki degerden buyuk olmalı ıxc olmamalı
                    // V, L, D karakterleri bitişik olarak tekrar edemez.
                    if ((RomeenListe(textkarakter[i].ToString()) == 1))
                    {
                        if (((RomeenListe(textkarakter[i + 1].ToString()) >= 50)))
                        {
                            MessageBox.Show("Hatalı Giriş Yaptınız");
                            textBox1.Clear();
                            result = 0;
                            goto end_;
                        }
                    }
                    if ((RomeenListe(textkarakter[i].ToString()) == 5))
                    {
                        if (((RomeenListe(textkarakter[i + 1].ToString()) >= 5)))
                        {
                            MessageBox.Show("Hatalı Giriş Yaptınız");
                            textBox1.Clear();
                            result = 0;
                            goto end_;
                        }
                    }
                    if ((RomeenListe(textkarakter[i].ToString()) == 10))
                    {
                        if (((RomeenListe(textkarakter[i + 1].ToString()) >= 500)))
                        {
                            MessageBox.Show("Hatalı Giriş Yaptınız");
                            textBox1.Clear();
                            result = 0;
                            goto end_;
                        }
                    }
                    if ((RomeenListe(textkarakter[i].ToString()) == 50))
                    {
                        if (((RomeenListe(textkarakter[i + 1].ToString()) >= 50)))
                        {
                            MessageBox.Show("Hatalı Giriş Yaptınız");
                            textBox1.Clear();
                            result = 0;
                            goto end_;
                        }
                    }
                    if ((RomeenListe(textkarakter[i].ToString()) == 500))
                    {
                        if (((RomeenListe(textkarakter[i + 1].ToString()) != 500)))
                        {
                            MessageBox.Show("Hatalı Giriş Yaptınız");
                            textBox1.Clear();
                            result = 0;
                            goto end_;
                        }
                    }
                    for ( int k = 2; k <= rom.Length; k++)
                    {
                        if (RomeenListe(textkarakter[0].ToString()) < (RomeenListe(textkarakter[i].ToString())))
                        {
                            MessageBox.Show("Hatalı Giriş Yaptınız");
                            textBox1.Clear();
                            result = 0;
                            goto end_;
                        }
                    }
                        if (RomeenListe(textkarakter[i].ToString()) >= RomeenListe(textkarakter[i + 1].ToString()))
                        {

                            result = result + RomeenListe(textkarakter[i].ToString());
                        }
                        else
                        {
                            result = result + RomeenListe(textkarakter[i + 1].ToString()) - RomeenListe(textkarakter[i].ToString());
                            i++;
                        }
                    
                }
                else
                {
                    result = result + RomeenListe(textkarakter[i].ToString());
                }

            }
            if (result > 3999)
            {
                result = 0;
                MessageBox.Show("Limiti aştınız lütfen tekrar deneyin");
                textBox1.Clear();
            }
        end_:
            return result;
        }

        public int RomeenListe(string a)
        {
            int value=0;
            switch (a)
            {
                case "I": value= 1; break;
                case "ı": value= 1; break;
                case "V": value= 5; break;
                case "L": value= 50; break;
                case "X": value= 10; break;
                case "C": value= 100; break;
                case "D": value= 500; break;
                case "M": value= 1000;break;
                default: value = 0; MessageBox.Show("Karakter tanımlı değil"); break;
                   
            }
            return value;

        }
        public void ConvertRoman(int value)
        {

            string M, C, I, X;
            M = Thousand((value / 1000) % 10);
            C = hundred((value / 100) % 10);
            X = ten((value / 10) % 10);
            I = ones(value % 10);
            MessageBox.Show(M + C + X + I);

        }

        public string Thousand(int k4)
        {
            string value = "";
            switch (k4)
            {

                case 1: value = "M"; break;
                case 2: value = "MM"; break;
                case 3: value = "MMM"; break;

                default: break;


            }
            return value;

        }
        public string hundred(int k1)
        {
            string value = "";
            switch (k1)
            {

                case 1: value = "C"; break;
                case 2: value = "CC"; break;
                case 3: value = "CCC"; break;
                case 4: value = "CD"; break;
                case 5: value = "D"; break;
                case 6: value = "DC"; break;
                case 7: value = "DCC"; break;
                case 8: value = "DCCC"; break;
                case 9: value = "CM"; break;
                default: break;


            }
            return value;

        }
        public string ten(int k2)
        {
            string value = "";
            switch (k2)
            {

                case 1: value = "X"; break;
                case 2: value = "XX"; break;
                case 3: value = "XXX"; break;
                case 4: value = "XL"; break;
                case 5: value = "L"; break;
                case 6: value = "LX"; break;
                case 7: value = "LXX"; break;
                case 8: value = "LXXX"; break;
                case 9: value = "XC"; break;
                default: break;

            }
            return value;
        }
        public string ones(int k3)
        {
            string value = "";
            switch (k3)
            {

                case 1: value = "I"; break;
                case 2: value = "II"; break;
                case 3: value = "III"; break;
                case 4: value = "IV"; break;
                case 5: value = "V"; break;
                case 6: value = "VI"; break;
                case 7: value = "VII"; break;
                case 8: value = "VIII"; break;
                case 9: value = "IX"; break;
                default: break;

            }
            return value;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form form = new Form();
            form.AcceptButton = button1;
        }

        
    }

}
