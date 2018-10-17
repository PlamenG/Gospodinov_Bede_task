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


        public static string PostNewBook(Object content)
        {
            Task<HttpResponseMessage> responseMessage = Client.client.PostAsJsonAsync(url + bookActionEndPoint, content);
            return RequestResponseStatusCodeSynchronously(responseMessage);
        }

        public static List<Book> GetAllBooks()
        {
            Task<HttpResponseMessage> responseMessage = Client.client.GetAsync(url + getAllBooksEndPoint);
            return GetObjectFromResponse<List<Book>>(responseMessage);
        }

        public static List<Book> GetBooksByTitle(string titleSearch)
        {
            Task<HttpResponseMessage> responseMessage = Client.client.GetAsync(url + getAllBooksEndPoint + titleSearch);
            return GetObjectFromResponse<List<Book>>(responseMessage);
        }

        public static string GetBooksByTitleRequestResponseCode(string titleSearch)
        {
            Task<HttpResponseMessage> responseMessage = Client.client.GetAsync(url + getAllBooksEndPoint + titleSearch);
            return RequestResponseStatusCodeSynchronously(responseMessage);
        }

        public static Book GetBook(long id)
        {
            Task<HttpResponseMessage> responseMessage = Client.client.GetAsync(url + bookActionEndPoint + @"/" + id.ToString());
            return GetObjectFromResponse<Book>(responseMessage);
        }

        public static string DeleteBook(long id)
        {
            Task<HttpResponseMessage> response = Client.client.DeleteAsync(url + bookActionEndPoint + @"/" + id.ToString());
            return RequestResponseStatusCodeSynchronously(response);
        }

        public static ResponseCodeAndPayload UpdateBook(long id)
        {
            Task<HttpResponseMessage> response = Client.client.DeleteAsync(url + bookActionEndPoint + @"/" + id.ToString());
            return new ResponseCodeAndPayload(RequestResponseStatusCodeSynchronously(response),
                                              GetObjectFromResponse<Book>(response));
        }

        private static string RequestResponseStatusCodeSynchronously(Task<HttpResponseMessage> httpResponseMessage)
        {
            httpResponseMessage.Result.Content.ReadAsStringAsync().Wait();
            return httpResponseMessage.Result.StatusCode.ToString();
        }

        //private static Book ResponseContentSingleBook(Task<HttpResponseMessage> httpResponseMessage)
        //{
        //    httpResponseMessage.Wait();
        //    return GetObjectFromResponse<Book>(httpResponseMessage);
        //}

        //private static List<Book> ResponseContentMultipleBooks(Task<HttpResponseMessage> httpResponseMessage)
        //{
        //    httpResponseMessage.Wait();
        //    return GetObjectFromResponse<List<Book>>(httpResponseMessage);
        //}

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
