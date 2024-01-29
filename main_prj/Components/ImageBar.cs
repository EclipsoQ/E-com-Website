using main_prj.Models;
using Microsoft.AspNetCore.Mvc;

namespace main_prj.Components
{
    public class ImageBar:ViewComponent
    {
        private readonly ComputerShopContext _context;
        public ImageBar(ComputerShopContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            return View(_context.Categories.ToList());
        }
    }
}
