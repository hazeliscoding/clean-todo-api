CREATE TABLE IF NOT EXISTS TodoItems (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Title VARCHAR(255) NOT NULL,
    DueDate DATE,
    IsCompleted BOOLEAN,
    Priority VARCHAR(50)
);

-- Seed some initial data
INSERT INTO TodoItems (Title, DueDate, IsCompleted, Priority) VALUES 
    ('Learn Docker', '2023-12-01', false, 'High'),
    ('Implement API', '2023-09-20', false, 'Medium'),
    ('Read GPT-4 paper', '2023-09-15', false, 'Low'),
    ('Set up new server', '2023-09-10', true, 'High'),
    ('Design database schema', '2023-09-12', true, 'Medium'),
    ('Write unit tests', '2023-09-30', false, 'Medium'),
    ('Prepare presentation', '2023-10-10', false, 'High'),
    ('Update project documentation', '2023-10-05', true, 'Low'),
    ('Attend weekly meeting', '2023-09-14', true, 'Low'),
    ('Refactor legacy code', '2023-09-25', false, 'High'),
    ('Review pull requests', '2023-09-18', true, 'Medium'),
    ('Plan sprint tasks', '2023-10-02', false, 'Medium'),
    ('Learn TypeScript', '2023-11-20', false, 'Low'),
    ('Backup important files', '2023-10-30', true, 'High'),
    ('Configure CI/CD pipeline', '2023-10-15', false, 'Medium');
