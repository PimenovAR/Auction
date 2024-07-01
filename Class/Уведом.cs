using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Аукцион.Model;

namespace Аукцион.Class
{
    public class Уведом
    {
        db db = new db();
        public void LoadFullRowsFromDatabase4(ListBox listBox, TextBox textBox)
        {
            db.con.Open();

            using (var command = db.con.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM Уведомления where Пользователь = '{textBox.Text}'";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listBox.Items.Add($"Уведомление: {reader["Уведомление"].ToString()}");
                    }
                }
            }
            db.con.Close();
        }

        public void LoadFullRows(ListBox listBox)
        {
            db.con.Open();

            using (var command = db.con.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM Уведомления";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listBox.Items.Add($"Уведомление: {reader["Уведомление"].ToString()} | Пользователь: { reader["Пользователь"].ToString()}");
                    }
                }
            }
            db.con.Close();
        }

        public void Qq(TextBox textBox, ComboBox textBox1)
        {
            {
                string query = $"insert into Уведомления(Уведомление,Пользователь) values ('{textBox.Text}','{textBox1.Text}')";
                SqlCommand command = new SqlCommand(query, db.con);

                try
                {
                    db.con.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    MessageBox.Show("Ставка создана, удачных торгов!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    db.con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                }
            }
        }


        public void Load(ListBox listBox)
        {
            db.con.Open();

            using (var command = db.con.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM ПерсональныеСтавки";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listBox.Items.Add($"idСтавки: {reader["idСтавки"].ToString()} | Ставка пользователя: {reader["ВашаСтавка"].ToString()} | Пользователь: {reader["Пользователь"].ToString()}");
                    }
                }
            }
            db.con.Close();
        }


    }
}
