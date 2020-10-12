using BlazorResume.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorResume.Server.Data
{
    public class SeedContact
    {
        public static void Initialize(ApplicationDbContext context)
        {
            var contact = new ContactModel()
            {
                PageTitle = "Contact Me",
                Title = "Contact",
                Details = "",
                ShowContactForm = true
            };

            context.Contact.Add(contact);
            context.SaveChanges();
        }
    }
}
