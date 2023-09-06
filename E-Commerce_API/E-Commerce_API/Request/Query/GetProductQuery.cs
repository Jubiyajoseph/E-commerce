using E_Commerce.Model.Models.ProductsModel;
using E_Commerce_API.Request.Command;
using MediatR;

namespace E_Commerce_API.Request.Query
{
    public class GetProductQuery: IRequest<ProductDetailsQuery>
    {
        public int ProductID { get; set; }
    }
}
