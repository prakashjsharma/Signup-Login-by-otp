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

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void logincontactButton_Click(object sender, EventArgs e)
    {
        logincontactPanel.Visible = false;
        loginotpPanel.Visible = true;
        Random random = new Random();
        int value = random.Next(10001, 99999);
        string destinationaddr = "+91" + logincontactTextBox.Text;
        string message = "Your OTP Number is " + value + " ( Sent By : Ecommerce website )";
        //Label3.Text = message;

        //store otp in db table otphistory : id,phonenumber,otpcode,isactive ,1,0
        try
        {
            
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconnect"].ConnectionString);
            
            string insert = "  Update otphistory set isactive = 0 where phonenumber = @phonenumber  insert into otphistory (phonenumber,otpcode,isactive) values(@phonenumber,@otpcode,@isactive)";
            SqlCommand cmd = new SqlCommand(insert, con);
            cmd.Parameters.AddWithValue("@phonenumber", logincontactTextBox.Text);
            cmd.Parameters.AddWithValue("@otpcode", value);
            cmd.Parameters.AddWithValue("@isactive", 1);
            cmd.ExecuteNonQuery();

            
            
            con.Close();
        }
             
           //-----------------------------------------


        catch (Exception ex)
        {
            Response.Write(ex);
        }

        if (SMSHelper.SendSMS(destinationaddr, message))
        {

        }
        else
        {
            Response.Write("login failed..! Please try again");
        }



    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Session["id"] == null )
        {
            loginFailedUnfailedPopupMsg.Text = "some thing went wrong... please try again";
            return;
        }

        if (loginotpTextBox.Text == Session["otp"].ToString())
        {
            
            //check in table otphistory 
            loginotpPanel.Visible = true;
            Response.Redirect("main.aspx");
        }
        else
        {
            loginFailedUnfailedPopupMsg.Text = "OTP Number is Not Correct : Your Mobile Number not Verified";
            loginotpPanel.Visible = true;
        }

        //--------------------------------------

        

    }
}