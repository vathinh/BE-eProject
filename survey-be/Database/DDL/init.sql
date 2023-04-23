-- Table definition for UserData
CREATE TABLE UserData (
  user_id SERIAL PRIMARY KEY,
  status_id VARCHAR(100) NOT NULL,
  user_role VARCHAR(150) NOT NULL,
  registration_type VARCHAR(150) NOT NULL,
  user_code VARCHAR(150) NOT NULL,
  user_password VARCHAR(100) NOT NULL,
  user_name VARCHAR(150) NOT NULL,
  FOREIGN KEY (status_id) REFERENCES Status(status_id)
);

-- Table definition for User_Role
CREATE TABLE User_Role (
  role_id SERIAL NOT NULL,
  user_id INTEGER NOT NULL,
  PRIMARY KEY (role_id, user_id),
  FOREIGN KEY (user_id) REFERENCES UserData(user_id)
);

-- Table definition for Role
CREATE TABLE Role (
  role_id SERIAL PRIMARY KEY,
  role_description VARCHAR(1000),
  role_name VARCHAR(100) NOT NULL
);

-- Table definition for Status
CREATE TABLE Status (
  status_id SERIAL PRIMARY KEY,
  status_content VARCHAR(100) NOT NULL,
  description VARCHAR(1000)
);

-- Table definition for Survey
CREATE TABLE Survey (
  survey_id SERIAL PRIMARY KEY,
  user_id INTEGER NOT NULL,
  survey_type VARCHAR(150) NOT NULL,
  survey_title VARCHAR(200) NOT NULL,
  survey_name VARCHAR(300) NOT NULL,
  status_survey VARCHAR(100) NOT NULL,
  total_mark INTEGER,
  FOREIGN KEY (user_id) REFERENCES UserData(user_id)
);

-- Table definition for Answer
CREATE TABLE Answer (
  answer_id SERIAL PRIMARY KEY,
  question_id VARCHAR(100) NOT NULL,
  survey_id INTEGER NOT NULL,
  answer_content VARCHAR(1000),
  mark INTEGER NOT NULL,
  FOREIGN KEY (question_id) REFERENCES Question(question_id),
  FOREIGN KEY (survey_id) REFERENCES Survey(survey_id)
);

-- Table definition for Question
CREATE TABLE Question (
  question_id SERIAL PRIMARY KEY,
  survey_id INTEGER NOT NULL,
  answer_content VARCHAR(1000) NOT NULL,
  FOREIGN KEY (survey_id) REFERENCES Survey(survey_id)
);

-- Table definition for Competition
CREATE TABLE Competition (
  competition_id SERIAL PRIMARY KEY,
  survey_id INTEGER NOT NULL,
  name VARCHAR(150) NOT NULL,
  time_start_competition TIMESTAMP NOT NULL,
  time_end_competition TIMESTAMP NOT NULL,
  status_competition VARCHAR(100) NOT NULL,
  location VARCHAR(100) NOT NULL,
  number_limit_user INTEGER NOT NULL,
  number_user_joined INTEGER NOT NULL,
  duration TIMESTAMP NOT NULL,
  FOREIGN KEY (survey_id) REFERENCES Survey(survey_id)
);

-- Table definition for Prize
CREATE TABLE Prize (
  prize_id SERIAL PRIMARY KEY,
  user_id INTEGER NOT NULL,
  competition_id INTEGER NOT NULL,
  prize_name VARCHAR(100) NOT NULL,
  prize_description VARCHAR(150),
  FOREIGN KEY (user_id) REFERENCES UserData(user_id),
  FOREIGN KEY (competition_id) REFERENCES Competition(competition_id)
);

-- Table definition for FAQs
CREATE TABLE FAQs (
  faq_id SERIAL PRIMARY KEY,
  user_id INTEGER NOT NULL,
  faq_content VARCHAR(1000) NOT NULL,
  FOREIGN KEY (user_id) REFERENCES UserData(user_id)
);

-- Table definition for SupportInformation
CREATE TABLE SupportInformation (
  support_id SERIAL PRIMARY KEY,
  user_id INTEGER NOT NULL,
  support_content VARCHAR(1000) NOT NULL,
  FOREIGN KEY (user_id) REFERENCES UserData(user_id)
);
