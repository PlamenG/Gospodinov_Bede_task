Feature: RetrievingBooks

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
| e1 |
| autoTitle9 |
|  |
# For no results
| 31 |
| autotitle |
| AUTOTITLE |

Scenario: Search for too long title is not possible
Given a book is requested by criteria "101 characters looooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooong autoTitle"
Then the response code for searching is Bad Request
