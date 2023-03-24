namespace SolarApp 
{
    public class SiteDetails 
    {
        public SiteDetails()
        {
            Name = "Uninitialized";
            Id=0;
            Status ="Uninitialized";
        }

        public string Name { get; set; }
        public int Id { get; set; }

        public string Status { get; set; }
       
    }

    public class SiteDetailsResult
    {
        public SiteDetailsResult()
        {
            details = new Details();
        }
        
        public class Details
        {
            public int id { get; set; }
            public string? name { get; set; }
            public int accountId { get; set; }
            public string? status { get; set; }
        }

        public Details details { get; set; }
    }

}

