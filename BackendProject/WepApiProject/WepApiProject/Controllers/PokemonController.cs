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
        /// Retrieves a single pokemon from the PokeAPI using their name and adds them to your team
        /// </summary>
        /// <param name="name">Please enter the name of a pokemon e.g. charizard, diglett, clefairy, mewtwo</param>
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
            
            var pokemon = await res.Content.ReadFromJsonAsync<Pokemon>();

            Console.WriteLine("Adding " + pokemon.name + " to your team!");
            PokemonServices.Add(pokemon);
            Console.WriteLine("Your team is now: ");
            foreach (Pokemon p in PokemonServices.GetAll()) { 
                Console.WriteLine(p.name);
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
            name = name.ToLower();
            Console.WriteLine("Created your new pokemon, " + name + " with default stats...");

            Pokemon pokemon = new Pokemon();
            pokemon.name = name;
            PokemonServices.Add(pokemon);

            return CreatedAtAction(nameof(CreatePokemon), new { id = pokemon.id }, pokemon);
            
        }

        /// <summary>
        /// Swaps out a pokemon with the specified pokemon
        /// </summary>
        /// <param name="oldPokemon">Please enter the name of the pokemon you wish to remove from your team</param>
        /// <param name="name">Please enter the name of the pokemon you want in your team</param>
        /// <returns>A 204 No Content Response></returns>
        [HttpPut]
        [ProducesResponseType(201)]
        public IActionResult UpdatePokemonTeam(string oldPokemon, string name)
        {
            name = name.ToLower();
            Pokemon pokemon = new Pokemon();
            pokemon.name = name;
            PokemonServices.Update(oldPokemon, pokemon);
            Console.WriteLine("You've swapped in to your team " + pokemon.name);
            Console.WriteLine("Youre pokemon team is now: ");
            foreach (Pokemon p in PokemonServices.GetAll())
            {
                Console.WriteLine(p.name);
            }

            return NoContent();
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
