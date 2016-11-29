using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using CandidatosSistema.Models;
using Point = DotNet.Highcharts.Options.Point;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CandidatosSistema.Controllers
{
    public class GaficaEmpresaPastelController : Controller
    {
        // GET: GaficaEmpresaPastel
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

                var data5 = bd.Candidato.ToLookup(x => x.EmpresaId).Where(x => x.FirstOrDefault() != null && x.First().Empresa != null).Select(x => new { NombreEmpresa = x.First().Empresa.Descripcion, NumeroCandidatos = x.Count() }).ToList();

                var xDataMonths = data4.Where(x => x != null).Select(i => i.NombreEmpresa).ToArray();
                var xDataMonths1 = data4.Where(x => x != null && x.NombreEmpresa == "Cemex").Select(i => i.NombreEmpresa).ToArray();
                var xDataMonths2 = data4.Where(x => x != null && x.NombreEmpresa == "IDER").Select(i => i.NombreEmpresa).ToArray();
                // var xDataMonths2 = data4.Where(x => x != null && x.NombreEmpresa == "IDER").Select(i => i.NombreEmpresa).ToArray();
                var yDataCounts = data4.Select(i => new object[] { i.NumeroCandidatos }).ToArray();


                var yDataCounts1 = data5.Where(x => x.NombreEmpresa == "Cemex").Select(i => new object[] { i.NumeroCandidatos }).ToArray();
                var yDataCounts2 = data5.Where(x => x.NombreEmpresa == "IDER").Select(i => new object[] { i.NumeroCandidatos }).ToArray();
                var yDataCounts3 = data5.Where(x => x.NombreEmpresa == "RABITA").Select(i => new object[] { i.NumeroCandidatos }).ToArray();
                var yDataCounts4 = data5.Where(x => x.NombreEmpresa == "SEPROSIMA").Select(i => new object[] { i.NumeroCandidatos }).ToArray();

            
               var yDataCounts5 = data5.Where(x => x.NombreEmpresa == "Otra Empresa").Select(i => new object[] { i.NumeroCandidatos }).ToArray();



                //instanciate an object of the Highcharts type
                var chart = new Highcharts("chart")
                        //define the type of chart 
                        .InitChart(new Chart { DefaultSeriesType = ChartTypes.Bar })
                        //overall Title of the chart 
                        .SetTitle(new Title { Text = "Grafica de colores por empresa" })
                        //small label below the main Title
                        .SetSubtitle(new Subtitle { Text = "Numpero de candidatos por emprpesa" })
                        .SetCredits(new Credits { Text = "Programer By Raul Diorelyon Cortes Amador" })
                        // en esta parte insetare los formatos de la Grafica con .SetPlotOptions


                        //load the X values
                        //.SetXAxis(new XAxis { Categories = "Empresas" })
                      
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
                         //you can add more y data to create a second line
                        // new Series { Name = "Other Name", Data = new Data(OtherData) }

                    new Series {Name = "Cemex" , Data = new Data(yDataCounts1)},
                    new Series {Name = "IDER" , Data = new Data(yDataCounts2)},
                    new Series {Name = "RABITA" , Data = new Data(yDataCounts3)},
                    new Series {Name = "SEPROSIMA" , Data = new Data(yDataCounts4)},
                    new Series {Name = "Otra Empresa" , Data = new Data(yDataCounts5)},
                }
                    );


                //.SetSeries(new Series
                //{
                //    Type = ChartTypes.Bar,
                //    Name = "Browser share",
                //    Data = new Data(new object[]
                //    {

                //    new Series {Name = "Cemex" , Data = new Data(yDataCounts1)},
                //    new Series {Name = "IDER" , Data = new Data(yDataCounts2)},
                //    new Series {Name = "RABITA" , Data = new Data(yDataCounts3)},
                //    new Series {Name = "SEPROSIMA" , Data = new Data(yDataCounts4)},
                //    new Series {Name = "Otra Empresa" , Data = new Data(yDataCounts5)}

                //    }),

                //});





                //   Highcharts chart = new Highcharts("chart")
                //.InitChart(new Chart { PlotShadow = false })
                //.SetTitle(new Title { Text = "Browser market shares at a specific website, 2010" })
                //.SetTooltip(new Tooltip { Formatter = "function() { return '<b>'+ this.point.name +'</b>: '+ this.percentage +' %'; }" })
                //.SetPlotOptions(new PlotOptions
                //{
                //    Pie = new PlotOptionsPie
                //    {
                //        AllowPointSelect = true,
                //        Cursor = Cursors.Pointer,
                //        DataLabels = new PlotOptionsPieDataLabels
                //        {

                //            Formatter = "function() { return '<b>'+ this.point.name +'</b>: '+ this.percentage +' %'; }"
                //        }
                //    }
                //})

                //       //load the X values
                //       .SetXAxis(new XAxis { Categories = xDataMonths })
                //       //set the Y title
                //       .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "Numero de candidatos" } })
                //       .SetTooltip(new Tooltip
                //       {
                //           Enabled = true,
                //           Formatter = @"function() { return '<b>'+ this.series.name +'</b><br/>'+ this.x +': '+ this.y; }"
                //       })
                //       .SetPlotOptions(new PlotOptions
                //       {
                //           Line = new PlotOptionsLine
                //           {
                //               DataLabels = new PlotOptionsLineDataLabels
                //               {
                //                   Enabled = true
                //               },
                //               EnableMouseTracking = false
                //           }
                //       })
                //       //load the Y values 
                //       .SetSeries(new[]
                //   {


                //       new Series {Name =  "CEMEX", Data = new Data(yDataCounts)},
                //       new Series {Name =  "COCA", Data = new Data(yDataCounts)},
                //       new Series {Name =  "CHOCLATERA", Data = new Data(yDataCounts)},
                //       new Series {Name =  "BIMBO", Data = new Data(yDataCounts)},

                //           //you can add more y data to create a second line
                //           // new Series { Name = "Other Name", Data = new Data(OtherData) }
                //   });



                //.SetSeries(new Series
                // {
                //     Type = ChartTypes.Pie,
                //     Name = "Browser share",
                //     Data = new Data(new object[]
                //    {
                //           new object[] { "Firefox", 45.0 },
                //           new object[] { "IE", 26.8 },
                //           new Point
                //           {
                //               Name = "Chrome",
                //               Y = 12.8,
                //               Sliced = true,
                //               Selected = true
                //           },
                //           new object[] { "Safari", 8.5 },
                //           new object[] { "Opera", 6.2 },
                //           new object[] { "Others", 0.7 }
                //    })
                // });





                return View(chart);

            }
        }
    }
}