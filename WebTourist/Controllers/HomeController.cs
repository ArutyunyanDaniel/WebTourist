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
            List<ContainerRouteAttraction> kontainerRouteAttraction = new List<ContainerRouteAttraction>();
            using (DBToutisrContext dbTourist = new DBToutisrContext())
            {
                var List = dbTourist.RouteAttraction.ToList();
                var ls = dbTourist.Attraction.ToList();
                var ll = dbTourist.Route.ToList();
                ContainerRouteAttraction routeAttraction = new ContainerRouteAttraction();
                foreach (var item in List)
                {
                    if (routeAttraction.IdR == 0)
                    {
                        routeAttraction.IdR = item.Route.Id;
                        routeAttraction.CoordinatesRoute = item.Route.Coordinates;
                        routeAttraction.CoordinatesPointsStart = item.Route.CoordinatesStartingPointsRoute;
                    }
                    if (routeAttraction.IdR == item.Route.Id)
                    {
                        attraction at = new attraction(item.Attraction.Name, item.Attraction.Description, item.Attraction.Coordinate);
                        routeAttraction.attractions.Add(at);
                    }
                    else
                    {
                        kontainerRouteAttraction.Add(routeAttraction);
                        routeAttraction = new ContainerRouteAttraction();
                        attraction at = new attraction(item.Attraction.Name, item.Attraction.Description, item.Attraction.Coordinate);
                        routeAttraction.attractions.Add(at);
                    }
                }
                kontainerRouteAttraction.Add(routeAttraction);
            }
            return View(kontainerRouteAttraction);
        }

    }
}
