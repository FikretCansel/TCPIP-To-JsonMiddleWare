using Core.TcpClient;
using Core.TcpObjects.Receive.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TcpTestController : ControllerBase
    {
        TcpClientManager tcpServerService;
        public TcpTestController()
        {
            tcpServerService = new TcpClientManager();
        }
        [HttpGet("get")]
        public IActionResult ReceiveTest()
        {
            tcpServerService.Send("sa");
            while (tcpServerService.tcpObject == null);
            return Ok((SettedLimit)tcpServerService.tcpObject);
        }
    }
}
