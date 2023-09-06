using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Model.Models.OrderModel
{
    public class WishList
    {
          public int WishListID { get; }
          public int UserID { get; private set; }
          public int ProductID { get; private set; }
          public bool IsDeleted { get; private set; }

        private WishList() { }
        public WishList(int wishListId, int userID, int productID, bool isDeleted)
        {
            WishListID = wishListId;
            UserID = userID;
            ProductID = productID;
            IsDeleted = isDeleted;

        }
    }

    

}
