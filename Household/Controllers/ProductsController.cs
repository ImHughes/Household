using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Household.Data;
using Household.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Household.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public ProductsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        [Authorize]
        // GET: Products
        public async Task<IActionResult> Index(string searchString)
        {
            ViewBag.CurrentFilter = searchString;            
            var user = await GetUserAsync();
            var products = from p in _context.Products
                .Include(p => p.ProductType)
                .Include(p => p.Room)              
                .Where(p => p.UserId == user.Id).ToList()
                           select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.ProductType.Name.Contains(searchString));
            }
            return View(products);
        }
        [Authorize]
        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }
        [Authorize]
        // GET: Products/Create
        public  async Task<IActionResult> Create()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var productTypeList = _context.ProductType.Where(p => p.UserId == user.Id ).ToList();
            var productTypeSelectList = productTypeList.Select(type => new SelectListItem
            {
                Text = type.Name,
                Value = type.Id.ToString()
            }).ToList();
            productTypeSelectList.Insert(0, new SelectListItem
            {
                Text = "Choose Product Type",
                Value = ""
            });

            ViewData["ProductTypes"] = productTypeSelectList;

            var roomTypeList = _context.Room.ToList();
            var roomTypeSelectList = roomTypeList.Select(type => new SelectListItem
            {
                Text = type.Name,
                Value = type.Id.ToString()
            }).ToList();
            roomTypeSelectList.Insert(0, new SelectListItem
            {
                Text = "Choose Room",
                Value = ""
            });

            ViewData["Rooms"] = roomTypeSelectList;



            return View();
        }
        [Authorize]
        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductTypeId,Make,Model,SerialNumber,WarrantyExperation,UserId,RoomId")] Products products)
        {

            ModelState.Remove("UserId");
            if (ModelState.IsValid)
            {
                var user = await GetUserAsync();
                products.UserId = user.Id;
                _context.Add(products);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(products);
        }
        [Authorize]
        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var productTypeList = _context.ProductType.ToList();
            var productTypeSelectList = productTypeList.Select(type => new SelectListItem
            {
                Text = type.Name,
                Value = type.Id.ToString()
            }).ToList();
            productTypeSelectList.Insert(0, new SelectListItem
            {
                Text = "Choose Product Type",
                Value = ""
            });

            ViewData["ProductTypes"] = productTypeSelectList;

            var roomTypeList = _context.Room.ToList();
            var roomTypeSelectList = roomTypeList.Select(type => new SelectListItem
            {
                Text = type.Name,
                Value = type.Id.ToString()
            }).ToList();
            roomTypeSelectList.Insert(0, new SelectListItem
            {
                Text = "Choose Room",
                Value = ""
            });

            ViewData["Rooms"] = roomTypeSelectList;
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }
            return View(products);
        }
        [Authorize]
        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductTypeId,Make,Model,SerialNumber,WarrantyExperation,UserId,RoomId")] Products products)
        {
            if (id != products.Id)
            {
                return NotFound();
            }
            ModelState.Remove("UserId");
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await GetUserAsync();
                    products.UserId = user.Id;
                    _context.Update(products);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsExists(products.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(products);
        }
        [Authorize]
        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }
        [Authorize]
        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var products = await _context.Products.FindAsync(id);
            _context.Products.Remove(products);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
        private Task<ApplicationUser> GetUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }
    }
}
