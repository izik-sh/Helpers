<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Frame.aspx.cs" Inherits="Frame" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
</head>
<body>
    <form id="form1" runat="server">
        <div id="divContent">
            divContent
            <button type="button" onclick="closeMe();">close</button>
        </div>
    </form>
    <script>
        function closeMe() {
            //alert('close');
           // self.close();
            //open('', '_self').close();
            top.close();
        }
    </script>
</body>
</html>
