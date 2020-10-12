window.googleMethods = {
    loadGoogleAnalytics: function (pathAndQuery, GoogleAnalyticsID) {
        if (GoogleAnalyticsID) {
            var script = document.createElement("script");
            script.async = true;
            script.src = "https://www.googletagmanager.com/gtag/js?id=" + GoogleAnalyticsID;
            script.id = "g-analytics-script";

            if (!document.getElementById('g-analytics-script')) {
                document.getElementsByTagName('head')[0].appendChild(script);
            }

            window.dataLayer = window.dataLayer || [];
            function gtag() { dataLayer.push(arguments); }
            gtag('js', new Date());

            gtag('config', GoogleAnalyticsID, { page_path: pathAndQuery });
        }
    },
    loadCaptchaHeadScript: function (ReCaptchaPublicKey) {
        var script = document.createElement("script");
        script.src = "https://www.google.com/recaptcha/api.js?render=" + ReCaptchaPublicKey;
        script.id = "recaptcha-script";

        if (!document.getElementById('recaptcha-script')) {
            document.getElementsByTagName('head')[0].appendChild(script);
        }
    },
    loadCaptcha: function (ReCaptchaPublicKey) {
        return new Promise((resolve, reject) => {
            grecaptcha.ready(function () {
                grecaptcha.execute(ReCaptchaPublicKey, { action: 'BlazorContactForm' }).then(function (token) {
                    resolve(token);
                });
            });
        });
    }
};

// Detect if user is using an IE browser, which isn't compatible with Blazor WebAssembly
// and display a message if they are using IE.
(function IEdetection() {
    var ua = window.navigator.userAgent;
    var trident = ua.indexOf('Trident/'); // For IE 11
    var msie = ua.indexOf('MSIE '); // For IE 10 & older
    var appDiv = document.getElementById("app");

    if (trident > 0 || msie > 0) {
        appDiv.setAttribute("style", "text-align:center; padding: 1em;");
        appDiv.innerHTML = "Sorry, your browser isn't compatible with the technology required to display this website. Please try a newer browser.";
    }
}());
