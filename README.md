# MovieRental Exercise

This is a dummy representation of a movie rental system.
Can you help us fix some issues and implement missing features?

- The app is throwing an error when we start, please help us. Also, tell us what caused the issue.
  - Issue was due to wrong pattern being applied. The desired pattern is Scoped, as we want to have a instance of the per request, contrary to the Singleton that creates a Instance for the entire application lifecycle
- The rental class has a method to save, but it is not async, can you make it async and explain to us what is the difference?
  - A async method does NOT lock the Thread Pool, allowing the server to keep working while the DB executes the async task. Once the task is completed, execution resumes automatically. This is the prefered method for web APIs, as it allows for better scalability and responsiveness.
- Please finish the method to filter rentals by customer name, and add the new endpoint.
- We noticed we do not have a table for customers, it is not good to have just the customer name in the rental.
  Can you help us add a new entity for this? Don't forget to change the customer name field to a foreign key, and fix your previous method!
- In the MovieFeatures class, there is a method to list all movies, tell us your opinion about it.
  - While the function works for its intent, it brings a concern about scalability and the fact that the API is currently thightly couple to the DB schema. To solve these issues, it would be necessary to implement DTOs, which would improve security, scalability and maintainability of the code while decoupling the code from the DB schema.
- No exceptions are being caught in this api, how would you deal with these exceptions?

  - Ideally, we should centralize exception handling and map the exceptions to meaningful responses. Essentially, delegate the exception handling to a global exception middleware

## Challenge (Nice to have)

We need to implement a new feature in the system that supports automatic payment processing. Given the advancements in technology, it is essential to integrate multiple payment providers into our system.

Here are the specific instructions for this implementation:

- Payment Provider Classes:
  - In the "PaymentProvider" folder, you will find two classes that contain basic (dummy) implementations of payment providers. These can be used as a starting point for your work.
- RentalFeatures Class:
  - Within the RentalFeatures class, you are required to implement the payment processing functionality.
- Payment Provider Designation:
  - The specific payment provider to be used in a rental is specified in the Rental model under the attribute named "PaymentMethod".
- Extensibility:
  - The system should be designed to allow the addition of more payment providers in the future, ensuring flexibility and scalability.
- Payment Failure Handling:
  - If the payment method fails during the transaction, the system should prevent the creation of the rental record. In such cases, no rental should be saved to the database.
