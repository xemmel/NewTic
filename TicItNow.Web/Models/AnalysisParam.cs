using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicItNow.Web.Models
{
  public class AnalysisParam
  {
    public int AnalysisParamId { get; set; }
    public string Name { get; set; }
    public int? MinValue { get; set; }
    public int? MaxValue { get; set; }

    public int? UnitId { get; set; }
    [ForeignKey("UnitId")]
    public virtual Unit Unit { get; set; }

    public int? SymbolId { get; set; }
    [ForeignKey("SymbolId")]
    public virtual Symbol Symbol { get; set; }


  }
}