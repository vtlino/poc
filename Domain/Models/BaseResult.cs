using System;

namespace OpenBanking.POC.Domain.Models
{
    public class Meta
    {
        public int TotalPages { get; set; }
        public DateTime FirstAvailableDateTime { get; set; }
        public DateTime LastAvailableDateTime { get; set; }
    }

    public class Links
    {
        public string Self { get; set; }
        public string First { get; set; }
        public string Prev { get; set; }
        public string Next { get; set; }
        public string Last { get; set; }
    }
}