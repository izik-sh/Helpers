<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WebGrid.aspx.cs" Inherits="WebGrid" %>

<%--<%@ Register Assembly="ISNet.WebUI.WebGrid" Namespace="ISNet.WebUI.WebGrid" TagPrefix="ISWebGrid" %>--%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

         <%--   <ISWebGrid:WebGrid ID="wgData" runat="server" Height="250px" UseDefaultStyle="true" Width="500px" AllowAutoDataCaching="true">
            </ISWebGrid:WebGrid>--%>

         <%--   <ISWebGrid:WebGrid ID="wgTransactions" runat="server"
                HorizontalAlign="NotSet" Width="100%" Height="600px"
                OnInitializeDataSource="wgTransactions_InitializeDataSource"

                RenderingMode="HTML5">
                <RootTable Caption="tPlanningValues" AutomaticFilter="False" DataKeyField="A" GridLineStyle="NotSet"
                    AllowFilter="Yes" AllowDelete="Yes" AllowEdit="Yes">
                    <Columns>
                        <ISWebGrid:WebGridColumn Caption="A" DataMember="A" Name="A" Width="90px"></ISWebGrid:WebGridColumn>
                        <ISWebGrid:WebGridColumn Caption="B" DataMember="B" Name="B" Width="90px"></ISWebGrid:WebGridColumn>
                    </Columns>
                </RootTable>
                <LayoutSettings AlternatingColors="True" CellPaddingDefault="2" GridLineColor="203, 207, 214"
                    GridLineStyle="Solid" RowHeightDefault="20px" ColumnFooters="Yes" AllowFilter="Yes" AllowGrouping="Yes"
                    AllowSelectColumns="Yes" AllowSorting="Yes" Culture="Invariant Language (Invariant Country)"
                    PagingMode="VirtualLoad" AllowExport="Yes" AlwaysShowHelpButton="False">
                    <HeaderStyle BackColor="#EEEFF1" BorderWidth="1px"
                        Font-Names="Tahoma" Font-Size="8pt" ForeColor="#022260" Height="20px" CustomRules="border-right: solid 1px #CBCFD6; border-bottom:  solid 1px #CBCFD6">
                        <BorderSettings>
                            <Top Color="White" />
                            <Left Color="White" />
                        </BorderSettings>
                    </HeaderStyle>
                    <FocusCellStyle BorderColor="Navy" BorderStyle="Solid" BorderWidth="1px" />
                    <PreviewRowStyle ForeColor="#0000C0">
                    </PreviewRowStyle>
                    <StatusBarCommandStyle>
                        <Active BackColor="RoyalBlue" BaseStyle="Over">
                        </Active>
                        <Over BackColor="CornflowerBlue" BorderColor="Navy" BorderStyle="Solid" BorderWidth="1px">
                        </Over>
                        <Normal>
                            <Padding Bottom="1px" Left="1px" Right="1px" Top="1px" />
                        </Normal>
                    </StatusBarCommandStyle>
                    <GroupRowInfoStyle BackColor="#F3EBDC" BorderColor="#CBCFD6" BorderStyle="Solid" BorderWidth="1px"
                        Font-Names="Tahoma" Font-Size="8pt">
                        <BorderSettings>
                            <Bottom Color="203, 207, 214" Style="solid" Width="1px" />
                            <Right Color="203, 207, 214" />
                            <Top Color="203, 207, 214" Style="solid" Width="1px" />
                        </BorderSettings>
                    </GroupRowInfoStyle>
                    <GroupByBox ConnectorLineColor="MidnightBlue" ConnectorLineStyle="Dotted">
                        <LabelStyle BackColor="#708ABC" BorderColor="#CBCFD6" BorderStyle="Solid" BorderWidth="1px"
                            Font-Names="Tahoma" Font-Size="8pt" Font-Bold="True" ForeColor="White" />
                        <Style BackColor="Gray"></Style>
                    </GroupByBox>
                    <EditTextboxStyle BorderStyle="None" BorderWidth="0px" Font-Names="Tahoma" Font-Size="8pt" ForeColor="#708ABC">
                    </EditTextboxStyle>
                    <FrameStyle BackColor="White" BorderColor="#CBCFD6" BorderStyle="Solid" BorderWidth="1px">
                    </FrameStyle>
                    <SelectedRowStyle BackColor="#E4F0FF" ForeColor="#243553" BorderColor="#243553" BorderStyle="Solid" BorderWidth="1px" />
                    <AlternatingRowStyle BackColor="#FBF8F2" CustomRules="text-overflow: ellipsis; overflow-x: hidden"
                        Font-Names="Tahoma" Font-Size="8pt" ForeColor="#243553" />
                    <StatusBarStyle BackColor="#E4E6E8" BorderColor="#ACA899" BorderStyle="Solid" BorderWidth="1px"
                        Font-Names="Tahoma" Font-Size="8pt" ForeColor="#022260">
                        <Padding Bottom="2px" Left="2px" Right="2px" Top="2px" />
                    </StatusBarStyle>
                    <RowStyle BackColor="White" CustomRules="text-overflow: ellipsis; overflow-x: hidden"
                        Font-Names="Tahoma" Font-Size="8pt" ForeColor="#243553" />
                    <NewRowStyle BackColor="White" Font-Names="Tahoma" Font-Size="8pt" ForeColor="White">
                    </NewRowStyle>
                    <FooterStyle BackColor="PeachPuff" ForeColor="Navy" />
                    <LostFocusRowStyle BackColor="#E4F0FF">
                    </LostFocusRowStyle>
                    <ClientSideEvents OnAfterResponseProcess="wgDoResize(true,true);" />
                </LayoutSettings>
                <FlyPostBackSettings PostInputControls="True" />
            </ISWebGrid:WebGrid>--%>

        </div>
    </form>
</body>
</html>
