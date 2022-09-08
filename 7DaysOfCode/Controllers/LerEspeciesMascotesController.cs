using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net;

namespace _7DaysOfCode.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LerEspeciesMascotesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            string url = @"https://pokeapi.co/api/v2/pokemon/";

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Accept = "application/json";
            httpWebRequest.Method = "GET";

            string json = string.Empty;

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                streamWriter.Write(json);

            IAsyncResult asyncResult = httpWebRequest.BeginGetResponse(null, null);

            asyncResult.AsyncWaitHandle.WaitOne();

            string soapResult;
            using (WebResponse webResponse = httpWebRequest.EndGetResponse(asyncResult))
            {
                using StreamReader rd = new StreamReader(webResponse.GetResponseStream());
                soapResult = rd.ReadToEnd();
            }

            return Ok(soapResult);
        }
    }
}
