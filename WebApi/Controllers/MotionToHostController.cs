using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using Entity;
using Core.Results;
using Core.Validation;
using FluentValidation.Results;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotionToHostController : Controller
    {
        IMotionToHostService _MotionToHostService;

        public MotionToHostController(IMotionToHostService MotionToHostService)
        {
            _MotionToHostService = MotionToHostService;
        }

        [HttpGet("get")]
        public MotionToHost Get()
        {
            return _MotionToHostService.Get();
        }

        [HttpPost("send")]
        public ActionResult Send(MotionToHost motionToHost)
        {
            MotionToHostValidator validator = new MotionToHostValidator();
            ValidationResult validationResult = validator.Validate(motionToHost);

            if (!validationResult.IsValid)
            {
                return Ok( new Result(false,validationResult.Errors[0].ErrorMessage));
            }

            Result result=_MotionToHostService.Send(motionToHost);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
