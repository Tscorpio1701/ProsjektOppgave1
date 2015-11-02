using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ProsjektOppgave1.Models
{
    public class Bestilling
    {
        [Key]
        public int BestillingID { get; set; }

        public System.DateTime OrdreDato { get; set; }

        public decimal Total { get; set; }

        public virtual List<Vare> Varer { get; set; }
        
    }
}