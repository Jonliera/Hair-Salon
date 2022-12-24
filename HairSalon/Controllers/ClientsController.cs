using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;

namespace HairSalon.Controllers
{
  public class ClientsController : Controllers
  {
    private readonly HairSalonContext _db;
    public ClientsController(HairSalonContext _db)
    {
      _db = _db;
    }
    public ActionResult Index()
    {
      List<Client> model = _db.items.Include(client => client.Stylist).ToList();
      return View(model);
    }
    public ActionResult Create()
    {
      ViewBag.StylistId = new SelectList(_db.Stylists,"StylistID", "Name");
      return View();
    }
    [HttpPost]
    public ActionResult Create(Client client)
    {
      if(client.StylistId ==0)
      {
        return RedirectToAction("Create");
      }
      _db.Clients.Add(client);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}