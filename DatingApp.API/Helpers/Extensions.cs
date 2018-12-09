using System;
using Microsoft.AspNetCore.Http;

namespace DatingApp.API.Helpers
{
    public static class Extensions
    {
        public static void AddApplicationError(this HttpResponse respomse, string message)
        {
            respomse.Headers.Add("Application-Error", message);
            respomse.Headers.Add("Access-Control-Expose-Header", "Application-Error");
            respomse.Headers.Add("Access-Control-Allow-Origin", "*");
        }

        public static int CalculateAge(this DateTime theDateTime)
        {
            var age = DateTime.Today.Year - theDateTime.Year;
            if (theDateTime.AddYears(age) > DateTime.Today)
            age--;

            return age;
        }
    }
}