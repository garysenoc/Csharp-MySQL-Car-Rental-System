using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CarRentalSystem
{
    class clsMySQL
    {
        public static string server = "127.0.0.1";
        public static string database = "dbrentalcar";
        public static string user = "root";
        public static string pass = "";
        public static string constring = "server = " + server + ";" + "database = " + database + ";" + "uid = " + user + ";" + "password = " + pass + ";";
        public static MySqlConnection sql_con = new MySqlConnection(constring);

        public static string pic = "";



        public static string name = "";
        public static string age = "";
        public static string status = "";
        public static string nationality = "";
        public static string homeaddress = "";
        public static string noDays = "";
        public static string model = "";
        public static string brand = "";
        public static string type = "";
        public static string plate = "";
        public static string price = "";
        public static string returnDate = "";
        public static string overallprice = "";
        public static string customerpic = "";
        public static string contact = "";
        public static string email = "";



        public static string userSYS = "";
    }
}
