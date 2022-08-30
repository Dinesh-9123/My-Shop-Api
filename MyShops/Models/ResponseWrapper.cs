using Microsoft.AspNetCore.Hosting.Server;

namespace MyShops.Models
{
    public class ResponseWrapper<T>
    {

        public ResponseWrapper()
        {

        }
        public ResponseWrapper(T res)
        {
            result = res;
        }

        public void Set(T res)
        {
            result = res;
        }
        public void Set(Exception exception)
        {
            isError = true;
            errorMessage = exception?.Message;
        }
        public T result { get; set; }
        public bool isError { get; set; }
        public string errorMessage { get; set; }
    }
}
