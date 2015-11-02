<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrontPage.aspx.cs" Inherits="ProsjektOppgave1.FrontPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Student Nettbutikk<br />
        <br />
        <asp:Button ID="registerBtn" runat="server" Text="Registrer" />
    
        <br />
    
        <asp:Button ID="loggIn" runat="server" Text="Logg in" />
    
        <asp:TextBox ID="eMail" runat="server"></asp:TextBox>
        <asp:TextBox ID="password" runat="server"></asp:TextBox>
    
        <br />
        <br />
    
        <br />
    
        <br />
    
    </div>
    </form>
</body>
</html>
