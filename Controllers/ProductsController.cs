using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Who_Whom_.Data;
using Who_Whom_.Models;
using System.Collections.Generic;

namespace Who_Whom_.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Product.ToListAsync());
        }

        public async Task<IActionResult> Who()
        {
            //List<Product> products = new List<Product>();

            //var Average = _context.Product.Average(m => m.Price);

            //Product[] Max = _context.Product.Where(m => m.Price > Average).ToArray();
            //Product[] Min = _context.Product.Where(m => m.Price < Average).ToArray();

            //for (int i = 0; i < Max.Length; i++)
            //{
            //    for (int j = 0; j < Min.Length; j++)// паребір по масиву боржників
            //    {
            //        int count = 0;
            //        while (Min[j].Price != Average)
            //        {
            //            if (Max[i].Price != Average)
            //            {
            //                Max[i].Price -= 1;
            //                Min[j].Price += 1;
            //                count++;
            //            }
            //            if (Min[j].Price == Average)
            //            {
            //                // Console.WriteLine("{0}, в сумі {2} має віддати - {1}", Min[j].Name, Max[i].Name, count);
            //                //j++;
            //                products.Add(new Product { Price = count, User = Max[i].User });
            //            }
            //            else if (Max[i].Price == Average)
            //            {
            //                //Console.WriteLine("{0}, в сумі {2} має віддати - {1}", Min[j].Name, Max[i].Name, count);
            //                products.Add(new Product { Price = count, User = Max[i].User });
            //                i++;
            //                count = 0;
            //            }
            //        }
            //    }
            //}

            return View(await _context.Product.ToListAsync());
        }


        public async Task<IActionResult>UserList()
        {
            
            return View(await _context.Product.ToListAsync());
           
        }
           

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Name,Price,User")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            return View(product);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}
