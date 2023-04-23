using System;

namespace Application.Dto.Common
{
    public class ResponseMessageDto
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public object Data { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
