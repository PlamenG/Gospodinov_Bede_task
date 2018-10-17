using Gospodinov_Bede_task.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Gospodinov_Bede_task.Helper
{
    public static class CrudBook
    {
        private static readonly string url = @"http://localhost:9000/api";
        private static readonly string getAllBooksEndPoint = @"/books?title=";
        private static readonly string bookActionEndPoint = @"/books";


        public static ResponseCodeAndPayload<Book> PostNewBook(Object content)
        {
            Task<HttpResponseMessage> responseMessage = Client.client.PostAsJsonAsync(url + bookActionEndPoint, content);
            return new ResponseCodeAndPayload<Book>(RequestResponseStatusCodeSynchronously(responseMessage),
                                                    GetObjectFromResponse<Book>(responseMessage));
        }

        public static ResponseCodeAndPayload<List<Book>> GetAllBooks()
        {
            Task<HttpResponseMessage> responseMessage = Client.client.GetAsync(url + getAllBooksEndPoint);
            return new ResponseCodeAndPayload<List<Book>>(RequestResponseStatusCodeSynchronously(responseMessage),
                                                    GetObjectFromResponse<List<Book>>(responseMessage));
        }

        public static ResponseCodeAndPayload<List<Book>> GetBooksByTitle(string titleSearch)
        {
            Task<HttpResponseMessage> responseMessage = Client.client.GetAsync(url + getAllBooksEndPoint + titleSearch);
            return new ResponseCodeAndPayload<List<Book>>(RequestResponseStatusCodeSynchronously(responseMessage),
                                                    GetObjectFromResponse<List<Book>>(responseMessage));
        }

        //public static string GetBooksByTitleRequestResponseCode(string titleSearch)
        //{
        //    Task<HttpResponseMessage> responseMessage = Client.client.GetAsync(url + getAllBooksEndPoint + titleSearch);
        //    return RequestResponseStatusCodeSynchronously(responseMessage);
        //}

        public static ResponseCodeAndPayload<Book> GetBook(long id)
        {
            Task<HttpResponseMessage> responseMessage = Client.client.GetAsync(url + bookActionEndPoint + @"/" + id.ToString());
            return new ResponseCodeAndPayload<Book>(RequestResponseStatusCodeSynchronously(responseMessage),
                                                    GetObjectFromResponse<Book>(responseMessage));
        }

        public static ResponseCodeAndPayload<ResponseMessageContent> DeleteBook(long id)
        {
            Task<HttpResponseMessage> response = Client.client.DeleteAsync(url + bookActionEndPoint + @"/" + id.ToString());
            return new ResponseCodeAndPayload<ResponseMessageContent>(RequestResponseStatusCodeSynchronously(response),
                                              GetObjectFromResponse<ResponseMessageContent>(response));
        }

        public static ResponseCodeAndPayload<Book> UpdateBook(long id, Object content)
        {
            Task<HttpResponseMessage> response = Client.client.PutAsJsonAsync(url + bookActionEndPoint + @"/" + id.ToString(),
                                                                              content);
            return new ResponseCodeAndPayload<Book>(RequestResponseStatusCodeSynchronously(response),
                                              GetObjectFromResponse<Book>(response));
        }

        private static string RequestResponseStatusCodeSynchronously(Task<HttpResponseMessage> httpResponseMessage)
        {
            httpResponseMessage.Result.Content.ReadAsStringAsync().Wait();
            return httpResponseMessage.Result.StatusCode.ToString();
        }
        
        private static ResponseMessageContent ResponseContentMessage(Task<HttpResponseMessage> httpResponseMessage)
        {
            var responseMessageContent = GetObjectFromResponse<ResponseMessageContent>(httpResponseMessage);
            return GetObjectFromResponse<ResponseMessageContent>(httpResponseMessage);
        }

        private static T GetObjectFromResponse<T>(Task<HttpResponseMessage> httpResponseMessage)
        {
            httpResponseMessage.Wait();

            if (httpResponseMessage.Result.IsSuccessStatusCode)
            {
                var messageResult = httpResponseMessage.Result.Content.ReadAsAsync<T>();
                messageResult.Wait();
                return messageResult.Result;
            }
            return default(T);
        }
    }
}
