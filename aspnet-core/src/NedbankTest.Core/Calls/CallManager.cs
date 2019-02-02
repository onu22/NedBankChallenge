using System;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.UI;

namespace NedbankTest.Calls
{
    public class CallManager : ICallManager
    {
        private readonly IRepository<Call, int> _callRepository;

        public CallManager(IRepository<Call, int> callRepository)
        {
            _callRepository = callRepository;
        }

        public async Task<Call> GetAsync(int id)
        {
            var @call = await _callRepository.FirstOrDefaultAsync(id);
            if (@call == null)
            {
                throw new UserFriendlyException("Could not found the call, maybe it's deleted!");
            }

            return @call;
        }

        public async Task CreateAsync(Call @call)
        {
            await _callRepository.InsertAsync(@call);
        }

       
    }
}
