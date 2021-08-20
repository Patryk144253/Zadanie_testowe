using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZAdanie_testowe.Models
{
    public class Rezerwacja
    {
        [StringLength(10)]
        [Required]
        public string Kod_rezerwacji { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Data_utworzenia { get; set; }

        [Required]
        [Range(0,100)]
        public decimal Cena { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Data_zameldowania { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Data_wymeldowania { get; set; }

        [Required]
        public string Waluta { get; set; }

        [Required]
        public int ID { get; set; }

        [Range(0, 100)]
        public decimal Prowizja { get; set; }

        public string Zrodlo { get; set; }

        public ICollection<Przejsciowa> Przejsciowa { get; set; }
    }
}