<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VehicleListing.aspx.cs" Inherits="ADI_FORMS.Reports.VL" %>

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
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" Height="652px" style="margin-right: 8px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%">
            <LocalReport ReportPath="Reports\VehicleListing.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="VehicleSqlDataSource" Name="DataSet1" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:SqlDataSource ID="VehicleSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:FAConnectionString %>" SelectCommand="SELECT VEHICLESVIEW.* FROM VEHICLESVIEW"></asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
