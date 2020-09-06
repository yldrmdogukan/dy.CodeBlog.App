using CodeBlog.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlog.Core.ResultTypes
{
    public class EntityResult
    {
        public string Message { get; set; }
        public ResultState State { get; set; }
        public EntityResult(string msg, ResultState state)
        {
            Message = msg;
            State = state;
        }

    }
    public class EntityResult<TData> : EntityResult where TData : class
    {
        public TData Data { get; set; }
        public EntityResult(TData data, string msg, ResultState state) : base(msg, state)
        {
            Data = data;
        }
    }
}
