using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Аукцион.Class
{
    public class ВашаСтавка
    {
        db db = new db();
        public void Bet(TextBox textBox, TextBox textBox1)
        {
            string query = $"update Ставки set ПоследняяСтавка = '{textBox1.Text}' where id = '{textBox.Text}'";

            SqlCommand command = new SqlCommand(query, db.con);

            try
            {
                db.con.Open();
                int rowsAffected = command.ExecuteNonQuery();
                MessageBox.Show("Ставка успешно поставлена, удачных торгов!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
        }

        public void YouBet(TextBox textBox, TextBox textBox1,TextBox textBox2)
        {
            {
                string query = $"insert into ПерсональныеСтавки(idСтавки,ВашаСтавка,Пользователь) values ('{textBox.Text}','{textBox1.Text}','{textBox2.Text}')";
                SqlCommand command = new SqlCommand(query, db.con);

                try
                {
                    db.con.Open();
                    int rowsAffected = command.ExecuteNonQuery();
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
