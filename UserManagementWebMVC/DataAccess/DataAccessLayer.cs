using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using UserManagementWebMVC.Models;

namespace UserManagementWebMVC.DataAccess
{
    public class DataAccessLayer
    {
        public string InsertData(CustomerModel objcust)
        {
            MySqlConnection con = null;
            string result = "";

            try
            {
                con = new MySqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
                MySqlCommand cmd = new MySqlCommand("INSERT INTO user(UserID, UserName, Birthday, Address, Email, Gender) VALUES (@CustomerID, @Name, @Birthdate, @Address, @Email, @Gender)", con);

                cmd.Parameters.AddWithValue("@CustomerID", objcust.UserID);
                cmd.Parameters.AddWithValue("@Name", objcust.UserName);
                cmd.Parameters.AddWithValue("@Birthdate", objcust.Birthday);
                cmd.Parameters.AddWithValue("@Address", objcust.Address);
                cmd.Parameters.AddWithValue("@Email", objcust.Email);
                cmd.Parameters.AddWithValue("@Gender", objcust.Gender);

                //cmd.Parameters.AddWithValue("@Query", 1);

                con.Open();

                //result = cmd.ExecuteScalar().ToString();
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                result = "Insert successful";

            }
            catch
            {
                result = "Insert error";
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return result;
        }

        public string UpdateData(CustomerModel objcust)
        {
            MySqlConnection con = null;
            string result = "";

            try
            {
                con = new MySqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
                MySqlCommand cmd = new MySqlCommand("UPDATE user SET UserName = @Name, Birthday = @Birthdate, Address = @Address, Email= @Email, Gender= @Gender WHERE UserID = @CustomerID ", con);

                cmd.Parameters.AddWithValue("@CustomerID", objcust.UserID);
                cmd.Parameters.AddWithValue("@Name", objcust.UserName);
                cmd.Parameters.AddWithValue("@Birthdate", objcust.Birthday);
                cmd.Parameters.AddWithValue("@Address", objcust.Address);
                cmd.Parameters.AddWithValue("@Email", objcust.Email);
                cmd.Parameters.AddWithValue("@Gender", objcust.Gender);

                //cmd.Parameters.AddWithValue("@Query", 2);

                con.Open();

                result = cmd.ExecuteScalar().ToString();
                cmd.Parameters.Clear();
            }
            catch
            {
                result = "Update error";
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return result;
        }

        public string DeleteData(string UserID)
        {

            MySqlConnection con = null;
            string result = "";

            try
            {
                con = new MySqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
                MySqlCommand cmd = new MySqlCommand("DELETE FROM user WHERE UserID = @CustomerID", con);

                cmd.Parameters.AddWithValue("@CustomerID", UserID);

                //cmd.Parameters.AddWithValue("@Query", 3);

                con.Open();

                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                result = "Delete successful";
            }
            catch
            {
                result = "Delete error";
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return result;
        }

        public List<CustomerModel> Selectalldata()
        {
            MySqlConnection con = null;
            List<CustomerModel> custlist = null;

            try
            {
                con = new MySqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
                MySqlCommand cmd = new MySqlCommand("Select * from user", con);

                con.Open();

                MySqlDataAdapter da = new MySqlDataAdapter
                {
                    SelectCommand = cmd
                };
                DataSet ds = new DataSet();
                da.Fill(ds);

                custlist = new List<CustomerModel>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    CustomerModel cobj = new CustomerModel
                    {
                        UserID = ds.Tables[0].Rows[i]["UserID"].ToString(),
                        UserName = ds.Tables[0].Rows[i]["UserName"].ToString(),
                        Birthday = Convert.ToDateTime(ds.Tables[0].Rows[i]["Birthday"].ToString()),
                        Address = ds.Tables[0].Rows[i]["Address"].ToString(),
                        Email = ds.Tables[0].Rows[i]["Email"].ToString(),
                        Gender = ds.Tables[0].Rows[i]["Gender"].ToString()
                    };

                    custlist.Add(cobj);

                }
                return custlist;
            }
            catch
            {
                return custlist;
            }
            finally
            {
                con.Close();
            }
        }

        public CustomerModel SelectDatabyID(string CustomerID)
        {
            MySqlConnection con = null;
            CustomerModel cobj = null;

            try
            {
                con = new MySqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
                MySqlCommand cmd = new MySqlCommand("Select * from user Where UserID = @CustomerID", con);

                cmd.Parameters.AddWithValue("@CustomerID", CustomerID);

                MySqlDataAdapter da = new MySqlDataAdapter
                {
                    SelectCommand = cmd
                };
                DataSet ds = new DataSet();
                da.Fill(ds);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    cobj = new CustomerModel
                    {
                        UserID = ds.Tables[0].Rows[i]["UserID"].ToString(),
                        UserName = ds.Tables[0].Rows[i]["UserName"].ToString(),
                        Birthday = Convert.ToDateTime(ds.Tables[0].Rows[i]["Birthday"].ToString()),
                        Address = ds.Tables[0].Rows[i]["Address"].ToString(),
                        Email = ds.Tables[0].Rows[i]["Email"].ToString(),
                        Gender = ds.Tables[0].Rows[i]["Gender"].ToString()
                    };

                }
                return cobj;
            }

            catch
            {
                return cobj;
            }
            finally
            {
                con.Close();
            }

        }

        public List<CustomerModel> SearchText(string text)
        {
            MySqlConnection con = null;
            //CustomerModel cobj = null;
            List<CustomerModel> custlist = null;

            try
            {
                string str = "Select * from user Where UserID  Like '%" + text + "%' ";
                con = new MySqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
                MySqlCommand cmd = new MySqlCommand(str, con);

                //cmd.Parameters.AddWithValue("@CustomerID", text);

                MySqlDataAdapter da = new MySqlDataAdapter
                {
                    SelectCommand = cmd
                };
                DataSet ds = new DataSet();
                da.Fill(ds);
                custlist = new List<CustomerModel>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    CustomerModel cobj = new CustomerModel
                    {
                        UserID = ds.Tables[0].Rows[i]["UserID"].ToString(),
                        UserName = ds.Tables[0].Rows[i]["UserName"].ToString(),
                        Birthday = Convert.ToDateTime(ds.Tables[0].Rows[i]["Birthday"].ToString()),
                        Address = ds.Tables[0].Rows[i]["Address"].ToString(),
                        Email = ds.Tables[0].Rows[i]["Email"].ToString(),
                        Gender = ds.Tables[0].Rows[i]["Gender"].ToString()
                    };
                    custlist.Add(cobj);

                }
                return custlist;
            }

            catch
            {
                return custlist;
            }
            finally
            {
                con.Close();
            }

        }

        public string IsLogin(string userName, string pass)
        {
            MySqlConnection con = null;
            string msg = "";
            try
            {
                con = new MySqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
                MySqlCommand cmd = new MySqlCommand("Select * from account Where Account = @Account and Password= @Password", con);

                cmd.Parameters.AddWithValue("@Account", userName);
                cmd.Parameters.AddWithValue("@Password", pass);

                MySqlDataAdapter da = new MySqlDataAdapter
                {
                    SelectCommand = cmd
                };
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    msg = "Login success";
                }
            }
            catch
            {

            }
            finally
            {
                con.Close();
            }
            return msg;
        }
    }
}