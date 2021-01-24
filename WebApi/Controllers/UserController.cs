using System.Linq;
using System.Threading.Tasks;
using Application.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Users.Common;
using WebApi.Models.Users.Get;
using WebApi.Models.Users.Index;
using WebApi.Models.Users.Post;
using WebApi.Models.Users.Put;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<UserIndexResponseModel> Index([FromQuery] UserIndexRequestModel request)
        {
            var result = await _mediator.Send(new UserGetListCommand(request.Page, request.DisplayCount, request.Search));
            var users = result.Users.Select(x => new UserResponseModel(x)).ToList();
            return new UserIndexResponseModel(users);
        }

        [HttpGet("{id}")]
        public async Task<UserGetResponseModel> Get(string id)
        {
            var result = await _mediator.Send(new UserGetCommand(id));
            var user = new UserResponseModel(result.User);
            return new UserGetResponseModel(user);
        }

        [HttpPost]
        public async Task<UserPostResponseModel> Post([FromBody] UserPostRequestModel request)
        {
            var result = await _mediator.Send(new UserRegisterCommand(request.Name));
            return new UserPostResponseModel(result.Id);
        }

        [HttpPut("{id}")]
        public async Task Put(string id, [FromBody]UserPutRequestModel request)
        {
            await _mediator.Send(new UserUpdateCommand(id, request.Name));
        }

        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await _mediator.Send(new UserDeleteCommand(id));
        }
    }
}
