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
using Microsoft.Reporting.WinForms;


namespace CarRentalSystem
{
    public partial class MAIN : Form
    {
        public string sID,cost;
        public string sID2;
        public string sql = "";
        public string pic;
        public string pic2;
        public string pic3;
        public string plate;
        public int number1;
        public string plate2;
        public int coco = 1;
        public string dateSQL;
        public string date2;
        public string name;
        public string brand;
        public string model;
        public string day;
        public string amountPaid;
        public string sendNumber;
        public string plateSend;

        public MySqlCommand sql_cmd = new MySqlCommand();
        public MAIN()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            
        }
        System.Windows.Forms.Timer tmr = null;
        private void StartTimer()
        {
            tmr = new System.Windows.Forms.Timer();
            tmr.Interval = 1000;
            tmr.Tick += new EventHandler(tmr_Tick);
            tmr.Enabled = true;
        }
        void tmr_Tick(object sender, EventArgs e)
        {
          label2.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void MAIN_Load(object sender, EventArgs e)
        {

            clsMySQL.sql_con.Close();
            clsMySQL.sql_con.Open();
            showReturnCar();
            StartTimer();
            getMonthAndDate();
            showListofCar();
            showAvailableCar();
                      showTransaction();
            showLog();
            recentCustomers();
            needToReturn();

            noAvailableCar();
            noRentedCar();
            noTransactions();
            totalSales();

            textBox25.Visible = false;
            showCustomersData();
            button3.Enabled = false;
            button4.Enabled = false;
            listView8.Visible = false;
            contractpanel.Visible = false;
            

            contractpanel.Dock = DockStyle.None;


            customerpanel.Visible = false;
            customerpanel.Dock = DockStyle.None;
            CarMaster.Visible = false;
            CarMaster.Dock = DockStyle.None;
            rentCar.Visible = false;
            rentCar.Dock = DockStyle.None;
            returnacaar.Visible = false;
            returnacaar.Dock = DockStyle.None;
            transactionPanel.Visible = false;
            transactionPanel.Dock = DockStyle.None;

         

            if(cost ==null || cost=="")
            {
                button11.Enabled = false;
            }

            
        }

        private void getMonth()
        {
            label3.Text = DateTime.Now.ToString("MMMM");
        }
        private void getDay()
        {
            label4.Text = DateTime.Now.ToString("dd");
        }
        private void getMonthAndDate()
    {

        getMonth();
        getDay();
    }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            totalSales();
            needToReturn();
            recentCustomers();
            noTransactions();
            contractpanel.Visible = false;
            contractpanel.Dock = DockStyle.None;
            label2.Visible = true;
            customerpanel.Visible = false;
            customerpanel.Dock = DockStyle.None;
            CarMaster.Visible = false;
            CarMaster.Dock = DockStyle.None;
            rentCar.Visible = false;
            rentCar.Dock = DockStyle.None;
            returnacaar.Visible = false;
            returnacaar.Dock = DockStyle.None;
            transactionPanel.Visible = false;
            transactionPanel.Dock = DockStyle.None;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            checkDuplicate();
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || txType.Text == "")
            {
                MessageBox.Show("Please fill up all the requirements needed");
            }
            else if(textBox3.Text == plate)
            {
                MessageBox.Show("The plate number was already taken, enter another plate number.");
            }
            else
            {
                AddCar();
                sql = string.Format("INSERT INTO tblog VALUES (null, '{0}', '{1}','{2}')",
  clsMySQL.userSYS, "Add Car", DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
                sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                sql_cmd.ExecuteNonQuery();
                noAvailableCar();
                noRentedCar();
                noTransactions();
                totalSales();
            }
        }

