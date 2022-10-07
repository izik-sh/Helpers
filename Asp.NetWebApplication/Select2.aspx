<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Select2.aspx.cs" Inherits="Select2_Select2aspx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <link href="https://cdn.jsdelivr.net/npm/select2@4.1.0-rc.0/dist/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/select2@4.1.0-rc.0/dist/js/select2.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>

    <script type="text/javascript">

        $(document).ready(function () {
            debugger;
            var data = [
                {
                    id: 0,
                    text: 'enhancement'
                },
                {
                    id: 1,
                    text: 'bug'
                },
                {
                    id: 2,
                    text: 'duplicate'
                },
                {
                    id: 3,
                    text: 'invalid'
                },
                {
                    id: 4,
                    text: 'wontfix'
                }
            ];
            alert(data[1].text);
            $(".js-example-data-array").select2({
                data: data
            })

            //$(".js-example-data-array-selected").select2({
            //    data: data
            //})

            alert(data[1].text);

            $("#divMain").hide();

            alert(data[2].text);
            //debugger;
            //$('.js-example-basic-single').select2({
            //    tags: true
            //}

            );
            //$('.js-example-basic-multiple').select2();
            //$(".js-example-ajax").select2({
            //    data: data
            //})

            // tell Select2 to use the property name for the text
            //function format(item) { return item.name; };

            //var names = [{ "id": "1", "name": "Adair,James" }
            //    , { "id": "2", "name": "Anderson,Peter" }
            //    , { "id": "3", "name": "Armstrong,Ryan" }]




        //$('.js-data-example-ajax').select2({
        //    ajax: {
        //        url: 'https://api.github.com/search/repositories',
        //        dataType: 'json'
        //        // Additional AJAX parameters go here; see the end of this chapter for the full code of this example
        //    }
        //});


    </script>

    <select class="js-example-basic-single" name="state">
        <option value="AL">Alabama</option>
        <option value="WY">Wyoming</option>
    </select>
    <select class="js-example-basic-multiple" name="states[]" multiple="multiple">
        <option value="AL">Alabama</option>
        <option value="WY">Wyoming</option>
    </select>
    <select>
        <optgroup label="Group Name">
            <option>Nested option</option>
            <option>Nested option2</option>
            <option>Nested option3</option>
        </optgroup>
        <optgroup label="Group Name 2">
            <option>Nested 2 option</option>
            <option>Nested 2 option2</option>
            <option>Nested 2 option3</option>
        </optgroup>
    </select>
    <input type="hidden" id="e10" style="width: 300px" />
    <select class="js-example-data-array" name="state"></select>
    <div id="divMain">
        hello
    </div>
</asp:Content>

