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
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                new mdl().homeGridBind(gridViewHome);
        }
        protected void gridViewHome_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow gridViewRow = gridViewHome.Rows[rowIndex];

            if (e.CommandName.ToString() == "editDtls")
            {
                string url_params = "?";
                for (int i = 0; i < gridViewHome.Columns.Count - 1; i++)
                {
                    url_params += ((i == 0) ? "" : "&") + gridViewHome.Columns[i].HeaderText + "=" + gridViewRow.Cells[i].Text.ToString();
                }

                Response.Redirect("~/dtlsEdit.aspx" + url_params);
            }
            else if (e.CommandName.ToString() == "deleteDtls")
            {
                string id = gridViewHome.Rows[rowIndex].Cells[0].Text;
                new mdl().delete_dtls(id);
                Response.Redirect(Request.Url.ToString(), true);
            }
        }

        protected void btnAddDtls_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/dtlsEdit.aspx");
        }
    }
}