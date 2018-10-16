Feature: CreatingBooks

@DeleteAllBooks
Scenario Outline: create a book
Given a book is created with the following properties - <Title>, <Author>, <Description>, <Id>
When create book request is executed
Then the book is available from the service
Examples: 
| Title     | Author     | Description     | Id |
| autoTitle | autoAuthor | autoDescription | 91 |
| autoTitle | autoAuthor |				   | 91 |
| 100 characters loooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooong autoTitle |  autoAuthor | autoDescription | 91 |
| autoTitle | 30 characters loong autoAuthor | autoDescription | 91 |
| autoTitle | autoAuthor | 900 autoDescription looooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooong | 91 |
| autoTitle | autoAuthor | autoDescription | 2147483647 |

@DeleteAllBooks
@SeedBook
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
| autoTitle | autoAuthor | autoDescription | 2147483648  |
| 101 characters looooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooong autoTitle | autoAuthor | autoDescription | 91 |
| autoTitle |  31 characters looong autoAuthor | autoDescription | 91 |
# Same Id as the seeded book
| autoTitle | autoAuthor | autoDescription | 33 |

