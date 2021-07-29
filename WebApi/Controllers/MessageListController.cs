using Business.Abstract;
using Core.Results;
using Core.Validation;
using Entity.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public class MessageListController : Controller
        {
            IMessageListService _MessageListService;

            public MessageListController(IMessageListService MessageListService)
            {
                _MessageListService = MessageListService;
            }

            [HttpGet("get")]
            public MessageList Get()
            {
                return _MessageListService.Get();
            }

            [HttpGet("send")]
            public ActionResult Send()
            {
            MessageListValidator validator = new MessageListValidator();
            /*ValidationResult validationResult = validator.Validate(messageList);

            if (!validationResult.IsValid)
            {
                return Ok(new Result(false, validationResult.Errors[0].ErrorMessage));
            }*/

            Result result = _MessageListService.TestSend("asdasd");
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
        }
    }

