using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jsender.Application;
using jsender.Requests;
using jsender.Responses;
using Microsoft.AspNetCore.Mvc;


namespace jsender.Controllers
{
  
    [Route("api/messages")]
    [ApiController]
    public class MessagesController : ControllerBase
    {

        private readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost("send")]
        public async Task<ActionResult> Send (SendMessageRequest request)
        {
            try
            {
                 await _messageService.SendMessageAsync(request.Message);

                return Ok();
            }
            catch (Exception ex)
            {
                SendMessageResponse response = new SendMessageResponse()
                {
                    Code = 500,
                    Message = ex.Message,
                    Description = "Internal Server Error"

                };

                return StatusCode(response.Code, response);

            }
        }

        [HttpGet("version")]
        public ActionResult GetVersion()
        {

            return Ok("v1");
        }
    }
}
