using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectMediiMaster_BogdanIstrate.Models;

namespace ProjectMediiMaster_BogdanIstrate.Data
{
    public class DbInitializer
    {
        public static void Initialize(LibraryContext context)
        {
            context.Database.EnsureCreated();
            if (context.Guitars.Any())
            {
                return; // BD a fost creata anterior
            }
            var guitars = new Guitar[]
            {
            new Guitar{Name="Fender",Description="All time blues, jazz favourite.",Price=800,Category="Electric"},
            new Guitar{Name="Gibson",Description="Rock and hard rock sound, used by Slash and Jimmy Page.",Price=1500,Category="Electric"},
            new Guitar{Name="Martin",Description="Best acoustic guitars, smooth and warm sound",Price=100,Category="Acoustic"},
            new Guitar{Name="Hefner",Description="Known for the solid sound",Price=500,Category="Bass"}
             };
            foreach (Guitar g in guitars)
            {
                context.Guitars.Add(g);
            }
            context.SaveChanges();
            var customers = new AppCustomer[]
            {

            new AppCustomer{AppCustomerId=100,Name="John Cena"},
            new AppCustomer{AppCustomerId=105,Name="Randy Orton"},
            new AppCustomer{AppCustomerId=110,Name="Conor McGregor"},
            };
            foreach (AppCustomer c in customers)
            {
                context.AppCustomers.Add(c);
            }
            context.SaveChanges();
            var orders = new GuitarOrder[]
            {
            new GuitarOrder{GuitarId=1,AppCustomerId=105},
            new GuitarOrder{GuitarId=3,AppCustomerId=100},
            new GuitarOrder{GuitarId=1,AppCustomerId=110},
            new GuitarOrder{GuitarId=2,AppCustomerId=110},
            new GuitarOrder{GuitarId=4,AppCustomerId=110},
            };
            foreach (GuitarOrder e in orders)
            {
                context.GuitarOrders.Add(e);
            }
            context.SaveChanges();

            var reviews = new Review[]
           {
            new Review{GuitarId=1,AppCustomerId=105,Rating=9},
            new Review{GuitarId=2,AppCustomerId=110,Rating=10},
            new Review{GuitarId=3,AppCustomerId=100,Rating=8},
            new Review{GuitarId=4,AppCustomerId=110,Rating=7},
           };
            foreach (Review r in reviews)
            {
                context.Reviews.Add(r);
            }
            context.SaveChanges();

            var factories = new Factory[]
            {

             new Factory{FactoryName="Thomann",Adress="Str. Bavaria, nr. 3, Germania"},
             new Factory{FactoryName="FenderUSA",Adress="Str. York, nr. 35, California"},
            new Factory{FactoryName="GibsonCorporation",Adress="Str. Mea, nr. 22, Los Angeles"},
            };
            foreach (Factory f in factories)
            {
                context.Factories.Add(f);
            }
            context.SaveChanges();

            var releasedguitars = new ReleasedGuitar[]
               {
                new ReleasedGuitar {
                GuitarID = guitars.Single(c => c.Name == "Fender" ).Id,
                FactoryID = factories.Single(i => i.FactoryName == "FenderUSA").ID
                },
                new ReleasedGuitar {
                GuitarID = guitars.Single(c => c.Name == "Gibson" ).Id,
                FactoryID = factories.Single(i => i.FactoryName == "GibsonCorporation").ID
                },
                new ReleasedGuitar {
                GuitarID = guitars.Single(c => c.Name == "Martin" ).Id,
                FactoryID = factories.Single(i => i.FactoryName == "Thomann").ID
                },
                new ReleasedGuitar {
                GuitarID = guitars.Single(c => c.Name == "Hefner" ).Id,
                FactoryID = factories.Single(i => i.FactoryName == "Thomann").ID
                },

            };
            foreach (ReleasedGuitar rg in releasedguitars)
            {
                context.ReleasedGuitars.Add(rg);
            }
            context.SaveChanges();

        }
    }
}

