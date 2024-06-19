<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccessDenied.aspx.cs" Inherits="LifeGymWebsite.AccessDenied" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Access Denied</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
<meta charset="UTF-8">
<link rel="stylesheet" href="AccessDenied.css">
<link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="w3-display-middle">
<h1 class="w3-jumbo w3-animate-top w3-center"><code>Access Denied</code></h1>
<hr class="w3-border-white w3-animate-left" style="margin:auto;width:50%">
<h3 class="w3-center w3-animate-right">You dont have permission to view this site.</h3>
<h3 class="w3-center w3-animate-zoom">🚫🚫🚫🚫</h3>
<h6 class="w3-center w3-animate-zoom">
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/login.aspx">Back to Login</asp:HyperLink></h6>
</div>
        </div>
    </form>
</body>
</html>
