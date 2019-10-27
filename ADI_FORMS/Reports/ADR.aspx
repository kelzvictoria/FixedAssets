<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ADR.aspx.cs" Inherits="ADI_FORMS.Reports.ADR" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" style="margin-right: 0px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%">
            <LocalReport ReportPath="Reports\AssetDetailReport.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="AssetsSqlDataSource" Name="DataSet1" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:SqlDataSource ID="AssetsSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:FAConnectionString %>" SelectCommand="SELECT ASSETSVIEW.* FROM ASSETSVIEW"></asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
