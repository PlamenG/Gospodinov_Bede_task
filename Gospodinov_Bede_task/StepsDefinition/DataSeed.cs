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

            string response = CrudBook.PostNewBook(book);
            ExceptionHandler.ThrowIfStatusCodeNotOk(response);
        }

        [AfterScenario("DeleteSeededBook")]
        public void DeleteSeededBook()
        {
            var book = ScenarioContext.Current.Get<Book>("seededBook");
            var response = CrudBook.DeleteBook(book.Id);

            ExceptionHandler.ThrowIfStatusCodeNotNoContent(response);
        }

        [AfterScenario("DeleteAllBooks")]
        public void DeleteAllBooks()
        {
            List<Book> books = CrudBook.GetAllBooks();

            foreach (var book in books)
            {
                var response = CrudBook.DeleteBook(book.Id);
                ExceptionHandler.ThrowIfStatusCodeNotNoContent(response);
            }
        }
    }

}
