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
            ScenarioContext.Current.Set<Book>(newBook, "testedBook");
        }


        [When(@"create book request is executed")]
        public void WhenCreateBookRequestIsExecuted()
        {
            ResponseCodeAndPayload<Book> responseCodeAdnPayload = CrudBook.PostNewBook(ScenarioContext.Current.Get<Book>("testedBook"));

            ScenarioContext.Current.Set<ResponseCodeAndPayload<Book>>(responseCodeAdnPayload, "responseCodeAdnPayload");
        }

        [Then(@"the book is available from the service as expected")]
        public void ThenTheBookIsUpdated()
        {
            var response = ScenarioContext.Current.Get<ResponseCodeAndPayload<Book>>("responseCodeAdnPayload");
            Assert.AreEqual(HttpStatusCode.OK.ToString()
                            , response.ResponseCode
                            , "Book creation failed with {0}", response.ResponseCode);

            Book actualBookInService = CrudBook.GetBook(response.PayLoadObject.Id).PayLoadObject;

            AssertHelper.PropertyValuesAreEquals(ScenarioContext.Current.Get<Book>("testedBook"),
                                                response.PayLoadObject);
            AssertHelper.PropertyValuesAreEquals(ScenarioContext.Current.Get<Book>("testedBook"),
                                                actualBookInService);
        }
        
        [Then(@"the response code is Bad Request")]
        public void ThenTheResponseCodeIsBadRequest()
        {
            var response = ScenarioContext.Current.Get<ResponseCodeAndPayload<Book>>("responseCodeAdnPayload");
            Assert.AreEqual(HttpStatusCode.BadRequest.ToString()
                            , response.ResponseCode
                            , "Book creation failed with {0}", response);
        }
    }
}
