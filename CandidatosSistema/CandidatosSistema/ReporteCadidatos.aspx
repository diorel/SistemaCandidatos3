﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteCadidatos.aspx.cs" Inherits="CandidatosSistema.ReporteCadidatos" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <h1>hesto es un reporte</h1>
        <p>&nbsp;</p>

        <rsweb:ReportViewer ID="ReportViewer1" runat="server"></rsweb:ReportViewer>
  
       
      <%--  <rsweb:ReportViewer ID="ReportViewer1" runat="server"  Font-Names="Verdana"  Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" ProcessingMode="Remote" Width="100%">
        </rsweb:ReportViewer>--%>
        <%--<ServerReport ReportPath="/ReportesRys/ReporteCandidatosActivo" ReportServerUrl="http://user-pc/ReportServer_DESAROLLO/" />--%>
    </div>
    </form>
</body>
</html>