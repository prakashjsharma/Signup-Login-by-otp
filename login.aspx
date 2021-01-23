<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            height: 123px;
            background-color: #ee8989;
        }
        .auto-style2 {
            width: 154px;
            height: 75px;
        }
        .auto-style3 {
            width: 100%;
            height: 97px;
            background-color: #ee8989;
        }
        .auto-style4 {
            width: 152px;
        }
        .auto-style5 {
            height: 75px;
        }
        .auto-style6 {
            width: 182px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lblWebsiteHeading" runat="server" style="font-weight: 700; font-size: xx-large" Text="Ecommerce website"></asp:Label>
    
    </div>
        <asp:Panel ID="logincontactPanel" runat="server" Height="119px" Width="350px" style="border-radius:3px; text-align: center;">
            <table class="auto-style1" border="1"  style="border-radius:3px;">
                <tr>
                    <td class="auto-style2">Enter your Mobile No : </td>
                    <td class="auto-style5">
                        <asp:TextBox ID="logincontactTextBox" runat="server" BorderColor="Black" Width="171px" placeholder=" Ex: 7738112455" ></asp:TextBox>
                       
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="logincontactTextBox" Display="Dynamic" ErrorMessage="invalid number" ForeColor="Red" SetFocusOnError="True" ValidationExpression="[0-9]{10}">invalid number</asp:RegularExpressionValidator>
                       
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="logincontactTextBox" Display="Dynamic" ErrorMessage="Mobile no required" ForeColor="Red"></asp:RequiredFieldValidator>
                       
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:Button ID="logincontactButton" runat="server" BackColor="#FF5050" BorderColor="Black" BorderWidth="2px" OnClick="logincontactButton_Click" Text="Send OTP" Height="30px" Width="80px" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <asp:Panel ID="loginotpPanel" runat="server" Height="97px" Width="350px" style="text-align: center; border-radius:3px;" Visible="False">
            <table class="auto-style3" border="1" style="border-radius:3px;">
                <tr>
                    <td class="auto-style4">Enter your OTP :</td>
                    <td class="auto-style6">
                        <asp:TextBox ID="loginotpTextBox" runat="server" BorderColor="Black" Width="172px" placeholder=" Your OTP"></asp:TextBox>

                    </td>
                </tr>
                <tr>
 
                    <td style="text-align: center" colspan="2">
                        <asp:Button ID="loginButton2" runat="server" BackColor="#66FF66" BorderColor="Black" BorderWidth="2px" OnClick="Button2_Click" Text="Verify" Height="30px" Width="80px" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Label ID="loginFailedUnfailedPopupMsg" runat="server" Font-Size="Large"></asp:Label>
    </form>
</body>
    </html>