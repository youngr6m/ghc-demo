// this class represents the data returned from the API, where an example of the JSON returned is:
// {"details":{"id":3401989,"name":"Hawthorn Cottage,","accountId":64814,"status":"Active","peakPower":8.0,"lastUpdateTime":"2023-02-09","installationDate":"2022-12-15","ptoDate":null,"notes":"","type":"Optimizers & Inverters","location":{"country":"United Kingdom","city":"FORDINGBRIDGE","address":"Hawthorn Cottage","address2":"Frogham Hil","zip":"SP6 2HW","timeZone":"Europe/London","countryCode":"GB"},"primaryModule":{"manufacturerName":"JA solar","modelName":"370W","maximumPower":370.0},"uris":{"DETAILS":"/site/3401989/details","DATA_PERIOD":"/site/3401989/dataPeriod","OVERVIEW":"/site/3401989/overview"},"publicSettings":{"isPublic":false}}}"}

using System;

namespace SolarApp
{
    public class SiteDetailsResult
    {
        public SiteDetails details { get; set; }

        public class SiteDetails
        {
            public int id { get; set; }
            public string name { get; set; }
            public int accountId { get; set; }
            public string status { get; set; }
            public double peakPower { get; set; }
            public DateTime lastUpdateTime { get; set; }
            public DateTime installationDate { get; set; }
            public object ptoDate { get; set; }
            public string notes { get; set; }
            public string type { get; set; }
            public Location location { get; set; }
            public PrimaryModule primaryModule { get; set; }
            public Uris uris { get; set; }
            public PublicSettings publicSettings { get; set; }

            public class Location
            {
                public string country { get; set; }
                public string city { get; set; }
                public string address { get; set; }
                public string address2 { get; set; }
                public string zip { get; set; }
                public string timeZone { get; set; }
                public string countryCode { get; set; }
            }

            public class PrimaryModule
            {
                public string manufacturerName { get; set; }
                public string modelName { get; set; }
                public double maximumPower { get; set; }
            }

            public class Uris
            {
                public string DETAILS { get; set; }
                public string DATA_PERIOD { get; set; }
                public string OVERVIEW { get; set; }
            }

            public class PublicSettings
            {
                public bool isPublic { get; set; }
            }
        }
    }
}


