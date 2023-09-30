namespace WebAPI.Models.Responses
{
    public class Response
    {
        public bool IsSuccess { get; set; }

        public string Error { get; set; }
    }

    public class Response< T > : Response
    {
        /// <summary> Empty constructor </summary>
        public Response()
        {
        }

        /// <summary> Create new success response </summary>
        /// <param name="result"></param>
        public Response( T result )
        {
            Result = result;
            IsSuccess = true;
        }

        /// <summary>
        /// Returned data
        /// </summary>
        public T Result { get; set; }
    }
}