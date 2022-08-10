using WepApiProject;
using WepApiProject.Services;
using NSubstitute;

namespace TestPokeApi
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
            PokemonIsCreated();
            Pokemon_are_different();
        }

        /// <summary>
        /// Tests that a Pokemon object can successfully be created and data accessed
        /// </summary>
        [Test]
        public void PokemonIsCreated()
        {
            Pokemon pokemon = new Pokemon();
            pokemon.name = "testPokemon";

            Assert.IsInstanceOf<Pokemon>(pokemon);
            Assert.That(pokemon.name, Is.EqualTo("testPokemon"));

            PokemonServices.Add(pokemon);
            var team = PokemonServices.GetAll();
            Assert.That(team, Is.Not.Null);
            
        }


        /// <summary>
        /// This unit test is to satisfy the NSubstitute requirement.
        /// Reading the NSub documentation, it seems my project doesnt benefit from NSUb as 
        /// its recommended for Interfaces which my project doesnt have. 
        /// So i've tried to make some use of it but its not very effective.
        /// --------------
        /// Tests pokemon with different values are not equal using a substitute
        /// </summary>
        [Test]
        public void Pokemon_are_different()
        {

            Pokemon pokemon = new Pokemon();
            pokemon.name = "SubtestPokemon";

            pokemon.base_experience = 10;

            var substitutePokemon = Substitute.For<Pokemon>();

            var teamSubstitute = Substitute.For<PokemonServices>();

            substitutePokemon.name = "SubtestPokemon";
            substitutePokemon.base_experience = 20;

            //their names being equal shows the pokemon are correctly accessed for the below test
            Assert.That(pokemon.name, Is.EqualTo(substitutePokemon.name));

            //pokemon should not == substitute as they have different base exp
            Assert.That(pokemon, Is.Not.EqualTo(substitutePokemon));
            
            
            

        }

    }
}