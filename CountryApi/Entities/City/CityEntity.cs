namespace CountryApi.Entities.City
{
    public enum Status
    {
        Catital
    }
    public class CityEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual Country.CountryEntity CountryEntity { get; set; }
        public Status Status { get; set; }
        public double Square { get; set; }
        public long Population { get; set; }
    }
}
