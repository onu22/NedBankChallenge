using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Services;
using NedbankTest.Authorization.Users;


namespace NedbankTest.Calls
{
    public interface ICallManager : IDomainService
    {

        Task<Call> GetAsync(int id);

        Task CreateAsync(Call @call);
    }
}
