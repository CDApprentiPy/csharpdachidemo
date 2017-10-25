using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using demodachi;

namespace demodachi.Controllers
{
    public class DachiController : Controller
    {
        public DemoDachi _mydachi;
        public DachiController()
        {
            _mydachi = new DemoDachi();
        }
        // index
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetObjectFromJson<DemoDachi>("dachi") == null)
            {
                HttpContext.Session.SetObjectAsJson("dachi", new DemoDachi());
            }
            ViewBag.dachi = HttpContext.Session.GetObjectFromJson<DemoDachi>("dachi");
            return View();
        }
        // dontdie
        [HttpPost]
        [Route("dontdie")]
        public IActionResult Dontdie(string activity)
        {
            // GetHashCode current state
            DemoDachi current_critter = HttpContext.Session.GetObjectFromJson<DemoDachi>("dachi");
            // figure out what to do
            if (activity == "feed")
            {
                current_critter.feed();
                _mydachi.feed();
                System.Console.WriteLine(_mydachi.fullness);
            }
            // do that thing
            // update state and go!
            HttpContext.Session.SetObjectAsJson("dachi", current_critter);
            return RedirectToAction("Index");
        }
        // reset

    }


    public static class SessionExtensions
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}