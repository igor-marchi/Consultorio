using System;

namespace CL.Core.Shared.ModelViews
{
    public class ErrorResponse
    {
        public ErrorResponse(string id, string requestId)
        {
            Id = id;
            RequestId = requestId;
            Date = DateTime.Now;
            Message = "Erro Inesperado";
        }

        public string Id { get; set; }

        public string RequestId { get; set; }


        public DateTime Date { get; set; }

        public string Message { get; set; }
    }
}