using Agency.Core.Models;

namespace Agency.ViewModels
{
    public class HomeViewModel
    {
        public List<Category> categories { get; set; }
        public List<Setting> settings { get; set; }
        public List<Portfolio> portfolios { get; set; }
    }
}
