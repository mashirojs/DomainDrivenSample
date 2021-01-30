using System.Linq;
using System.Threading.Tasks;
using Application.Circles.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Circle.Common;
using WebApi.Models.Circle.Get;
using WebApi.Models.Circle.Index;
using WebApi.Models.Circle.JoinMember;
using WebApi.Models.Circle.Post;
using WebApi.Models.Circle.Put;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CircleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CircleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<CircleIndexResponseModel> Index()
        {
            var result = await _mediator.Send(new CircleGetListCommand());
            var circles = result.Circles.Select(x => new CircleResponseModel(x.Id, x.Name, x.Owner, x.Members));
            return new CircleIndexResponseModel(circles);
        }

        [HttpGet("{id}")]
        public async Task<CircleGetResponseModel> Get([FromRoute] string id)
        {
            var result = await _mediator.Send(new CircleGetCommand(id));
            return new CircleGetResponseModel(result.Cirlce);
        }

        [HttpPost]
        public async Task<CirclePostResponseModel> Post([FromBody] CirclePostRequestModel request)
        {
            var result = await _mediator.Send(new CircleRegisterCommand(request.Name, request.Owner));
            return new CirclePostResponseModel(result.Id);
        }

        [HttpPut("{id}")]
        public async Task Put([FromRoute] string id, [FromBody] CirclePutRequestModel request)
        {
            await _mediator.Send(new CircleUpdateCommand(id, request.Name));
        }

        [HttpPut("{id}/[action]")]
        public async Task JoinMember([FromRoute] string id, [FromBody] CircleJoinMemberRequestModel request)
        {
            await _mediator.Send(new CircleJoinMemberCommand(id, request.UserId));
        }

        [HttpDelete("{id}")]
        public async Task Delete([FromRoute] string id)
        {
            await _mediator.Send(new CircleDeleteCommand(id));
        }
    }
}