// using System;
// using System.Web.Http;
// using Newtonsoft.Json;

// namespace Sol3.Infrastructure.IoT.Ifttt.Feature.Api
// {
//     [RoutePrefix("api/worker")]
//     public class ApiWorkerController : ApiController
//     {
//         [HttpGet]
//         [Route("")]
//         public string Get()
//         {
//             var targetDay = DateTime.Today.AddDays(1);
//             var sunriseSunsetHandler = new Handler();
//             sunriseSunsetHandler.ExecuteRequest(40.1175836, -104.9684357, targetDay);

//             Log.Logger.Debug("Hit Sunrise/Sunset API: {@results}", sunriseSunsetHandler);

//             return JsonConvert.SerializeObject(sunriseSunsetHandler);
//         }

//         [HttpGet]
//         [HttpPut]
//         [Route("Shutdown/{id:int}")]
//         public void Shutdown(int id)
//         {
//             Log.Logger.Information("Shutdown requested via API while in DEBUG mode...");
//             if (!AppSettings.Instance.IsService)
//                 AppSettings.Instance.CancellationTokenSource.Cancel();
//         }
//     }
// }
