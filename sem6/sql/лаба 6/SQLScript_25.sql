SELECT m.ID, m.ReportCard, m.Department, m.Course, m.EndYear
FROM Student_m m

UNION

SELECT b.ID, b.ReportCard, b.Department, b.Course, b.EndYear
FROM Student_b b