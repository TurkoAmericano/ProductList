using ProductList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductList.ViewModels
{
  public class HomeViewModel
  {
    public IEnumerable<Product> Products { get; set; }
    public int CurrentIndex { get; set; }
    public int TotalCount { get; set; }
    public int PageSize { get; set; }

  }
}
