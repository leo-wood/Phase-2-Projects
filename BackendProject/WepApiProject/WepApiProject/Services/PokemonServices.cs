namespace WepApiProject.Services
{
    public class PokemonServices
    {
        static List<Pokemon> PokemonTeam { get; set; }

        static PokemonServices() {
            PokemonTeam = new List<Pokemon>();
        }
        public static List<Pokemon> GetAll() => PokemonTeam;

        public static Pokemon? Get(string name) => PokemonTeam.FirstOrDefault(p => p.name == name);

        public static void Add(Pokemon pokemon)
        {
            PokemonTeam.Add(pokemon);
            Console.WriteLine(pokemon.name + " was added to your team");
        }

        public static void Delete(string name)
        {
            var pokemon = Get(name);
            if (pokemon is null)
            {
                Console.WriteLine(name + " wasn't removed.. are you sure you've got them in your pocket?");
                return;
            }
                
            PokemonTeam.Remove(pokemon);
            Console.WriteLine("You've released " + pokemon.name + " into the wild... say goodbye!");
            return;
        }

        public static void Update(string pokemon, Pokemon newPokemon)
        {
            var index = PokemonTeam.FindIndex(p => p.name.Equals(pokemon, StringComparison.OrdinalIgnoreCase));
            if (index == -1) {
                PokemonTeam.Add(newPokemon);
                return; } 
            else { 
                PokemonTeam.RemoveAt(index); 
                PokemonTeam.Insert(index, newPokemon);
                return;
                    }

           
        }
    }

    
}
