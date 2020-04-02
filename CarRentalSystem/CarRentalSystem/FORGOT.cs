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
    
    public partial class FORGOT : Form
    {
        public string sID;
        public string sql = "";
        public MySqlCommand sql_cmd = new MySqlCommand();
        public string ans;
        public FORGOT()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        
        }

        private void FORGOT_Load(object sender, EventArgs e)
        {
               clsMySQL.sql_con.Close();
            clsMySQL.sql_con.Open();
            sql = "SELECT *FROM tbadmin";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                label2.Text = rd["secquestion"].ToString();
                ans = rd["secanswer"].ToString();

            }
            rd.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == ans)
            {
                MessageBox.Show("You may now reset your password");
                RESETPASS res = new RESETPASS();
                this.Hide();
                res.ShowDialog();
            }
            else
            {
                MessageBox.Show("Sorry, your answer is incorrect, Try again");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MAIN mn = new MAIN();
            this.Hide();
            mn.ShowDialog();
        }
    }
}
