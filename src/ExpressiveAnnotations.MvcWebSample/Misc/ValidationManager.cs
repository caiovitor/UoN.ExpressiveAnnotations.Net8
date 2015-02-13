﻿using System;
using System.Web;

namespace ExpressiveAnnotations.MvcWebSample.Misc
{
    public class ValidationManager
    {
        private static readonly ValidationManager _instance = new ValidationManager();

        private ValidationManager()
        {
        }

        public static ValidationManager Instance
        {
            get { return _instance; }
        }

        public void Save(string type, HttpContextBase httpContext)
        {
            SetValueToCookie(type, httpContext);
        }

        public string Load(HttpContextBase httpContext)
        {
            var value = GetValueFromCookie(httpContext);
            if (value != null) 
                return value;

            value = "client";
            SetValueToCookie(value, httpContext);
            return value;
        }

        private string GetValueFromCookie(HttpContextBase httpContext)
        {
            var cookie = httpContext.Request.Cookies.Get("expressiv.mvcwebsample.validation");
            return cookie != null ? cookie.Value : null;
        }

        private void SetValueToCookie(string type, HttpContextBase httpContext)
        {
            var cookie = new HttpCookie("expressiv.mvcwebsample.validation", type) {Expires = DateTime.Now.AddMonths(1)};
            httpContext.Response.SetCookie(cookie);
        }
    }
}
