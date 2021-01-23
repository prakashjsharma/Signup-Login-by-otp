<%@ Page Language="C#" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 133%;
        }
        .auto-style4 {
            text-align:center;
            width: 397px;
            height: 78px;
        }
        .auto-style5 {
            text-align:center;
            width: 397px;
            height: 84px;
        }
        .auto-style6 {
            height: 84px;
        }
        .auto-style7 {
            height: 78px;
        }
        .auto-style8 {
            height: 68px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="background-color: yellow; text-align: center; color:red; height: 44px;" >
    
        <h2 style="color:#00ff90;">You are sucessfully logged in...! Please fill up your details</h2>
    </div>
        <br />
        <br />
        <br />
        <asp:Panel ID="Panel1" runat="server" Width="1048px">
            <table class="auto-style1">
                <tr>
                    <td class="auto-style4">Name : </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="nametextbox" runat="server" Height="20px" Width="252px" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="nametextbox" Display="Dynamic" ErrorMessage="required" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">Email ID : </td>
                    <td class="auto-style6">
                        <asp:TextBox ID="emailtextbox" runat="server" Height="20px" Width="247px" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="emailtextbox" Display="Dynamic" ErrorMessage="invalid email id" ForeColor="Red" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
            </table>

        </asp:Panel>
        <asp:Panel ID="sumbitbuttonpanel" runat="server" Height="70px" Width="1047px">
            <table class="auto-style1">
                <tr >
                    <td class="auto-style8" style="text-align: center; color:red; ">
                        <asp:Button ID="Submitbutton" runat="server" BackColor="#66FF99" BorderStyle="Double" BorderWidth="5px" Font-Bold="True" Text="Submit" OnClick="Button1_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </form>
</body>


    <script type="text/javascript">
        window.history.forward();
        function noBack() { window.history.forward(); }
</script>
</html>

