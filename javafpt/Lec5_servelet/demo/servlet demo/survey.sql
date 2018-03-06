DROP TABLE SurveyResults;

CREATE TABLE SurveyResults (
       ID             INT(5) NOT NULL,
       SurveyOption   VARCHAR(25) NOT NULL,
       Votes          INT(5) NOT NULL,
       PRIMARY KEY (ID)
);

INSERT INTO SurveyResults(ID, SurveyOption, Votes) VALUES(1, "Dog", 1);
INSERT INTO SurveyResults(ID, SurveyOption, Votes) VALUES(2, "Cat", 2);
INSERT INTO SurveyResults(ID, SurveyOption, Votes) VALUES(3, "Bird", 2);
INSERT INTO SurveyResults(ID, SurveyOption, Votes) VALUES(4, "Snake", 4);
INSERT INTO SurveyResults(ID, SurveyOption, Votes) VALUES(5, "None", 7);