﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DropDown.aspx.cs" Inherits="DropDown" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="ddlMain" runat="server">
            </asp:DropDownList>
            <asp:Button ID="btnRun" runat="server" Text="Run" OnClick="btnRun_Click" />
        </div>
    </form>
</body>
</html>
