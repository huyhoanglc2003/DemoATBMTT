using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo
{
    public partial class Form1 : Form
    {
        private static Random random = new Random();
        private const int a = 1;
        private const int b = 6;
        private static int p = 9973;

        private static PrivateKey privateKey = new PrivateKey(random.Next());

        ECC crypto = new ECC(new EllipticCurve(a, b, p), privateKey);

        public Form1()
        {
            InitializeComponent();
        }

        private void EncodeBtn_Click(object sender, EventArgs e)
        {
            Ciphertext.Text = crypto.ECCEncoding(InputPlaintext.Text);
        }

        private void TransferBtn_Click(object sender, EventArgs e)
        {
            InputCiphertext.Text = Ciphertext.Text;
        }

        private void DecodeBtn_Click(object sender, EventArgs e)
        {
            Plaintext.Text = crypto.ECCDecoding(InputCiphertext.Text,privateKey);
        }

        private void ReadPlaintextBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string fileContent = File.ReadAllText(openFileDialog.FileName);

                    InputPlaintext.Text = fileContent;
                }
                catch (Exception ex) { 
                
                }
            }
        }

        private void ReadCiphertextBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string fileContent = File.ReadAllText(openFileDialog.FileName);

                    InputCiphertext.Text = fileContent;
                }
                catch (Exception ex)
                {

                }
            }
        }


        private void SavePlaintextBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = saveFileDialog.FileName;

                    string fileContent = Plaintext.Text;

                    File.WriteAllText(filePath, fileContent);
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void SaveCiphertextBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = saveFileDialog.FileName;

                    string fileContent = Ciphertext.Text;

                    File.WriteAllText(filePath, fileContent);
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
