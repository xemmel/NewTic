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
  }
}