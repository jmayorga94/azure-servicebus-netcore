using System;
using System.Threading.Tasks;
using AutoMapper;
using jsender.API.Models;
using jsender.API.Requests;
using jsender.Application;
using jsender.Requests;
using jsender.Responses;
using Microsoft.AspNetCore.Mvc;


namespace jsender.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/transactions")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {

        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public TransactionsController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        [HttpPost("send")]
        public async Task<ActionResult> Send (SendSingleTransactionRequest request)
        {
            try
            {
                var transaction = _mapper.Map<Transaction>(request);

                 await _messageService.SendMessageAsync(transaction);

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

        [HttpPost("send/multiple")]
        public async Task<ActionResult> SendMultuple(SendMultipleTransactionsRequest request)
        {
            try
            {
                var transaction = _mapper.Map<Transaction>(request);

                await _messageService.SendMultipleMessages(request.Quantity,transaction);

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
