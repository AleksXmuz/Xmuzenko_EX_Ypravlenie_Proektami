using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xmuzenko_EX_Ypravlenie_Proektami
{
    public partial class Form1 : Form
    {
        int[] key;
        string encryptText;

        public Form1()
        {
            InitializeComponent();
        }

        private int[] GenerateKey()
        {
            int[] array = new int[9];

            Random random = new Random(((int)DateTime.Now.Ticks));

            int temp = 0;
            int temp2 = 0;

            int x = random.Next(0, 9);

            for (int i = 0; i < array.Length; i++)
            {
                if (i == x)
                {
                    continue;
                }

                temp = random.Next(0, 9);
                if (temp == temp2 || array.Contains(temp))
                {
                    temp = random.Next(0, 9);

                    i -= 1;
                    continue;
                }
                else
                {
                    array[i] = temp;
                    temp2 = temp;
                }

            }

            textBox3.Text = "";
            foreach (var item in array)
            {
                textBox3.Text += item.ToString();
            }

            return array;
        }

        private void EncryptText()
        {
            string temp = textBox1.Text;
            string temp2 = "";

            int a = 0;
            int c = 0;

            int x = 0;
            int y = 9;

            List<string> b = new List<string>();

            a = temp.Length / 9;

            for (int i = 0; i < a; i++)
            {
                b.Add(temp.Substring(x, y));
                x += y;
            }
            b.Add(temp.Substring(x));

            foreach (var item in b)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    if (item.Length < key.Length)
                    {
                        for (int k = 0; k < key.Length; k++)
                        {
                            int m = item.IndexOf(item[i]);
                            if (key[k] != m)
                            {
                                temp2 += " ";
                            }
                            else
                            {
                                temp2 += item.ElementAt(key[k]);
                            }
                            c++;
                        }
                    }

                    if (item.Length == key.Length)
                    {
                        temp2 += item.ElementAt(key[c]);
                    }

                    c++;
                    if (c == 9)
                    {
                        c = 0;
                    }


                }
            }

            textBox2.Text = temp2.Replace(' ', '.');
            encryptText = temp2;
        }

        private void DeencryptText()
        {
            string temp = encryptText;
            string[] temp2 = new string[9];
            string temp3 = "";

            int a = 0;

            int x = 0;
            int y = 9;

            List<string> b = new List<string>();

            a = temp.Length / 9;

            for (int i = 0; i < a; i++)
            {
                b.Add(temp.Substring(x, y));
                x += y;
            }
            b.Add(temp.Substring(x));

            foreach (var item in b)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    temp2[key[i]] += item[i];
                }

                foreach (var item2 in temp2)
                {
                    temp3 += item2;
                }
                temp2 = new string[9];
            }

            textBox4.Text = temp3;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            key = GenerateKey();
            EncryptText();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeencryptText();
        }
    }
}
