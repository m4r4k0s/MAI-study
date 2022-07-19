USE Vedomost17
GO

SELECT  t1.*, t2.*, t3.*, t4.*
From Vedomost17.dbo.Evaluation as t1
Join Vedomost17.dbo.Student_m as t2 on t1.FK_S = t2.PK 
Join Vedomost17.dbo.Discipline as t3 on t1.FK_D = t3.PK 
Join Vedomost17.dbo.Teacher as t4 on t1.FK_T = t4.PK
Where t3.Title = 'Math'
GO