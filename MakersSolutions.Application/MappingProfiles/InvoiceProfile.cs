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
    public class InvoiceProfile : Profile
    {
        public InvoiceProfile()
        {
            CreateMap<Invoice, InvoiceDto>().ReverseMap();
            CreateMap<InvoiceStoredProcedure, InvoiceStoredProcedureDto>();
        }
    }
}
