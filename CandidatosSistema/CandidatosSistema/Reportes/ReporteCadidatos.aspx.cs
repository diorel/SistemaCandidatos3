
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CandidatosSistema
{
    public partial class ReporteCadidatos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                showrep("ReportesRys", "ReporteCandidatosActivo2");
        }

        protected void showrep(string nombrepath, string reporteremoto)
        {

            ReportViewer1.ProcessingMode = ProcessingMode.Remote;
            ReportViewer1.ServerReport.ReportServerUrl = new Uri("http://servertalent:80/ReportServer");
            ReportViewer1.ServerReport.ReportPath = "/" + nombrepath + "/" + reporteremoto;
            ReportViewer1.ServerReport.Refresh();


        }

    }
}