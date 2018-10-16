Feature: UsingBooks

@SeedBook
@DeleteAllBooks
Scenario: Get book by Id
Given book is requested by Id
Then the book has the same properties as expected
 
@SeedBooks
@DeleteAllBooks
Scenario Outline: Get book by search
Given a book is requested by criteria "<searchString>"
Then the search result is correct
Examples: 
| searchString |
| auto         |
| 2 |
| autoTitle |
| 31 |
| e1 |
| autoTitle9 |
|  |

Scenario: Search for too long title
Given a book is requested by criteria "101 characters looooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooong autoTitle"
Then the response code is Bad Request
