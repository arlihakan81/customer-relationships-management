using CRM.Application.Dtos.Companies;
using CRM.Application.Requests;
using CRM.Application.Responses;

namespace CRM.Application.Interfaces
{
    public interface ICompanyService
    {
        Task<BaseResponse<PagedResult<CompanyListDto>?>> GetAllAsync(QueryParams queryParams);

        Task CreateAsync(CreateCompanyDto request);


    }
}
