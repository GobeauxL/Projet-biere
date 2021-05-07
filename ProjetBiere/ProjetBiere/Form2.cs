using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProjetBiere
{
    public partial class Form2 : Form
    {
        string sDataBase = "server=localhost;uid=root;pwd=;database=brasserie;";
        public Form2()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string myConnect = sDataBase;
            MySqlConnection myConnec = new MySqlConnection(myConnect);
            myConnec.Open();
            MySqlCommand Sql = myConnec.CreateCommand();
            Sql.CommandType = CommandType.Text;
            Sql.CommandText = "SELECT * FROM user WHERE log = '" + textBox1 + "' AND mdp = '" + textBox2 + "'";
            Sql.ExecuteNonQuery();
            int i = 0;
            if (i == 1)
            {
                Form1 form1 = new Form1();
                form1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Veuillez réessayer");
            }
            myConnec.Close();


            /*i = 0;
            myConnec.Open();
            MySqlCommand Sql = myConnec.CreateCommand();
            Sql.CommandType = CommandType.Text;
            Sql.CommandText = "SELECT * FROM user WHERE log = '" + textBox1 + "' AND mdp = '" + textBox2 + "'";
            Sql.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(Sql);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());
            if (i == 0)
                {
                    MessageBox.Show("Veuillez réessayer");
                }
            else
            {
                this.Hide();
            }
            myConnec.Close();*/


            /*MySqlConnection myConnec = new MySqlConnection(myConnect);
            myConnec.Open();
            MySqlCommand Sql = new MySqlCommand("");
            Sql.Connection = myConnec;
            Sql.ExecuteNonQuery();
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                Form1 form1 = new Form1();
                form1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Veuillez réessayer");
            }
            myConnec.Close();*/
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            textBox2.MaxLength = 100;
        }
    }
}
