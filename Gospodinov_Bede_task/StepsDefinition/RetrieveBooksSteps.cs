using Gospodinov_Bede_task.Helper;
using Gospodinov_Bede_task.Objects;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net;
using TechTalk.SpecFlow;

namespace Gospodinov_Bede_task.StepsDefinition
{
    [Binding]
    public class RetrieveBooksSteps
    {
        [StepDefinition(@"book is requested by Id")]
        public void GivenBookIsRequestedById()
        {
            Book foundBook = CrudBook.GetBook(ScenarioContext.Current.Get<Book>("seededBook").Id);

            ScenarioContext.Current.Set<Book>(foundBook, "foundBook");
        }

        [Then(@"the book has the same properties as expected")]
        public void ThenTheBookHasTheSamePropertiesAsExpected()
        {
            AssertHelper.PropertyValuesAreEquals(ScenarioContext.Current.Get<Book>("seededBook"),
                                                 ScenarioContext.Current.Get<Book>("foundBook"));
        }

        [Given(@"a book is requested by criteria ""(.*)""")]
        public void GivenABookIsRequestedByCriteria(string searchCriteria)
        {
            ScenarioContext.Current.Set<string>(CrudBook.GetBooksByTitleRequestResponseCode(searchCriteria),
                                                "responseCode");

            List<Book> foundBooks = CrudBook.GetBooksByTitle(searchCriteria);

            ScenarioContext.Current.Set<string>(searchCriteria, "searchCriteria");
            ScenarioContext.Current.Set<List<Book>>(foundBooks, "foundBooks");
        }

        [Then(@"the search result is correct")]
        public void ThenTheSearchResultIsCorrect()
        {
            var searchCriteria = ScenarioContext.Current.Get<string>("searchCriteria");
            var seededBooks = ScenarioContext.Current.Get<List<Book>>("seededBooks");
            List<Book> booksFromSearch = new List<Book>();

            foreach (var book in seededBooks)
            {
                if (book.Title.Contains(searchCriteria))
                {
                    booksFromSearch.Add(book);
                }
            }
            AssertHelper.AssertListsAreEquals(booksFromSearch,
                                              ScenarioContext.Current.Get <List<Book>>("foundBooks"));
        }

    }
}
