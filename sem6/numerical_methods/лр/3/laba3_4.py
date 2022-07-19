import numpy as np


def first_derivative(i, x, y):
    return (y[i+1] - y[i]) / (x[i+1] - x[i])


def second_derivative(i, x, y):
    a = (y[i+2] - y[i+1]) / (x[i+2] - x[i+1])
    b = (y[i+1] - y[i]) / (x[i+1] - x[i])
    c = x[i+2] - x[i]
    return 2 * (a - b) /c

#произведения разностей искомого х и Х с известным значением с n-ым элементом
def omega_function_Newton(x, n, X):
    res = 1
    for i in range(n+1):
        res*= x-X[i]
    return res

#находим значение коэффицентов полинома Ньютона
def f(n, i, j, X, Y):
    if(n==0):
        return (Y[i] - Y[j]) / (X[i] - X[j])
    else:
        return (f(n-1, i, j-1, X, Y) - f(n-1, i+1, j, X, Y)) / (X[i] - X[j])


#составляем полином Ньютона
def newton_polynom(x, X, Y):
    n = len(X)
    N = [Y[0] + (x- X[0])*f(0, 1, 0, X, Y)]
    for i in range(0, n-1):
        N.append(f(i, 0, i+1, X, Y))
    return N

def newton_der(x, X, Y,n):
    N = newton_polynom(x,X,Y)
    tmp_2 = 0
    for i in range(n, len(N)):
        tmp_1 = 1
        for j in range(1,i):
            tmp_1 *=(x - X[j])
        tmp_2 += N[i]*tmp_1
    return tmp_2


def main():
    x = [-0.2, 0.0, 0.2, 0.4, 0.6]
    y = [-0.40136, 0.0, 0.40136, 0.81152, 1.2435]
    x0 = 0.2
    for i in range(len(x)):
        if ((x[i]<=x0) and (x0 <=x[i+1])):
            print("y' = {}".format(first_derivative(i, x, y)))
            print("y'' = {}".format(second_derivative(i, x, y)))
            break
    print(newton_polynom(x0 , x , y))
    print(newton_der(x0, x, y, 1))
    print(newton_der(x0, x, y, 2))



if __name__ == "__main__":
    main()
