using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using inventory_all_the_things.Models;

namespace inventory_all_the_things.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ItemController : ControllerBase
  {
    [HttpGet]
    public ActionResult<IOrderedEnumerable> GetAllItems()
    {
      var context = new DatabaseContext();
      var theThing = context.Items.FirstOrDefault(i => i.Id == Id);
      if (theThing == null)
      {
        return NotFound();
      }
      else
      {
        return theThing;
      }

    }
  }
}