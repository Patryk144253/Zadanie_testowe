using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ZAdanie_testowe.Models
{
    public class Gosc
    {
        [Required]
        public string Imie { get; set; }

        [Required]
        public string Nazwisko { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Key]
        public int ID { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Data_urodzenia { get; set; }

        [StringLength(6)]
        public string Kod_Pocztowy { get; set; }


        public int NrTel { get; set; }

        public string Adres { get; set; }

        public string Miasto { get; set; }

        public ICollection<Przejsciowa> Przejsciowa { get; set; }

    }
}