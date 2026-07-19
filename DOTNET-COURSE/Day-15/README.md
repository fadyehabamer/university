# DataBase Task
> Soloution For Data Manipulation Questions for 20-4-2024
> 
> Dummydata insertion and soloution.sql file is attached

## Note
> Verify of Soloution will be found here [verifySoloution.md](https://github.com/fadyehabamer/DOTNET-COURSE/blob/main/Day-15/VerfiySoloutions/verifySoloution.md)

### 2.	Create a schema named "Sales" within the "CompanyDB" database.
```sql
CREATE SCHEMA Sales;
```

<hr/>

### 3.	Create a table named "employees" with columns: employee_id (INT), first_name (VARCHAR), last_name (VARCHAR), and salary (DECIMAL) within the "Sales" schema. Note: on employee_id use identity.

``` sql
CREATE TABLE CompanyDB.Sales.employees (
    employee_id INT IDENTITY(1,1) PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    salary DECIMAL(10, 2)
);
```
<hr/>

### 4.	Alter the "employees" table to add a new column named "hire_date" with the data type DATE.
``` sql
ALTER TABLE CompanyDB.Sales.employees
ADD hire_date DATE;
```
<hr/>


### 5.	Add mock data to this table use https://www.mockaroo.com
```sql
insert into CompanyDB.Sales.employees (first_name, last_name, salary, hire_date) values ('Carlynne', 'Salerno', 16675, '2023-03-01');
```
<hr/>


## DATA MANIPULATION Exercises:

### 1.	Select all columns from the "employees" table.

```sql
SELECT * FROM CompanyDB.Sales.employees;
```

<hr/>

### 2.	Retrieve only the "first_name" and "last_name" columns from the "employees" table.
``` sql
SELECT first_name, last_name FROM CompanyDB.Sales.employees;
```
<hr/>

### 3.	Retrieve “full name” as a one column from "first_name" and "last_name" columns from the "employees" table.
``` sql
SELECT first_name + ' ' + last_name AS full_name
FROM CompanyDB.Sales.employees;

--- or 

SELECT CONCAT(first_name, ' ', last_name) AS full_name
FROM CompanyDB.Sales.employees;
```

<hr/>

### 4.	Show the average salary of all employees. (search)
``` sql
SELECT AVG(salary) AS average_salary
FROM CompanyDB.Sales.employees;
```

<hr/>

### 5.	Select employees whose salary is greater than 50000.
```sql
SELECT *
FROM CompanyDB.Sales.employees
WHERE salary > 50000;

--- no result will be found because i limit the maximum salary = 20,000
```

<hr/>

### 6.	Retrieve employees hired in the year 2020.
``` sql
SELECT *
FROM CompanyDB.Sales.employees
WHERE YEAR(hire_date) = 2020;

--- no result will be found because the hire_date takes a start value of november 2022

```

<hr/>

### 7.	List employees whose last names start with 'S.'
```sql
SELECT *
FROM CompanyDB.Sales.employees
WHERE last_name LIKE 'S%';
```

<hr />

### 8.	Display the top 10 highest-paid employees.
``` sql
SELECT TOP 10 *
FROM CompanyDB.Sales.employees
ORDER BY salary DESC;
```

### 9.	Find employees with salaries between 40000 and 60000.
> I modified it to be from 10k to 20k to match data
```sql
SELECT *
FROM CompanyDB.Sales.employees
WHERE salary BETWEEN 10000 AND 20000;
```

<hr />

### 10.	Show employees with names containing the substring 'man.'
```sql
SELECT *
FROM CompanyDB.Sales.employees
WHERE first_name LIKE '%man%' OR last_name LIKE '%man%';
```
<hr />

### 11.	Display employees with a NULL value in the "hire_date" column.
```sql
SELECT *
FROM CompanyDB.Sales.employees
WHERE hire_date IS NULL;
```
<hr />

### 12.	Select employees with a salary in the set (5000, 10000, 15000). 
> DONT GET IT ?
```sql
SELECT *
FROM CompanyDB.Sales.employees
WHERE salary IN (5000, 10000, 15000);
```
<hr />

### 13.	Retrieve employees hired between '2022-11-11' and '2023-01-01.'
```sql
SELECT *
FROM CompanyDB.Sales.employees
WHERE hire_date BETWEEN '2022-11-11' AND '2023-01-01';
```
<hr />

### 14.	List employees with salaries in descending order.
```sql
SELECT *
FROM CompanyDB.Sales.employees
ORDER BY salary DESC;
```
<hr />

### 15.	Show the first 5 employees ordered by "last_name" in ascending order.
```sql
SELECT TOP 5 *
FROM CompanyDB.Sales.employees
ORDER BY last_name;
```
<hr />

### 16.	Display employees with a salary greater than 15000 and hired in 2022.
```sql
SELECT *
FROM CompanyDB.Sales.employees
WHERE salary > 15000
AND hire_date >= '2022-01-01'
AND hire_date <= '2022-12-31';
```

<hr />

### 17.	Select employees whose first name is 'John' or 'Jane.'
```sql
SELECT *
FROM CompanyDB.Sales.employees
WHERE first_name = 'John' OR first_name = 'Jane';
```
<hr />



### 18.	List employees with a salary less than or equal to 10000 and a hire date after '2022-01-01.'
```sql
SELECT *
FROM CompanyDB.Sales.employees
WHERE salary <= 10000
AND hire_date > '2022-01-01';
```
<hr />


### 19.	Retrieve employees with a salary greater than the average salary.
```sql
SELECT *
FROM CompanyDB.Sales.employees
WHERE salary > (SELECT AVG(salary) FROM CompanyDB.Sales.employees);
```
<hr />


### 20.	Display the 3rd to 7th highest-paid employees.
```sql
SELECT *
FROM CompanyDB.Sales.employees
ORDER BY salary DESC
OFFSET 2 ROWS FETCH NEXT 5 ROWS ONLY;
```
<hr />

### 21.	List employees hired after '2021-01-01' in alphabetical order.
```sql
SELECT *
FROM CompanyDB.Sales.employees
WHERE hire_date > '2021-01-01'
ORDER BY first_name ASC, last_name ASC;
```

<hr />


### 22.	Retrieve employees with a salary greater than 15000 and last name not starting with 'A.'
```sql
SELECT *
FROM CompanyDB.Sales.employees
WHERE salary > 15000
AND last_name NOT LIKE 'A%'
ORDER BY last_name;

```
<hr />


### 23.	Display employees with a salary that is not NULL.
```sql
SELECT *
FROM CompanyDB.Sales.employees
WHERE salary IS NOT NULL;
```
<hr />

### 24.	Show employees with names containing 'e' or 'i' and a salary greater than 10000.
```sql
SELECT *
FROM CompanyDB.Sales.employees
WHERE (first_name LIKE '%e%' OR first_name LIKE '%i%' OR last_name LIKE '%e%' OR last_name LIKE '%i%')
AND salary > 10000;
```
