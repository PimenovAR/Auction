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
    public partial class АвтРег : Form
    {
        db db = new db();
        public АвтРег()
        {
            InitializeComponent();
        }

        public void logins()
        {

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable Table = new DataTable();

            string query = $"select * from Аккаунт where Логин='{textBox1.Text}' and Пароль='{textBox2.Text}'";

            SqlCommand command = new SqlCommand(query, db.con);

            adapter.SelectCommand = command;

            adapter.Fill(Table);

            if (Table.Rows.Count == 1)
            {
                if(textBox1.Text == "admin")
                {
                    MessageBox.Show("Вы успешно вошли!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    User.user = textBox1.Text;
                    Админ админ = new Админ();
                    админ.Show();
                }
                else
                {
                    MessageBox.Show("Вы успешно вошли!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    User.user = textBox1.Text;
                    Аукцион аукцион = new Аукцион();
                    аукцион.Show();
                }

                db.con.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Close();
                db.con.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин/пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void registration()
        {

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable Table = new DataTable();

            string query = $"select * from Аккаунт where Логин='{textBox1.Text}'";

            SqlCommand cmd = new SqlCommand(query, db.con);

            adapter.SelectCommand = cmd;

            adapter.Fill(Table);

            db.con.Open();

            if (Table.Rows.Count == 0)
            {
                SqlCommand insertCommand = new SqlCommand($"insert into Аккаунт(Логин,Пароль) values ('{textBox1.Text}','{textBox2.Text}')", db.con);

                if (insertCommand.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Регистрация прошла успешно!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    User.user = textBox1.Text;
                    this.Hide();
                    Аукцион аукцион = new Аукцион();
                    аукцион.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Такой логин/почта уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            db.con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {

            }
            else
            {
                logins();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {

            }
            else
            {
                registration();
            }
        }

        private void АвтРег_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
