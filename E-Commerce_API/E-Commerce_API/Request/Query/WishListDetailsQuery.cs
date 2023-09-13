using System.Security.Cryptography.X509Certificates;

namespace E_Commerce_API.Request.Query
{
    public class WishListDetailsQuery
    {
       public int WishListId { get; set; }  
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
      
    }
}
