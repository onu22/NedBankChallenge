using System;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using NedbankTest.Calls.Dtos;
using Abp.Authorization;
using Abp.Application.Services;
using NedbankTest.Authorization.Users;

namespace NedbankTest.Calls
{
    [AbpAuthorize]
    public class CallAppService : AsyncCrudAppService<Call, CallDto, int, PagedResultRequestDto, CreateCallDto, CallDto>, ICallAppService
    {
        private readonly ICallManager _callManager;
        private readonly IRepository<Call, int> _callRepository;
      
        public UserManager UserManager { get; set; }
        public CallAppService(IRepository<Call, int> repository, ICallManager callManager)
            : base(repository)
        {
            _callManager = callManager;
            _callRepository = repository;
        }


        public override async Task<CallDto> Update(CallDto input)
        {            
             var call = await _callManager.GetAsync(input.Id);
             MapToEntity(input, call);
             call.UserId= AbpSession.UserId.Value;
             call.TenantId = 1; //AbpSession.GetTenantId();
             await _callManager.UpdateAsync(call);            
             return await Get(input);
        }


        public override async Task<CallDto> Create(CreateCallDto input)
        {
            var tenantId = 1; //AbpSession.GetTenantId();
            var user = UserManager.FindByIdAsync(AbpSession.GetUserId().ToString());
             var call = await _callManager.CreateAsync(Call.Create(tenantId, input.Code, user.Result, input.Description));
            return MapToEntityDto(call);

        }
    }
}
