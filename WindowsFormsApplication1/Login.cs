using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace WindowsFormsApplication1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "") { }
            else if (this.textBox1.Text == "") { }
            else
            {
                string md5 = System.IO.File.ReadAllText(@"" + this.path + "\\saida.txt");
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
                bool achei = false;
                int f;
                for(f = 0; !achei; f++)
                {
                    if (users.ElementAt(f) == this.textBox1.Text)
                        achei = true;
                }
                MD5 H = MD5.Create();
                string senha = GetMd5Hash(H, this.textBox2.Text);
                if (pass.ElementAt(f-1) == senha)
                {
                    MessageBox.Show("Sucesso =D");
                }else
                {
                    MessageBox.Show("Noooops =P");
                }
            }

        }
    }
}
