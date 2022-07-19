import numpy as np


def swp(a, b):
    p = np.zeros(len(b))
    q = np.zeros(len(b))
    p[0] = -a[0][1]/a[0][0]
    q[0] = b[0]/a[0][0]

    for i in range(1, len(p)-1):
        p[i] = -a[i][i+1]/(a[i][i] + a[i][i-1]*p[i-1])
        q[i] = (b[i] - a[i][i-1]*q[i-1])/(a[i][i] + a[i][i-1]*p[i-1])

    i = len(a)-1
    p[-1] = 0
    q[-1] = (b[-1] - a[-1][-2]*q[-2])/(a[-1][-1] + a[-1][-2]*p[-2])
    
    x = np.zeros(len(b))
    x[-1] = q[-1]

    for i in reversed(range(len(b)-1)):
        x[i] = p[i]*x[i+1] + q[i]
    
    return x


a = np.zeros((5, 5))
b = np.zeros(5)

#1
a[0][0] = -6; a[0][1] = 5; b[0] = 51

#2
a[1][0] = -1; a[1][1] = 13; a[1][2] = 6; b[1] = 100

#3
a[2][1] = -9; a[2][2] = -15; a[2][3] = -4; b[2] = -12

#4
a[3][2] = -1; a[3][3] = -7; a[3][4] = 1; b[3] = 47

#5
a[4][3] = 9; a[4][4] = -18; b[4] = -90
    
print('Матрица:\n', a, '\n')
print('Правая часть матрицы:\n', b, '\n')
print('Решение: ', swp(a, b))

