using Gospodinov_Bede_task.Helper;
using Gospodinov_Bede_task.Objects;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Gospodinov_Bede_task.StepsDefinition
{
    [Binding]
    public sealed class DataSeed
    {
        [BeforeScenario("SeedBook")]
        public void SeedBook()
        {
            var book = new Book(33, "autoAuthor", "autoTitle", "autoDescription");
           
            ScenarioContext.Current.Set<Book>(book, "seededBook");

            ResponseCodeAndPayload<Book> response = CrudBook.PostNewBook(book);
            ExceptionHandler.ThrowIfStatusCodeNotOk(response.ResponseCode);
        }

        [BeforeScenario("SeedBooks")]
        public void SeedBooks()
        {
            List<Book> books = new List<Book>();

            for (int i = 1; i <= 10; i++)
            {
                books.Add(new Book(i, "autoAuthor" + i, "autoTitle" + i, "autoDescription" + i));
            }

            ScenarioContext.Current.Set<List<Book>>(books, "seededBooks");

            foreach (var book in books)
            {
                ResponseCodeAndPayload<Book> response = CrudBook.PostNewBook(book);
                ExceptionHandler.ThrowIfStatusCodeNotOk(response.ResponseCode);
            }
        }

        [AfterScenario("DeleteSeededBook")]
        public void DeleteSeededBook()
        {
            var book = ScenarioContext.Current.Get<Book>("seededBook");
            var response = CrudBook.DeleteBook(book.Id);

            ExceptionHandler.ThrowIfStatusCodeNotNoContent(response.ResponseCode);
        }

        [AfterScenario("DeleteAllBooks")]
        public void DeleteAllBooks()
        {
            List<Book> books = CrudBook.GetAllBooks().PayLoadObject;

            foreach (var book in books)
            {
                ExceptionHandler.ThrowIfStatusCodeNotNoContent(CrudBook.DeleteBook(book.Id).ResponseCode);
            }
        }
    }

}
