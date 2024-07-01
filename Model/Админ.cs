using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Аукцион.Class;

namespace Аукцион.Model
{
    public partial class Админ : Form
    {
        public Админ()
        {
            InitializeComponent();
            Уведом уведом = new Уведом();
            уведом.LoadFullRows(listBox1);
            уведом.Load(listBox3);
            НовыйЛист админ = new НовыйЛист();
            админ.Admin(listBox2);
            админ.AdminUser(comboBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(comboBox1.Text))
            {

            }
            else
            {
                listBox1.Items.Clear();
                Уведом уведом = new Уведом();
                уведом.Qq(textBox1,comboBox1);
                уведом.LoadFullRows(listBox1);
            }
        }

        private void Админ_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();

            printDocument.PrintPage += PrintDocument_PrintPage;

            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.PrinterSettings = printDialog.PrinterSettings;

                printDocument.Print();
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;

            string header = "Отчет о ставках";
            Font headerFont = new Font("Arial", 14, FontStyle.Bold);
            graphics.DrawString(header, headerFont, Brushes.Black, 100, 100);

            int y = 150;
            foreach (string item in listBox3.Items)
            {
                graphics.DrawString(item, new Font("Arial", 12), Brushes.Black, 100, y);
                y += 20;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            Уведом уведом = new Уведом();
            уведом.Load(listBox3);
            НовыйЛист админ = new НовыйЛист();
            админ.Admin(listBox2);
        }
    }
}
