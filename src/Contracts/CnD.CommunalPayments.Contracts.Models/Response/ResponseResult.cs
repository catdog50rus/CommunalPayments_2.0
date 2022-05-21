using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnD.CommunalPayments.Contracts.Models.Response
{
    public class ResponseResult<T> : BaseResponse where T : class, new()
    {
        public T Result { get; set; }
    }

    public class ResponseResult : BaseResponse
    {

    }
}