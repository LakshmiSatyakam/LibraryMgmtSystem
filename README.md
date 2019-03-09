# LibraryMgmtSystem


Instruction to build and run LibraryMgmtSystem APIs:

1) Clone the complete repository 
2) Go to ~\LibraryMgmtSystem folder in explorer
3) Open LibraryMgmtSystem.sln in Visual Studio 2017
4) Build the Solution
5) Next set the LibraryMgmtSystem project as 'Start up project' and run (F5 or Ctrl+F5)
6) Api will be hosted now, which opens a web browser
7) Open any of API testing tools like Postman

Example requests:
   Get all books: Select GET verb
	a. http://localhost:49229/api/books/getall
	b. http://localhost:49229/api/books/getoverdue

   Borrow a book: Select POST verb
	a. http://localhost:49229/api/booksassign/assignbook
		Input body:		
		{ "studentId":"8",
"bookId":"8"}

   Renew a book: Select PUT verb
	a. http://localhost:49229/api/booksrenew/renewbook
		Input body:
		{ "studentId":"1",
"bookId":"2"}

==============================================================================================


In-memory store data set:
-------------------------

1. Books:

|---------------------------------------------------------------------------------------------|
|	Id 	| Name			 						      |
|---------------------------------------------------------------------------------------------|
|	1	| Year 3 NAPLAN Literacy tests                                                |
|	2	| The Girl who saved the king of sweden					      |
|	3	| Hundred years of solitude						      |
|	4	| Sophie's world							      |
|	5	| The Phoenix project: A novel about IT, DevOps & Helping your business win   |
|	6	| Matilda								      |
|	7	| Tom Gates Epic							      |
| 	8	| Dairy of Anne Frank							      |
|---------------------------------------------------------------------------------------------|

2. Students

|--------------------------|
|	Id 	| Name     |
|--------------------------|
|	1	| Amar     |
|	2	| Akbar    |
|	3	| Antony   |
|	4	| Ram	   |
|	5	| Rahim    |
|	6	| Robin    |
|	7	| Prachu   |
| 	8	| Pillip   |
|--------------------------|

3. AssignDetails

|---------------------------------------------------|
|	Id 	| BookId   | StudentId |  DueDate   |
|---------------------------------------------------|
|	1	| 2        |  1        | 26-02-2019 | 
|	2	| 5        |  2        | 20-03-2919 |
|	3	| 6        |  3        | 20-03-2019 |
|	4	| 7        |  4        | 23-03-2019 |
|	5	| 1        |  4        | 23-02-2019 |
|---------------------------------------------------|

==============================================================================================


Design details:
---------------

1. Dependency injection is achieved using AutoFac
2. Repository pattern is used for data
3. Composite pattern is used in Controllers
4. SOLID principles is adhered for the classes

==============================================================================================