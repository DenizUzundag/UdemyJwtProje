using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YSK.UdemyJwtProje.Business.Interfaces;

namespace YSK.UdemyJwtProje.WebApi.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService,IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
     
        public async Task<IActionResult> Index()
        {
           
            return View(await _productService.GetAll());
        }
    }
}
