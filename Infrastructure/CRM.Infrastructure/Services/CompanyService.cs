using AutoMapper;
using CRM.Application.Dtos.Companies;
using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using CRM.Application.Requests;
using CRM.Application.Responses;
using CRM.Domain.Entities;

namespace CRM.Infrastructure.Services
{
    public class CompanyService(IRepository<Company, Guid> repository, IMapper mapper) : ICompanyService
    {
        private readonly IRepository<Company, Guid> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task CreateAsync(CreateCompanyDto request)
        {
            await _repository.AddAsync(_mapper.Map<Company>(request));
        }

        public async Task<BaseResponse<PagedResult<CompanyListDto>?>> GetAllAsync(QueryParams queryParams)
        {
            var data = await _repository.GetAllAsync(queryParams.Page, queryParams.PageSize, _ => _.Name.Contains(queryParams.SearchTerm));          
            return BaseResponse<PagedResult<CompanyListDto>>.SuccessResult(200, _mapper.Map<PagedResult<CompanyListDto>>(data))!;            
        }
    }
}
