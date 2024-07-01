using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Аукцион.Class
{
    public class Ставки
    {
        db db = new db();
        public void Stav(TextBox textBox, TextBox textBox1, DateTimePicker picker, TextBox label)
        {
            {
                string query = $"insert into Ставки(Предмет,СтартоваяЦена,ПоследняяСтавка,ВремяПроведения,Владелец) values ('{textBox.Text}','{textBox1.Text}','{textBox1.Text}','{picker.Text}','{label.Text}')";
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
    }
}
