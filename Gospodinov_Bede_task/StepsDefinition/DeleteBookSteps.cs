using Gospodinov_Bede_task.Helper;
using Gospodinov_Bede_task.Objects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using TechTalk.SpecFlow;

namespace Gospodinov_Bede_task.StepsDefinition
{
    [Binding]
    public sealed class DeleteBookSteps
    {
        [Given(@"book is deleted by Id (.*)")]
        public void GivenBookIsDeletedById(int id)
        {
            Book deletedBook = CrudBook.GetBook(id).PayLoadObject;
            ResponseCodeAndPayload<ResponseMessageContent> deletedRequestMessage = CrudBook.DeleteBook(id);

            ScenarioContext.Current.Set<Book>(deletedBook, "deletedBook");
            ScenarioContext.Current.Set<ResponseCodeAndPayload<ResponseMessageContent>>
                                        (deletedRequestMessage, "deletedRequestMessage");
        }

        [Then(@"the book is no longer availabl in the service")]
        public void ThenTheBookIsNoLongerAvailablInTheService()
        {
            List<Book> foundBooks = CrudBook.GetAllBooks().PayLoadObject;

            var response = ScenarioContext.Current
                                          .Get<ResponseCodeAndPayload<ResponseMessageContent>>("deletedRequestMessage");

            Assert.AreEqual(HttpStatusCode.NoContent.ToString(),
                            response.ResponseCode,
                            "Book creation failed with {0}", response.ResponseCode);

            foreach (var book in foundBooks)
            {
                Assert.AreNotEqual(ScenarioContext.Current.Get<Book>("deletedBook").Id,
                                   book.Id,
                                   "Book was not deleted!");
            }
        }
    }
}
