using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product> {
                new Product{ProductID=1, CategoryID=1, ProductName="Kulaklık", UnitPrice=150, UnitsInStock=10},
                new Product{ProductID=2, CategoryID=1, ProductName="Bilgisayar", UnitPrice=8500, UnitsInStock=25},
                new Product{ProductID=3, CategoryID=2, ProductName="Telefon", UnitPrice=5500, UnitsInStock=24},
                new Product{ProductID=4, CategoryID=2, ProductName="Mouse", UnitPrice=350, UnitsInStock=11},
                new Product{ProductID=5, CategoryID=2, ProductName="Laptop", UnitPrice=4000, UnitsInStock=17}

            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = _products.SingleOrDefault(p => p.ProductID == product.ProductID);
            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Update(Product product)
        {
            //GÖnderdiğim ürün idsine sahip olan listedeki ürünü bul
            Product productToUpDate = _products.SingleOrDefault(p => p.ProductID == product.ProductID);
            productToUpDate.ProductName = product.ProductName;
            productToUpDate.CategoryID = product.CategoryID;
            productToUpDate.UnitPrice = product.UnitPrice;
            productToUpDate.UnitsInStock = product.UnitsInStock;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p=> p.CategoryID == categoryId).ToList();

        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}
