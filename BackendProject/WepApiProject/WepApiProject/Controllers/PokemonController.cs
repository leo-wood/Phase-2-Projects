using Microsoft.AspNetCore.Mvc;

namespace WepApiProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {

        private readonly HttpClient _client;
        public PokemonController(IHttpClientFactory clientFactory)
        {
            if (clientFactory == null) { throw new ArgumentNullException(nameof(clientFactory)); }
            _client = clientFactory.CreateClient("PokeApi");
        }

        /// <summary>
        /// GET method for the Poke API
        /// </summary>
        
        [HttpGet]
        [Route("")]
        [ProducesResponseType(200)]
        [Produces("application/json")]
        public async Task<IActionResult> GetPokemon()
        {
            var apiLink = "pokemon/mewtwo";
            var res = await _client.GetAsync(apiLink);
            
            var content = await res.Content.ReadAsStringAsync();
            Console.WriteLine("Returning information on the upcoming Pokemon");
            var test = await res.Content.ReadFromJsonAsync<Pokemon>();
            Console.WriteLine(test.name);
            Console.WriteLine(test.id);

            apiLink = "pokemon/clefairy";
            res = await _client.GetAsync(apiLink);

            content = await res.Content.ReadAsStringAsync();
            Console.WriteLine("Returning information on the upcoming Pokemon");
            test = await res.Content.ReadFromJsonAsync<Pokemon>();
            Console.WriteLine(test.name);
            Console.WriteLine(test.id);

            //var test1 = await res.Content.ReadFromJsonAsync<IList<Pokemon>>();

            return Ok(content);


        }

        

        /// <summary>
        /// Demonstrates posting action
        /// </summary>
        /// <returns>A 201 Created response</returns>
        [HttpPost]
        [ProducesResponseType(201)]
        public IActionResult DemonstratePost()
        {
            Console.WriteLine("I'm doing some work right now to create a new thing...");

            return Created(new Uri("https://www.google.com"), "Hi There");
        }

        /// <summary>
        /// Demonstrates put action
        /// </summary>
        /// <returns>A 201 Created Response></returns>
        [HttpPut]
        [ProducesResponseType(201)]
        public IActionResult DemonstratePut()
        {
            Console.WriteLine("I'm over-writing whatever was there in the first place...");

            return Created(new Uri("https://www.google.com"), "Hi There");
        }

        /// <summary>
        /// Demonstrates a delete action
        /// </summary>
        /// <returns>A 204 No Content Response</returns>
        [HttpDelete]
        [ProducesResponseType(204)]
        public IActionResult DemonstrateDelete()
        {
            Console.WriteLine("I'm removing something from the database...");

            return NoContent();
        }

    }
}
