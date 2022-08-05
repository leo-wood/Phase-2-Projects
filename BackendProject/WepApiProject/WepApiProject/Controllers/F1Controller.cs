using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.Json;
using WepApiProject.Models;

namespace WepApiProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class F1Controller : ControllerBase
    {
        private readonly HttpClient _client;
        public F1Controller(IHttpClientFactory clientFactory)
        {
            if (clientFactory == null) { throw new ArgumentNullException(nameof(clientFactory)); }
            _client = clientFactory.CreateClient("f1");
        }


        /// <summary>
        /// GET method for returning the standings of a specified year
        /// </summary>
        /// <param name="year">Enter a year between 1950 and 2022 inclusive. using format 2022, or 1998</param>
        [HttpGet]
        [Route("")]
        [ProducesResponseType(200)]
        [Produces("application/json")]
        public async Task<IActionResult> GetF1Standings(string year)
        {
            var apiLink = "/api/f1/" + year + "/driverStandings.json";
            var res = await _client.GetAsync(apiLink);
            var content = await res.Content.ReadAsStringAsync();
            Console.WriteLine("Returning information on the upcoming Formula One race");
            //Console.WriteLine(content);

            //var driversMap = JsonSerializer.Deserialize<Dictionary<string, Driver>>(content);
            Mrdata? driver = JsonSerializer.Deserialize<Mrdata>(content);


            Console.WriteLine(content.GetType());
            Console.WriteLine("Below here");
            Console.WriteLine(driver);
            Console.WriteLine("Driver is: }");

            

            return Ok(content);


        }
    }


}
