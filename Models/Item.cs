using System.Linq;
using System;

namespace inventory_all_the_things.Models
{
  public class Item
  {
    public int Id { get; set; }

    public int SKU { get; set; }

    public string Name { get; set; }

    public string ShortDescription { get; set; }

    public int NumberInStock { get; set; }

    public int Price { get; set; }

    public DateTime DateOrdered { get; set; }
  }
}