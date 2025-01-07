create database  quizz;
CREATE TABLE Questionss (
    
    QuestionText TEXT NOT NULL,
    CorrectAnswer TEXT NOT NULL,
    AssignedMarks INTEGER NOT NULL,
    TimeLimit INTEGER NOT NULL,
    Topic TEXT NOT NULL,
    DifficultyLevel TEXT NOT NULL
);


INSERT INTO Questionss (QuestionText, CorrectAnswer, AssignedMarks, TimeLimit, Topic, DifficultyLevel) VALUES
('What is the capital of France?', 'Paris', 5, 30, 'Geography', 'Easy'),
('Solve the equation: 5x - 3 = 2', 'x = 1', 10, 60, 'Math', 'Medium'),
('Who wrote "To Kill a Mockingbird"?', 'Harper Lee', 5, 30, 'Literature', 'Easy'),
('Explain the theory of relativity', 'Einstein''s theory that E=mc^2', 20, 120, 'Physics', 'Hard');
