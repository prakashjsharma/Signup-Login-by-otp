using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SmsDetails
/// </summary>
public class SmsDetails
{
    public string body { get; set; }
    public string type { get; set; }
    public string data_coding { get; set; }
    public string campaign_id { get; set; }
    public List<recipient> recipient { get; set; }
}

public class recipient
{
    public string to { get; set; }
}
