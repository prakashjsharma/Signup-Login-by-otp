using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

/// <summary>
/// Summary description for SMSHelper
/// </summary>
public static class SMSHelper
{
    private static string apiID = "600aebe39658171b1e6c3f26";
    private static string apiKey = "reNeSa4uAyge4u6aSyJeDaVe3yHy7azyqy2e";
    private static string url = "https://api.enablex.io/sms/v1/messages/";
    

    public static bool SendSMS(string PhoneNumber, string  message)
    {
        
        SmsDetails details = new SmsDetails { type = "sms", data_coding = "plain", campaign_id = "28245824", body = message };

        details.recipient = new List<recipient>();
        details.recipient.Add(new recipient { to = PhoneNumber });

        string json = new JavaScriptSerializer().Serialize(details);
        ServicePointManager.Expect100Continue = true;
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11;
        // Skip validation of SSL/TLS certificate
        ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };


        
       

        HttpWebRequest request = null;
        
        request = (HttpWebRequest)WebRequest.Create(url); // Create a request using a URL that can receive a post. 
       
         request.Headers.Add(HttpRequestHeader.Authorization, "Basic " +Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(apiID+":"+apiKey)));
        request.Method = "POST";  // Set the Method property of the request to POST.                
        request.ContentType = "application/json";
        StreamWriter sw = new StreamWriter(request.GetRequestStream()); // Wrap the   request stream with a text-based writer                   
        sw.WriteLine(json);  // Write the xml as text into the stream
        sw.Close();

        WebResponse response = request.GetResponse(); // Send the data to the webserver // Get the response.
        if (request != null) request.GetRequestStream().Close(); //Close the request object

        string responseFromServer = string.Empty;
        if (response != null)
        {
            StreamReader incomingStreamReader = new StreamReader(response.GetResponseStream());
            responseFromServer = incomingStreamReader.ReadToEnd(); // Put the response in a string
            incomingStreamReader.Close();
            response.GetResponseStream().Close();
            
        }


        if (responseFromServer.Contains("job_id"))
        {
            return true;
        }
        return false;
    }
    private static CredentialCache GetCredential()
    {
        
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
        CredentialCache credentialCache = new CredentialCache();
        credentialCache.Add(new System.Uri(url), "Basic", new NetworkCredential(apiID,apiKey));
        return credentialCache;
    }
}