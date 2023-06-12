using Context;
using Domain.Entity;
using System.Threading.Tasks;

namespace Services
{
    public class RequestServices : IRequestServices
    {
        public async Task AddRequestInfoAsync(RequestInfo info)
        {
            using (var context = new DataDbContext())
            {
                context.Info.Add(info);
                await context.SaveChangesAsync().ConfigureAwait(false);
            }
        }
    }
}
