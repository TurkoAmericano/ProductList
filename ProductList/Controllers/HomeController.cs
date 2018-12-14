using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductList.Cache;
using ProductList.Models;
using ProductList.ViewModels;

namespace ProductList.Controllers
{
  public class HomeController : Controller
  {

    private IProductCache _productCache;
    private const int PAGE_SIZE = 10;
    
    public HomeController(IProductCache productCache)
    {
      _productCache = productCache;
    }

    [HttpGet("api/products/{pageIndex}/{filter?}")]
    public ActionResult GetProducts(int pageIndex, string filter)
    {

      var products = _productCache.GetProducts().OrderBy(x => x.Id);

      if (!string.IsNullOrEmpty(filter))
      {
        products = products.Where(x => x.Name.Contains(filter)).OrderBy(x => x.Id);
      }

      var productListPaged = products.Skip((pageIndex) * PAGE_SIZE).Take(PAGE_SIZE);
      var homeViewModel = new HomeViewModel() { CurrentIndex = pageIndex, Products = productListPaged, TotalCount = products.Count(), PageSize = PAGE_SIZE };
      return PartialView(@"~/Views/Home/_Products.cshtml", homeViewModel);


    }

    [HttpGet("api/home")]
    public ActionResult Index()
    {
      return View();
    }



  }
}
