using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tcsDemoWebForms2
{
    public partial class dtlsEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ID=2&FIRST NAME=Monojit&LAST NAME=Debnath&COUNTRY=India
            if (!IsPostBack && Request.QueryString != null && Request.QueryString.Count > 0)
            {
                new mdl().ddlBind(ddlCountry);
                btnSubmit.Text = "Save Details";
                lblID.Text = Request.Params["ID"].ToString();
                txtFName.Text = Request.Params["FIRST NAME"].ToString();
                txtLName.Text = Request.Params["LAST NAME"].ToString();
                ddlCountry.SelectedItem.Text = Request.Params["COUNTRY"].ToString();
            }
            else if (!IsPostBack)
            {
                btnSubmit.Text = "Add Details";
                new mdl().ddlBind(ddlCountry);
            }
        }

        //protected void ddlBind()
        //{
        //    string command = "select country_code,country_name from country";
        //    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand(command))
        //        {
        //            cmd.CommandType = CommandType.Text;
        //            cmd.Connection = con;
        //            con.Open();
        //            ddlCountry.DataSource = cmd.ExecuteReader();
        //            ddlCountry.DataTextField = "country_name";
        //            ddlCountry.DataValueField = "country_code";
        //            ddlCountry.DataBind();
        //            con.Close();
        //        }
        //    }

        //}

        public void btnSubmit_Click(object sender, EventArgs e)
        {
            new mdl().details_submit(txtFName.Text, txtLName.Text, ddlCountry.SelectedValue, lblID.Text, (btnSubmit.Text == "Add Details")? true:false);
            Response.Redirect("~/home.aspx");
        }
    }
}