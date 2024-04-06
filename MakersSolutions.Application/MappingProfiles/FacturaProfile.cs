using AutoMapper;
using MakersSolutions.Application.DTOs;
using MakersSolutions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakersSolutions.Application.MappingProfiles
{
    public class FacturaProfile : Profile
    {
        public FacturaProfile()
        {
            CreateMap<Factura, InvoiceDto>().ReverseMap();
        }
    }
}
