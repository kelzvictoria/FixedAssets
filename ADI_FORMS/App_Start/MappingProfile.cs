using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ADI_FORMS.App_Start;
using ADI_FORMS.Dtos;
using ADI_FORMS.Models;

namespace ADI_FORMS.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<FixedAsset, FixedAssetDto>();
            Mapper.CreateMap<AssetMaintenanceInterval, AssetMaintenanceIntervalDto>();
            Mapper.CreateMap<AssetStatus, AssetStatusDto>();
            Mapper.CreateMap<DepreciationMTD, DepreciationMTDDto>();
            Mapper.CreateMap<Branch, BranchDto>();
            Mapper.CreateMap<Category, CategoryDto>();
            Mapper.CreateMap<Location, LocationDto>();
            Mapper.CreateMap<Vendor, VendorDto>();
            Mapper.CreateMap<Grade, GradeDto>();
            Mapper.CreateMap<Company, CompanyDto>();
            Mapper.CreateMap<AssetsMaintenanceDetails, AssetsMaintenanceDetailsDto>();
            Mapper.CreateMap<State, StateDto>();
            Mapper.CreateMap<Country, CountryDto>();
            Mapper.CreateMap<Months, MonthsDto>();
            Mapper.CreateMap<EndOfMonth, EndOfMonthDto>();
            Mapper.CreateMap<AssetsMaintenanceCode, AssetsMaintenanceCodeDto>();
            Mapper.CreateMap<AssetsDetailReport, AssetsDetailReportDto>();
            Mapper.CreateMap<SortBy,SortByDto>();

            Mapper.CreateMap<EndOfYear, EndOfYearDto>();
            Mapper.CreateMap<FixedAssetDto, FixedAsset>()
                .ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<AssetsMaintenanceDetailsDto, AssetsMaintenanceDetails>()
                .ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<CompanyDto, Company>()
                .ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<VendorDto, Vendor>()
                .ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<EndOfMonthDto, EndOfMonth>()
                .ForMember(m => m.Id, opt => opt.Ignore());

            Mapper.CreateMap<EndOfYearDto, EndOfYear>()
                .ForMember(m => m.Id, opt => opt.Ignore());

            Mapper.CreateMap<AssetsMaintenanceCodeDto, AssetsMaintenanceCode>()
                .ForMember(m => m.Id, opt => opt.Ignore());

            Mapper.CreateMap<CategoryDto, Category>()
                .ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<BranchDto, Branch>()
                .ForMember(m => m.Id, opt => opt.Ignore());

            Mapper.CreateMap<AssetsDetailReportDto, AssetsDetailReport>()
                .ForMember(m => m.Id, opt => opt.Ignore());

            Mapper.CreateMap<SortByDto, SortBy>()
                .ForMember(m => m.Id, opt => opt.Ignore());

            Mapper.CreateMap<LocationDto, Location>()
                .ForMember(m => m.Id, opt => opt.Ignore());
        }
    }
}