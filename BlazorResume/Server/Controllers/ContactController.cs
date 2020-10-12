using BlazorResume.Server.Helpers.Google;
using BlazorResume.Server.Interfaces;
using BlazorResume.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlazorResume.Server.Controllers
{
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IManageContact _manageContact;
        private readonly IManageSettings _manageSettings;

        public ContactController(IManageContact manageContact, IManageSettings manageSettings)
        {
            _manageContact = manageContact;
            _manageSettings = manageSettings;
        }

        [HttpGet]
        [Route("api/contact")]
        public async Task<ContactModel> Get()
        {
            return await _manageContact.GetContactDetailsAsync();
        }

        [HttpPost]
        [Route("api/contact")]
        [Authorize(Roles = "administrator")]
        public async Task<bool?> Post(ContactModel contactModel)
        {
            try
            {
                var updated = await _manageContact.UpdateContactDetailsAsync(contactModel);
                if (updated)
                {
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return null;
            }
        }

        [HttpPost]
        [Route("api/contactform")]
        public async Task<bool?> PostForm(ContactFormModel contactFormModel)
        {
            try
            {
                var settings = await _manageSettings.GetSettingsAsync();
                var reCaptcha = new ReCaptcha();
                if (!reCaptcha.Validate(contactFormModel.ReCaptcha, settings.ReCaptchaSecretKey))
                {
                    return false;
                }

                await new Services.EmailSender(_manageSettings)
                    .SendContactFormEmailAsync(contactFormModel.SenderName, contactFormModel.SenderEmail, contactFormModel.SenderPhone, contactFormModel.SenderMessage);

                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
