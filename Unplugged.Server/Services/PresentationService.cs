using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Unplugged.Server.Database;
using UnpluggedModel;

namespace Unplugged.Server.Services
{
    public class PresentationService : UnpluggedModel.PresentationService.PresentationServiceBase
    {
        private readonly UPContext _ctx;

        public PresentationService(UPContext ctx)
        {
            _ctx = ctx;
        }

        [Authorize(Policy = nameof(UserRole.Moderator))]
        public override async Task<PresentationListResponse> GetPresentationList(EmptyRequest request, ServerCallContext context)
        {
            var presentations = await _ctx.Presentations.Include(t=>t.User).Where(t => string.IsNullOrEmpty(t._EventId)).ToListAsync();

            var ret = new PresentationListResponse();
            ret.Presentations.AddRange(presentations);

            return ret;
        }
    }
}