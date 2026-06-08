CREATE TABLE demo_user (
    id BIGSERIAL PRIMARY KEY,
    account VARCHAR(50) NOT NULL,
    name VARCHAR(100) NOT NULL,
    age INTEGER,
    salary NUMERIC(10,2),
    enabled BOOLEAN DEFAULT TRUE,
    birthday DATE,
    last_login TIMESTAMP,
    create_time TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO demo_user
(account, name, age, salary, enabled, birthday, last_login)
VALUES
('admin', 'System Admin', 30, 85000.50, TRUE, '1995-05-01', CURRENT_TIMESTAMP);

INSERT INTO demo_user
(account, name, age, salary, enabled, birthday, last_login)
VALUES
('user01', 'John Doe', 25, 42000.00, FALSE, '2000-08-15', CURRENT_TIMESTAMP);

SELECT * FROM demo_user;

UPDATE demo_user SET name = 'Amy', age = 32, salary = 55000 WHERE id = 4 RETURNING *;

SELECT age, COUNT(*) FROM demo_user GROUP BY age ORDER BY age DESC ;