using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using inventory_all_the_things;
using inventory_all_the_things.Models;
using System.Collections.Generic;

namespace inventory_all_the_things.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ItemController : ControllerBase
  {
    [HttpGet]
    public ActionResult<IEnumerable<Item>> GetAllItems()
    {
      var context = new DatabaseContext();
      var theThing = context.Items.OrderByDescending(i => i.Id);
      return theThing.ToList();
    }

    [HttpGet("{Id}")]
    public ActionResult GetOneItem(int Id)
    {
      var context = new DatabaseContext();
      var OneItem = context.Items.FirstOrDefault(i => i.Id == Id);
      if (OneItem != null)
      {
        return Ok(OneItem);
      }
      else
      {
        return NotFound();
      }
    }

    [HttpPost]
    public ActionResult<Item> CreateItem([FromBody]Item entry)
    {
      var context = new DatabaseContext();
      context.Items.Add(entry);
      context.SaveChanges();
      return entry;
    }

    [HttpPut("{Id}")]
    public ActionResult<Item> PutItem(int Id, [FromBody]Item entry)
    {
      var context = new DatabaseContext();
      context.Items.Add(entry);
      context.SaveChanges();
      return entry;

    }

    [HttpDelete("{Id}")]
    public ActionResult DeleteItem(int Id)
    {
      return Ok(Id);
    }

    [HttpGet]
    public ActionResult<IEnumerable<Item>> GetOutOfStock()
    {
      var context = new DatabaseContext();
      var theThing = context.Items.OrderByDescending(i => i.NumberInStock == 0);
      return theThing.ToList();
    }
  }
}