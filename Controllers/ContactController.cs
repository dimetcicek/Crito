﻿using Crito.Models;
using Crito.Services;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;

namespace Crito.Controllers
{
    public class ContactController : SurfaceController
    {
        public ContactController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider) : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
        }


        [HttpPost]
        public IActionResult Index(ContactForm contactForm)
        {
            if (!ModelState.IsValid)     
                return CurrentUmbracoPage();

            if (string.IsNullOrWhiteSpace(contactForm.Name) || string.IsNullOrWhiteSpace(contactForm.Email) || string.IsNullOrWhiteSpace(contactForm.Message))
            {
                return CurrentUmbracoPage();
            }

            using var mail = new MailService("no-reply@crito.com", "smtp.crito.com", 587, "dimet.cicek96@hotmail.com", "ehELap!234");
            // to sender
            mail.SendAsync(contactForm.Email, "Your contact request was received.", "Hi your request was received and we will be in contact with you as soon as possible.").ConfigureAwait(false);

            // to receiver
            mail.SendAsync("dimet.cicek96@hotmail.com", $"{contactForm.Name} sent a contact request.", contactForm.Message).ConfigureAwait(false);

            return LocalRedirect(contactForm.RedirectUrl ?? "/");

        }
    }
}
