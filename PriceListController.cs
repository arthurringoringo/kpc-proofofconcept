using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apitest.Database;
using apitest.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apitest


{

    [Route("api/[controller]")]
    [ApiController]
    public class PriceListController : ControllerBase

    {
        private readonly ApiDbContext _context;

        public PriceListController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet("storea")]
        public List<StoreA> GetListA()
        {
            return _context.StoreA.ToList();


        }
        [HttpGet("storeb")]
        public List<StoreB> GetListB()
        {
            return _context.StoreB.ToList();


        }

        [HttpGet("storea/{id}")]
        public IActionResult GetA(int id)
        {
            var item = _context.StoreA.Find(id);

            if (item == null)
            {

                return NotFound();
            }
            return Ok(item);


        }
        [HttpGet("storeb/{id}")]
        public IActionResult GetB(int id)
        {
            var item = _context.StoreB.Find(id);

            if (item == null)
            {

                return NotFound();
            }
            return Ok(item);


        }


        [HttpGet("compare/{maxdif}/")]
        public IActionResult ComparePrice(int maxdif)
        {
            var overPrice = 0;
            var underPrice = 0;
            var equal = 0;
            var notfoud = 0;
            var a = GetListA().ToList();
            var b = GetListB().ToList();



            foreach (StoreA item in a)
            {

                StoreB tempb = b.Find(obj => obj.Barcode.Equals(item.Barcode));

                if (tempb == null)
                {

                    notfoud++;

                }
                else
                {
                    var priceRange = item.Price - tempb.Price;
                    if (priceRange > maxdif)
                    {
                        overPrice++;
                    }
                    else if (priceRange < 0)
                    {
                        underPrice++;
                    }
                    else
                    {
                        equal++;

                    }

                }



            }

            int[] data = { underPrice, overPrice, equal, notfoud };

            return Ok(data.ToList());

        }



        [HttpGet("compare/items")]
        public IActionResult compareItems()
        {
            var a = GetListA().ToList();
            var b = GetListB().ToList();
            var sameas = 0;
            var diffwith = 0;
            var dontHave = 0;

            foreach (StoreA item in a)
            {

                StoreB tempb = b.Find(obj => obj.Barcode.Equals(item.Barcode));

                if (tempb == null)
                {
                    diffwith++;


                }
                else
                {
                    sameas++;

                }

            }
            foreach (StoreB item in b)
            {

                StoreA tempa = a.Find(obj => obj.Barcode.Equals(item.Barcode));

                if (tempa == null)
                {
                    dontHave++;


                }

            }



            int[] data = { sameas, diffwith, dontHave };


            return Ok(data.ToList());


        }
        [HttpGet("compare/percentage")]
        public IActionResult getPricePercentile()
        {
            var a = GetListA().ToList();
            var b = GetListB().ToList();
            var abv50 = 0;
            var bel50 = 0;
            var min50 = 0;
            var maxmin50 = 0;
            var na = 0;

            foreach (StoreA item in a)
            {

                StoreB tempb = b.Find(obj => obj.Barcode.Equals(item.Barcode));

                if (tempb == null)
                {
                    na++;
                }
                else
                {
                    float result = 0;
                    result = ((tempb.Price - item.Price) * 100) / item.Price;

                    if (result >= 50)
                    {
                        abv50++;

                    }
                    else if (result >= 0 && result <= 49)
                    {
                        bel50++;
                    }
                    else if (result <= 0 && result >= -49)
                    {
                        min50++;
                    }
                    else
                    {
                        maxmin50++;
                    }
                }
            }

            int[] data = { na, maxmin50, min50, bel50, abv50 };

            return Ok(data);
        }


        [HttpGet("compare/category")]
        public IActionResult getCategory()
        {
            var a = GetListA().ToList();
            int size = a.Count;

            decimal Food = a.Where(x => x.Tag.Equals("Food")).Count();
            Food = Math.Ceiling((Food / size) * 100);

            decimal Technology = (a.Where(x => x.Tag.Equals("Technology")).Count());
            Technology = Math.Ceiling((Technology / size) * 100);

            decimal Beauty = (a.Where(x => x.Tag.Equals("Beauty")).Count());
            Beauty = Math.Ceiling((Beauty / size) * 100);

            decimal Drinks = (a.Where(x => x.Tag.Equals("Drinks")).Count());
            Drinks = Math.Ceiling((Drinks / size) * 100);
            
            decimal[] data = {Food, Technology, Beauty, Drinks };
            return Ok(data);
        }
    }
}