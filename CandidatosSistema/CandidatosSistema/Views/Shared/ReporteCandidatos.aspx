<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteCandidatos.aspx.cs" Inherits="CandidatosSistema.Views.Shared.ReporteCandidatos" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> es te es el reporte loco</title>

    <script runat="server">


        void Page_Load(object sender, EventArgs e)
        {
             if (!IsPostBack)
                showrep("ReportesRys", "ReporteCandidatosActivo");


        }

        protected void showrep(string nombrepath, string reporteremoto)
        {

            ReportViewer1.ProcessingMode = ProcessingMode.Remote;
            ReportViewer1.ServerReport.ReportServerUrl = new Uri("http://user-pc/ReportServer_DESAROLLO");
            ReportViewer1.ServerReport.ReportPath = "/" + nombrepath + "/" + reporteremoto;
            ReportViewer1.ServerReport.Refresh();


        }






    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" AsyncRendering="false" SizeToReportContent="false"></rsweb:ReportViewer>
    </div>
    </form>
</body>
</html>
