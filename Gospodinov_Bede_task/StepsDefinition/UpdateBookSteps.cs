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
    public sealed class UpdateBookSteps
    {
        [Given(@"a book is updated with the following properties - (.*), (.*), (.*), (.*)")]
        public void GivenABookIsUpdatedWithTheFollowingProperties(string title, string author, string description, long id)
        {
            Book newBook = new Book(id, author, title, description);
            ScenarioContext.Current.Set<Book>(newBook, "testedBook");
        }

        [When(@"update book request is executed")]
        public void WhenUpdateBookRequestIsExecuted()
        {
            var bookToBeUpdated = ScenarioContext.Current.Get<Book>("testedBook");
            var responseCodeAdnPayload = CrudBook.UpdateBook(bookToBeUpdated.Id, bookToBeUpdated);

            ScenarioContext.Current.Set<ResponseCodeAndPayload<Book>>(responseCodeAdnPayload, "responseCodeAdnPayload");
        }

        [Then(@"the book is updated")]
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
    }
}
