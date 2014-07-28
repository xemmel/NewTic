using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TicItNow.Web.Models
{
  public class Symbol
  {
    public int SymbolId { get; set; }
        [DisplayName("Symbol")]
    public string Name { get; set; }
  }
}