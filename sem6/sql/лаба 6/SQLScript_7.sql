SELECT r.*, l.*
FROM LeftTable l
LEFT JOIN RightTable r ON l.LCode = r.RCode