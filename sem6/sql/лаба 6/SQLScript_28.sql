SELECT t1.Date as Date,
t1.Mark as Mark,
t1.PK,
t2.Name as Name_of_Teacher,
t2.PK,
t3.Name as Name_of_Student,
t3.PK,
t4.Title,
t4.PK
From Evaluation t1
INNER JOIN Teacher t2 ON t1.FK_T = t2.PK
INNER JOIN Student_m t3 ON t1.FK_S = t3.PK
INNER JOIN Discipline t4 ON t1.FK_D = t4.PK

