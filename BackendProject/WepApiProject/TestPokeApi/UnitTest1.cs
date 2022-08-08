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
            
        }

        /// <summary>
        /// Tests that a Pokemon object can successfully be created and data accessed
        /// </summary>
        [Test]
        public void TestNewPokemon()
        {
            Pokemon pokemon = new Pokemon();
            pokemon.name = "testPokemon";

            Assert.IsInstanceOf<Pokemon>(pokemon);
            Assert.That(pokemon.name, Is.EqualTo("testPokemon"));

            PokemonServices.Add(pokemon);
            var team = PokemonServices.GetAll();
            Assert.That(team, Is.Not.Null);
            
        }

        public void NSubTest()
        {


            Pokemon pokemon = new Pokemon();
            pokemon.name = "SubtestPokemon";

            var substitute = Substitute.For<Pokemon>();

            var teamSubstitute = Substitute.For<PokemonServices>();



            




        }
    }
}