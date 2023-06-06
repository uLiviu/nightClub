using nightClub.Domain.Entities.Bar;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace nightClub.BusinessLogic.DBModel.Seed
{
    internal class BarDbInitializer : CreateDatabaseIfNotExists<BarContext>
    {
        protected override void Seed(BarContext context)
        {
            var drinks = new List<BarDbTable>
            {
                new BarDbTable
                {
                    Title = "Tenuta BELTRAME",
                    Description = "Wine Grapes - Wine Label Sauvignon Blanc Red Wine Bottle",
                    Url ="https://panebiancowines.com/wp-content/uploads/2022/04/Tenuta-Beltrame-Friulano-Friuli-DOC-square-1024x1024.png",
                    Category = "Wine",
                    Alcohol = 0.13,
                    Price = 1.9,
                    Date = DateTime.Now
                },
                new BarDbTable
                {
                    Title = "Cabernet Sauvignon",
                    Description = "Cabernet sauvignon is a dark red wine with a full body and alcohol content over 13.5%, with certain varietals featuring alcohol content over 15%. Wine connoisseurs can discern the taste of green peppers in this wine, along with dark spices and fruits such as cherries.",
                    Url ="https://basavin.md/wp-content/uploads/2018/02/cabernet.png",
                    Category = "Wine",
                    Alcohol = 0.135,
                    Price = 2.3,
                    Date = DateTime.Now
                },
                new BarDbTable
                {
                    Title = "GIN BURDON HIERBABUENA 37.5%",
                    Description = "Coarsen Peppermint is a gin based on the best alcohols and mint-joined and other botanicals to create a fresh flavor.",
                    Url ="https://alcomarket.md/media/images/items/0011/th2/items-10120-4038.png",
                    Category = "Gin",
                    Alcohol = 0.375,
                    Price = 4,
                    Date = DateTime.Now
                },
                new BarDbTable
                {
                    Title = "Calavera Vert 89.9%",
                    Description = "Calavera Verde is an absinthe from Spain. Its green colour and the vicious horned devil on the front of the bottle promise a thrilling experience... and a dangerous one! and dangerous! Absinthe, symbolising the Parisian bohemian movement of the late 19th century, has a complex and controversial history.",
                    Url ="https://i.pinimg.com/originals/cc/0f/b0/cc0fb0a1e6f2bd4f7032e517ff136cb8.jpg",
                    Category = "Absinthe",
                    Alcohol = 0.899,
                    Price = 5.6,
                    Date = DateTime.Now
                },
                new BarDbTable
                {
                    Title = "Coca Cola",
                    Description = "These sodas have all the cola taste you know and love.",
                    Url ="https://us.coca-cola.com/content/dam/nagbrands/us/coke/en/home/coca-cola-original-20oz.png",
                    Category = "Soda",
                    Alcohol = 0,
                    Price = 1.2,
                    Date = DateTime.Now
                }
            };
            drinks.ForEach(d => context.Bars.Add(d));
            context.SaveChanges();
        }
    }
}

