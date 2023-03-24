
namespace SolarApp 
{
     class Program 
    {
        static async Task Main(string[] args) 
        {
            Console.WriteLine("Hello World! This is a test.");

            SolarAPIClient client = new SolarAPIClient();
            var details = await client.GetSiteDetailsAsync(3401989);

            Console.WriteLine($"Site Name: {details.Name}");

            var overview = await client.GetSiteOverviewAsync(3401989);

            Console.WriteLine($"Site Overview: {overview.LastUpdateTime}");
            Console.WriteLine($"--> Lifetime Energy  : {overview.LifeTimeEnergy}");
            Console.WriteLine($"--> Current Power: {overview.CurrentPower}");

            // Calculate the percentage of current power, where the maximum 100% would be 8000 

            var percentage = (overview.CurrentPower / 8000) * 100;
            Console.WriteLine($"--> Current Power Percentage: {percentage}");
            

        }




      
    }
}