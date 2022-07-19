import numpy as np


def ab(a, b):
    n = a.shape[0]
    alpha = np.zeros((n, n))
    beta = np.zeros(n)
    for i in range(n):
        alpha[i] = -a[i] / a[i][i]
        beta[i] = b[i]/a[i][i]
        alpha[i][i] = 0
    return alpha, beta


def norm_abs(a):
    res = 0
    for i in range(a.shape[0]):
        s = 0
        try:
            for j in range(a.shape[0]):
                s += abs(a[j][i])
            if s > res:
                res = s
        except:
            res += abs(a[i])
    return res


def norm_sq(a):
    res = 0
    for i in range(a.shape[0]):
        try:
            for j in range(a.shape[0]):
                res += a[i][j]**2
        except:
            res += a[i]**2
    return res**0.5


def norm_c(a):
    res = 0
    for i in range(a.shape[0]):
        s = 0
        try:
            for j in range(a.shape[0]):
                s += abs(a[i][j])
            if s > res:
                res = s
        except:
            if abs(a[i]) > res:
                res = abs(a[i])
    return res
    

a = np.zeros((4, 4))

#1
a[0][0] = -19; a[0][1] = 2; a[0][2] = -1; a[0][3] = -8

#2
a[1][0] = 2; a[1][1] = 14; a[1][2] = 0; a[1][3] = -4

#3
a[2][0] = 6; a[2][1] = -5; a[2][2] = -20; a[2][3] = -6

#4
a[3][0] = -6; a[3][1] = 4; a[3][2] = -2; a[3][3] = 15

b = np.zeros(4)
b[0] = 38; b[1] = 20; b[2] = 52; b[3] = 43
    
print('Матрица A\n', a, '\n'); print('Правая чаасть', b, '\n')
alpha, beta = ab(a, b)
print('Alpha:\n', alpha, '\n')
print('beta\n', beta, '\n')
print('Нормы\n', norm_abs(alpha), '\n', norm_sq(alpha), '\n', norm_c(alpha), '\n')
eps = float(input('Введите эпсилон:\n'))
print('Метод простых итераций.')
prev = beta
curr = beta + alpha.dot(beta)
i = 0
norm_alpha = norm_c(alpha)
while norm_c(curr - prev) * (norm_alpha / (1 - norm_alpha)) > eps:
    prev = curr
    curr = beta + alpha.dot(prev)
    print('Текущее приближение: ', curr)
    i += 1
print('Решение закончилось на {}-й итерации'.format(i))

print('Решение x:\n', curr)

print('Проверка, A*x', a.dot(curr))

print("////////////////////////////////////////")
print('Метод Зейделя')
k = 0
prev = beta
converge = False
m = alpha.shape[0]
while not converge:
    curr = np.copy(prev)
    for i in range(m):
        s = 0
        for j in range(m):
            s += alpha[i, j] * curr[j]
        curr[i] = beta[i] + s
    converge = norm_c(curr - prev) * (norm_alpha / (1 - norm_alpha)) < eps
    k += 1
    prev = np.copy(curr)

print('Решение закончилось на {}-й итерации'.format(k))

print('Решение x:\n', curr)

print('Проверка, A*x', a.dot(curr))
