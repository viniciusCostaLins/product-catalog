using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Models;
using ProductCatalog.ViewModels.ProductViewModels;
using System.Collections.Generic;
using System.Linq;
using ProductCatalog.ViewModels;
using ProductCatalog.Repositories;

namespace ProductCatalog.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepository _prodRepo;

        public ProductController(ProductRepository prodRepo)
        {
            _prodRepo = prodRepo;
        }

        [Route("v1/products")]
        [HttpGet]
        public IEnumerable<ListProductViewModel> Get() 
        {
            return this._prodRepo.Get();
        }

        [Route("v1/products/{id}")]
        [HttpGet]
        public Product Get(int id)
        {
            return this._prodRepo.Get(id);
        }

        [Route("v1/products")]
        [HttpPost]
        public ResultViewModel Post ([FromBody]EditorProductViewModel model) 
        {
            model.Validate();
            
            if (model.Invalid) 
            {
                return new ResultViewModel 
                {
                    Success = false,
                    Message = "Não foi possível cadastrar o produto",
                    Data = model.Notifications
                };
            }

            var product = new Product();
            product.Title = model.Title;
            product.CategoryId = model.CategoryId;
            product.CreateDate = DateTime.Now;
            product.Description = model.Description;
            product.Image = model.Image;
            product.LastUpdateDate = DateTime.Now;
            product.Price = model.Price;
            product.Quantity = model.Quantity;      

            this._prodRepo.Save(product);

            return new ResultViewModel 
            {
                Success = true,
                Message = "Produto cadastrado  com sucesso",
                Data = product
            };
        }

        [Route("v1/products")]
        [HttpPut]
        public ResultViewModel Put ([FromBody]EditorProductViewModel model) 
        {
            model.Validate();
            
            if (model.Invalid) 
            {
                return new ResultViewModel 
                {
                    Success = false,
                    Message = "Não foi possível alterar o produto",
                    Data = model.Notifications
                };
            }

            var product = _prodRepo.Get(model.Id);
            product.Title = model.Title;
            product.CategoryId = model.CategoryId;
            product.Description = model.Description;
            product.Image = model.Image;
            product.LastUpdateDate = DateTime.Now;
            product.Price = model.Price;
            product.Quantity = model.Quantity;

            this._prodRepo.Update(product);

            return new ResultViewModel 
            {
                Success = true,
                Message = "Produto alterado  com sucesso",
                Data = product
            };
        }
    }
}