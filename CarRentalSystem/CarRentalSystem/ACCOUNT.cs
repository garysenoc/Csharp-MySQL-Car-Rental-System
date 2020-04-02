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
    public partial class ACCOUNT : Form
    {
        public string sID;
        public string sql = "";
        public string pass;
        public string usern;

        public string user1;
        public string pass1;
        public MySqlCommand sql_cmd = new MySqlCommand();
        public ACCOUNT()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        void changepass()
        {
            sql = "SELECT *FROM tbadmin";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                pass = rd["password"].ToString();


            }
            rd.Close();
            if (textBox4.Text != pass)
            {
                MessageBox.Show("Incorrect password");
            }
            if (textBox3.Text != textBox5.Text)
            {
                MessageBox.Show("Password do not match, Try Again");
            }

            if (textBox4.Text == pass && textBox3.Text == textBox5.Text)
            {
                sql = "UPDATE tbadmin SET password='" + textBox3.Text + "'";
                sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                sql_cmd.ExecuteNonQuery();
                MessageBox.Show("You have successfully changed your password");
                button4.PerformClick();
            }
        }

        private void ACCOUNT_Load(object sender, EventArgs e)
        {
            clsMySQL.sql_con.Close();
            clsMySQL.sql_con.Open();
            this.ActiveControl = groupBox1;
        }
        void changeUsername()
        {
            sql = "SELECT *FROM tbadmin";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                pass = rd["password"].ToString();


            }
            rd.Close();

            if (textBox2.Text == pass)
            {
                sql = "UPDATE tbadmin SET username='" + textBox1.Text + "'";
                sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                sql_cmd.ExecuteNonQuery();
                textBox1.Text = "Enter New Username:";
                textBox2.Text = "Enter Password:";
                MessageBox.Show(" You have successfully changed your Username", "Change username", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Incorrect password", "Unable to Change username", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void changeQuestion()
        {
            sql = "SELECT *FROM tbadmin";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                pass = rd["password"].ToString();


            }
            rd.Close();

            if (textBox6.Text == pass)
            {
                sql = "UPDATE tbadmin SET secquestion='" + textBox7.Text + "'";
                sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                sql_cmd.ExecuteNonQuery();
                sql = "UPDATE tbadmin SET secanswer='" + textBox8.Text + "'";
                sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                sql_cmd.ExecuteNonQuery();

                button5.PerformClick();
                MessageBox.Show("You have successfully updated your Security Question");
            }
            else
            {
                MessageBox.Show("Invalid Password, Try again");
            }
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            changeUsername();
            sql = string.Format("INSERT INTO tblog VALUES (null, '{0}', '{1}','{2}')",
  clsMySQL.userSYS, "Change Admin Username", DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            sql_cmd.ExecuteNonQuery();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            changepass();
            sql = string.Format("INSERT INTO tblog VALUES (null, '{0}', '{1}','{2}')",
  clsMySQL.userSYS, "Change Admin Password", DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            sql_cmd.ExecuteNonQuery();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            changeQuestion();
            sql = string.Format("INSERT INTO tblog VALUES (null, '{0}', '{1}','{2}')",
  clsMySQL.userSYS, "Change Admin Security Question", DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            sql_cmd.ExecuteNonQuery();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            textBox1.Text = "Enter New Username";
            textBox2.PasswordChar = '\0';
            textBox2.Text = "Enter Password";
        }

        private void button4_Click(object sender, EventArgs e)
        {

            textBox3.PasswordChar = '\0';
            textBox4.PasswordChar = '\0';
            textBox5.PasswordChar = '\0';

            textBox3.Text = "Enter New Password: ";
            textBox4.Text = "Enter Current Password:";
            textBox5.Text = "Confirm New Password:";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox6.PasswordChar = '\0';
            textBox6.Text = "Enter Password";
            textBox8.Text = "Enter Answer:";
            textBox7.Text = "Enter New Question:";
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox2.PasswordChar = '*';
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            textBox4.Text = "";
            textBox4.PasswordChar = '*';
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox3.PasswordChar = '*';
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            textBox5.Text = "";
            textBox5.PasswordChar = '*';
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            textBox6.Text = "";
            textBox6.PasswordChar = '*';
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            textBox7.Text = "";
        }

        private void textBox8_Enter(object sender, EventArgs e)
        {
            textBox8.Text = "";
        }

        private void button10_Click(object sender, EventArgs e)
        {

          ///  textBox16.Text = "Enter New Username";
            ///  textBox15.PasswordChar = '\0';
            /// textBox15.Text = "Enter Password";
        }

        private void button11_Click(object sender, EventArgs e)
        {
         
               
            }

        private void button9_Click(object sender, EventArgs e)
        {
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
             
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox14_Enter(object sender, EventArgs e)
        {
          
        }

        private void textBox13_Enter(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
      
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void textBox12_Enter(object sender, EventArgs e)
        {
           
        }

        private void textBox10_Enter(object sender, EventArgs e)
        {
            
        }

        private void textBox16_Enter(object sender, EventArgs e)
        {
           
        }

        private void textBox15_Enter(object sender, EventArgs e)
        {
            
        }

        private void textBox11_Enter(object sender, EventArgs e)
        {
        }

        private void textBox9_Enter(object sender, EventArgs e)
        {
           
        }
        }
    }

