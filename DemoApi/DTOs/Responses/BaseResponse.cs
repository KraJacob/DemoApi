using System.Net;

namespace DemoApi.DTOs.Responses
{
    public class BaseResponse
    {
        public int StatusCode { get; set; }
        public object Data { get; set; }

        /// <summary>
        /// this method can be use to generate the response object from the the class which are inherited from the BaseResponse class
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="data"></param>
        public void CreateResponse(HttpStatusCode statusCode, Object data)
        {
            StatusCode = (int)statusCode;
            this.Data = data;
        }
    }
}
