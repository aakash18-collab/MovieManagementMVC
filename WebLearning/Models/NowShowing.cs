using NuGet.DependencyResolver;

namespace MovieManagementMVC.Models
{
    public class NowShowing
    {
        public int Id { get; set; }
        public IEnumerable<Movies> Movies { get; set; }
        public IEnumerable<Shifts> Shifts { get; set; }
        public IEnumerable<Halls> Halls { get; set; }
    }
}
