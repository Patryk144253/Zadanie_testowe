using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZAdanie_testowe.Models
{
    public class Przejsciowa
    {
        [Key]
        public int Id { get; set; }

        public int RezerwacjaId { get; set; }

        public Rezerwacja Rezerwacja { get; set; }

        public int GoscId { get; set; }

        public Gosc Gosc { get; set; }
    }
}