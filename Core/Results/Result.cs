using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Results
{
    public class Result
    {
        public bool Success { get; set; }

        public String Message { get; set; }


        public Result(bool Success,String Message)
        {
            this.Success=Success;
            this.Message = Message;
        }
    }
}
