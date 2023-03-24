using static SolarApp.SiteOverviewResult;
using System.Text.Json.Serialization;
using System.Text.Json;


namespace SolarApp
{
 

   public class DataStore
   {
    Dictionary<DateTime, double> _powerReadings = new Dictionary<DateTime, double>();

    public DataStore()
    {
    }

    public void AddPowerReading(DateTime time, double reading)
    {
        _powerReadings.Add(time, reading);
        SavePowerReadings();    
    }


    // Save power readings to file
    public void SavePowerReadings()
    {
        var json = JsonSerializer.Serialize(_powerReadings);
        File.WriteAllText("powerReadings.json", json);
    }



 

    
 
    
   }
}