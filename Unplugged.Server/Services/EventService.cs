using System;
using System.IO;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Unplugged.Server.Database;
using Unplugged.Server.Utils;
using UnpluggedModel;

namespace Unplugged.Server.Services
{
    public class EventService : UnpluggedModel.EventService.EventServiceBase
    {
        private readonly UPContext _ctx;

        public EventService(UPContext ctx)
        {
            _ctx = ctx;
        }

        [Authorize(Policy = nameof(UserRole.Common))]
        public override async Task<EventListResponse> GetList(EmptyRequest request, ServerCallContext context)
        {
            var events = await _ctx.Events.ToListAsync();
            var ret = new EventListResponse();
            ret.Events.AddRange(events);
            var file = File.ReadAllBytes(".\\cover.jpg");
            var data = Convert.ToBase64String(file);
            var small = ImageUtils.GetSmallBase64(data);
            for (int i = 0; i < 22; i++)
            {
                ret.Events.Add(new Event
                {
                    EventName = $"Unplugged #{i}",
                    CoverData = small,
                    StartTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                    Type = EventType.Unplugged,
                    Status = i < 20 ? EventStatus.Finished : EventStatus.Planning
                });
            }


            return ret;
        }
    }
}