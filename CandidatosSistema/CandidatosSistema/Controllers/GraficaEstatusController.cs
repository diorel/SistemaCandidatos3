using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using CandidatosSistema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CandidatosSistema.Controllers
{
    public class GraficaEstatusController : Controller
    {
        // GET: GraficaEstatus
        public ActionResult Index()
        {
 

            using (var bd = new SisCandidatosEntities())
            {
                // var data = bd.usp_Candidatos_Region();

                // esta llamada hace los mismo pero sin usar un sp
                // osea que es una consulta con LINQ y ya hciciste un join y agrupaste los datos. verdad? ok de hecho era lo que nesesitaba aun que todoavia no entiendo por que utilizaste el Usin y las llaves 

                var data3 = bd.Candidato.ToLookup(x => x.Sueldo).Select(x => new { TipoEstatus = x.Key.Descripcion, NumeroCadidatos = x.Count() }).ToList();

                var xDataMonths = data3.Select(i => i.TipoEstatus).ToArray();
                var yDataCounts = data3.Select(i => new object[] { i.NumeroCadidatos }).ToArray();

                //instanciate an object of the Highcharts type
                var chart = new Highcharts("chart")
                        //define the type of chart 
                        .InitChart(new Chart { DefaultSeriesType = ChartTypes.Pie })
                        //overall Title of the chart 
                        .SetTitle(new Title { Text = "Incoming Transacions per hour" })
                        //small label below the main Title
                        .SetSubtitle(new Subtitle { Text = "Accounting" })
                        //load the X values
                        .SetXAxis(new XAxis { Categories = xDataMonths })
                        //set the Y title
                        .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "Nummerod de candidatos" } })
                        .SetTooltip(new Tooltip
                        {
                            Enabled = true,
                            Formatter = @"function() { return '<b>'+ this.series.name +'</b><br/>'+ this.x +': '+ this.y; }"
                        })
                        .SetPlotOptions(new PlotOptions
                        {
                            Line = new PlotOptionsLine
                            {
                                DataLabels = new PlotOptionsLineDataLabels
                                {
                                    Enabled = true
                                },
                                EnableMouseTracking = false
                            }
                        })
                        //load the Y values 
                        .SetSeries(new[]
                    {
                        new Series {Name = "Candidatos", Data = new Data(yDataCounts)},

                            //you can add more y data to create a second line
                            // new Series { Name = "Other Name", Data = new Data(OtherData) }
                    });

                return View(chart);

            }
        }
    }
}