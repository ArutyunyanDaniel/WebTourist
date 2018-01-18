using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebTourist.Models;

namespace WebTourist.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //DBToutisrContext db = new DBToutisrContext();
            //List < Attraction > list = db.Attraction.ToList();
            List<ContainerRouteAttraction> kontainer = new List<ContainerRouteAttraction>();
            using (DBToutisrContext dbTourist = new DBToutisrContext())
            {
                var List = dbTourist.RouteAttraction.ToList();
                var ls = dbTourist.Attraction.ToList();
                var ll = dbTourist.Route.ToList();
                ContainerRouteAttraction temp = new ContainerRouteAttraction();
                foreach (var item in List)
                {
                    if (temp.IdR == 0)
                    {
                        temp.IdR = item.Route.Id;
                        temp.CoordinatesRoute = item.Route.Coordinates;
                        temp.CoordinatesPointsStart = item.Route.CoordinatesStartingPointsRoute;
                    }
                    if (temp.IdR == item.Route.Id)
                    {
                        attraction at = new attraction(item.Attraction.Name, item.Attraction.Description, item.Attraction.Coordinate);
                        temp.attractions.Add(at);
                    }
                    else
                    {
                        kontainer.Add(temp);
                        temp = new ContainerRouteAttraction();
                        attraction at = new attraction(item.Attraction.Name, item.Attraction.Description, item.Attraction.Coordinate);
                        temp.attractions.Add(at);
                    }
                }
                kontainer.Add(temp);
            }
            return View(kontainer);
        }

    }
}
