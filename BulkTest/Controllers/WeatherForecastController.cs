using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BulkTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

/*        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            Stopwatch s = new Stopwatch();
            s.Start();

            var profiles = GenerateProfiles(count);
            var gererationTime = s.Elapsed.ToString();
            s.Restart();

            primeDbContext.Profiles.AddRange(profiles);
            var insertedCount = await primeDbContext.SaveChangesAsync();

            return Ok(new
            {
                inserted = insertedCount,
                generationTime = gererationTime,
                insertTime = s.Elapsed.ToString()
            });
        }*/

/*        private IEnumerable<Profile> GenerateProfiles(int count)
        {
            var salutations = new string[] { "Mr", "Mrs" };

            var profileGenerator = new Faker<Profile>()
                .RuleFor(p => p.Ref, v => v.Person.UserName)
                .RuleFor(p => p.Forename, v => v.Person.FirstName)
                .RuleFor(p => p.Surname, v => v.Person.LastName)
                .RuleFor(p => p.Email, v => v.Person.Email)
                .RuleFor(p => p.TelNo, v => v.Person.Phone)
                .RuleFor(p => p.DateOfBirth, v => v.Person.DateOfBirth)
                .RuleFor(p => p.Salutation, v => v.PickRandom(salutations))
                .RuleFor(p => p.Country, v => v.Address.Country());

            return profileGenerator.Generate(count);
        }*/
    }
}