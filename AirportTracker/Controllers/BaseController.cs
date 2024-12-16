using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using AirportTracker.Models;
using System.Linq;

public abstract class BaseController : Controller
{
    protected AirportContext Context { get; }
    
    

    public BaseController(AirportContext ctx)
    {
        Context = ctx;
}

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var airports = Context.Airports.ToList();
        ViewBag.Airports = airports; 
        base.OnActionExecuting(context);
    }
}
