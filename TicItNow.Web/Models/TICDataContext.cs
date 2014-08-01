using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TicItNow.Web.Models
{
  public class TICDataContext : DbContext
  {
    public TICDataContext() :base("name=TICContext") {}


    public DbSet<Unit> Units { get; set; }
    public DbSet<Symbol> Symbols { get; set; }
    public DbSet<AnalysisParam> AnalysisParams { get; set; }
    public DbSet<Customer> Customers { get; set; }


  }
}