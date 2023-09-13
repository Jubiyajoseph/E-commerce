namespace E_Commerce_API.Request.Query
{
    public class AddressDetailsQuery
    {
        public int AddressId { get; set; }
        public string? ResidentialAddress { get; set; }
        public string? CityName { get; set; }
        public string? StateName { get; set; }
        public string? CountryName { get; set; }

    }
}
