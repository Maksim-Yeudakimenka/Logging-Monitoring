using PerformanceCounterHelper;
using System.Diagnostics;

namespace MvcMusicStore.Infrastructure
{
    [PerformanceCounterCategory("MvcMusicStore", PerformanceCounterCategoryType.MultiInstance, "Performance counters for the MvcMusicStore web app.")]
    public enum PerformanceCounters
    {
        [PerformanceCounter("LogInCount", "Log in count", PerformanceCounterType.NumberOfItems32)]
        LogInCount,

        [PerformanceCounter("LogOutCount", "Log out count", PerformanceCounterType.NumberOfItems32)]
        LogOutCount,

        [PerformanceCounter("HomePageHitCount", "Home page hit count", PerformanceCounterType.NumberOfItems32)]
        HomePageHitCount
    }
}