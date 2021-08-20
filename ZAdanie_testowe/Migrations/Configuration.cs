namespace ZAdanie_testowe.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ZAdanie_testowe.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ZAdanie_testowe.Data.AplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }


        protected override void Seed(ZAdanie_testowe.Data.AplicationDbContext context) 
        {
            var rezerwacja = new List<Rezerwacja>
            {
                new Rezerwacja { Kod_rezerwacji="Rez1",Data_utworzenia=DateTime.Parse("15-08-2021"),Cena=decimal.Parse("10,0"),Data_zameldowania=DateTime.Parse("15-08-2021"),Data_wymeldowania=DateTime.Parse("17-08-2021"),Waluta="PLN",ID=1,Prowizja=decimal.Parse("0,0"),Zrodlo="brak"},
                new Rezerwacja { Kod_rezerwacji="Rez2",Data_utworzenia=DateTime.Parse("15-08-2021"),Cena=decimal.Parse("10,0"),Data_zameldowania=DateTime.Parse("15-08-2021"),Data_wymeldowania=DateTime.Parse("17-08-2021"),Waluta="PLN",ID=2,Prowizja=decimal.Parse("0,0"),Zrodlo="brak"},
                new Rezerwacja { Kod_rezerwacji="Rez3",Data_utworzenia=DateTime.Parse("15-08-2021"),Cena=decimal.Parse("10,0"),Data_zameldowania=DateTime.Parse("15-08-2021"),Data_wymeldowania=DateTime.Parse("17-08-2021"),Waluta="PLN",ID=3,Prowizja=decimal.Parse("0,0"),Zrodlo="brak"}
            };

            rezerwacja.ForEach(r => context.Rezerwacja.Add(r));
            context.SaveChanges();
            

            var gosc = new List<Gosc>
            {
                new Gosc {Imie="Piotr",Nazwisko="Nazwisko1",Email="Osoba1@gmail.com",Data_urodzenia=DateTime.Parse("01-01-1993"),Kod_Pocztowy="97-565",NrTel=369852147,Adres=null,Miasto="Wrocław" },
                new Gosc {Imie="Piotr",Nazwisko="Nazwisko2",Email="Osoba2@gmail.com",Data_urodzenia=DateTime.Parse("02-01-1993"),Kod_Pocztowy="97-565",NrTel=369852147,Adres=null,Miasto=null },
                new Gosc {Imie="Imie3",Nazwisko="Nazwisko3",Email="Osoba3@gmail.com",Data_urodzenia=DateTime.Parse("03-01-1993"),Kod_Pocztowy="97-565",NrTel=369852147,Adres=null,Miasto=null }
            };

            gosc.ForEach(g => context.Gosc.Add(g));
            context.SaveChanges();

        }
    }
}
