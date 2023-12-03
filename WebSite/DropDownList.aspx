<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DropDownList.aspx.cs" Inherits="DropDownListaspx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.10.1/jquery.min.js"></script>
    <script src="http://code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <link href="http://code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.11.1/i18n/jquery-ui-i18n.min.js"></script>
</head>

<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="ddlTest" runat="server" ClientIDMode="Static">
            </asp:DropDownList>
        </div>
    </form>
    <script>
        $("#ddlTest").change(function () {
            debugger;
            var end = this.value;
            var firstDropVal = $('#pick').val();

            var value = $("select#ddlTest option").filter(":selected").val();
            var text = $("select#ddlTest option").filter(":selected").text();

            alert('value: ' + value + " - text: " + text);

        });

        debugger;
        var programming_languages = [{ "36": "php", "2": "java", "3": "javascript", "4": "ruby", "5": "go", "6": "shell script", "7": "c#", "8": "python", "9": "perl" }];



        function produceOptions(programming_languages) {
            var populated_options = "";
            $.each(programming_languages, function (key, value) {
                var object = value;
                $.each(object, function (k, v) {
                    populated_options += "<option value='" + k + "'>" + v + "</option>";
                });
            });

            return populated_options;
        }


        test();
        function test() {
            debugger;
            var elem = document.getElementById('<%= ddlTest.ClientID %>');
            $('#ddlTest').append(produceOptions(programming_languages))

        }
    </script>
</body>
</html>
