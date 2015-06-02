using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash. 
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes 
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string. 
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string. 
            return sBuilder.ToString();
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Text = System.IO.File.ReadAllText(@"" + this.textBox1.Text+"\\base.txt");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.IO.File.WriteAllText(@"" + this.textBox1.Text + "\\saida.txt", this.richTextBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime data = new DateTime();
            data = DateTime.Now;
            MD5 md5hash = MD5.Create();
            string md5 = this.richTextBox1.Text;
            string[] has = md5.Split('\n', '\t');
            List<string> users = new List<string>();
            List<string> pass = new List<string>();
            for (int i = 0; i < has.Length; i++)
            {
                if(i%2 == 0)
                {
                    users.Add(has[i]);
                }
                else
                {
                    pass.Add(has[i]);
                }
            }
            this.richTextBox1.Text = "";
            int temp = users.Count;
            string testeString = "" ;
            for (int i = 1; i < temp; i++)
            {
                testeString += users.First() + "\t" + GetMd5Hash(md5hash, pass.First()) + "\n";
                users.Remove(users.First());
                pass.Remove(pass.First());
            }
            this.richTextBox1.Text = testeString;
            MessageBox.Show((DateTime.Now - data).ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DateTime data = new DateTime();
            data = DateTime.Now;
            SHA1 md5hash = SHA1.Create();
            string md5 = this.richTextBox1.Text;
            string[] has = md5.Split('\n', '\t');
            List<string> users = new List<string>();
            List<string> pass = new List<string>();
            for (int i = 0; i < has.Length; i++)
            {
                if (i % 2 == 0)
                {
                    users.Add(has[i]);
                }
                else
                {
                    pass.Add(has[i]);
                }
            }
            this.richTextBox1.Text = "";
            int temp = users.Count;
            string testeString = "";
            for (int i = 1; i < temp; i++)
            {
                testeString += users.First() + "\t" + GetSha1Hash(md5hash, pass.First()) + "\n";
                users.Remove(users.First());
                pass.Remove(pass.First());
            }
            this.richTextBox1.Text = testeString;
            MessageBox.Show((DateTime.Now - data).ToString());
        }

        private string GetSha1Hash(SHA1 Sha1, string v)
        {
            // Convert the input string to a byte array and compute the hash. 
            byte[] data = Sha1.ComputeHash(Encoding.UTF8.GetBytes(v));

            // Create a new Stringbuilder to collect the bytes 
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string. 
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string. 
            return sBuilder.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DateTime data = new DateTime();
            data = DateTime.Now;
            SHA256 md5hash = SHA256.Create();
            string md5 = this.richTextBox1.Text;
            string[] has = md5.Split('\n', '\t');
            List<string> users = new List<string>();
            List<string> pass = new List<string>();
            for (int i = 0; i < has.Length; i++)
            {
                if (i % 2 == 0)
                {
                    users.Add(has[i]);
                }
                else
                {
                    pass.Add(has[i]);
                }
            }
            this.richTextBox1.Text = "";
            int temp = users.Count;
            string testeString = "";
            for (int i = 1; i < temp; i++)
            {
                testeString += users.First() + "\t" + GetSha256Hash(md5hash, pass.First()) + "\n";
                users.Remove(users.First());
                pass.Remove(pass.First());
            }
            this.richTextBox1.Text = testeString;
            MessageBox.Show((DateTime.Now - data).ToString());
        }

        private string GetSha256Hash(SHA256 Sha1, string v)
        {
            // Convert the input string to a byte array and compute the hash. 
            byte[] data = Sha1.ComputeHash(Encoding.UTF8.GetBytes(v));

            // Create a new Stringbuilder to collect the bytes 
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string. 
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string. 
            return sBuilder.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.path = this.textBox1.Text;
            login.Visible = true;
        }
    }
}
