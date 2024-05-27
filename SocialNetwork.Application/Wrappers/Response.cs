

namespace SocialNetwork.Application.Wrappers
{
    /// <summary>
    /// Respuesta Estandar de la API 
    /// </summary>
    public class Response<T>
        {
            public Response()
            {
            }
            public Response(T data, string? message = null)
            {
                Succeeded = true;
                Message = message ?? "";
                Data = data;
            }
            public Response(string message)
            {
                Succeeded = false;
                Message = message;
            }
            public bool Succeeded { get; set; }
            public string? Message { get; set; }
            public T? Data { get; set; }

        }

}
