
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LeerplatformJH.Models;
using LeerplatformJH.Data;

namespace LeerplatformJH.Data
{
    /*public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            //context.Database.EnsureCreated();

            // Look for any students.
            if (context.Studenten.Any())
            {
                return;   // DB has been seeded
            }

            var studenten = new Student[]
            {
                new Student { Voornaam = "Jan",   Achternaam = "Hanssen", Email = "Jan.Hanssen@hotmail.com",
                    Inschrijvingsdatum = DateTime.Parse("2020-09-01") },
                new Student { Voornaam = "Wim", Achternaam = "Billen", Email = "Wim.Billen@hotmail.com",
                    Inschrijvingsdatum = DateTime.Parse("2021-09-01") },
                new Student { Voornaam = "Anne",   Achternaam = "Broekmans", Email = "Anne.Broekmans@hotmail.com",
                    Inschrijvingsdatum = DateTime.Parse("2022-09-01") },
                new Student { Voornaam = "Sara",    Achternaam = "Putzeys", Email = "Sara.Putzeys@hotmail.com",
                    Inschrijvingsdatum = DateTime.Parse("2019-09-01") },
                new Student { Voornaam = "Steven",      Achternaam = "Grosemans", Email = "Steven.Grosemans@hotmail.com",
                    Inschrijvingsdatum = DateTime.Parse("2023-09-01") },
                new Student { Voornaam = "Elke",    Achternaam = "Vandeplas", Email = "Elke.Vandeplas@hotmail.com",
                    Inschrijvingsdatum = DateTime.Parse("2022-09-01") },
                new Student { Voornaam = "Laura",    Achternaam = "Janssen", Email = "Laura.Janssen@hotmail.com",
                    Inschrijvingsdatum = DateTime.Parse("2023-09-01") },
                new Student { Voornaam = "Willem",     Achternaam = "Omloop", Email = "Willem.Omloop@hotmail.com",
                    Inschrijvingsdatum = DateTime.Parse("2022-09-01") }
            };

            foreach (Student s in studenten)
            {
                context.Studenten.Add(s);
            }
            context.SaveChanges();

            var docenten = new Docent[]
            {
                new Docent { Voornaam = "Kim",     Achternaam = "Vanneste", Email = "Kim.Vanneste@Ucll.be",
                    Indiensttreding = DateTime.Parse("2015-03-11") },
                new Docent { Voornaam = "Jurgen",    Achternaam = "Achten", Email = "Jurgen.Achten@Ucll.be",
                    Indiensttreding = DateTime.Parse("2012-07-06") },
                new Docent { Voornaam = "Roger",   Achternaam = "Smets", Email = "Roger.Smets@Ucll.be",
                    Indiensttreding = DateTime.Parse("2020-07-01") },
                new Docent { Voornaam = "Lotte", Achternaam = "Knopper", Email = "Lotte.Knopper@Ucll.be",
                    Indiensttreding = DateTime.Parse("2019-01-15") },
                new Docent { Voornaam = "Maarten",   Achternaam = "Colson", Email = "Maarten.Colson@Ucll.be",
                    Indiensttreding = DateTime.Parse("2012-02-12") }
            };

            foreach (Docent i in docenten)
            {
                context.Docenten.Add(i);
            }
            context.SaveChanges();

            var lokalen = new Lokaal[]
           {
                new Lokaal { Titel = "Heverlee kleine zaal", Omschrijving = "Stationstraat 2, 3001 Heverlee", Capaciteit = 40, Middelen = "Whiteboard" },
                new Lokaal { Titel = "Heverlee grote zaal", Omschrijving = "Stationstraat 2, 3001 Heverlee", Capaciteit = 60, Middelen = "Projector, Micro, Whiteboard"},
                new Lokaal { Titel = "Leuven kleine zaal 1", Omschrijving = "Nieuwstraat 8, 3000 Leuven", Capaciteit = 30, Middelen = "Whiteboard"},
                new Lokaal { Titel = "Leuven grote zaal", Omschrijving = "Nieuwstraat 8, 3000 Leuven", Capaciteit = 70, Middelen = "Projector, Micro, Whiteboard"},
                new Lokaal { Titel = "Leuven kleine zaal 2", Omschrijving = "Nieuwstraat 8, 3000 Leuven", Capaciteit = 35, Middelen = "Whiteboard"}
           };

            foreach (Docent i in docenten)
            {
                context.Docenten.Add(i);
            }
            context.SaveChanges();

            var vakken = new Vak[]
            {
                new Vak { Titel = "Engels", Studiepunten = 4, 
                DocentId = docenten.Single( d => d.Achternaam == "Vanneste").DocentId },
                new Vak { Titel = "Wiskunde", Studiepunten = 4,
                DocentId = docenten.Single( d => d.Achternaam == "Achten").DocentId },
                new Vak { Titel = "Nederlands", Studiepunten = 3,
                DocentId = docenten.Single( d => d.Achternaam == "Smets").DocentId },
                new Vak { Titel = "Economie",   Studiepunten = 3,
                DocentId = docenten.Single( d => d.Achternaam == "Knopper").DocentId },
                new Vak { Titel = "Frans", Studiepunten = 4,
                DocentId = docenten.Single( d => d.Achternaam == "Colson").DocentId }
            };

            foreach (Vak d in vakken)
            {
                context.Vakken.Add(d);
            }
            context.SaveChanges();

            var administratoren = new Administrator[]
           {
                new Administrator { Voornaam = "Fons",   Achternaam = "Janssens", Email = "Janssens.Fons@Ucll.be",
                    Indiensttreding = DateTime.Parse("2010-09-01") },
                new Administrator { Voornaam = "Tom", Achternaam = "Vandenbroek", Email = "Vandenbroek.Tom@Ucll.be",
                    Indiensttreding = DateTime.Parse("2012-09-01") },
                new Administrator { Voornaam = "Artuur",   Achternaam = "Willems", Email = "Willems.Artuur@Ucll.be",
                    Indiensttreding = DateTime.Parse("2013-09-01") },
           };

            foreach (Student s in studenten)
            {
                context.Studenten.Add(s);
            }
            context.SaveChanges();

            var vakInschrijvingen = new VakInschrijving[]
           {
                new VakInschrijving { Titel = "Jan Hanssen Nederlands 2023",
                    StudentId = studenten.Single( s => s.Achternaam == "Hanssen").StudentId,
                    VakId = vakken.Single( v => v.Titel == "Nederlands").VakId },
                new VakInschrijving { Titel = "Jan Hanssen Wiskunde 2023",
                    StudentId = studenten.Single( s => s.Achternaam == "Hanssen").StudentId,
                    VakId = vakken.Single( v => v.Titel == "Wiskunde").VakId,
                    },
                new VakInschrijving { Titel = "Jan Hanssen Engels 2023",
                    StudentId = studenten.Single( s => s.Achternaam == "Hanssen").StudentId,
                    VakId = vakken.Single( v => v.Titel == "Engels").VakId,
                    },
                new VakInschrijving { Titel = "Wim Billen Engels 2023",
                    StudentId = studenten.Single( s => s.Achternaam == "Billen").StudentId,
                    VakId = vakken.Single( v => v.Titel == "Engels").VakId,
                    },
                new VakInschrijving { Titel = "Wim Billen Frans 2023",
                    StudentId = studenten.Single( s => s.Achternaam == "Billen").StudentId,
                    VakId = vakken.Single( v => v.Titel == "Frans").VakId,
                    },
                new VakInschrijving { Titel = "Wim Billen Nederlands 2023",
                    StudentId = studenten.Single( s => s.Achternaam == "Billen").StudentId,
                    VakId = vakken.Single( v => v.Titel == "Nederlands").VakId,
                    },
                new VakInschrijving { Titel = "Anne Broekmans Economie 2023",
                    StudentId = studenten.Single( s => s.Achternaam == "Broekmans").StudentId,
                    VakId = vakken.Single( v => v.Titel == "Economie").VakId,
                    },
                new VakInschrijving {  Titel = "Anne Broekmans Wiskunde 2023",
                    StudentId = studenten.Single( s => s.Achternaam == "Broekmans").StudentId,
                    VakId = vakken.Single( v => v.Titel == "Wiskunde").VakId,
                    },
                new VakInschrijving {  Titel = "Anne Broekmans Engels 2023",
                    StudentId = studenten.Single( s => s.Achternaam == "Broekmans").StudentId,
                    VakId = vakken.Single( v => v.Titel == "Engels").VakId,
                    },
                new VakInschrijving {  Titel = "Sara Putzeys Engels 2023",
                    StudentId = studenten.Single( s => s.Achternaam == "Putzeys").StudentId,
                    VakId = vakken.Single( v => v.Titel == "Engels").VakId,
                    },
                new VakInschrijving { Titel = "Sara Putzeys Frans 2023",
                    StudentId = studenten.Single( s => s.Achternaam == "Putzeys").StudentId,
                    VakId = vakken.Single( v => v.Titel == "Frans").VakId,
                    },
                new VakInschrijving { Titel = "Sara Putzeys Nederlands 2023",
                    StudentId = studenten.Single( s => s.Achternaam == "Putzeys").StudentId,
                    VakId = vakken.Single( v => v.Titel == "Nederlands").VakId,
                    },
                new VakInschrijving { Titel = "Steven Grosemans Wiskunde 2023",
                    StudentId = studenten.Single( s => s.Achternaam == "Grosemans").StudentId,
                    VakId = vakken.Single( v => v.Titel == "Wiskunde").VakId,
                    },
                new VakInschrijving { Titel = "Steven Grosemans Economie 2023",
                    StudentId = studenten.Single( s => s.Achternaam == "Grosemans").StudentId,
                    VakId = vakken.Single( v => v.Titel == "Economie").VakId,
                    },
                new VakInschrijving { Titel = "Steven Grosemans Frans 2023",
                    StudentId = studenten.Single( s => s.Achternaam == "Grosemans").StudentId,
                    VakId = vakken.Single( v => v.Titel == "Frans").VakId,
                    },
                new VakInschrijving { Titel = "Elke Vandeplas Engels 2023",
                    StudentId = studenten.Single( s => s.Achternaam == "Vandeplas").StudentId,
                    VakId = vakken.Single( v => v.Titel == "Engels").VakId,
                    },
                new VakInschrijving { Titel = "Elke Vandeplas Nederlands 2023",
                    StudentId = studenten.Single( s => s.Achternaam == "Vandeplas").StudentId,
                    VakId = vakken.Single( v => v.Titel == "Nederlands").VakId,
                    },
                new VakInschrijving { Titel = "Elke Vandeplas Frans 2023",
                    StudentId = studenten.Single( s => s.Achternaam == "Vandeplas").StudentId,
                    VakId = vakken.Single( v => v.Titel == "Frans").VakId,
                    },
                new VakInschrijving { Titel = "Laura Janssen Wiskunde 2023",
                    StudentId = studenten.Single( s => s.Achternaam == "Janssen").StudentId,
                    VakId = vakken.Single( v => v.Titel == "Wiskunde").VakId,
                    },
                new VakInschrijving { Titel = "Laura Janssen Economie 2023",
                    StudentId = studenten.Single( s => s.Achternaam == "Janssen").StudentId,
                    VakId = vakken.Single( v => v.Titel == "Economie").VakId,
                    },
                new VakInschrijving { Titel = "Laura Janssen Nederlands 2023",
                    StudentId = studenten.Single( s => s.Achternaam == "Janssen").StudentId,
                    VakId = vakken.Single( v => v.Titel == "Nederlands").VakId,
                    },
                new VakInschrijving { Titel = "Willem Omloop Engels 2023",
                    StudentId = studenten.Single( s => s.Achternaam == "Omloop").StudentId,
                    VakId = vakken.Single( v => v.Titel == "Engels").VakId,
                    },
                new VakInschrijving { Titel = "Willem Omloop Frans 2023",
                    StudentId = studenten.Single( s => s.Achternaam == "Omloop").StudentId,
                    VakId = vakken.Single( v => v.Titel == "Frans").VakId,
                    },
                new VakInschrijving { Titel = "Willem Omloop Wiskunde 2023",
                    StudentId = studenten.Single( s => s.Achternaam == "Omloop").StudentId,
                    VakId = vakken.Single( v => v.Titel == "Wiskunde").VakId,
                    },

           };

            foreach (VakInschrijving v in vakInschrijvingen)
            {
                context.VakInschrijvingen.Add(v);
            }
            context.SaveChanges();

            var lessen = new Les[]
            {
                new Les {Titel = "Wiskunde1A", Omschrijving = "Introductie tot de lineaire algebra", TijdstipStart = DateTime.Parse("2023,09,23,9,00,0"), TijdstipEinde = DateTime.Parse("2023,09,23,10,30,0"),
                    LokaalId = lokalen.Single( l => l.Titel == "Heverlee kleine zaal").LokaalId
                },

                new Les {Titel = "Economie1B", Omschrijving = "Marxisme", TijdstipStart = DateTime.Parse("2023,09,24,9,00,0"), TijdstipEinde = DateTime.Parse("2023,09,24,10,30,0"),
                    LokaalId = lokalen.Single( l => l.Titel == "Heverlee grote zaal").LokaalId

                },
                new Les {Titel = "Nederlands1A", Omschrijving = "Het lijdend voorwerp", TijdstipStart = DateTime.Parse("2023,09,25,9,00,0"), TijdstipEinde = DateTime.Parse("2023,09,25,10,30,0"),
                    LokaalId = lokalen.Single( l => l.Titel == "Leuven kleine zaal 1").LokaalId

                },
                new Les {Titel = "Nederlands1B", Omschrijving = "Het meewerkend voorwerp", TijdstipStart = DateTime.Parse("2023,09,26,9,00,0"), TijdstipEinde = DateTime.Parse("2023,09,26,10,30,0"),
                    LokaalId = lokalen.Single( l => l.Titel == "Leuven kleine zaal 2").LokaalId

                },
                new Les {Titel = "Engels1A", Omschrijving = "Inleiding", TijdstipStart = DateTime.Parse("2023,09,27,9,00,0"), TijdstipEinde = DateTime.Parse("2023,09,27,10,30,0"),
                    LokaalId = lokalen.Single( l => l.Titel == "Leuven grote zaal").LokaalId

                },
                new Les {Titel = "Engels1B", Omschrijving = "Pronunciation", TijdstipStart = DateTime.Parse("2023,09,28,9,00,0"), TijdstipEinde = DateTime.Parse("2023,09,28,10,30,0"),
                    LokaalId = lokalen.Single( l => l.Titel == "Heverlee kleine zaal").LokaalId

                },
                new Les {Titel = "Economie1A", Omschrijving = "Wat is economie?", TijdstipStart = DateTime.Parse("2023,09,29,9,00,0"), TijdstipEinde = DateTime.Parse("2029,09,23,10,30,0"),
                    LokaalId = lokalen.Single( l => l.Titel == "Heverlee kleine zaal").LokaalId

                },
            };

            foreach (Les l in lessen)
            {
                context.Lessen.Add(l);
            }
            context.SaveChanges();
        }
    }*/
    
}