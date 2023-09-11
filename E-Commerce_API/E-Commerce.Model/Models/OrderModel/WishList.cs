using E_Commerce.Model.Models.ProductsModel;
using E_Commerce.Model.Models.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Model.Models.OrderModel
{
    public class WishList
    {
          public int WishListId { get; }
          public int UserID { get; private set; }
          public User? User { get; set; }
          public int ProductID { get; private set; }
          public Product? Product { get;  set; }    
          public bool IsDeleted { get; private set; }

        public WishList(int userID, int productID, bool isDeleted)
        {
            UserID = userID;
            ProductID = productID;
            IsDeleted = isDeleted;

        }
        public WishList(int wishListId, int userID, int productID, bool isDeleted)
        {
            WishListId = wishListId;
            UserID = userID;
            ProductID = productID;
            IsDeleted = isDeleted;

        }
    }

    

}
