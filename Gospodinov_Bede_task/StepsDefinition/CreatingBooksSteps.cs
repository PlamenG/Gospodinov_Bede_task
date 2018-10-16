using Gospodinov_Bede_task.Helper;
using Gospodinov_Bede_task.Objects;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net;
using TechTalk.SpecFlow;

namespace Gospodinov_Bede_task.StepsDefinition
{
    [Binding]
    public sealed class CreatingBooksSteps
    {
        [Given(@"a book is created with the following properties - (.*), (.*), (.*), (.*)")]
        public void GivenABookIsCreatedWithTheFollowingProperties_(string title, string author, string description, long id)
        {
            Book newBook = new Book(id, author, title, description);
            ScenarioContext.Current.Set<Book>(newBook, "createdBook");
        }


        [When(@"create book request is executed")]
        public void WhenCreateBookRequestIsExecuted()
        {
            string responseCode = CrudBook.PostNewBook(ScenarioContext.Current.Get<Book>("createdBook"));

            ScenarioContext.Current.Set<string>(responseCode, "responseCode");
        }

        [Then(@"the book is available from the service")]
        public void ThenTheBookIsAvailableAtTheService()
        {
            var responseCode = ScenarioContext.Current.Get<string>("responseCode");
            Assert.AreEqual(HttpStatusCode.OK.ToString()
                            , responseCode
                            , "Book creation failed with {0}", responseCode);

            Book actualBook = CrudBook.GetBook(ScenarioContext.Current.Get<Book>("createdBook").Id);

            AssertHelper.PropertyValuesAreEquals(ScenarioContext.Current.Get<Book>("createdBook"),
                                                actualBook);
        }

        [Then(@"the response code is Bad Request")]
        public void ThenTheResponseCodeIsBadRequest()
        {
            var responseCode = ScenarioContext.Current.Get<string>("responseCode");
            Assert.AreEqual(HttpStatusCode.BadRequest.ToString()
                            , responseCode
                            , "Book creation failed with {0}", responseCode);
        }


    }
}
