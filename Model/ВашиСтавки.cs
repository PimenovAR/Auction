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

namespace Аукцион
{
    public partial class ВашиСтавки : Form
    {
        public ВашиСтавки()
        {
            InitializeComponent();
            textBox1.Text = User.user;
            НовыйЛист новый = new НовыйЛист();
            новый.You(listBox1,textBox1);
            новый.You2(listBox2, textBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
