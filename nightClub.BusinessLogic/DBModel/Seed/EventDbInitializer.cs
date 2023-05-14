using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nightClub.Domain.Entities.Event;

namespace nightClub.BusinessLogic.DBModel.Seed
{
    public class EventDbInitializer:CreateDatabaseIfNotExists<EventContext>
    {
        protected override void Seed(EventContext context)
        {
            var events = new List<EDbTable>
            {
                new EDbTable
                {
                    Title = "Summer Music Festival",
                    Description = "Join us for a time of live music and fun! Featuring some of the hottest bands in the country and a variety of food and drink vendors, this is an event you won't want to miss!",
                    ImageUrl ="https://i.scdn.co/image/ab67616d0000b2730831fe63bece83201dd926a6",
                    TicketPrice = 25.99,
                    TotalTicketsNumber = 150,
                    TicketsLeft = 150,
                    StartDate = new DateTime(2023,07,15,21,00,00),
                    EndDate = new DateTime(2023,07,16,7,00,00),
                    SpecialGuest = "John Legend"
                },
                new EDbTable
                {
                    Title = "Halloween Party",
                    Description = "Get ready for a spooky night of music, costumes, and fun! This year's Halloween party will feature live DJ performances, a costume contest with prizes, and a variety of Halloween-themed cocktails and snacks!",
                    ImageUrl ="https://media-api.xogrp.com/images/91afbe54-7c23-4d94-a4df-26266119268e~cr_0.0.837.561?quality=50",
                    TicketPrice = 17.85,
                    TotalTicketsNumber = 100,
                    TicketsLeft = 100,
                    StartDate = new DateTime(2023,10,31,8,00,00),
                    EndDate = new DateTime(2023,11,01,2,00,00),
                    SpecialGuest = "none"
                }
            };
            events.ForEach(e=>context.Events.Add(e));
            context.SaveChanges();
        }
    }
}
