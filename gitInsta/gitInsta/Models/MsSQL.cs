using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace gitInsta.Models
{
    public class MsSQL
    {

        SqlConnection conn; // само подключение
        string connectionString; // строка подключения

        SqlCommand cmd; //команднный оператор

        //WebConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        string query; //строка запроса
        string error; //строка ошибки
       

        public MsSQL()
        {
            this.connectionString = WebConfigurationManager.ConnectionStrings["conn"].ConnectionString;
                //.ToString();
        }
        //Data Source=DESKTOP-3ITI3JI\SQLEXPRESS;Initial Catalog=GitInsta;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False

        protected bool Open()
        {
            error = "";
            try {
                conn = new SqlConnection(connectionString);
                conn.Open();
                return true;

            }
            catch(Exception ex) {
                error = ex.Message; 
                query = "Ошибка открытия CONNECT";

            }

            return false;
        }


        protected bool Close()
        {
            try
            {
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                query = " Ошибка закрытия";
                return false;
            }

        }

        public string Scalar(string query)
        {
            this.error = "";
            this.query = query;
            string scalar = "";
            if (!Open()) return "";

            try {
                cmd = new SqlCommand(query, conn);
                scalar = cmd.ExecuteScalar().ToString();

            }
            catch (Exception ex) {
                error = ex.Message;
                scalar = "";

            }
            return scalar;



        }


    }
}