        private void AddCar()
        {
            sql = string.Format("INSERT INTO tbcar VALUES (null, '{0}', '{1}', '{2}','{3}', '{4}','{5}','{6}','{7}','{8}')",
                textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, txType.Text, pic, "Available",textBox6.Text,textBox7.Text);
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            sql_cmd.ExecuteNonQuery();
            clearAll();
            showListofCar();
            MessageBox.Show("New car added succesfully", "Car added", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        void clearAll()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            txType.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            label9.Text = "";
            pictureBox3.Image = null;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                pictureBox3.Image = new Bitmap(open.FileName);
                pic = open.FileName.Replace(@"\", @"\\");
            }
        }

        private void showListofCar()
        {
            sql = "SELECT * FROM tbcar";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            listView2.Items.Clear();
            while (rd.Read())
            {
                listView2.Items.Add(rd["id"].ToString());
                listView2.Items[listView2.Items.Count - 1].SubItems.Add(rd["model"].ToString());
                listView2.Items[listView2.Items.Count - 1].SubItems.Add(rd["brand"].ToString());
                listView2.Items[listView2.Items.Count - 1].SubItems.Add(rd["cartype"].ToString());
                listView2.Items[listView2.Items.Count - 1].SubItems.Add(rd["plate"].ToString());
                listView2.Items[listView2.Items.Count - 1].SubItems.Add(rd["price"].ToString());
                listView2.Items[listView2.Items.Count - 1].SubItems.Add(rd["availability"].ToString());
                listView2.Items[listView2.Items.Count - 1].SubItems.Add(rd["engine"].ToString());
                listView2.Items[listView2.Items.Count - 1].SubItems.Add(rd["chase"].ToString());
            }
            rd.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clearAll();
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            sID = listView2.FocusedItem.Text;
            show_Car(sID);
            if (label9.Text == "Available")
            {
                button3.Enabled = true;
                button4.Enabled = true;

            }
            else
            {
                button3.Enabled = false;
                button4.Enabled = false;
            }
        }
        
        private void show_Car(string srcID)
        {
            sql = "SELECT * FROM tbcar WHERE id = " + srcID;
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                textBox1.Text = rd["model"].ToString();
                textBox2.Text = rd["brand"].ToString();
                txType.Text = rd["cartype"].ToString();
                textBox3.Text = rd["plate"].ToString();
                textBox4.Text = rd["price"].ToString();
                label9.Text = rd["availability"].ToString();
                pictureBox3.ImageLocation = rd["pic"].ToString();
                textBox6.Text = rd["engine"].ToString();
                textBox7.Text = rd["chase"].ToString();
                label9.Text = rd["availability"].ToString();
                pic = rd["pic"].ToString();

            }
            rd.Close();
        }
        private void deleteCar()
        {
            sID = listView2.FocusedItem.Text;
            if (sID == "" || sID == null) { return; }
            else
            {
                sql = "DELETE FROM tbcar WHERE id=" + sID;
                sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                sql_cmd.ExecuteNonQuery();
                button2.PerformClick();
                showListofCar();
                MessageBox.Show("You have successfully deleted a record", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            deleteCar();
            sql = string.Format("INSERT INTO tblog VALUES (null, '{0}', '{1}','{2}')",
  clsMySQL.userSYS, "Delete Car record", DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            sql_cmd.ExecuteNonQuery();
            noAvailableCar();
            noRentedCar();
            noTransactions();
            totalSales();
        }
        private void updateCar(string srcID)
        {
            if (pictureBox3.ImageLocation == pic)
            {
                sql = string.Format("UPDATE tbcar SET model='{0}', brand='{1}', plate='{2}',price='{3}',cartype='{4}',engine='{5}',chase='{6}' WHERE id={7}",
               textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, txType.Text,textBox6.Text, textBox7.Text, srcID);
                sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                sql_cmd.ExecuteNonQuery();
                clearAll();
                showListofCar();
                button2.PerformClick();
                MessageBox.Show("Car record has been update successfully!", "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                sql = string.Format("UPDATE tbcar SET model='{0}', brand='{1}', plate='{2}',price='{3}',cartype='{4}',  pic='{5}',engine='{6}',chase='{7}' WHERE id={8}",
     textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, txType.Text, pic,textBox6.Text, textBox7.Text, srcID);
                sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                sql_cmd.ExecuteNonQuery();
                clearAll();
                showListofCar();
                button2.PerformClick();
                MessageBox.Show("Car record has been update successfully!", "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sID = listView2.FocusedItem.Text;
            updateCar(sID);
            sql = string.Format("INSERT INTO tblog VALUES (null, '{0}', '{1}','{2}')",
  clsMySQL.userSYS, "Update Car Info", DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            sql_cmd.ExecuteNonQuery();
        }

        private void checkDuplicate()
        {
            sql = "SELECT * FROM tbcar  where plate LIKE '" + textBox3.Text + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {


                plate = rd["plate"].ToString();

            }
            rd.Close();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            sql = "SELECT * FROM tbcar WHERE model LIKE '%" + textBox5.Text + "%' OR brand LIKE '%" + textBox5.Text + "%' OR cartype LIKE '%" + textBox5.Text + "%' OR plate LIKE '%" + textBox5.Text + "%' OR price LIKE '%" + textBox5.Text + "%' OR availability LIKE '%" + textBox5.Text + "%'OR engine LIKE '%" + textBox5.Text + "%'OR chase LIKE '%" + textBox5.Text + "%'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            listView2.Items.Clear();
            while (rd.Read())
            {

                listView2.Items.Add(rd["id"].ToString());
                listView2.Items[listView2.Items.Count - 1].SubItems.Add(rd["model"].ToString());
                listView2.Items[listView2.Items.Count - 1].SubItems.Add(rd["brand"].ToString());
                listView2.Items[listView2.Items.Count - 1].SubItems.Add(rd["cartype"].ToString());
                listView2.Items[listView2.Items.Count - 1].SubItems.Add(rd["plate"].ToString());
                listView2.Items[listView2.Items.Count - 1].SubItems.Add(rd["price"].ToString());
                listView2.Items[listView2.Items.Count - 1].SubItems.Add(rd["availability"].ToString());
                listView2.Items[listView2.Items.Count - 1].SubItems.Add(rd["engine"].ToString());
                listView2.Items[listView2.Items.Count - 1].SubItems.Add(rd["chase"].ToString());

            }
            rd.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            customerpanel.Visible = false;
            customerpanel.Dock = DockStyle.None;
            CarMaster.Visible = true;
            CarMaster.Dock = DockStyle.Fill ;
            rentCar.Visible = false;
            rentCar.Dock = DockStyle.None;
            returnacaar.Visible = false;
            returnacaar.Dock = DockStyle.None;
            transactionPanel.Visible = false;
            transactionPanel.Dock = DockStyle.None;
            contractpanel.Visible = false;
            contractpanel.Dock = DockStyle.None;
        }

        private void CarMaster_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            this.Hide();
            login.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        } ///
        ///For renting a car
        ///
        ///

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            sID2 = listView3.FocusedItem.Text;
            showDataAvailableCar(sID2);
            label40.Text = "";
            textBox14.Text = "";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                pictureBox1.Image = new Bitmap(open.FileName);
                pic2 = open.FileName.Replace(@"\", @"\\");
            }
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }
        private void showAvailableCar()
        {
            sql = "SELECT * FROM tbcar where availability = 'Available'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            listView3.Items.Clear();
            while (rd.Read())
            {
                listView3.Items.Add(rd["id"].ToString());
                listView3.Items[listView3.Items.Count - 1].SubItems.Add(rd["model"].ToString());
                listView3.Items[listView3.Items.Count - 1].SubItems.Add(rd["brand"].ToString());
                listView3.Items[listView3.Items.Count - 1].SubItems.Add(rd["cartype"].ToString());
                listView3.Items[listView3.Items.Count - 1].SubItems.Add(rd["plate"].ToString());
                listView3.Items[listView3.Items.Count - 1].SubItems.Add(rd["price"].ToString());
            }
            rd.Close();
        }
        private void showDataAvailableCar(string srcID)
        {
            sql = "SELECT * FROM tbcar WHERE id = " + srcID;
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                label31.Text = rd["model"].ToString();
               label29.Text = rd["brand"].ToString();
                label36.Text = rd["cartype"].ToString();
                label37.Text = rd["plate"].ToString();
                label38.Text = rd["price"].ToString();
                label77.Text = rd["engine"].ToString();
                label78.Text = rd["chase"].ToString();
               }
            rd.Close();
        }
        private void overAllPrice(string days)
        {
            double price;
            double fullamount;
            double num;

        
                price = Convert.ToDouble(label38.Text);
                num = Convert.ToDouble(days);
                fullamount = price * num;

                label40.Text = fullamount.ToString();
            
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            if(!int.TryParse(textBox14.Text,out number1))
            {
                return;
            }
            else
            {
                          overAllPrice(textBox14.Text);
            }
  
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox8.Text == "" || textBox9.Text == "" || comboBox1.Text == "" || textBox13.Text == "" || textBox12.Text == "" || textBox10.Text == "" || textBox11.Text == "")
            {
                MessageBox.Show("Please fill up all the requirements needed");
            }
            else if (sID2 == "" | sID2 == null)
            {
                MessageBox.Show("Select a car");
            }
            else
            {
                contractpanel.Visible = true;
                contractpanel.Dock = DockStyle.Fill;
                customerpanel.Visible = false;
                customerpanel.Dock = DockStyle.None;
                CarMaster.Visible = false;
                CarMaster.Dock = DockStyle.None;
                rentCar.Visible = false;
                rentCar.Dock = DockStyle.None;
                returnacaar.Visible = false;
                returnacaar.Dock = DockStyle.None;
                transactionPanel.Visible = false;
                transactionPanel.Dock = DockStyle.None;

                ReportParameter af = new ReportParameter("day", DateTime.Now.ToString("dd"));
                ReportParameter a = new ReportParameter("month", DateTime.Now.ToString("MMMM"));
                ReportParameter b = new ReportParameter("brand", label29.Text);
                ReportParameter c = new ReportParameter("type", label36.Text);
                ReportParameter d = new ReportParameter("model", label31.Text);
                ReportParameter f = new ReportParameter("en", label77.Text);
                ReportParameter g = new ReportParameter("cn", label78.Text);
                ReportParameter h = new ReportParameter("pn", label37.Text);

                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataRow dr;

                DataColumn dc1 = new DataColumn("name", Type.GetType("System.String"));
                DataColumn dc2 = new DataColumn("age", Type.GetType("System.String"));
                DataColumn dc3 = new DataColumn("marital", Type.GetType("System.String"));
                DataColumn dc4 = new DataColumn("nationality", Type.GetType("System.String"));
                DataColumn dc5 = new DataColumn("home", Type.GetType("System.String"));
                DataColumn dc6 = new DataColumn("email", Type.GetType("System.String"));
                DataColumn dc7 = new DataColumn("contact", Type.GetType("System.String"));
                DataColumn dc8 = new DataColumn("brand", Type.GetType("System.String"));
                DataColumn dc9 = new DataColumn("model", Type.GetType("System.String"));
                DataColumn dc10 = new DataColumn("plate", Type.GetType("System.String"));



                dt.Columns.Add(dc1);
                dt.Columns.Add(dc2);
                dt.Columns.Add(dc3);
                dt.Columns.Add(dc4);
                dt.Columns.Add(dc5);
                dt.Columns.Add(dc6);
                dt.Columns.Add(dc7);
                dt.Columns.Add(dc8);
                dt.Columns.Add(dc9);
                dt.Columns.Add(dc10);


                string sql = "SELECT * FROM tbcustomer where id = " + cost;
                sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                MySqlDataReader rd = sql_cmd.ExecuteReader();
                while (rd.Read())
                {
                    dr = dt.NewRow();
                    dr[0] = rd["name"].ToString();
                    dr[1] = rd["age"].ToString();
                    dr[2] = rd["marital"].ToString();
                    dr[3] = rd["nationality"].ToString();
                    dr[4] = rd["home"].ToString();
                    dr[5] = rd["email"].ToString();
                    dr[6] = rd["contact"].ToString();
                    dr[7] = rd["brand"].ToString();
                    dr[8] = rd["model"].ToString();
                    dr[9] = rd["plate"].ToString();
                    dt.Rows.Add(dr);

                }
                rd.Close();
                ds.Tables.Add(dt);


                this.rprtcontract.RefreshReport();
                this.rprtcontract.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
                this.rprtcontract.LocalReport.ReportPath = Environment.CurrentDirectory + "\\contract.rdlc";
                this.rprtcontract.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal);

                ReportDataSource rds = new ReportDataSource("ds1", ds.Tables[0]);
                //ReportDataSource r = new ReportDataSource("ds2", ds.Tables[2]);

                this.rprtcontract.LocalReport.DataSources.Clear();

                this.rprtcontract.LocalReport.SetParameters(af);
                this.rprtcontract.LocalReport.SetParameters(a);
                this.rprtcontract.LocalReport.SetParameters(b);
                this.rprtcontract.LocalReport.SetParameters(c);
                this.rprtcontract.LocalReport.SetParameters(d);
                this.rprtcontract.LocalReport.SetParameters(f);
                this.rprtcontract.LocalReport.SetParameters(g);
                this.rprtcontract.LocalReport.SetParameters(h);

                this.rprtcontract.LocalReport.DataSources.Add(rds);
                //this.rprtcontract.LocalReport.DataSources.Add(r);

                this.rprtcontract.LocalReport.Refresh();
                this.rprtcontract.DocumentMapCollapsed = true;
                this.rprtcontract.RefreshReport();
            }
            
        }
        private void rentACar()
        {

            string returnDate = DateTime.Now.AddDays(Convert.ToInt32(textBox14.Text)).ToString("yyyy-MM-dd HH-mm-ss");



            sql = string.Format("INSERT INTO tbcustomer VALUES (null, '{0}', '{1}', '{2}','{3}', '{4}','{5}','{6}','{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}','{17}')",
            textBox8.Text, textBox9.Text, comboBox1.Text, textBox13.Text, textBox12.Text, textBox10.Text, textBox11.Text, pic2, label31.Text, label29.Text, label36.Text, label37.Text, label38.Text, label40.Text, textBox14.Text, returnDate,"Not return","now()");
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
          
            sql_cmd.ExecuteNonQuery();
            showReturnCar();
            saveTransactionForRent();
         
            MessageBox.Show("Rented succesfully", "Rent Car", MessageBoxButtons.OK, MessageBoxIcon.Information);
            updateCarAvailabilty();
        }


        private void updateCarAvailabilty()
        {
            sql = "UPDATE tbcar SET availability = 'Unavailable' where plate='" + label37.Text + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            sql_cmd.ExecuteNonQuery();
            showAvailableCar();
            clearRent();
        }

        private void clearRent()
        {
            textBox8.Text = ""; textBox9.Text = ""; comboBox1.Text = ""; textBox13.Text = ""; textBox12.Text = ""; textBox10.Text = ""; textBox11.Text = ""; pic2 = ""; pictureBox1.Image = null; label31.Text = ""; label29.Text = ""; label36.Text = ""; label37.Text = ""; label38.Text = ""; label40.Text = ""; textBox14.Text = "";
        }
        private void label29_Click(object sender, EventArgs e)
        {

        }/////
        /////
        /////Return car
        /////
        /////

        private void showReturnCar()
        {
            sql = "SELECT * FROM tbcustomer where returnstatus = 'Not return'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            listView4.Items.Clear();
            while (rd.Read())
            {
                listView4.Items.Add(rd["id"].ToString());
                listView4.Items[listView4.Items.Count - 1].SubItems.Add(rd["name"].ToString());
                listView4.Items[listView4.Items.Count - 1].SubItems.Add(rd["nationality"].ToString());
                listView4.Items[listView4.Items.Count - 1].SubItems.Add(rd["contact"].ToString());
                listView4.Items[listView4.Items.Count - 1].SubItems.Add(rd["model"].ToString());
                listView4.Items[listView4.Items.Count - 1].SubItems.Add(rd["brand"].ToString());
                listView4.Items[listView4.Items.Count - 1].SubItems.Add(rd["type"].ToString());
                listView4.Items[listView4.Items.Count - 1].SubItems.Add(rd["plate"].ToString());

                listView4.Items[listView4.Items.Count - 1].SubItems.Add(rd["daytorent"].ToString());
                listView4.Items[listView4.Items.Count - 1].SubItems.Add(rd["returndate"].ToString());
            }
            rd.Close();
        }

        private void returnCar()
        {
            sql = "UPDATE tbcustomer SET returnstatus = 'Return' where id='" + listView4.FocusedItem.Text + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            sql_cmd.ExecuteNonQuery();
            updateCarReturn();
            showReturnCar();
            MessageBox.Show("The car was successfully return");
        }
        private void updateCarReturn()
        {
            sql = "UPDATE tbcar SET availability = 'Available' where plate='" + plate2 + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            sql_cmd.ExecuteNonQuery();
          
        }

        private void listView4_SelectedIndexChanged(object sender, EventArgs e)
        {
            sql = "SELECT * FROM tbcustomer WHERE id = '" + listView4.FocusedItem.Text + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {

                plate2 = rd["plate"].ToString();

                clsMySQL.name = rd["name"].ToString();
                clsMySQL.age = rd["age"].ToString();
                clsMySQL.status = rd["marital"].ToString();
                clsMySQL.nationality = rd["nationality"].ToString();
                clsMySQL.homeaddress = rd["home"].ToString();
                clsMySQL.noDays = rd["daytorent"].ToString();
                clsMySQL.model = rd["model"].ToString();
                clsMySQL.brand = rd["brand"].ToString();
                clsMySQL.type = rd["type"].ToString();
                clsMySQL.plate = rd["plate"].ToString();
                clsMySQL.price = rd["price"].ToString();
                clsMySQL.returnDate = rd["returndate"].ToString();
                clsMySQL.overallprice = rd["overallprice"].ToString();
                clsMySQL.customerpic = rd["pic"].ToString();
                clsMySQL.email = rd["email"].ToString();
                clsMySQL.contact = rd["contact"].ToString();








            }
            rd.Close();
        }

        private void returnCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            returnCar();
            sql = string.Format("INSERT INTO tblog VALUES (null, '{0}', '{1}','{2}')",
  clsMySQL.userSYS, "Return Car", DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            sql_cmd.ExecuteNonQuery();
            updateCarReturn();
            saveTransactionForReturn();
            noAvailableCar();
            noRentedCar();
            noTransactions();
            totalSales();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            contractpanel.Visible = false;
            contractpanel.Dock = DockStyle.None;
            customerpanel.Visible = false;
            customerpanel.Dock = DockStyle.None;
            CarMaster.Visible = false;
            CarMaster.Dock = DockStyle.None;
            rentCar.Visible = true;
            rentCar.Dock = DockStyle.Fill;
            returnacaar.Visible = false;
            returnacaar.Dock = DockStyle.None;
            transactionPanel.Visible = false;
            transactionPanel.Dock = DockStyle.None;
            showAvailableCar();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            showReturnCar();
            label2.Visible = false;
            contractpanel.Visible = false;
            contractpanel.Dock = DockStyle.None;
            customerpanel.Visible = false;
            customerpanel.Dock = DockStyle.None;
            CarMaster.Visible = false;
            CarMaster.Dock = DockStyle.None;
            rentCar.Visible = false;
            rentCar.Dock = DockStyle.None;
            returnacaar.Visible = true;
            returnacaar.Dock = DockStyle.Fill;
            transactionPanel.Visible = false;
            transactionPanel.Dock = DockStyle.None;
          
        }

        private void viewPhotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sql = "SELECT * FROM tbcar WHERE id = '" + listView3.FocusedItem.Text + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {

                clsMySQL.pic = rd["pic"].ToString();

            }
            rd.Close();

            VIEWPIC vw = new VIEWPIC();
            vw.ShowDialog();
        }

