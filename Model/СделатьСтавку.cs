using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Аукцион.Class;

namespace Аукцион.Model
{
    public partial class СделатьСтавку : Form
    {
        public СделатьСтавку()
        {
            InitializeComponent();
            textBox1.Text = User.bet;
            textBox3.Text = User.user;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBox2.Text))
            {

            }
            else
            {

                ВашаСтавка в = new ВашаСтавка();
                в.Bet(textBox1,textBox2);
                в.YouBet(textBox1, textBox2,textBox3);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}
