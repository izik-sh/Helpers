<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileUpload.aspx.cs" Inherits="FileUpload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="Form1" method="post" runat="server" EncType="multipart/form-data" action="WebForm1.aspx">
        <div>
            <asp:FileUpload runat="server" ID="fileUpload" />
            <asp:Button runat="server" ID="btnUpload" OnClick="btnUpload_Click" />
        </div>
    </form>
</body>
</html>
