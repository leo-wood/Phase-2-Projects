using Microsoft.AspNetCore.Mvc;
using WepApiProject.Services;


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
        /// Retrieves a pokemon from the PokeAPI using their name
        /// </summary>
        /// <param name="name">Please enter the name of a pokemon</param>
        /// <returns>Ok Response. Adds your new pokemon to the team</returns>
        [HttpGet]
        [Route("")]
        [ProducesResponseType(200)]
        [Produces("application/json")]
        public async Task<IActionResult> GetPokemon(string name)
        {
            name = name.ToLower();
            var apiLink = "pokemon/" + name;
            var res = await _client.GetAsync(apiLink);
            
            var content = await res.Content.ReadAsStringAsync();
            Console.WriteLine("Returning information on the upcoming Pokemon");
            var test = await res.Content.ReadFromJsonAsync<Pokemon>();

            Console.WriteLine("Adding " + test.name + " to your team!");
            PokemonServices.Add(test);
            Console.WriteLine("Your team is now: ");
            foreach (Pokemon pokemon in PokemonServices.GetAll()) { 
                Console.WriteLine(pokemon.name);
            }

            return Ok(content);
        }

        /// <summary>
        /// Creates a pokemon with any name you choose! Your new pokemon will have null stats to start so dont go into the grass just yet
        /// </summary>
        /// <param name="name">Please enter the name of your newly created pokemon</param>
        /// <returns>A 201 Created response</returns>
        [HttpPost]
        [ProducesResponseType(201)]
        public IActionResult CreatePokemon(string name)
        {
            Console.WriteLine("Created your new pokemon, " + name + " with default stats...");

            Pokemon pokemon = new Pokemon();
            pokemon.name = name;
            PokemonServices.Add(pokemon);

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
        /// Removes the chosen pokemon from your team
        /// </summary>
        /// <param name="pokemonName">Please enter the name of a pokemon in your team</param>
        /// <returns>A 204 No Content Response</returns>
        [HttpDelete]
        [ProducesResponseType(204)]
        public IActionResult DeletePokemon(string pokemonName)
        {
            pokemonName = pokemonName.ToLower();
            PokemonServices.Delete(pokemonName);
           
            return NoContent();
        }

    }
}
