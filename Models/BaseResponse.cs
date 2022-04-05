using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace MiniBank.Models
{
    public class BaseResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }


        public BaseResponse() : this(status: true, "Success")

        {
        }

        public BaseResponse(bool status, string message)
        {
            Status = status;
            Message = message;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}