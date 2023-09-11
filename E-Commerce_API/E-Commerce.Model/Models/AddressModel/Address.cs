using E_Commerce.Model.Models.UserModel;


namespace E_Commerce.Model.Models.AddressModel
{
    public class Address
    {
        public int AddressId { get; }
        public string ResidentialAddress { get; private set; }=string.Empty;   
        public int CityId { get; private set; }
        public City? City { get; set; }
        public int StateId { get; private set; }
        public State? State { get; set; }
        public int CountryId { get; private set; }
        public Country? Country { get; set; }
        public int UserId { get; private set; } 
        public User? User { get; set; }
        public bool IsDeleted {get; private set; }

        private Address()
        {

        }

        public Address(string residentialAddress,int cityId,int stateId,int countryId,int userId,bool isDeleted)
        {
            ResidentialAddress = residentialAddress;
            CityId = cityId;
            StateId = stateId;
            CountryId = countryId;
            UserId = userId;
            IsDeleted = isDeleted;
        }

        public void UpdateAddress(string residentialAddress, int cityId, int stateId, int countryId,int userId)
        {
            ResidentialAddress=residentialAddress;
            CityId = cityId;
            StateId = stateId;
            CountryId = countryId;
            UserId = userId;
        }

    }
}
