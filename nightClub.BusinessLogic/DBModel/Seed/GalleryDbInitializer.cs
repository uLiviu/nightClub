using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nightClub.Domain.Entities.Gallery;

namespace nightClub.BusinessLogic.DBModel.Seed
{
    public class GalleryDbInitializer: CreateDatabaseIfNotExists<GalleryContext>
    {
        protected override void Seed(GalleryContext context)
        {
            var photos = new List<PDbTable>
            {
                new PDbTable
                {
                    Url = "https://media.istockphoto.com/id/499366816/photo/ecstatic.jpg?s=612x612&w=0&k=20&c=JeUl-3CL_gHRQl34nqaWc7nbGF-xjphf6pkYTaIW5LI=",
                    Title = "First",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    Date = DateTime.Now
                },
                new PDbTable
                {
                    Url = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS5SS7INU54lBD1s3E142rPUl7JiWew39eaTw&usqp=CAU",
                    Title = "Second",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    Date = DateTime.Now
                },
                new PDbTable
                {
                    Url = "https://static.wixstatic.com/media/b4d1a2_a7c2c78329324cdabe8d9c9b6dd747dd~mv2.jpg/v1/fill/w_640,h_660,al_c,q_85,usm_0.66_1.00_0.01,enc_auto/b4d1a2_a7c2c78329324cdabe8d9c9b6dd747dd~mv2.jpg",
                    Title = "Third",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    Date = DateTime.Now
                },
                new PDbTable
                {
                    Url = "https://stage48afterprom.com/images/venue-photos/stage-48-nightclub-3.jpg",
                    Title = "Fourth",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    Date = DateTime.Now
                },
            };
            photos.ForEach(p=>context.Photos.Add(p));
            context.SaveChanges();
        }
    }
}
