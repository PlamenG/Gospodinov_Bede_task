Feature: UpdateBook

@SeedBooks
@DeleteAllBooks
Scenario Outline: Update a book
Given a book is updated with the following properties - <Title>, <Author>, <Description>, <Id>
When update book request is executed
Then the book is available from the service as expected

Examples: 
| Title			| Author		| Description		| Id |
| autoTitle20	| autoAuthor20	| autoDescription20 | 2  |
| autoTitle		| autoAuthor	| 					| 7	 |
| 100 characters loooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooong autoTitle |  autoAuthor | autoDescription | 4 |
| autoTitle		| 30 characters loong autoAuthor	|  | 9 |
| autoTitle		| autoAuthor	|					| 1  |
| autoTitle		| autoAuthor	|					| 3  |