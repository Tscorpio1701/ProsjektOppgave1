using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProsjektOppgave1.Models
{
    public class Vare
    {
        [Key]
        public int ID { get; set; }
        public string Varenavn { get; set; }
        public int Pris { get; set; }
        public int Varebeholdning { get; set; }

    }

    
}