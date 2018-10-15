Feature: CreatingBooks

@DeleteAllBooks
Scenario Outline: create a book
Given a book is created with the following properties - <Title>, <Author>, <Description>, <Id>
When create book request is executed
Then the book is available at the service
Examples: 
| Title     | Author     | Description     | Id |
| autoTitle | autoAuthor | autoDescription | 91 |
| autoTitle | autoAuthor |				   | 91 |
| very very very very very very very very very very very very very very very very very long autoTitle |  567 very very long autoAuthor |  very very very very very very very very very very very very very very very very very long very very very very very very very very very very very very very very very very very long  autoDescription | 1234567890 |

@DeleteAllBooks
Scenario Outline: create a book with wrong property
Given a book is created with the following properties - <Title>, <Author>, <Description>, <Id>
When create book request is executed
Then the response code is Bad Request
Examples: 
| Title     | Author     | Description     | Id |
| autoTitle |            | autoDescription | 91 |
|           | autoAuthor | autoDescription | 91 |
| autoTitle | autoAuthor | autoDescription | -1 |
| autoTitle | autoAuthor | autoDescription | 0  |
| too long very very very very very very very very very very very very very very very very very long autoTitle |  567 very very long autoAuthor |  very very very very very very very very very very very very very very very very very long very very very very very very very very very very very very very very very very very long  autoDescription | 1234567890 |
| autoTitle |  too long very very long autoAuthor |  very very very very very very very very very very very very very very very very very long very very very very very very very very very very very very very very very very very long  autoDescription | 1234567890 |
