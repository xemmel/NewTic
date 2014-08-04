using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicItNow.Web.Models
{
  public class Customer
  {
    public int CustomerId { get; set; }
    public string Name { get; set; }
    public int CustomerType { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime? ValidTo { get; set; }

    public bool IsActive { get {
      DateTime now = DateTime.Now;
      bool hasStarted = (ValidFrom <= now);
      bool hasEnded = (ValidTo == null) ? false : (ValidTo < now);
      return ((hasStarted) && (!hasEnded));
    } }
  }
}