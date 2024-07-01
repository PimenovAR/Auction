using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Аукцион.Class
{
    public class НовыйЛист
    {
        db db = new db();
        public void LoadFullRowsFromDatabase4(ListBox listBox)
        {
            db.con.Open();

            using (var command = db.con.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Ставки";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listBox.Items.Add($"{reader["id"].ToString()} | Предмет: {reader["Предмет"].ToString()} | Стартовая цена: {reader["СтартоваяЦена"].ToString()} | Последняя ставка: {reader["ПоследняяСтавка"].ToString()} | Время проведения: до {reader["ВремяПроведения"].ToString()} | Владелец: {reader["Владелец"].ToString()}");
                    }
                }
            }
            db.con.Close();
        }

        public void You(ListBox listBox,TextBox textBox1)
        {
            db.con.Open();

            using (var command = db.con.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM Ставки where Владелец ='{textBox1.Text}'";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listBox.Items.Add($"{reader["id"].ToString()} | Предмет: {reader["Предмет"].ToString()} | Стартовая цена: {reader["СтартоваяЦена"].ToString()} | Последняя ставка: {reader["ПоследняяСтавка"].ToString()} | Время проведения: до {reader["ВремяПроведения"].ToString()}");
                    }
                }
            }
            db.con.Close();
        }

        public void You2(ListBox listBox, TextBox textBox1)
        {
            db.con.Open();

            using (var command = db.con.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM ПерсональныеСтавки where Пользователь ='{textBox1.Text}'";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listBox.Items.Add($"{reader["id"].ToString()} | Номер ставки: {reader["idСтавки"].ToString()} | Ваша cтавка: {reader["ВашаСтавка"].ToString()}");
                    }
                }
            }
            db.con.Close();
        }


        public void Admin(ListBox listBox)
        {
            db.con.Open();

            using (var command = db.con.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM Ставки";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listBox.Items.Add($"{reader["id"].ToString()} | Предмет: {reader["Предмет"].ToString()} | Стартовая цена: {reader["СтартоваяЦена"].ToString()} | Последняя ставка: {reader["ПоследняяСтавка"].ToString()} | Время проведения: до {reader["ВремяПроведения"].ToString()}");
                    }
                }
            }
            db.con.Close();
        }

        public void AdminUser(ComboBox comboBox)
        {
            db.con.Open();

            using (var command = db.con.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM Аккаунт";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBox.Items.Add($"{reader["Логин"].ToString()}");
                    }
                }
            }
            db.con.Close();
        }
    }
}
