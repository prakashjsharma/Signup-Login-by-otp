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


public partial class _Default : System.Web.UI.Page
{
    SqlCommand cmd;
    SqlConnection con;
    SqlDataAdapter da;
    SqlDataReader dr;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void contactButton_Click(object sender, EventArgs e)
    {

        contactPanel.Visible = false;
        otpPanel.Visible = true;
        Random random = new Random();
        int value = random.Next(10001, 99999);
        string destinationaddr = "+91" + contactTextBox.Text;
        string message = "Your OTP Number is " + value + " ( Sent By : Ecommerce website )";
        //Label3.Text = message;

        //store otp in db table otphistory : id,phonenumber,otpcode,isactive ,1,0
        try
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconnect"].ConnectionString);
            con.Open();
            string insert = "  Update otphistory set isactive = 0 where phonenumber = @phonenumber  insert into otphistory (phonenumber,otpcode,isactive) values(@phonenumber,@otpcode,@isactive)";
            SqlCommand cmd = new SqlCommand(insert, con);
            cmd.Parameters.AddWithValue("@phonenumber", contactTextBox.Text);
            cmd.Parameters.AddWithValue("@otpcode", value);
            cmd.Parameters.AddWithValue("@isactive", 1);
            cmd.ExecuteNonQuery();

            con.Close();



        }
        catch (Exception ex) {
            Response.Write(ex);
            return;
        }

        Session["id"] = contactTextBox.Text;
        if (SMSHelper.SendSMS(destinationaddr, message))
        {
            otpPanel.Visible = true;
        }
        else
        {
            Response.Write("login failed..! Please try again");
        }


        
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        
        if (Session["id"] == null)
        {
            FailedUnfailedPopupMsg.Text = "some thing went wrong... please try again";
            return;
        }
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconnect"].ConnectionString);
        con.Open();
        string insert = "  Select otpcode from  otphistory  where phonenumber = @phonenumber and  isactive = 1";
        SqlCommand cmd = new SqlCommand(insert, con);
        cmd.Parameters.AddWithValue("@phonenumber", contactTextBox.Text);
        string otpcode =  (string)cmd.ExecuteScalar();

        con.Close();
        if ( otpTextBox.Text.Trim() == otpcode.Trim())
        {
            SqlConnection con2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconnect"].ConnectionString);
            con2.Open();
            string query = "  Select phonenumber from  userdata  where phonenumber = @phonenumber";
            SqlCommand cmd2 = new SqlCommand(query, con2);
            cmd2.Parameters.AddWithValue("@phonenumber", Session["id"].ToString());
            string phonenumber = (string)cmd2.ExecuteScalar();

            con.Close();
            //check in table otphistory 
            otpPanel.Visible = false;
            if (string.IsNullOrEmpty(phonenumber))
            {
                Response.Redirect("home.aspx");
            }
            else
            {
                FailedUnfailedPopupMsg.Text = "User already exists login done.";
            }
        }
        else
        {
            FailedUnfailedPopupMsg.Text = "OTP Number is Not Correct : Your Mobile Number not Verified";
            otpPanel.Visible = true;
        }

    }

}






