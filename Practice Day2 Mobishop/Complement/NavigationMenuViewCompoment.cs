using Microsoft.AspNetCore.Mvc;
using Practice_Day2_Mobishop.Models;

public class NavigationMenuViewComponent : ViewComponent
{
    private readonly AppDbContext _db;

    public NavigationMenuViewComponent(AppDbContext db)
    {
        _db = db ?? throw new ArgumentNullException(nameof(db)); // Kiểm tra null
    }

    public IViewComponentResult Invoke()
    {
        var categories = _db.Products
                                    .Select(p => p.Name)
                                    .Distinct()
                                    .OrderBy(name => name)
                                    .ToList();
        return View(categories);
    }
}