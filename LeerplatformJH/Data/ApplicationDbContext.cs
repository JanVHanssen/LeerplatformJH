using LeerplatformJH.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LeerplatformJH.Models.ViewModels;

namespace LeerplatformJH.Data
{
    public class ApplicationDbContext : IdentityDbContext<Gebruiker>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Vak> Vakken { get; set; }
        public DbSet<VakInschrijving> VakInschrijvingen { get; set; }
        public DbSet<Student> Studenten { get; set; }
        public DbSet<Lokaal> Lokalen { get; set; }
        public DbSet<Docent> Docenten { get; set; }
        public DbSet<Les> Lessen { get; set; }
        public DbSet<Administrator> Administratoren { get; set; }
        public DbSet<StudentLessen> StudentLessen { get; set; }
        public DbSet<StudentInschrijvingen> StudentInschrijvingen { get; set; }
        public DbSet<Gebruiker> gebruikers { get; set; }
        public DbSet<StudentLessen> studentLessen { get; set; }
        public DbSet<StudentInschrijvingen> studentInschrijvingen { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vak>().ToTable("Vak");
            modelBuilder.Entity<VakInschrijving>().ToTable("Inschrijving");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Lokaal>().ToTable("Lokaal");
            modelBuilder.Entity<Docent>().ToTable("Docent");
            modelBuilder.Entity<Les>().ToTable("Les");
            modelBuilder.Entity<Administrator>().ToTable("Administrator");
            modelBuilder.Entity<Gebruiker>().ToTable("Gebruiker");


            var gebruikers = new Gebruiker[]
            {
                   new Gebruiker { GebruikerId = 1, Voornaam = "Bart", Achternaam = "Peters", Email = "Bart.Peters@Hotmail.com"}
            };
         var studenten = new Student[]
            {
                new Student { StudentId = 1, Voornaam = "Jan",   Achternaam = "Hanssen", Email = "Jan.Hanssen@hotmail.com",
                    Inschrijvingsdatum = DateTime.Parse("2020-09-01") },
                new Student { StudentId = 2, Voornaam = "Wim", Achternaam = "Billen", Email = "Wim.Billen@hotmail.com",
                    Inschrijvingsdatum = DateTime.Parse("2021-09-01") },
                new Student { StudentId = 3, Voornaam = "Anne",   Achternaam = "Broekmans", Email = "Anne.Broekmans@hotmail.com",
                    Inschrijvingsdatum = DateTime.Parse("2022-09-01") },
                new Student { StudentId = 4, Voornaam = "Sara",    Achternaam = "Putzeys", Email = "Sara.Putzeys@hotmail.com",
                    Inschrijvingsdatum = DateTime.Parse("2019-09-01") },
                new Student { StudentId = 5, Voornaam = "Steven",      Achternaam = "Grosemans", Email = "Steven.Grosemans@hotmail.com",
                    Inschrijvingsdatum = DateTime.Parse("2023-09-01") },
                new Student { StudentId = 6, Voornaam = "Elke",    Achternaam = "Vandeplas", Email = "Elke.Vandeplas@hotmail.com",
                    Inschrijvingsdatum = DateTime.Parse("2022-09-01") },
                new Student { StudentId = 7, Voornaam = "Laura",    Achternaam = "Janssen", Email = "Laura.Janssen@hotmail.com",
                    Inschrijvingsdatum = DateTime.Parse("2023-09-01") },
                new Student { StudentId = 8, Voornaam = "Willem",     Achternaam = "Omloop", Email = "Willem.Omloop@hotmail.com",
                    Inschrijvingsdatum = DateTime.Parse("2022-09-01") }
            };

            var docenten = new Docent[]
            {
                new Docent { DocentId = 1, Voornaam = "Kim",     Achternaam = "Vanneste", Email = "Kim.Vanneste@Ucll.be",
                    Indiensttreding = DateTime.Parse("2015-03-11") },
                new Docent { DocentId = 2, Voornaam = "Jurgen",    Achternaam = "Achten", Email = "Jurgen.Achten@Ucll.be",
                    Indiensttreding = DateTime.Parse("2012-07-06") },
                new Docent { DocentId = 3, Voornaam = "Roger",   Achternaam = "Smets", Email = "Roger.Smets@Ucll.be",
                    Indiensttreding = DateTime.Parse("2020-07-01") },
                new Docent { DocentId = 4, Voornaam = "Lotte", Achternaam = "Knopper", Email = "Lotte.Knopper@Ucll.be",
                    Indiensttreding = DateTime.Parse("2019-01-15") },
                new Docent { DocentId = 5, Voornaam = "Maarten",   Achternaam = "Colson", Email = "Maarten.Colson@Ucll.be",
                    Indiensttreding = DateTime.Parse("2012-02-12") }
            };

            var lokalen = new Lokaal[]
            {
                new Lokaal { LokaalId = 1, Titel = "Heverlee kleine zaal", Omschrijving = "Stationstraat 2, 3001 Heverlee", Capaciteit = 40, Middelen = "Whiteboard" },
                new Lokaal { LokaalId = 2, Titel = "Heverlee grote zaal", Omschrijving = "Stationstraat 2, 3001 Heverlee", Capaciteit = 60, Middelen = "Projector, Micro, Whiteboard"},
                new Lokaal { LokaalId = 3, Titel = "Leuven kleine zaal 1", Omschrijving = "Nieuwstraat 8, 3000 Leuven", Capaciteit = 30, Middelen = "Whiteboard"},
                new Lokaal { LokaalId = 4, Titel = "Leuven grote zaal", Omschrijving = "Nieuwstraat 8, 3000 Leuven", Capaciteit = 70, Middelen = "Projector, Micro, Whiteboard"},
                new Lokaal { LokaalId = 5, Titel = "Leuven kleine zaal 2", Omschrijving = "Nieuwstraat 8, 3000 Leuven", Capaciteit = 35, Middelen = "Whiteboard"}
            };

            var vakken = new Vak[]
            {
                new Vak { VakId = 1, Titel = "Engels", Studiepunten = 4,
                DocentId = docenten.Single( d => d.Achternaam == "Vanneste").DocentId },
                new Vak { VakId = 2, Titel = "Wiskunde", Studiepunten = 4,
                DocentId = docenten.Single( d => d.Achternaam == "Achten").DocentId },
                new Vak { VakId = 3, Titel = "Nederlands", Studiepunten = 3,
                DocentId = docenten.Single( d => d.Achternaam == "Smets").DocentId },
                new Vak { VakId = 4, Titel = "Economie",   Studiepunten = 3,
                DocentId = docenten.Single( d => d.Achternaam == "Knopper").DocentId },
                new Vak { VakId = 5, Titel = "Frans", Studiepunten = 4,
                DocentId = docenten.Single( d => d.Achternaam == "Colson").DocentId }
            };

            var administratoren = new Administrator[]
            {
                new Administrator { AdministratorId = 1, Voornaam = "Fons", Achternaam = "Janssens", Email = "Janssens.Fons@Ucll.be",
                    Indiensttreding = DateTime.Parse("2010-09-01") },
                new Administrator { AdministratorId = 2, Voornaam = "Tom", Achternaam = "Vandenbroek", Email = "Vandenbroek.Tom@Ucll.be",
                    Indiensttreding = DateTime.Parse("2012-09-01") },
                new Administrator { AdministratorId = 3, Voornaam = "Artuur", Achternaam = "Willems", Email = "Willems.Artuur@Ucll.be",
                    Indiensttreding = DateTime.Parse("2013-09-01") },
            };
            
            var vakInschrijvingen = new VakInschrijving[]
            {
                new VakInschrijving { VakInschrijvingId = 1, Titel = "Jan Hanssen Nederlands 2023",
                    StudentId = studenten.Single( s => s.Achternaam == "Hanssen").StudentId,
                    VakId = vakken.Single( v => v.Titel == "Nederlands").VakId },
                new VakInschrijving { VakInschrijvingId = 2, Titel = "Jan Hanssen Wiskunde 2023",
                    StudentId = studenten.Single( s => s.Achternaam == "Hanssen").StudentId,
                    VakId = vakken.Single( v => v.Titel == "Wiskunde").VakId,
                    },
                new VakInschrijving { VakInschrijvingId = 3, Titel = "Jan Hanssen Engels 2023",
                    StudentId = studenten.Single( s => s.Achternaam == "Hanssen").StudentId,
                    VakId = vakken.Single( v => v.Titel == "Engels").VakId,
                    },
                new VakInschrijving { VakInschrijvingId = 4, Titel = "Wim Billen Engels 2023",
                    StudentId = studenten.Single( s => s.Achternaam == "Billen").StudentId,
                    VakId = vakken.Single( v => v.Titel == "Engels").VakId,
                    },
                new VakInschrijving { VakInschrijvingId = 5, Titel = "Wim Billen Frans 2023",
                    StudentId = studenten.Single( s => s.Achternaam == "Billen").StudentId,
                    VakId = vakken.Single( v => v.Titel == "Frans").VakId,
                    },
                new VakInschrijving { VakInschrijvingId = 6, Titel = "Wim Billen Nederlands 2023",
                    StudentId = studenten.Single(s => s.Achternaam == "Billen").StudentId,
                    VakId = vakken.Single(v => v.Titel == "Nederlands").VakId,
                    },
                new VakInschrijving { VakInschrijvingId = 7, Titel = "Anne Broekmans Economie 2023",
                    StudentId = studenten.Single( s => s.Achternaam == "Broekmans").StudentId,
                    VakId = vakken.Single( v => v.Titel == "Economie").VakId,
                    },
                new VakInschrijving { VakInschrijvingId = 8, Titel = "Anne Broekmans Wiskunde 2023",
                    StudentId = studenten.Single(s => s.Achternaam == "Broekmans").StudentId, 
                    VakId = vakken.Single(v => v.Titel == "Wiskunde").VakId,
                    },
                new VakInschrijving { VakInschrijvingId = 9, Titel = "Anne Broekmans Engels 2023",
                    StudentId = studenten.Single(s => s.Achternaam == "Broekmans").StudentId, 
                    VakId = vakken.Single(v => v.Titel == "Engels").VakId,
                    },
                new VakInschrijving { VakInschrijvingId = 10, Titel = "Sara Putzeys Engels 2023",
                    StudentId = studenten.Single(s => s.Achternaam == "Putzeys").StudentId, 
                    VakId = vakken.Single(v => v.Titel == "Engels").VakId,
                    },
                new VakInschrijving { VakInschrijvingId = 11, Titel = "Sara Putzeys Frans 2023",
                    StudentId = studenten.Single(s => s.Achternaam == "Putzeys").StudentId, 
                    VakId = vakken.Single(v => v.Titel == "Frans").VakId,
                    },
                new VakInschrijving { VakInschrijvingId = 12, Titel = "Sara Putzeys Nederlands 2023",
                    StudentId = studenten.Single(s => s.Achternaam == "Putzeys").StudentId,
                    VakId = vakken.Single(v => v.Titel == "Nederlands").VakId,
                    },
                new VakInschrijving { VakInschrijvingId = 13, Titel = "Steven Grosemans Wiskunde 2023",
                    StudentId = studenten.Single(s => s.Achternaam == "Grosemans").StudentId, 
                    VakId = vakken.Single(v => v.Titel == "Wiskunde").VakId,
                    },
                new VakInschrijving { VakInschrijvingId = 14, Titel = "Steven Grosemans Economie 2023",
                    StudentId = studenten.Single(s => s.Achternaam == "Grosemans").StudentId,
                    VakId = vakken.Single(v => v.Titel == "Economie").VakId,
                    },
                new VakInschrijving { VakInschrijvingId = 15, Titel = "Steven Grosemans Frans 2023",
                    StudentId = studenten.Single(s => s.Achternaam == "Grosemans").StudentId,
                    VakId = vakken.Single(v => v.Titel == "Frans").VakId,
                    },
                new VakInschrijving { VakInschrijvingId = 16, Titel = "Elke Vandeplas Engels 2023",
                    StudentId = studenten.Single(s => s.Achternaam == "Vandeplas").StudentId,
                    VakId = vakken.Single(v => v.Titel == "Engels").VakId,
                    },
                new VakInschrijving { VakInschrijvingId = 17, Titel = "Elke Vandeplas Nederlands 2023",
                    StudentId = studenten.Single( s => s.Achternaam == "Vandeplas").StudentId,
                    VakId = vakken.Single( v => v.Titel == "Nederlands").VakId,
                    },
                new VakInschrijving { VakInschrijvingId = 18, Titel = "Elke Vandeplas Frans 2023",
                    StudentId = studenten.Single(s => s.Achternaam == "Vandeplas").StudentId,
                    VakId = vakken.Single(v => v.Titel == "Frans").VakId,
                    },
                new VakInschrijving { VakInschrijvingId = 19, Titel = "Laura Janssen Wiskunde 2023",
                    StudentId = studenten.Single(s => s.Achternaam == "Janssen").StudentId,
                    VakId = vakken.Single(v => v.Titel == "Wiskunde").VakId,
                    },
                new VakInschrijving { VakInschrijvingId = 20, Titel = "Laura Janssen Economie 2023",
                    StudentId = studenten.Single(s => s.Achternaam == "Janssen").StudentId,
                    VakId = vakken.Single(v => v.Titel == "Economie").VakId,
                    },
                new VakInschrijving { VakInschrijvingId = 21, Titel = "Laura Janssen Nederlands 2023",
                    StudentId = studenten.Single(s => s.Achternaam == "Janssen").StudentId, 
                    VakId = vakken.Single(v => v.Titel == "Nederlands").VakId,
                    },
                new VakInschrijving { VakInschrijvingId = 22, Titel = "Willem Omloop Engels 2023",
                    StudentId = studenten.Single(s => s.Achternaam == "Omloop").StudentId,
                    VakId = vakken.Single(v => v.Titel == "Engels").VakId,
                    },
                new VakInschrijving { VakInschrijvingId = 23, Titel = "Willem Omloop Frans 2023",
                    StudentId = studenten.Single( s => s.Achternaam == "Omloop").StudentId,
                    VakId = vakken.Single( v => v.Titel == "Frans").VakId,
                    },
                new VakInschrijving { VakInschrijvingId = 24, Titel = "Willem Omloop Wiskunde 2023",
                    StudentId = studenten.Single(s => s.Achternaam == "Omloop").StudentId,
                    VakId = vakken.Single(v => v.Titel == "Wiskunde").VakId,
                    },
            };

            var lessen = new Les[]
            {
                new Les { LesId = 1, Titel = "Wiskunde1A", Omschrijving = "Introductie tot de lineaire algebra", TijdstipStart = DateTime.Parse("2023-09-23T09:00:00"), TijdstipEinde = DateTime.Parse("2023-09-23T10:30:00"),
                    LokaalId = lokalen.Single( l => l.Titel == "Heverlee kleine zaal").LokaalId
                },

                new Les { LesId = 2, Titel = "Economie1B", Omschrijving = "Marxisme", TijdstipStart = DateTime.Parse("2023-09-24T09:00:00"), TijdstipEinde = DateTime.Parse("2023-09-24T10:30:00"),
                    LokaalId = lokalen.Single( l => l.Titel == "Heverlee grote zaal").LokaalId

                },
                new Les { LesId = 3, Titel = "Nederlands1A", Omschrijving = "Het lijdend voorwerp", TijdstipStart = DateTime.Parse("2023-09-25T09:00:00"), TijdstipEinde = DateTime.Parse("2023-09-25T10:30:00"),
                    LokaalId = lokalen.Single( l => l.Titel == "Leuven kleine zaal 1").LokaalId

                },
                new Les { LesId = 4, Titel = "Nederlands1B", Omschrijving = "Het meewerkend voorwerp", TijdstipStart = DateTime.Parse("2023-09-26T09:00:00"), TijdstipEinde = DateTime.Parse("2023-09-26T10:30:00"),
                    LokaalId = lokalen.Single( l => l.Titel == "Leuven kleine zaal 2").LokaalId

                },
                new Les { LesId = 5, Titel = "Engels1A", Omschrijving = "Inleiding", TijdstipStart = DateTime.Parse("2023-09-27T09:00:00"), TijdstipEinde = DateTime.Parse("2023-09-27T10:30:00"),
                    LokaalId = lokalen.Single( l => l.Titel == "Leuven grote zaal").LokaalId

                },
                new Les { LesId = 6, Titel = "Engels1B", Omschrijving = "Pronunciation", TijdstipStart = DateTime.Parse("2023-09-28T09:00:00"), TijdstipEinde = DateTime.Parse("2023-09-28T10:30:00"),
                    LokaalId = lokalen.Single( l => l.Titel == "Heverlee kleine zaal").LokaalId

                },
                new Les { LesId = 7, Titel = "Economie1A", Omschrijving = "Wat is economie?", TijdstipStart = DateTime.Parse("2023-09-29T09:00:00"), TijdstipEinde = DateTime.Parse("2029-09-23T10:30:00"),
                    LokaalId = lokalen.Single( l => l.Titel == "Heverlee kleine zaal").LokaalId

                },
            };

            modelBuilder.Entity<Student>().HasData(studenten);
            modelBuilder.Entity<Docent>().HasData(docenten);
            modelBuilder.Entity<Lokaal>().HasData(lokalen);
            modelBuilder.Entity<Vak>().HasData(vakken);
            modelBuilder.Entity<Administrator>().HasData(administratoren);
            modelBuilder.Entity<VakInschrijving>().HasData(vakInschrijvingen);
            modelBuilder.Entity<Les>().HasData(lessen);

 


            base.OnModelCreating(modelBuilder);
        
        }

       
    }
}
