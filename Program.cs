
namespace SolarApp 
{
     class Program 
    {
        static async Task Main(string[] args) 
        {
            // write a welcome to the Solar Demo App to the console
            Console.WriteLine("Welcome to the Solar Demo App");
            

            SolarAPIClient client = new SolarAPIClient();
            var details = await client.GetSiteDetailsAsync(3401989);

            Console.WriteLine($"Site Name: {details.Name}");

            var overview = await client.GetSiteOverviewAsync(3401989);

            Console.WriteLine($"Site Overview: {overview.LastUpdateTime}");
            Console.WriteLine($"--> Lifetime Energy  : {overview.LifeTimeEnergy}");
            Console.WriteLine($"--> Current Power: {overview.CurrentPower}");



        }


      
    }
}