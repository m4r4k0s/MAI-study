import numpy as np


def function_v17_5(x):
    return 1/(256 -pow(x,4))


#метод прямоугольников
def rectangle_method(func, h, x, n):
    sum=0
    for i in range(1,n):
        sum += func((x[i]+x[i-1])/2)
    return h*sum


#метод трапеций
def trapeze_method(func, h, x, n):
    sum = (func(x[0]) + func(x[n-1])) / 2
    for i in range(1,n-1):
        sum += func(x[i])
    return h*sum


#метод Симпсона
def sympson_method(func, h, x, n):
    sum = func(x[0]) + func(x[n-1])
    for i in range(1,n-1):
        if(i%2==0):
            sum += 2*func(x[i])
        else:
            sum += 4*func(x[i])
    return h*sum/3


#метод... их короче
def runge_romberg_method(Fh, Fkh, p):
    return Fh + ((Fh - Fkh) / (pow(2,p) - 1))


def main():
    k1 = 2
    k0 = -2
    h = [1, 0.5, 0.25]
    n = len(h)
    rectangle = np.zeros(n)
    trapeze = np.zeros(n)
    sympson = np.zeros(n)
    rrm = np.zeros([n, 3])
    for i in range(n):
        N = (int)((k1-k0)/h[i]+1)
        x = np.zeros(N)
        x[0] = k0
        for j in range(1,N):
            x[j] = x[j-1] + h[i]
        rectangle[i] = rectangle_method(function_v17_5, h[i], x, N)
        trapeze[i] = trapeze_method(function_v17_5, h[i], x, N)
        sympson[i] = sympson_method(function_v17_5, h[i], x, N)
        print("h = {}: rectangle = {}; trapeze = {}; sympson = {}".format(h[i], rectangle[i], trapeze[i], sympson[i]))
    for i in range(1,n):
        rrm[i-1][0] = runge_romberg_method(rectangle[i], rectangle[i-1], 2)
        rrm[i-1][1] = runge_romberg_method(trapeze[i], trapeze[i-1], 2)
        rrm[i-1][2] = runge_romberg_method(sympson[i], sympson[i-1], 2)
        print("refined rectangle = {}; refined trapeze = {}; refined sympson = {}; betwe h{}={} and h{}={}".format(rrm[i-1][0], rrm[i-1][1], rrm[i-1][2], i-1, h[i-1], i, h[i]))
        print("error: rectangle = {}; trapeze = {};  sympson = {};".format(abs(rectangle[i] - rrm[i-1][0]), abs(trapeze[i] - rrm[i-1][1]), abs(sympson[i] - rrm[i-1][2])))


if __name__ == "__main__":
    main()