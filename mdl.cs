using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

//this class contains all the model logic of project

namespace tcsDemoWebForms2
{
    public class mdl
    {
        public void homeGridBind(GridView gridView)
        {
            string command = "select a.id as ID, a.first_name as 'FIRST NAME', a.last_name 'LAST NAME' , b.country_name as 'COUNTRY' from person a, country b where  a.coutry_id = b.country_code";
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(command))
                {
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
                    {
                        sqlCommand.Connection = con;
                        sqlDataAdapter.SelectCommand = sqlCommand;
                        using (DataTable dt = new DataTable())
                        {
                            sqlDataAdapter.Fill(dt);
                            gridView.DataSource = dt;
                            gridView.DataBind();
                        }
                    }
                }
            }
        }

        public void ddlBind(DropDownList dropDownList)
        {
            string command = "select country_code,country_name from country";
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(command))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    dropDownList.DataSource = cmd.ExecuteReader();
                    dropDownList.DataTextField = "country_name";
                    dropDownList.DataValueField = "country_code";
                    dropDownList.DataBind();
                    con.Close();
                }
                dropDownList.Items.Insert(0, "Select Country");
            }
        }

        public void details_submit(string fn, string ln, string country, string id, bool isAdd = false)
        {
            string command = "";
            if (!isAdd)
                command = "update person set first_name = @fn, last_name = @ln, coutry_id = @cid where id = @pid";
            else
                command = "insert into person (first_name, last_name,  coutry_id) values (@fn, @ln,  @cid)";
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(command))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("fn", fn);
                    cmd.Parameters.AddWithValue("ln", ln);
                    cmd.Parameters.AddWithValue("cid", country);
                    cmd.Parameters.AddWithValue("pid", id);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        

        public void delete_dtls(string id)
        {
            string command = "delete from person where id = @id";
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(command))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("id", id);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }
}