        private void viewFullDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VIEWFULLDETAILS vv = new VIEWFULLDETAILS();
            vv.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
          

            if( textBox8.Text==""|| textBox9.Text==""|| comboBox1.Text==""|| textBox13.Text==""|| textBox12.Text==""|| textBox10.Text==""|| textBox11.Text=="")
            {
                MessageBox.Show("Please fill up all the requirements needed");
            }
            else if (sID2 == "" | sID2 == null)
            {
                MessageBox.Show("Select a car");
            }
            else
            {

                string MessageBoxTitle = "Rent Car";
                string MessageBoxContent = "By clicking yes, You've agreed to all terms and conditions applied in the contract";

                DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    rentACar();
                    
                    sql = string.Format("INSERT INTO tblog VALUES (null, '{0}', '{1}','{2}')",
  clsMySQL.userSYS, "Rent Car", DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
                    sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                    sql_cmd.ExecuteNonQuery();
                    
                    noAvailableCar();
                    noRentedCar();
                    noTransactions();
                    totalSales();
                    button11.Enabled = false;
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }

        }

        private void panel10_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void showCustomersData()
        {
            sql = "SELECT * FROM tbcustomer";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            listView5.Items.Clear();
            while (rd.Read())
            {
                listView5.Items.Add(rd["id"].ToString());
                listView5.Items[listView5.Items.Count - 1].SubItems.Add(rd["name"].ToString());
                listView5.Items[listView5.Items.Count - 1].SubItems.Add(rd["nationality"].ToString());
                listView5.Items[listView5.Items.Count - 1].SubItems.Add(rd["contact"].ToString());
                listView5.Items[listView5.Items.Count - 1].SubItems.Add(rd["model"].ToString() + " " + rd["brand"].ToString());
                listView5.Items[listView5.Items.Count - 1].SubItems.Add(rd["type"].ToString());
                listView5.Items[listView5.Items.Count - 1].SubItems.Add(rd["plate"].ToString());
                listView5.Items[listView5.Items.Count - 1].SubItems.Add(rd["returnstatus"].ToString());
                listView5.Items[listView5.Items.Count - 1].SubItems.Add(rd["rentday"].ToString());
            }
            rd.Close();
        }

