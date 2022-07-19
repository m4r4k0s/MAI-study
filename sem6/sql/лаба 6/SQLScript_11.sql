SELECT t1.Key2,
t1.Name as Name,
t1.Key2 as LKey2,
t2.Key2 as RKey2,
t2.City as City
From LeftTable t1
Inner JOIN RightTable t2 On t1.Key2 <= t2.Key2
Where t1.Key2 = 3;