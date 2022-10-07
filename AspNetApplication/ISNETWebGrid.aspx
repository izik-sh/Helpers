<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ISNETWebGrid.aspx.cs" Inherits="ISNETWebGrid" %>


<%@ Register Assembly="ISNet.WebUI.WebGrid" Namespace="ISNet.WebUI.WebGrid" TagPrefix="ISWebGrid" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../assets/styles/samples.css" runat="server" />

    <link href="../Assets/styles/ornamenthorizontal.css" rel="stylesheet" />
    <link href="../Assets/styles/ornamentvertical.css" rel="stylesheet" />
    <link href="../Assets/styles/searchbar.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.5.0/css/font-awesome.min.css" />

    <!-- designtime links will be automatically removed at runtime -->
    <link id="designtime_1" rel="stylesheet" href="~/Themes/webui-bootstrap/css/bootstrap.min.css" runat="server" />
    <link id="designtime_2" rel="stylesheet" href="~/Themes/webui-bootstrap/css/bootstrap.theme.min.css" runat="server" />
    <link id="designtime_3" rel="stylesheet" href="~/Themes/webui-bootstrap/css/webui-bootstrap.min.css" runat="server" />


    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="ornament-body-image">
                <ISWebGrid:WebGrid ID="WebGrid1" runat="server" Height="100%" 
                    Width="100%">
                    <RootTable CaptionImage="../Assets/images/Customer.svg" Caption="Customers" DataKeyField="A"
                        DataMember="A" NewRowInfoText="Please click here to add new customer..."
                        TableHeaderVisible="True">
                        
                        <Columns>
                            <ISWebGrid:WebGridColumn Caption="A" DataMember="A" EditInfoText="Enter A (*required)"
                                InputRequired="True" Name="A" Width="71px">
                            </ISWebGrid:WebGridColumn>
                                  <ISWebGrid:WebGridColumn Caption="B" DataMember="B" EditInfoText="Enter B (*required)"
                                InputRequired="True" Name="B" Width="71px">
                            </ISWebGrid:WebGridColumn>
                                  <ISWebGrid:WebGridColumn Caption="C" DataMember="C" EditInfoText="Enter C (*required)"
                                InputRequired="True" Name="C" Width="71px">
                            </ISWebGrid:WebGridColumn>
                        
                        </Columns>
                    </RootTable>
                    <LayoutSettings Hierarchical="True" AllowAddNew="Yes" AllowColumnMove="Yes"
                        AllowDelete="Yes" AllowEdit="Yes" AllowExport="Yes" AllowFilter="Yes" AllowGrouping="Yes"
                        AllowSelectColumns="Yes" AllowSorting="Yes" AutoFilterSuggestion="True" GridLines="Vertical"
                        GroupByBoxVisible="True" HeaderClickAction="SortMulti" HideColumnsWhenGrouped="No"
                        NewRowLostFocusAction="AlwaysPrompt" PromptBeforeDelete="True" RowLostFocusAction="AlwaysPrompt"
                        ShowFilterStatus="True" ResetNewRowValuesOnError="False" VerboseEditingInformation="True" MarkDefaultValuesAsDirty="false">
                        <FrameStyle CssClass=", grid-frameless" Overflow="Hidden"></FrameStyle>
                    </LayoutSettings>
                </ISWebGrid:WebGrid>
            </div>
        </div>
    </form>
</body>
</html>
