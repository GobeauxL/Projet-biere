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
    public partial class Form1 : Form
    {
        string sDataBase = "server=localhost;uid=root;pwd=;database=brasserie;";
        public Form1()
        {
            InitializeComponent();
        }

        private void Button4_Click(object sender, EventArgs e)
        {

        }

        private void Recette_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string myConnect = sDataBase;
            MySqlConnection myConnec = new MySqlConnection(myConnect);
            myConnec.Open();
            MySqlCommand Sql = new MySqlCommand("INSERT INTO recette (id, nom, date_creation) VALUES('" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "')", myConnec);
            Sql.Connection = myConnec;
            Sql.ExecuteNonQuery();
            myConnec.Close();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Recette.Items.Clear();
            string myConnection = sDataBase;
            MySqlConnection myConn = new MySqlConnection(myConnection);
            myConn.Open();
            MySqlCommand Sql = new MySqlCommand("SELECT * FROM recette",myConn);
            MySqlDataReader rdr;
            rdr = Sql.ExecuteReader();

            while (rdr.Read())
            {
                Recette.Items.Add(Convert.ToInt32(rdr["id"]) + ", " + Convert.ToString(rdr["nom"]) + ", " + Convert.ToDateTime(rdr["date_creation"]).Year + "/" + Convert.ToDateTime(rdr["date_creation"]).Month + "/" + Convert.ToDateTime(rdr["date_creation"]).Day);
            }
            rdr.Close();
            myConn.Close();
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "  ^ [0-9]"))
            {
                textBox2.Text = "";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            string myConnect = sDataBase;
            MySqlConnection myConnec = new MySqlConnection(myConnect);
            myConnec.Open();
            MySqlCommand Sql = new MySqlCommand("DELETE FROM recette WHERE id = '" + textBox5.Text + "'", myConnec);
            Sql.Connection = myConnec;
            Sql.ExecuteNonQuery();
            myConnec.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Ingredient.Items.Clear();
            string myConnection = sDataBase;
            MySqlConnection myConn = new MySqlConnection(myConnection);
            myConn.Open();
            MySqlCommand Sql = new MySqlCommand("SELECT * FROM ingredient", myConn);
            MySqlDataReader rdr;
            rdr = Sql.ExecuteReader();

            while (rdr.Read())
            {
                Ingredient.Items.Add(Convert.ToInt32(rdr["id"]) + ", " + Convert.ToString(rdr["nom"]) + ", " + Convert.ToString(rdr["fournisseur"]));
            }
            rdr.Close();
            myConn.Close();
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            string myConnect = sDataBase;
            MySqlConnection myConnec = new MySqlConnection(myConnect);
            myConnec.Open();
            MySqlCommand Sql = new MySqlCommand("INSERT INTO ingredient (id, nom, fournisseur) VALUES('" + textBox9.Text + "', '" + textBox10.Text + "', '" + textBox11.Text + "')", myConnec);
            Sql.Connection = myConnec;
            Sql.ExecuteNonQuery();
            myConnec.Close();
        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void Button8_Click(object sender, EventArgs e)
        {
            string myConnect = sDataBase;
            MySqlConnection myConnec = new MySqlConnection(myConnect);
            myConnec.Open();
            MySqlCommand Sql = new MySqlCommand("DELETE FROM ingredient WHERE id = '" + textBox8.Text + "'", myConnec);
            Sql.Connection = myConnec;
            Sql.ExecuteNonQuery();
            myConnec.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            string myConnect = sDataBase;
            MySqlConnection myConnec = new MySqlConnection(myConnect);
            myConnec.Open();
            MySqlCommand Sql = new MySqlCommand("UPDATE recette SET nom = '"+ textBox1.Text + "', date_creation = '"+ textBox6.Text + "' WHERE id = '" + textBox13.Text + "'", myConnec);
            Sql.Connection = myConnec;
            Sql.ExecuteNonQuery();
            myConnec.Close();
        }

        private void TabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Label14_Click(object sender, EventArgs e)
        {

        }

        private void TextBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button4_Click_1(object sender, EventArgs e)
        {
            string myConnect = sDataBase;
            MySqlConnection myConnec = new MySqlConnection(myConnect);
            myConnec.Open();
            MySqlCommand Sql = new MySqlCommand("UPDATE ingredient SET nom = '" + textBox7.Text + "', fournisseur = '" + textBox12.Text + "' WHERE id = '" + textBox14.Text + "'", myConnec);
            Sql.Connection = myConnec;
            Sql.ExecuteNonQuery();
            myConnec.Close();
        }
    }
}