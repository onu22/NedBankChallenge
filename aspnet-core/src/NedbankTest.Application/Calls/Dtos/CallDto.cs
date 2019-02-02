using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using NedbankTest.Authorization.Users;

namespace NedbankTest.Calls.Dtos
{
    [AutoMapFrom(typeof(Call))]
    public class CallDto : FullAuditedEntityDto<int>
    {
        public string Code { get; set; }

        public string Description { get; set; }

        public int TenantId { get; set; }
        public long UserId { get; set; }
      
    }
}
