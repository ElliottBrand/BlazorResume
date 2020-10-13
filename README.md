BlazorResume
============
BlazorResume is a fairly simple Blazor WebAssembly web application (in development) for displaying a resume on the home page, a simple about page, and a contact form that utilizes Google ReCaptcha. The form is designed to send through a SendGrid account.

Also on the home page is the "Hire-inator", which can be disabled. It's a fun little tool to display a salary range, whether it's acceptible, and it has cogs that spin in the background as the slider moves. It is also a good example of an interactive use case for Blazor.

An administration area is built in to manage the site content as well.

## Special Notes
You should change the DataEncryptKey in appsettings.json and appsettings.Development.json, but be careful NOT to change it after you've added a SendGrid Key, Google ReCaptcha Key, or Google ReCaptcha Secret Key, as this DataEncryptKey encrypts that data in the database. If you change the DataEncryptKey, you'll have to update those field values again.