        private void showCustomer(string srcID)
        {
            sql = "SELECT * FROM tbcustomer WHERE id = '" + srcID+ "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {

                textBox21.Text = rd["name"].ToString();
                textBox20.Text = rd["age"].ToString();
                comboBox2.Text = rd["marital"].ToString();
                textBox16.Text = rd["nationality"].ToString();
                textBox17.Text = rd["home"].ToString();

                textBox19.Text = rd["contact"].ToString();
                textBox18.Text = rd["email"].ToString();



                
                label60.Text = rd["model"].ToString();



                label56.Text = rd["brand"].ToString();
                label55.Text = rd["type"].ToString();
                label54.Text = rd["plate"].ToString();
                label53.Text = rd["price"].ToString();
                label63.Text = rd["overallprice"].ToString();
                label51.Text = rd["returndate"].ToString();
                pictureBox2.ImageLocation = rd["pic"].ToString();
                label66.Text = rd["daytorent"].ToString();
                label67.Text = rd["returnstatus"].ToString();
               pic3 = rd["pic"].ToString();






               textBox8.Text = rd["name"].ToString();
               textBox9.Text = rd["age"].ToString();
               comboBox1.Text = rd["marital"].ToString();
               textBox13.Text = rd["nationality"].ToString();
               textBox12.Text = rd["home"].ToString();

               textBox10.Text = rd["contact"].ToString();
               textBox11.Text = rd["email"].ToString();



               pictureBox1.ImageLocation = rd["pic"].ToString();
               label31.Text = rd["model"].ToString();



               label29.Text = rd["brand"].ToString();
               label36.Text = rd["type"].ToString();
               label37.Text = rd["plate"].ToString();
               label38.Text = rd["price"].ToString();
               label40.Text = rd["overallprice"].ToString();

              










            }
            rd.Close();
        }

        private void listView5_SelectedIndexChanged(object sender, EventArgs e)
        {
            showCustomer(listView5.FocusedItem.Text);
            cost = listView5.FocusedItem.Text;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
    
            if (listView5.FocusedItem.Text == "" || listView5.FocusedItem.Text == null) { return; }
            else
            {
                sql = "DELETE FROM tbcustomer WHERE id='" + listView5.FocusedItem.Text+"'";
                sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                sql_cmd.ExecuteNonQuery();
                showCustomersData();
                sql = string.Format("INSERT INTO tblog VALUES (null, '{0}', '{1}','{2}')",
  clsMySQL.userSYS, "Delete record", DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
                sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                sql_cmd.ExecuteNonQuery();
                clearBox();
                MessageBox.Show("You have successfully deleted a record", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
        }

        private void clearBox()
        {

            textBox21.Text = "";
            textBox20.Text = "";
            comboBox2.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";

            textBox19.Text = "";
            textBox18.Text = "";



            textBox14.Text = "";
            label60.Text = "";



            label56.Text = "";
            label55.Text = "";
            label54.Text = "";
            label53.Text = "";
            label63.Text = "";
            label51.Text = "";
            pictureBox2.Image = null;
            label66.Text = "";
            label67.Text = "";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            clearBox();
        }

        private void deleteAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sql = "DELETE FROM tbcustomer";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            sql_cmd.ExecuteNonQuery();
            showCustomersData();
            clearBox();
            sql = string.Format("INSERT INTO tblog VALUES (null, '{0}', '{1}','{2}')",
  clsMySQL.userSYS, "Delete All Record", DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            sql_cmd.ExecuteNonQuery();
            MessageBox.Show("You have successfully deleted all customer record", "Delete All Record", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button15_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                pictureBox2.Image = new Bitmap(open.FileName);
                pic3 = open.FileName.Replace(@"\", @"\\");
            }
        }

        private void updateCustomerProfile()
        {
            if (pictureBox2.ImageLocation == pic3)
            {
                sql = string.Format("UPDATE tbcustomer SET name='{0}', age='{1}', marital='{2}',nationality='{3}',home='{4}',contact='{5}',email='{6}' WHERE id={7}",
               textBox21.Text, textBox20.Text, comboBox2.Text, textBox16.Text, textBox17.Text, textBox19.Text, textBox18.Text, listView5.FocusedItem.Text);
                sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                sql_cmd.ExecuteNonQuery();
                showCustomersData();
                clearBox();
                MessageBox.Show("Customer record has been update successfully!", "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                sql = string.Format("UPDATE tbcustomer SET name='{0}', age='{1}', marital='{2}',nationality='{3}',home='{4}',contact='{5}',email='{6}',pic='{7}' WHERE id={8}",
             textBox21.Text, textBox20.Text, comboBox2.Text, textBox16.Text, textBox17.Text, textBox19.Text, textBox18.Text,pic3, listView5.FocusedItem.Text);
                sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                sql_cmd.ExecuteNonQuery();
                showCustomersData();
                clearBox();
                MessageBox.Show("Customer record has been update successfully!", "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            updateCustomerProfile();
            sql = string.Format("INSERT INTO tblog VALUES (null, '{0}', '{1}','{2}')",
  clsMySQL.userSYS, "Update Customer Profile", DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            sql_cmd.ExecuteNonQuery();
        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {
            sql = "SELECT * FROM tbcustomer WHERE id LIKE '%" + textBox22.Text + "%' OR name LIKE '%" + textBox22.Text + "%' OR nationality LIKE '%" + textBox22.Text + "%' OR contact LIKE '%" + textBox22.Text + "%' OR model LIKE '%" + textBox22.Text + "%' OR type LIKE '%" + textBox22.Text + "%'OR plate LIKE '%" + textBox22.Text + "%'OR returnstatus LIKE '%" + textBox22.Text + "%'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            listView5.Items.Clear();
            while (rd.Read())
            {
                listView5.Items.Add(rd["id"].ToString());
                listView5.Items[listView5.Items.Count - 1].SubItems.Add(rd["name"].ToString());
                listView5.Items[listView5.Items.Count - 1].SubItems.Add(rd["nationality"].ToString());
                listView5.Items[listView5.Items.Count - 1].SubItems.Add(rd["contact"].ToString());
                listView5.Items[listView5.Items.Count - 1].SubItems.Add(rd["model"].ToString() + " " + rd["brand"].ToString());
                listView5.Items[listView5.Items.Count - 1].SubItems.Add(rd["type"].ToString());
                listView5.Items[listView5.Items.Count - 1].SubItems.Add(rd["plate"].ToString());
                listView5.Items[listView5.Items.Count - 1].SubItems.Add(rd["returnstatus"].ToString());

            }
            rd.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void button18_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            
            CarMaster.Visible = false;
            CarMaster.Dock = DockStyle.None;
            rentCar.Visible = false;
            rentCar.Dock = DockStyle.None;
            returnacaar.Visible = false;
            returnacaar.Dock = DockStyle.None;
            transactionPanel.Visible = false;
            transactionPanel.Dock = DockStyle.None;
            customerpanel.Visible = true;
            customerpanel.Dock = DockStyle.Fill;
            contractpanel.Visible = false;
            contractpanel.Dock = DockStyle.None;
            showCustomersData();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            ACCOUNT ACT = new ACCOUNT();
            ACT.ShowDialog();   
        }

        private void panel10_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void showTransaction()
        {
            sql = "SELECT * FROM tbtransaction";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            listView7.Items.Clear();
            while (rd.Read())
            {
                listView7.Items.Add(rd["id"].ToString());
                listView7.Items[listView7.Items.Count - 1].SubItems.Add(rd["name"].ToString());
                listView7.Items[listView7.Items.Count - 1].SubItems.Add(rd["activity"].ToString());
                listView7.Items[listView7.Items.Count - 1].SubItems.Add(rd["brand"].ToString());
                listView7.Items[listView7.Items.Count - 1].SubItems.Add(rd["model"].ToString());
                listView7.Items[listView7.Items.Count - 1].SubItems.Add(rd["daytorent"].ToString());
                listView7.Items[listView7.Items.Count - 1].SubItems.Add(rd["pay"].ToString());
                listView7.Items[listView7.Items.Count - 1].SubItems.Add(rd["date"].ToString());

            }
            rd.Close();
        }

        private void saveTransactionForRent()
        {
            sql = string.Format("INSERT INTO tbtransaction VALUES (null, '{0}', '{1}', '{2}','{3}', '{4}','{5}','{6}')",
       textBox8.Text,"Rent Car",label29.Text,label31.Text,textBox14.Text,label40.Text, DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            sql_cmd.ExecuteNonQuery();
        }
        private void saveTransactionForReturn()
        {
              sql = string.Format("INSERT INTO tbtransaction VALUES (null, '{0}', '{1}', '{2}','{3}', '{4}','{5}','{6}')",
      clsMySQL.name,"Return Car",clsMySQL.brand,clsMySQL.model,clsMySQL.noDays,clsMySQL.overallprice, DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            sql_cmd.ExecuteNonQuery();
        }

        private void deleteTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView7.FocusedItem.Text == "" || listView7.FocusedItem.Text == null) { return; }
            else
            {
                sql = "DELETE FROM tbtransaction WHERE id='" + listView7.FocusedItem.Text + "'";
                sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                sql_cmd.ExecuteNonQuery();
                showTransaction();
                MessageBox.Show("You have successfully deleted a record", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sql = string.Format("INSERT INTO tblog VALUES (null, '{0}', '{1}','{2}')",
  clsMySQL.userSYS, "Delete Transaction", DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
                showLog();
                sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                sql_cmd.ExecuteNonQuery();
                noAvailableCar();
                noRentedCar();
                noTransactions();
                totalSales();

            }
        }

        private void deleteAllTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView7.FocusedItem.Text == "" || listView7.FocusedItem.Text == null) { return; }
            else
            {
                sql = "DELETE FROM tbtransaction";
                sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                sql_cmd.ExecuteNonQuery();
                showTransaction();
                MessageBox.Show("You have successfully deleted all record", "Delete All Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sql = string.Format("INSERT INTO tblog VALUES (null, '{0}', '{1}','{2}')",
  clsMySQL.userSYS, "Delete All Transaction", DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
                sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                sql_cmd.ExecuteNonQuery();
                noAvailableCar();
                noRentedCar();
                noTransactions();
                totalSales();

            }
        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void button20_Click(object sender, EventArgs e)
        {
          
        }

        private void button21_Click(object sender, EventArgs e)
        {
          
        }

        private void showLog()
        {
            sql = "SELECT * FROM tblog";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            listView8.Items.Clear();
            while (rd.Read())
            {
                listView8.Items.Add(rd["id"].ToString());
                listView8.Items[listView8.Items.Count - 1].SubItems.Add(rd["user"].ToString());
                listView8.Items[listView8.Items.Count - 1].SubItems.Add(rd["activity"].ToString());
                listView8.Items[listView8.Items.Count - 1].SubItems.Add(rd["date"].ToString());
                }
            rd.Close();
        }

        private void deleteLogToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (listView8.FocusedItem.Text == "" || listView8.FocusedItem.Text == null) { return; }
            else
            {
                sql = "DELETE FROM tblog WHERE id='" + listView8.FocusedItem.Text + "'";
                sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                sql_cmd.ExecuteNonQuery();
                sql = string.Format("INSERT INTO tblog VALUES (null, '{0}', '{1}','{2}')",
  clsMySQL.userSYS, "Delete log", DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
                sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                sql_cmd.ExecuteNonQuery();
                showLog();
                MessageBox.Show("You have successfully deleted a log", "Delete log", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
        }

        private void deleteAllLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView8.FocusedItem.Text == "" || listView8.FocusedItem.Text == null) { return; }
            else
            {
                sql = "DELETE FROM tblog";
                sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                sql_cmd.ExecuteNonQuery();
                showLog();
                sql = string.Format("INSERT INTO tblog VALUES (null, '{0}', '{1}','{2}')",
  clsMySQL.userSYS, "Delete all logs", DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
                sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                sql_cmd.ExecuteNonQuery();
                MessageBox.Show("You have successfully deleted all log", "Delete All logs", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "Transaction")
            {
                sql = "SELECT * FROM tbtransaction where id LIKE '%" + textBox24.Text + "%' or name like '%" + textBox24.Text + "%' or activity like '%" + textBox24.Text + "%'or brand like '%" + textBox24.Text + "%'or model like '%" + textBox24.Text + "%'or daytorent like '%" + textBox24.Text + "%'or pay like '%" + textBox24.Text + "%' or date like '%" + textBox24.Text + "%'";
                sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                MySqlDataReader rd = sql_cmd.ExecuteReader();
                listView7.Items.Clear();
                while (rd.Read())
                {
                    listView7.Items.Add(rd["id"].ToString());
                    listView7.Items[listView7.Items.Count - 1].SubItems.Add(rd["name"].ToString());
                    listView7.Items[listView7.Items.Count - 1].SubItems.Add(rd["activity"].ToString());
                    listView7.Items[listView7.Items.Count - 1].SubItems.Add(rd["brand"].ToString());
                    listView7.Items[listView7.Items.Count - 1].SubItems.Add(rd["model"].ToString());
                    listView7.Items[listView7.Items.Count - 1].SubItems.Add(rd["daytorent"].ToString());
                    listView7.Items[listView7.Items.Count - 1].SubItems.Add(rd["pay"].ToString());
                    listView7.Items[listView7.Items.Count - 1].SubItems.Add(rd["date"].ToString());


                }
                rd.Close();
            }
            if (comboBox3.Text == "Log")
            {


                sql = "SELECT * FROM tblog where id LIKE '%" + textBox24.Text + "%' or user like '%" + textBox24.Text + "%' or activity like '%" + textBox24.Text + "%'or date like '%" + textBox24.Text + "%'";
                sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                MySqlDataReader rd = sql_cmd.ExecuteReader();
                listView8.Items.Clear();
                while (rd.Read())
                {
                    listView8.Items.Add(rd["id"].ToString());
                    listView8.Items[listView8.Items.Count - 1].SubItems.Add(rd["user"].ToString());
                    listView8.Items[listView8.Items.Count - 1].SubItems.Add(rd["activity"].ToString());
                    listView8.Items[listView8.Items.Count - 1].SubItems.Add(rd["date"].ToString());


                }
                rd.Close();
            }
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox3.Text == "Transaction")
            {
                showTransaction();
                listView8.Visible = false;
               
                textBox25.Visible = false;
            }
            if(comboBox3.Text == "Log")
            {

                listView8.Visible = true;
               
                textBox25.Visible = true;
            }
        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {

            sql = "SELECT * FROM tblog where id LIKE '%" + textBox25.Text + "%' or user like '%" + textBox25.Text + "%' or activity like '%" + textBox25.Text + "%'or date like '%" + textBox25.Text + "%'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            listView8.Items.Clear();
            while (rd.Read())
            {
                listView8.Items.Add(rd["id"].ToString());
                listView8.Items[listView8.Items.Count - 1].SubItems.Add(rd["user"].ToString());
                listView8.Items[listView8.Items.Count - 1].SubItems.Add(rd["activity"].ToString());
                listView8.Items[listView8.Items.Count - 1].SubItems.Add(rd["date"].ToString());


            }
            rd.Close();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            showLog();
            showTransaction();
            label2.Visible = false;
            customerpanel.Visible = false;
            customerpanel.Dock = DockStyle.None;
            CarMaster.Visible = false;
            CarMaster.Dock = DockStyle.None;
            rentCar.Visible = false;
            rentCar.Dock = DockStyle.None;
            returnacaar.Visible = false;
            returnacaar.Dock = DockStyle.None;
            transactionPanel.Visible = true;
            transactionPanel.Dock = DockStyle.Fill;
            contractpanel.Visible = false;
            contractpanel.Dock = DockStyle.None;
        }

           private void recentCustomers()
        {
            sql = "SELECT * FROM tbcustomer order by id DESC limit 10;";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            listView1.Items.Clear();
            while (rd.Read())
            {
                listView1.Items.Add(rd["id"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["name"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["brand"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["model"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["plate"].ToString());
            }
            rd.Close();
        }

           private void button20_Click_1(object sender, EventArgs e)
           {
               label2.Visible = false;
               customerpanel.Visible = false;
               customerpanel.Dock = DockStyle.None;
               CarMaster.Visible = false;
               CarMaster.Dock = DockStyle.None;
               rentCar.Visible = false;
               rentCar.Dock = DockStyle.None;
               returnacaar.Visible = false;
               returnacaar.Dock = DockStyle.None;
               transactionPanel.Visible = true;
               transactionPanel.Dock = DockStyle.Fill;
           }
           private void needToReturn()

           {
               sql = "SELECT * FROM tbcustomer where returnstatus = 'Not return' order by returndate ASC ";
               sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
               MySqlDataReader rd = sql_cmd.ExecuteReader();
               listView6.Items.Clear();
               while (rd.Read())
               {
                   listView6.Items.Add(rd["id"].ToString());
                   listView6.Items[listView6.Items.Count - 1].SubItems.Add(rd["name"].ToString());
                   listView6.Items[listView6.Items.Count - 1].SubItems.Add(rd["brand"].ToString() + " " + rd["model"].ToString());
                   listView6.Items[listView6.Items.Count - 1].SubItems.Add(rd["plate"].ToString());
                   listView6.Items[listView6.Items.Count - 1].SubItems.Add(rd["returndate"].ToString());
               }
               rd.Close();
           }

           private void sendSMSNotificationToolStripMenuItem_Click(object sender, EventArgs e)
           {
               object functionReturnValue = null;
               using (System.Net.WebClient client = new System.Net.WebClient())
               {
                   System.Collections.Specialized.NameValueCollection parameter = new System.Collections.Specialized.NameValueCollection();
                   string url = "https://www.itexmo.com/php_api/api.php";
                   parameter.Add("1", label71.Text);
                   parameter.Add("2", "The car you rented is near from deadline. A reminder from TADCRS");
                   parameter.Add("3", "TR-KAYCE634848_RG476");
                   dynamic rpb = client.UploadValues(url, "POST", parameter);
                   functionReturnValue = (new System.Text.UTF8Encoding()).GetString(rpb);
               }
               sql = string.Format("INSERT INTO tblog VALUES (null, '{0}', '{1}','{2}')",
  clsMySQL.userSYS, "Send SMS Notification", DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
               sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
               sql_cmd.ExecuteNonQuery();
           
           }

           private void listView6_SelectedIndexChanged(object sender, EventArgs e)
           {
               string sfd = listView6.FocusedItem.Text;

               sql = "SELECT * FROM tbcustomer WHERE id = '" + sfd + "'";
               sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
               MySqlDataReader rd = sql_cmd.ExecuteReader();
               while (rd.Read())
               {
                   sendNumber = rd["contact"].ToString();
                   plateSend = rd["plate"].ToString();
               }
               rd.Close();

               label71.Text = sendNumber;
           }


        private void noAvailableCar()
           {
               sql = "SELECT count(id)as haha FROM tbcar WHERE availability = '" + "Available" + "'";
               sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
               MySqlDataReader rd = sql_cmd.ExecuteReader();
               while (rd.Read())
               {
                 label72.Text = rd["haha"].ToString();
                  
               }
               rd.Close();

             
           }
        private void noRentedCar()
        {
            sql = "SELECT count(id)as haha FROM tbcar WHERE availability = '" + "Unavailable" + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                label73.Text = rd["haha"].ToString();

            }
            rd.Close();


        }

        private void noTransactions()
        {
            sql = "SELECT count(id)as haha FROM tbcustomer";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                label74.Text = rd["haha"].ToString();

            }
            rd.Close();
        }
        private void totalSales()
        {
            sql = "SELECT sum(overallprice)as haha FROM tbcustomer";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                label27.Text = rd["haha"].ToString();

            }
            rd.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            clearRent();
            button11.Enabled = false;
        }

        private void rentAgainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            customerpanel.Visible = false;
            customerpanel.Dock = DockStyle.None;
            CarMaster.Visible = false;
            CarMaster.Dock = DockStyle.None;
            rentCar.Visible = true;
            rentCar.Dock = DockStyle.Fill;
            returnacaar.Visible = false;
            returnacaar.Dock = DockStyle.None;
            transactionPanel.Visible = false;
            transactionPanel.Dock = DockStyle.None;
            button11.Enabled = true;
            showAvailableCar();
        }

        private void contractpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button21_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("This is not available right now, Please try again later , Thank you");
        }

    }
}
