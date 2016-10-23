using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using MvcMusicStore.Infrastructure;
using MvcMusicStore.Models;
using PerformanceCounterHelper;

namespace MvcMusicStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly MusicStoreEntities _storeContext = new MusicStoreEntities();

        private static readonly CounterHelper<PerformanceCounters> CounterHelper =
            PerformanceHelper.CreateCounterHelper<PerformanceCounters>("MvcMusicStore");

        // GET: /Home/
        public async Task<ActionResult> Index()
        {
            CounterHelper.Increment(PerformanceCounters.HomePageHitCount);

            return View(await _storeContext.Albums
                .OrderByDescending(a => a.OrderDetails.Count())
                .Take(6)
                .ToListAsync());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _storeContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}