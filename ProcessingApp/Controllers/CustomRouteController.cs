using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessingApp.Controllers
{

    //this Conttoller is created just to test making a custom route 
    public class CustomRouteController : Controller
    {
        public string[] index()
        {
            return new[]
            {
                "You have created a custome route",
                "List statement 2",
            };

        }

        public IActionResult anotherPage()
        {

            return RedirectToAction("Property/Index");
        }
        public IActionResult Ad()
        {

            return RedirectToAction("Property/Ad");
        }


        public string Details(int id)
        {
            return $"{id} - Is the ID shown?";
        }



    }
}
