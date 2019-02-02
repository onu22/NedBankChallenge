using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using NedbankTest.Calls.Dtos;

namespace NedbankTest.Calls
{
    public interface ICallAppService : IAsyncCrudAppService<CallDto, int, PagedResultRequestDto, CreateCallDto, CallDto>
    {
    }

}
