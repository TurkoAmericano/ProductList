using AutoFixture;
using ProductList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductList.DB
{

  public interface IProducts
  {
    List<Product> GetProducts();
  }

  public class Products : IProducts
  {

    private static List<Product> _products = new List<Product>();

    public Products()
    {

      Fixture fixture = new Fixture();

      if (!_products.Any())
      {
        _products = fixture.CreateMany<Product>(1000).ToList();
      }
    }

    public List<Product> GetProducts()
    {
      return _products;
    }

  }
}
