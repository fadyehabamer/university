# DataBase Task

> Soloution For Data Manipulation Questions for 2024-04-27
>
> [Triggers in SQL are explained here ](https://github.com/fadyehabamer/DOTNET-COURSE/blob/main/Day-16/Triggers%20in%20SQL%20Server.pdf)
>
>  [The basic understanding , ERD , Mapping will be found here](https://github.com/fadyehabamer/DOTNET-COURSE/blob/main/Day-16/ERD%20%26%20MAPPING%2027-4.pdf)

### 1. SELECT: Retrieve all columns from the Doctor table.

```sql
Select * from Doctor;
```

<hr/>

### 2. ORDER BY: List patients in the Patient table in ascending order of their ages.

```sql
SELECT * FROM Patient ORDER BY age;
-- or
SELECT * FROM Patient ORDER BY age ASC;

```

<hr/>

### 3. OFFSET FETCH: Retrieve the first 10 patients from the Patient table, starting from the 5th record.

```sql
SELECT *FROM Patient ORDER BY UR_NUM OFFSET 4 ROWS
FETCH NEXT 10 ROWS ONLY;
```

<hr/>

### 4. SELECT TOP: Retrieve the top 5 doctors from the Doctor table.

```sql
SELECT TOP 5 * FROM Doctor;
```

<hr/>

### 5. SELECT DISTINCT: Get a list of unique address from the Patient table.

```sql
SELECT DISTINCT address FROM Patient;
```

<hr/>

### 6. WHERE: Retrieve patients from the Patient table who are aged 25.

```sql
SELECT * FROM Patient WHERE age = 25;
```

<hr/>

### 7. NULL: Retrieve patients from the Patient table whose email is not provided.

```sql
SELECT * FROM Patient WHERE email IS NULL;
```

<hr/>

### 8. AND: Retrieve doctors from the Doctor table who have experience greater than 5 years and specialize in 'Cardiology'

```sql
SELECT * FROM Doctor WHERE
yrs_of_exp > 5 AND specialization = 'Cardiology';
```

<hr/>

### 9. IN: Retrieve doctors from the Doctor table whose speciality is either 'Dermatology' or 'Oncology'.

```sql
SELECT * FROM Doctor
WHERE specialization IN ('Dermatology', 'Oncology');
```

<hr/>

### 10. BETWEEN: Retrieve patients from the Patient table whose ages are between 18 and 30.

```sql
SELECT * FROM Patient
WHERE age BETWEEN 18 AND 30;
```

<hr/>

### 11. LIKE: Retrieve doctors from the Doctor table whose names start with 'Dr.'.

```sql
SELECT * FROM Doctor WHERE name LIKE 'DR.%';
```

<hr/>

### 12. Column & Table Aliases: Select the name and email of doctors, aliasing them as 'DoctorName' and 'DoctorEmail'.

```sql
SELECT name AS DoctorName, email AS DoctorEmail FROM Doctor;
```

<hr />

### 13. Joins: Retrieve all prescriptions with corresponding patient names.

```sql
--- will solve it later to revise it first
```

### 14. GROUP BY: Retrieve the count of patients grouped by their cities.

> I drew the ERD Diagram with whole address and without city

```sql
SELECT city, count(UR_NUM) AS TotalPatientsInArea FROM Patient GROUP BY city;
```

<hr />

### 15. HAVING: Retrieve cities with more than 3 patients.

```sql
SELECT city, COUNT(UR_NUM) AS TotalNumOfPaitents FROM Patient GROUP BY city
HAVING count(UR_NUM) > 3
```

<hr />

### 16. GROUPING SETS: Retrieve counts of patients grouped by cities and ages.

```sql
SELECT city, age, count(UR_NUM) AS TotalNumOfPaitents FROM Patient
GROUP BY GROUPING SETS ((city, age));
```

<hr />

### 17. CUBE: Retrieve counts of patients considering all possible combinations of city and age.

```sql
SELECT city, age, count(UR_NUM) AS TotalNumOfPaitents FROM Patient
GROUP BY CUBE ((city, age));
```

<hr />

### 18. ROLLUP: Retrieve counts of patients rolled up by city.

```sql
SELECT city, count() AS Count_of_Patients
FROM Patient GROUP BY ROLLUP ((city));
```

<hr />

### 19. EXISTS: Retrieve patients who have at least one prescription.

```sql
SELECT * FROM Patient patient
WHERE
	EXISTS(
		SELECT UR_NUM
		FROM Prescription prescription
		WHERE patient.UR_NUM = prescription.ur_num
	)
```

<hr />

### 20. UNION: Retrieve a combined list of doctors and patients.

```sql
SELECT
doctorId , name, phone, email, specialization, yrs_of_exp,
--from patient as null
NULL AS age, NULL AS address, NULL AS medicare_card_num
FROM Doctor

UNION

SELECT UR_NUM, name, phone, email,
NULL AS specialization, NULL AS yrs_of_exp, age, MediCareCardNumber , address
FROM Patient;
```

<hr />

### 21. Common Table Expression (CTE): Retrieve patients along with their doctors using a CTE.

```sql
WITH PatientDoctorCTE (patient_id, patient_name, doctor_id, doctor_name)
AS (
	SELECT
		pat.UR_NUM, pat.name, doc.doctorId, doc.name
	FROM Patient pat JOIN Doctor doc
		ON doc.doctorId = pat.doctorId
)


SELECT
	patient_id, patient_name, doctor_id, doctor_name
FROM PatientDoctorCTE
```

<hr />

### 22. INSERT: Insert a new doctor into the Doctor table.

```sql
INSERT INTO Doctor(name, email , phone, specialization, yrs_of_exp)
VALUES('FADY EHAB AMER', 'fadyamer45@gmail.com', '201554506314', 'Neurology ', 1)
```

<hr />

### 23. INSERT Multiple Rows: Insert multiple patients into the Patient table.

```sql
INSERT INTO Doctor(name, email , phone, specialization, yrs_of_exp)
VALUES
('FADY EHAB AMER2', 'fadyamer452@gmail.com', '2015545063142', 'Neurology2 ', 12),
('FADY EHAB AMER3', 'fadyamer453@gmail.com', '2015545063143', 'Neurology3 ', 13),

```

<hr />

### 24. UPDATE: Update the phone number of a doctor.

```sql
UPDATE Doctor SET phone = '01014489085' WHERE doctorId = 11;
```

<hr />

### 25.	UPDATE JOIN: Update the city of patients who have a prescription from a specific doctor.

```sql
--- will revise it 
```

<hr />

### 26.	DELETE: Delete a patient from the Patient table.

```sql
DELETE FROM Patient WHERE UR_NUM = 11;
```

<hr />

> will revise from Transaction to Backup 