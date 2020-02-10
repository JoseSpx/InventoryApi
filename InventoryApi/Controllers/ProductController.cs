using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Dto.Layer;
using Domain.Layer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Layer;

namespace InventoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpPost("GetListProducts")]
        public IActionResult GetListProducts([FromBody] PaginationSearchDto paginationSearch)
        {
            var listaProducts = _productService.GetListProducts(paginationSearch.NumberPage, paginationSearch.QuantityPage);
            var listProductsDto = new List<ProductoDto>();
            listaProducts.ForEach(item =>
            {
                listProductsDto.Add(_mapper.Map<ProductoDto>(item));
            });
            return Ok(listProductsDto);
        }
    }
}