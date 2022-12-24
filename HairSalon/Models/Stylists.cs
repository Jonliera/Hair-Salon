using System.Collections.Generic;

namespace HairSalon.Models
{
  public class Stylists
  {
    public int StylistId { get; set; }
    public string Name { get; set; }
    public List<Client> Clients{ get; set; }
  }
}