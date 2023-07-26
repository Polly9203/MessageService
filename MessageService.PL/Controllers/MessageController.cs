using MediatR;
using MessageService.BLL.DeleteMessages.Commands;
using MessageService.BLL.GetMessages.Queries;
using MessageService.BLL.Models;
using MessageService.BLL.SendMessage.Commands;
using Microsoft.AspNetCore.Mvc;


namespace MessageService.PL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : BaseController
    {
        public MessageController(IMediator mediator) : base(mediator) { }

        [HttpPost]
        [ProducesResponseType(typeof(MessageResult), StatusCodes.Status200OK)]
        public async Task<ActionResult<MessageResult>> SendMessage([FromBody] SendMessageCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteAllMessages()
        {
            await Mediator.Send(new DeleteAllMessagesCommand());

            return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(IEnumerable<MessageResult>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<MessageResult>>> GetAllMessages()
        {
            var result = await Mediator.Send(new GetAllMessagesQuery());

            if (!result.Any())
            {
                return NoContent();
            }
            else
            {
                return Ok(result);
            }
        }
    }
}
