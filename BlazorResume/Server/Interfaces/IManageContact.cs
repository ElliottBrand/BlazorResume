using BlazorResume.Server.Data;
using BlazorResume.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorResume.Server.Interfaces
{
    public interface IManageContact
    {
        Task<ContactModel> GetContactDetailsAsync();
        Task<bool> UpdateContactDetailsAsync(ContactModel contactModel);
    }

    public class ManageContact : IManageContact
    {
        private readonly ApplicationDbContext _context;

        public ManageContact(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ContactModel> GetContactDetailsAsync() =>
            await new Data.Repository.Contact(_context).GetContactDetailsAsync();

        public async Task<bool> UpdateContactDetailsAsync(ContactModel contactModel) =>
            await new Data.Repository.Contact(_context).UpdateContactDetailsAsync(contactModel);
    }
}
