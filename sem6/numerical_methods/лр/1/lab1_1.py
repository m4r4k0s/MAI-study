import numpy as np


def LU(a):

    n = a.shape[0]
    u = np.matrix(np.zeros([a.shape[0], a.shape[1]]))
    l = np.matrix(np.zeros([a.shape[0], a.shape[1]]))
    
    for k in range(n):
        
        for j in range(k, n):
            u[k, j] = a[k, j] - l[k, :k] * u[:k, j]
        
        for i in range(k + 1, n):
            if i == k:
                l[i, k] = 1
            l[i, k] = (a[i, k] - l[i, : k] * u[: k, k]) / u[k, k]

    for i in range(n):
        for k in range(n):
            if i == k:
                l[i, k] = 1
    return l, u


def solve(a, b):
    n = a.shape[0]
    l, u = LU(a)
    x = np.zeros(n)
    y = np.zeros(n)
    
    def sum_y(i):
        res = 0
        for k in range(n):
            res += l[i, k] * y[k]
        return res
    for i in range(n):
        y[i] = b[i] - sum_y(i)
    
    def sum_x(i):
        res = 0
        for j in range(i, n):
            res += u[i, j]*x[j]
        return res
        
    for i in reversed(range(n)):
        x[i] = (y[i] - sum_x(i))/u[i, i]
        
    return x


def invert(a):
    n = a.shape[0]
    L, U = LU(a)
    x = np.zeros((n, n))
    es = []
    ys = []

    for i in range(n):
        es.append(np.zeros(n))
        es[i][i] = 1
        ys.append(solve(L, es[i]))
        x[i] = solve(U, ys[i])

    return x.transpose()


def det(a):
    L, U = LU(a)
    d = 1
    for i in range(a.shape[0]):
        d *= U[i, i]
    return d
    

a = np.zeros((4, 4))

#1
a[0][0] = 8; a[0][1] = 8; a[0][2] = -5; a[0][3] = -8

#2
a[1][0] = 8; a[1][1] = -5; a[1][2] = 9; a[1][3] = -8

#3
a[2][0] = 5; a[2][1] = -4; a[2][2] = -6; a[2][3] = -2

#4
a[3][0] = 8; a[3][1] = 3; a[3][2] = 6; a[3][3] = 6

b = np.zeros(4)
b[0] = 13; b[1] = 38; b[2] = 14; b[3] = -95

print('Матрица A\n', a, '\n'); print('Правая часть\n', b, '\n')
L, U = LU(a)
print('L*U:\n', L*U, '\n')
print('L:\n', L, '\n')
print('U:\n', U, '\n')
print('det A = ', det(a), '\n')
print('Решение:\n', solve(a, b), '\n')
print('Обратная:\n', invert(a), '\n')
print(np.dot(a, invert(a)))