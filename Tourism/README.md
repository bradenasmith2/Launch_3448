# Launch Mod 3 Week 2 Assessment

## Questions (10 Points)

1. Define MVC and explain the purpose of each of the three parts of this pattern.
	* MVC is a structure or guideline that is followed by many companies that enables developers to follow the same path for creating a web application.
		* Model - This portion is the c# backend for the whole program. This outlines the classes, database(created by the models), and nearly all logic.
		* View - This portion of MVC is exlusively for displaying the razor webpage (cshtml). This portion should have minimal to no logic, at most the c# should be limited to loops to display data, but no data should be altered.
		* Controller - This portion belongs to the connection between Model and View since they cannot communicate with eachother. Contained in this portion is the handeling of Requests from the client.

2. Explain the difference between the **New** route and the **Create** route.
	* New - This is a GET request which will typically display a type of form that a user can fill out (a seperate create route is used to submit the data entered)
	* Create - This is a POST request which will add the information entered in the form into the database.

3. List all of the RESTful routes for the `employee` entity. Make sure to include the Route Name, Path, and HTTP Method for each of the routes. (2 points)
	* The first route would be the `Index()`, which could be `/employees` this would create a `GET` request.
	* Next, we could specify an employee, this would be `Show()` which could be `/employees/{int:id}` instead of '/employees/show/id' this would also be a `GET` request.
	* If we wanted to add a new employee, this would be `New()` which could be `/employees/new` this would once again be a `GET` request.
	* Since we need to add that employee to the Db, we would need a `Create()` which could be `/employees/create` this would be a `POST` request.
	* Lastly, if we want to delete an employee from the Db, we would neeed a `Destroy()` which could be `/employees/destroy` (sounds ominous we can change it: `[Route("/employees/remove")]`) and this would create a `DELETE` request.

</br>
For the following three questions, explain both how to fix the error/bug and why the part of the code that was broken is important. (2 points each)

4. 
<img width="1213" alt="Screenshot 2023-06-13 102204" src="https://github.com/turingschool/launch-curriculum/assets/11747682/f37c233d-e7aa-483e-9f75-7c9b111811e5">
	* Since we are collecting an IEnumerable "list" from our controller, the correct foreach should be: `var hotel in Model.Hotels'

5.
<img width="1245" alt="Screenshot 2023-06-13 102555" src="https://github.com/turingschool/launch-curriculum/assets/11747682/87c9fbf7-de63-4580-9b36-8632df27b91b">
	* Here our controller has a method 'Index()' that returns a 'View()' however, that view must be returned to a view file with a corresponding name, here the View name is 'Indexes.cshtml' where it should be 'Index.cshtml'.

6. 
<img width="1238" alt="Screenshot 2023-06-13 102856" src="https://github.com/turingschool/launch-curriculum/assets/11747682/a39b525d-ae05-463f-b724-be68aa70148c">
	* To differientate between C# and HTML in a Razor file, the '@' symbol must be used to prefix any C# code.
	* Therefore, the correct statement would be: '<strong>Name:</strong> @hotel.Name, <strong>Location:</strong> @hotel.Location'

## Exercise (10 Points)

Make sure to first run `update-database` to populate the `Tourism` database used by this application.

This application already has the `Index` route for States.

Your task is to do the following:
1. Add the `Show` RESTful route to display the name and abbreviation for a particular state.
1. Add a test for your new `Show` route in the `StateCRUDTests.cs` file.
