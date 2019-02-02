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

        public async Task CreateAsync(CreateCallDto input)
        {

            try
            {
                //var tenantId = AbpSession.GetTenantId();

                var user = UserManager.FindByIdAsync(AbpSession.GetUserId().ToString());
                var @call = Call.Create(1, input.Code, user.Result, input.Description);
                await _callManager.CreateAsync(@call);
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

    }
}
