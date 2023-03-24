namespace SolarApp 
{
    public class SiteOverview 
    {
        public string? LastUpdateTime { get; set; }
        public double LifeTimeEnergy { get; set; }
        public double LastYearEnergy { get; set; }
        public double LastMonthEnergy { get; set; }
        public double LastDayEnergy { get; set; }
        public double CurrentPower { get; set; }
    }
}