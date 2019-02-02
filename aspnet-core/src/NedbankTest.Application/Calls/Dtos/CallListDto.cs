using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace NedbankTest.Calls.Dtos
{

    [AutoMapFrom(typeof(Call))]
    public class CallListDto : FullAuditedEntityDto<int>
    {
        public string Code { get; set; }

        public string Description { get; set; }
    }
}
