using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Аукцион.Class;
using Аукцион.Model;

namespace Аукцион
{
    public partial class Аукцион : Form
    {
        db db = new db();
        public Аукцион()
        {
            InitializeComponent();
            listBox2.Items[0] = User.user;
            НовыйЛист новый = new НовыйЛист();
            новый.LoadFullRowsFromDatabase4(listBox1);
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox2.SelectedIndex == 1)
            {
                ВашиСтавки ставки = new ВашиСтавки();
                ставки.ShowDialog();
            }
            if (listBox2.SelectedIndex == 2)
            {
                Уведомления уведомления = new Уведомления();
                уведомления.ShowDialog();
            }
            if (listBox2.SelectedIndex == 3)
            {
                this.Hide();
                АвтРег автРег = new АвтРег();
                автРег.ShowDialog();
            }
        }

        private void Аукцион_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            СозданиеСтавки с = new СозданиеСтавки();
            с.ShowDialog();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = listBox1.SelectedItem;

            if (selectedItem != null)
            {
                var selectedItemText = selectedItem.ToString();

                var lines = selectedItemText.Split();

                textBox1.Text = lines[0];
                User.bet = textBox1.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Выберите ставку в списке!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                СделатьСтавку сделатьСтавку = new СделатьСтавку();
                сделатьСтавку.ShowDialog();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            НовыйЛист новый = new НовыйЛист();
            новый.LoadFullRowsFromDatabase4(listBox1);
        }
    }
}
