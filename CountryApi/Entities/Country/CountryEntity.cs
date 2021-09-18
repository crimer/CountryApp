using System;
using System.ComponentModel;

namespace CountryApi.Entities.Country
{
    public class CountryEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime FoundationDate { get; set; }
        public string OfficialLanguage { get; set; }
        public string Capital { get; set; }
        public int Territory { get; set; }
        public long Population { get; set; }
        public double GdpTotal { get; set; }
        public double HDI { get; set; }
        public string Currency { get; set; }
    }
}
