# Toy Store Backend

This project is the backend part of a full stack development project. The frontend is written in React. The goal of this project is to provide functions that pass data from an SQL Server database to the frontend. The project aims to teach the concept of full stack development. I received a high mark for this project.

## Project Requirements

### Full Stack Project Characterization
The guiding motif is a virtual business that includes an end-to-end process.

### Basic Database Characterization:
- **Product Table**
- **Category Table**
- **User Table**
- **Purchase Table**
- **Purchase Details Table**

**Note:** This characterization assumes there is one manager for the business and that the buying process is managed solely by the user. Any change in this assumption or in the general idea requires an addition or change in the database.

### Server-Side Functionality
- **Products**
  - View all products
  - View product by product code
  - View product by category code
  - Add a product
  - Delete a product
  - Update a product

- **Categories**
  - View all categories
  - Add a category
  - Edit a category
  - Delete a category

- **Users**
  - Add a new user
  - Edit user details
  - View all users
  - Find a user by email and password

### Purchase Completion Process
- Receive an array of products and a user code, and save the purchase details in the appropriate tables:
  - Add a row to the purchase table - purchase details.
  - For each desired product:
    - Check if it is available in stock in the desired quantity. If so, remove the purchased quantity from the inventory.
    - Add appropriate rows to the purchase details table.
    - Consider how to connect the purchase table to the purchase details table.
    - Challenge: Assist in the transaction by preventing the addition of a purchase without its details.
