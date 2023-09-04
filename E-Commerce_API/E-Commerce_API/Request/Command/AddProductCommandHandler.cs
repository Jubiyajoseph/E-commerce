﻿using E_Commerce.Model.Models.ProductsModel;
using E_Commerce.Repository.Context;
using MediatR;

namespace E_Commerce_API.Request.Command
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, bool>
    {
        private readonly E_Commerce_DbContext _context;
        public AddProductCommandHandler(E_Commerce_DbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(AddProductCommand command, CancellationToken cancellationToken)
        {
            Product product = new(command.Name,command.Weight,command.Stock,command.BrandId,command.CategoryId,command.UnitPrice);
            _context.Product.Add(product);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
