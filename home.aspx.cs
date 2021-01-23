using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Web.Configuration;

public partial class home : System.Web.UI.Page
{
    SqlCommand cmd;
    SqlConnection con;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id"] == null)
        {
            Response.Redirect("Default.aspx");
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["id"] == null)
            {
                Response.Write("some thing went wrong... please try again");
                return;
            }
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconnect"].ConnectionString);
            con.Open();
            string insert = "  insert into userdata (phonenumber,name,email) values(@phonenumber,@name,@email)";
            SqlCommand cmd = new SqlCommand(insert, con);
            cmd.Parameters.AddWithValue("@name", nametextbox.Text);
            cmd.Parameters.AddWithValue("@email", emailtextbox.Text);
            cmd.Parameters.AddWithValue("@phonenumber", Session["id"].ToString());
            int count  = cmd.ExecuteNonQuery();
            con.Close();
            if (count > 0)
            {
                Response.Write("<script>alert('Done.');</script>");
                Response.Write("Done.");
            }
            else
            {
                Response.Write("some thing went wrong... please try again");
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex);
        }




    }
}