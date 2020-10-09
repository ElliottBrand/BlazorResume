﻿window.analyticsMethods = {
    loadGoogleAnalytics: function (pathAndQuery, GoogleAnalyticsID) {
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
};