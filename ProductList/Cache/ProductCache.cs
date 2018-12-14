using Microsoft.Extensions.Caching.Memory;
using ProductList.DB;
using ProductList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductList.Cache
{

  public interface IProductCache
  {
    List<Product> GetProducts();
  }

  public class ProductCache : IProductCache
  {

    private IProducts _products;
    private IMemoryCache _cache;
    private const string PRODUCT_KEY = "pk";

    public ProductCache(IMemoryCache cache, IProducts products)
    {
      _cache = cache;
      _products = products;
    }

    
    public List<Product> GetProducts()
    {

      List<Product> products = new List<Product>();

      if (_cache.TryGetValue(PRODUCT_KEY, out products))
      {
        return products;
      }
      else
      {
        products = _products.GetProducts();
        _cache.Set(PRODUCT_KEY, products, new MemoryCacheEntryOptions() { AbsoluteExpiration = DateTime.Now.AddHours(1) });
        return products;
      }
    }
  }
}
