using AutoMapper;
using Domain.Dto.Layer;
using Domain.Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApi.Config
{
    public static class AutoMapperConfig
    {
        public static IMapper Config()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductoDto, Producto>();
                cfg.CreateMap<Producto, ProductoDto>();
            });
            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}
