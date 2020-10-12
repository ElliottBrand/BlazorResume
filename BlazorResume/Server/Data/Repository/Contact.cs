using BlazorResume.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorResume.Server.Data.Repository
{
    public class Contact
    {
        private readonly ApplicationDbContext _context;

        public Contact(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ContactModel> GetContactDetailsAsync()
        {
            return await _context.Contact.FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateContactDetailsAsync(ContactModel contactModel)
        {
            var contact = await _context.Contact.FirstOrDefaultAsync();

            if(contact != null)
            {
                try
                {
                    contact.PageTitle = contactModel.PageTitle;
                    contact.Title = contactModel.Title;
                    contact.Details = contactModel.Details;
                    contact.ShowContactForm = contactModel.ShowContactForm;

                    await _context.SaveChangesAsync();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
    }
}
