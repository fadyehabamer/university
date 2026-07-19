CREATE SCHEMA Sales;
Go;

CREATE TABLE CompanyDB.Sales.employees (
    employee_id INT IDENTITY(1,1) PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    salary DECIMAL(10, 2)
);

ALTER TABLE CompanyDB.Sales.employees.Sales.employees
ADD hire_date DATE;


SELECT * FROM CompanyDB.Sales.employees;
SELECT first_name, last_name FROM CompanyDB.Sales.employees;

SELECT first_name + ' ' + last_name AS full_name
FROM CompanyDB.Sales.employees;


SELECT AVG(salary) AS average_salary
FROM CompanyDB.Sales.employees;

SELECT *
FROM CompanyDB.Sales.employees
WHERE salary > 50000;

SELECT *
FROM CompanyDB.Sales.employees
WHERE YEAR(hire_date) = 2020;


SELECT *
FROM CompanyDB.Sales.employees
WHERE last_name LIKE 'S%';


SELECT TOP 10 *
FROM CompanyDB.Sales.employees
ORDER BY salary ;

SELECT *
FROM CompanyDB.Sales.employees
WHERE salary BETWEEN 10000 AND 20000;


SELECT *
FROM CompanyDB.Sales.employees
WHERE first_name LIKE '%man%' OR last_name LIKE '%man%';


SELECT *
FROM CompanyDB.Sales.employees
WHERE hire_date IS NULL;


SELECT *
FROM CompanyDB.Sales.employees
WHERE salary IN (5000, 10000, 15000);

SELECT *
FROM CompanyDB.Sales.employees
WHERE hire_date BETWEEN '2022-11-11' AND '2023-01-01';

SELECT *
FROM CompanyDB.Sales.employees
ORDER BY salary DESC;


SELECT TOP 5 *
FROM CompanyDB.Sales.employees
ORDER BY last_name;


SELECT *
FROM CompanyDB.Sales.employees
WHERE salary > 15000
AND hire_date >= '2022-01-01'

SELECT *
FROM CompanyDB.Sales.employees
WHERE first_name = 'John' OR first_name = 'Jane';

SELECT *
FROM CompanyDB.Sales.employees
WHERE salary <= 10000
AND hire_date > '2022-01-01';

SELECT *
FROM CompanyDB.Sales.employees
WHERE salary > (SELECT AVG(salary) FROM CompanyDB.Sales.employees);

SELECT *
FROM CompanyDB.Sales.employees
ORDER BY salary DESC
OFFSET 2 ROWS FETCH NEXT 5 ROWS ONLY;

SELECT *
FROM CompanyDB.Sales.employees
WHERE hire_date > '2021-01-01'
ORDER BY first_name , last_name ;

SELECT *
FROM CompanyDB.Sales.employees
WHERE salary > 15000
AND last_name NOT LIKE 'A%'
ORDER BY last_name;


SELECT *
FROM CompanyDB.Sales.employees
WHERE salary IS NOT NULL;



SELECT *
FROM CompanyDB.Sales.employees
WHERE (first_name LIKE '%e%' OR first_name LIKE '%i%' OR last_name LIKE '%e%' OR last_name LIKE '%i%')
AND salary > 15000;