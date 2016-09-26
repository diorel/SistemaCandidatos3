﻿using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CandidatosSistema.Views.Filtro
{
    public partial class Reporte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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



    }
}