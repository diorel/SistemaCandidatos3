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
    public class GraficaEmpresaController : Controller
    {
        // GET: GraficaEmpresa
        public ActionResult Index()
        {
            using (var bd = new SisCandidatosEntities())
            {



                //var data4 = from A in bd.Candidato
                //            group A.Empresa by new
                //            {
                //                A.Empresa.Descripcion
                //            } into g
                //            select new { NumeroCandidatos = g.Count(), NombreEmpresa = g.Key.Descripcion };

                //List<Candidato> listado = new data4.ToList();


                var data4 = bd.Candidato.ToLookup(x => x.EmpresaId).Where(x => x.FirstOrDefault() != null && x.First().Empresa != null).Select(x => new { NombreEmpresa = x.First().Empresa.Descripcion, NumeroCandidatos = x.Count() }).ToList();


                var xDataMonths = data4.Where(x => x != null).Select(i => i.NombreEmpresa).ToArray();
                var yDataCounts = data4.Select(i => new object[] { i.NumeroCandidatos}).ToArray();



                //instanciate an object of the Highcharts type
                var chart = new Highcharts("chart")
                        //define the type of chart 
                        .InitChart(new Chart { DefaultSeriesType = ChartTypes.Bar })                            
                        //overall Title of the chart 
                        .SetTitle(new Title { Text = "Incoming Transacions per hour" })
                        //small label below the main Title
                        .SetSubtitle(new Subtitle { Text = "Accounting" })
                        .SetCredits(new Credits { Text = "Programer By Raul Diorelyon Cortes Amador" })
                        // en esta parte insetare los formatos de la Grafica con .SetPlotOptions

                        .SetPlotOptions(new PlotOptions {Pie = new PlotOptionsPie { AllowPointSelect = true, Cursor = Cursors.Pointer, DataLabels = new PlotOptionsPieDataLabels { Formatter = "function() { return '<b>'+ this.point.name +'</b>: '+ this.percentage +' %'; }" },
                        Point = new PlotOptionsPiePoint
                        {
                            Events = new PlotOptionsPiePointEvents
                            {
                                Click = "function() { alert (this.category +': '+ this.y); }"
                            }
                        }
                        } })

                        //load the X values
                        .SetXAxis(new XAxis { Categories = xDataMonths })
                        .SetXAxis(new XAxis { Categories = xDataMonths })
                        //set the Y title
                        .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "Numero de candidatos" } })
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