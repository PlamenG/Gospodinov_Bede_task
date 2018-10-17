Feature: DeleteBook

@SeedBooks
@DeleteAllBooks
Scenario: Delete a book
Given book is deleted by Id 6
Then the book is no longer availabl in the service