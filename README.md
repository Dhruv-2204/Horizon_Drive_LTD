#  **README File for Car Rental System WinForms App - HORIZON DRIVE LTD**

## <ins>**Development Team:**</ins>
1. Team Leader: Dhruv Ramachundrah (M01012026)
2. Secretary: Aayush Lochun (M01004726)
3. Developer 1: Rumaisa Mahomathoo-Ghaboos (M01012611)
4. Developer 2: Yash Booputh (M01006629)
5. Tester: Khorisha Gooroodoyal (M01003456)

## **Project overview:** -- enter a good email address

This is a WinForms application a Car Rental System that includes a database connectivity, search functionailty and management features. The application allows users to: 
- View available cars
- Both rent and list car(s)
- Manage rental listings
- Keep track of upcoming bookings
- Customise user account


## **Prerequisites:**

1. .NET Framework 4.7.2 or later installed
2. SQL Server (Express edition recommended)
3. Visual Studio 2022 

## Installation Instructions
~ Clone the repository to your local machine
~ Open the solution file (.sln) in Visual Studio
~ Restore NuGet packages (right-click solution > Restore NuGet Packages)
~ Set up the database (see Database Setup below)

## <ins>Database Setup</ins> :
1. Go on your SQL Server Management Studio 20.
2. Click on connect and right click on Databases to create a new Database "CarDBMS".
3. Now, right click on the database you just created and click on new query.
4. Copy and paste the content found in *DatabaseScripts/CarDBMS.txt* from to the query and execute it.
5. On your Visual Studio, go on Tools > Connect to Database.
6. Enter your server name from SQL server > Trust Server Certificate > Select or enter database name > Ok.
7. From Server Explorer/ Database connections > Right click to get properties > copy the connection string.
8. Update the connection string in App.config to match your SQL Server instance.

## Running the application : 
- Run the application (Debug > Start Debugging or F5)
- The main form will launch, providing access to all system features

## Walkthrough for Examinator
After following the steps to set up your database setup, you will need to use the app as the Admin to populate the hashtable and database by using the text files provided in the repository (user.txt, car.txt, customer.txt)

1. On the login page, you will need to enter your username as "Admin" and your password "Adminpassword!". Then you will see a message box saying you have login successfully.
   
2. Then you will be greeted by the Admin Dashboard where you can perform several tasks (Manage Users Option, Upload File Option, Manage Bookings Option, Maintenance Option, Logout Option).
   
3. Since the database we have provided you with already contains some data,
You can click on the Manage Users option on the menu bar to perform actions like :
- Viewing all the users' details found in our database.
- Use the search bar to search for specif users in our database (search can be done by all the fields).
- Click on a specific user cell on the grid to open another window where you will be able to edit their details. You need to click on the view/edit button to make the fields changeable. Then the editable fields turns yellow, only userid and user's password are uneditable.
- After changing user's details, you click on save button where the new changes will be updated in the database.

Upload File Page
Here you can upload more data into our hashtable and database by uploading the User.txt, Car.txt, Customer.txt files.
- First click on the upload file button and ensure that you SHOULD upload the text files in the order specified below to prevent referential integrity issues in the database.
  1. Upload User.txt, then click on save to database button.
  2. Upload Car.txt, then click on save to database button.
  3. Upload Customer.txt, then click on save to database button.

Manage Bookings Page
Here you can view all the car bookings made with all their important information such as Booking Date, Duration of Booking etc.
- You can search for details about the car booking on the search bar and click on go to view the details.
- You can use the filter functionality to filter cars based on their booking status (Cancelled Bookings, Completed Bookings and Confirmed Bookings).
- You can use the date range functionality to view bookings made on a specific date range.
- You can click on the Action field on the grid to cancel specific bookings, after cancelling the booking, the specific cell will turn red.
  
Maintenance Page
Here you can choose specific cars that will need maintenance.
- You can select the specific car that need maintenace by using the dropdown functionality.
- For the date selection, make use of the calendar to select a specific date.
- Then click on the add maintenance button to add the changes in the maintenance table in the database.


## Application Features For Users:
- Users can create an account to hire a car on the app.
- Users are able to view all the cars available for renting on the browsing page with their respective photos and details (car name, car year, price per day).
- User can also view all their previous, upcoming and cancelled bookings on the Manage Bookings Page
- User can update user profiles such as username, profile pictures, email address, password.
- User can also upload details about their driving licence such as driving licence photo. 
- Users can act both as a lessor since registered users can list their own cars for rent by entering their car details and upload pictures.
- Users can also view all the cars they have listed and how many of them are currently booked with the amount of money they have made. User also have the ability to delete the car they have listed if it is not booked.


## App Navigation
When launching the application, a splash screen with the Horizon Drive Ltd logo is displayed. 
After that, you are directed to the Login Page. If you already have an account, enter your login credentials.
If not, click on the Sign Up button to create a new account.

1. Sign up Page
On the Sign Up page, users can register by entering their personal details such as name, username, date of birth, email address, phone number, password, and address.
Users must be at least 18 years old to use the system. Input validation ensures all data is correctly formatted—e.g., phone numbers must be 8 digits and passwords must be strong (at least 8 characters, including uppercase, lowercase, a number, and a special character).
A valid email address is required to receive booking confirmation emails. Passwords are securely hashed before being stored in the database.
  
3. Login Page
Users must enter their registered username and password to log in to the application.
If the credentials are correct, they will be granted access to the system.

5. Browse Listing Page
After successful login or registration, users are redirected to the Browse Listings page where all available cars for rent are displayed.
By clicking on the View button, more detailed information about each car is shown, such as drivetrain, engine capacity, seating, and more.
Users can choose pickup and drop-off locations and add extra options like a driver, roof rack, baby seat, or airport pickup/drop-off.
Booking dates can also be selected. If the selected dates are already booked, the system prompts the user to choose different dates. Once a booking is confirmed,
the user receives an email with all the details.

7. List a Car Page
Users can list their own cars for rent by filling out a form with car details such as brand, model, rental price, and features.
They can also upload up to 5 images of the vehicle.

9. Manage Listings Page
This page shows all the user’s listed cars along with their transaction history.
Users can view booking dates, number of reservations, and total earnings.
If a user wants to remove a car from the platform, they can simply click the Delete button.

11. Manage Bookings Page
Here, users can see all the cars they have booked—categorized as past, upcoming, and cancelled bookings.
Users also have the option to cancel an upcoming booking directly from this page using the Cancel button.

13. Options Page
This page allows users to update their profile information, including first name, last name, username, address, phone number, and profile picture.

15. Logout
Clicking the Logout button from the menu bar will log the user out and redirect them back to the Login Page.


If you encounter any issues or have suggestions for improvements, feel free to reach out to the development team.

Contact Email: horizondrivecompany@gmail.com
Developed by the Horizon Drive LTD Team


|\---/|
| o_o |
 \_^_/ 










