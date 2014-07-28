using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TicItNow.Web.Models
{
  public class Unit
  {
    public int UnitId { get; set; }
    [DisplayName("SI Unit")]
    public string Name { get; set; }
  }
}