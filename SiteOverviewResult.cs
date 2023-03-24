namespace SolarApp
{
    public class SiteOverviewResult
    {
        public SiteOverviewResult() { overview = new Overview(); }
        public class energyReading
        {
            public double energy { get; set; }
        }

        public class powerReading
        {
            public double power { get; set; }
        }

        public class Overview
        {
            public Overview() { lifeTimeData = new energyReading(); lastYearData = new energyReading(); lastMonthData = new energyReading(); lastDayData = new energyReading(); currentPower = new powerReading();}
            public string? lastUpdateTime { get; set; }
            public energyReading lifeTimeData { get; set; }
            public energyReading lastYearData { get; set; }
            public energyReading lastMonthData { get; set; }
            public energyReading lastDayData { get; set; }
            public powerReading currentPower { get; set; }
        }

        public Overview overview { get; set; }
    }
}