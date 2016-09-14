using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Helpers
{
    public static class ExtentionMethodes
    {

        public static IEnumerable<SelectListItem> ToSelectListItem(this IEnumerable<string> flights)
        {
            return flights.OrderBy(g => g).Select(g =>

                new SelectListItem
                {
                    Text = g,
                    Value = g
                });

        }

        public static IEnumerable<SelectListItem> ToSelectListItem(this IEnumerable<Flight> flights)
        {
            return flights.OrderBy(p => p.Number).Select(p =>

                new SelectListItem
                {
                    Text = p.Number,
                    Value = p.FlightId.ToString()
                });

        }
    }
}







