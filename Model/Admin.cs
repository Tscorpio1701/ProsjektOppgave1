using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProsjektOppgave1.Models
{
    public class Admin
    {
        [Required(ErrorMessage = "Brukenavn må oppgis!")]
        public string Brukernavn { get; set; }   
        [Required(ErrorMessage = "Passord må oppgis")]
        public string Passord { get; set; }
    }

}