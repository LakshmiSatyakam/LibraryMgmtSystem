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

===================================================================

In-memory store data set:
-------------------------

Please refer "InputData.txt"

===================================================================


Design details:
---------------

1. Dependency injection is achieved using AutoFac
2. Repository pattern is used for data
3. Composite pattern is used in Controllers
4. SOLID principles is adhered for the classes

===================================================================
