DROP DATABASE IF EXISTS nbfp;
CREATE DATABASE nbfp;
USE nbfp;

CREATE TABLE users (
  id SERIAL PRIMARY KEY,
  username varchar(100) NOT NULL,
  password varchar(100) NOT NULL
);

CREATE TABLE households (
    id SERIAL PRIMARY KEY,
    `address` varchar(255) NOT NULL,
    members int NOT NULL,
    infants int NOT NULL,
    toddlers int NOT NULL,
    children int NOT NULL,
    adults int NOT NULL,
    seniors int NOT NULL,
    eligibility_type varchar(50) NOT NULL,
    eligibility_attestation_date DATE NOT NULL,
    last_change_date DATE NOT NULL,
    others_authorized varchar(255)
);

CREATE TABLE household_members (
    id SERIAL PRIMARY KEY,
    household_id int NOT NULL,
    first_name varchar(100) NOT NULL,
    last_name varchar(100) NOT NULL,
    age int NOT NULL,
    FOREIGN KEY (household_id) REFERENCES households(id) ON DELETE CASCADE
);

CREATE TABLE household_visits (
    id SERIAL PRIMARY KEY,
    household_id int NOT NULL,
    visit_date DATE NOT NULL,
    staff_name varchar(100) NOT NULL,
    FOREIGN KEY (household_id) REFERENCES households(id) ON DELETE CASCADE
);

INSERT INTO users (username, password) VALUES ('admin', 'nbfpfeedsmore');

INSERT INTO households (
    address, members, infants, toddlers, children, adults, seniors, 
    eligibility_type, eligibility_attestation_date, last_change_date
    ) VALUES (
        '123 Main St', 4, 1, 1, 1, 1, 0, 'Low Income', '2023-01-01', 
        '2023-01-01'
);

INSERT INTO household_members (household_id, first_name, last_name, age) VALUES
    (1, 'John', 'Doe', 30),
    (1, 'Jane', 'Doe', 28),
    (1, 'Baby', 'Doe', 1),
    (1, 'Toddler', 'Doe', 3);

INSERT INTO household_visits (household_id, visit_date, staff_name) VALUES
    (1, '2023-01-15', 'Cameron Turner'),
    (1, '2023-02-15', 'Cameron Turner');
