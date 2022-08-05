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
        }

        public static void Delete(string name)
        {
            var pokemon = Get(name);
            if (pokemon is null)
                return;

            PokemonTeam.Remove(pokemon);
        }

        public static void Update(Pokemon pokemon)
        {
            var index = PokemonTeam.FindIndex(p => p.name.Equals(pokemon.name, StringComparison.OrdinalIgnoreCase));
            if (index == -1) { return; }

            PokemonTeam.Insert(index, pokemon);
        }
    }

    
}
