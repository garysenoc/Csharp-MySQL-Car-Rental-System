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

namespace CarRentalSystem
{
    public partial class Form1 : Form
    {

        public string sID;
        public string sql = "";
        public string usern;
        public string pass;
        public string user1;
        public string pass1;
        public MySqlCommand sql_cmd = new MySqlCommand();
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            clsMySQL.sql_con.Close();
            clsMySQL.sql_con.Open();
            sql = "SELECT *FROM tbuser";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {

                user1 = rd["username"].ToString();
                pass1 = rd["password"].ToString();


            }
            rd.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login(textBox1.Text, textBox2.Text);
        }
        void login(string username, string password)
        {
            sql = "SELECT *FROM tbadmin";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {

                usern = rd["username"].ToString();
                pass = rd["password"].ToString();


            }
            rd.Close();

            if (username == usern && password == pass)
            {
                clsMySQL.userSYS = "Admin";
                MessageBox.Show("You have successfully login", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sql = string.Format("INSERT INTO tblog VALUES (null, '{0}', '{1}','{2}')",
    clsMySQL.userSYS,"Login - Admin", DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
                sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                sql_cmd.ExecuteNonQuery();
                 MAIN main = new MAIN();
                this.Hide();
                main.ShowDialog();
            }
            else if(username==user1 && password ==pass1)
            {
                clsMySQL.userSYS = "User";
                MessageBox.Show("You have successfully login", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sql = string.Format("INSERT INTO tblog VALUES (null, '{0}', '{1}','{2}')",
    clsMySQL.userSYS, "Login - User", DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
                sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                sql_cmd.ExecuteNonQuery();
                MAIN main = new MAIN();
                this.Hide();
                main.ShowDialog();

            }
            else
            {
                MessageBox.Show("Incorrect username or password", "Unable to Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Text = "";
            }
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login(textBox1.Text, textBox2.Text);

            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {
            FORGOT FG = new FORGOT();
            this.Hide();
            FG.ShowDialog();
        }
    }
}
