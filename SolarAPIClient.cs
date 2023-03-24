using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SolarApp 
{
    public class SolarAPIClient 
    {
        public const string api_key="PSRSGI7KC8C6AFFA39VHJRG1P0BDN0TD";
        public const string BaseURL = "https://monitoringapi.solaredge.com/";

        public DataStore DataStore { get; set; } = new DataStore();

        HttpClient client;
        public SolarAPIClient() 
        {
            client = new HttpClient();

            // Set the base URL for the API
            client.BaseAddress = new Uri(BaseURL);

            // Set the Accept header
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));
        }


        /// Call the details api to get the site details and convert from json to SiteDetails object

        public async Task<SiteDetails> GetSiteDetailsAsync(int siteId)
        {
            SiteDetails siteDetails = null;
            HttpResponseMessage response = await client.GetAsync($"site/{siteId}/details?api_key={api_key}");
            if (response.IsSuccessStatusCode)
            {
                SiteDetailsResult res = JsonSerializer.Deserialize<SiteDetailsResult>( await response.Content.ReadAsStreamAsync());
                if(res == null || res.details == null)
                    throw new Exception("SiteDetailsResult is null");

                siteDetails = new SiteDetails { Name = res.details.name, Id = res.details.id, Status = res.details.status };
            }
            return siteDetails ?? throw new Exception("Failed to get site details");
        }
         
        public async Task<SiteOverview> GetSiteOverviewAsync(int siteId)
        {
            SiteOverview siteOverview = null;
            HttpResponseMessage response = await client.GetAsync($"site/{siteId}/overview?api_key={api_key}");
            if (response.IsSuccessStatusCode)
            {
                SiteOverviewResult res = JsonSerializer.Deserialize<SiteOverviewResult>(await response.Content.ReadAsStreamAsync());
                if(res != null && res.overview != null && res.overview.lifeTimeData != null && res.overview.lastYearData != null && res.overview.lastMonthData != null && res.overview.lastDayData != null && res.overview.currentPower != null)
                {
                    siteOverview = new SiteOverview{
                        LastUpdateTime = res.overview.lastUpdateTime,
                        LifeTimeEnergy = res.overview.lifeTimeData.energy,
                        LastYearEnergy = res.overview.lastYearData.energy,
                        LastMonthEnergy = res.overview.lastMonthData.energy,
                        LastDayEnergy = res.overview.lastDayData.energy,
                        CurrentPower = res.overview.currentPower.power};

                    DateTime readingTime = DateTime.Now;
                    if(DateTime.TryParse(siteOverview.LastUpdateTime, out readingTime))
                    {
                        DataStore.AddPowerReading(readingTime, siteOverview.CurrentPower);
                    }
                }
            }
            return siteOverview ?? throw new Exception("Failed to get site overview");    
        }
    }

}
