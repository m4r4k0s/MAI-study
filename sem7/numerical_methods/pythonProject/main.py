import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
from mpl_toolkits.mplot3d import Axes3D


def implit(T, l, k, N, args1, args2, phi0, phil, ksi, f):
    tau = T / k
    h = l / (N - 1)
    n = []
    sys = np.zeros((N, N))
    tmp = []
    for i in range(N):
        tmp.append(ksi(i * h))
    n.append(tmp)
    for i in range(1, N - 1):
        sys[i][i - 1] = -(args1[0] / (h * h) - args1[1] / (2 * h)) * tau
        sys[i][i] = -(-1 + args1[2] - 2 * args1[0] / (h * h)) * tau
        sys[i][i + 1] = -(args1[0] / (h * h) + args1[1] / (2 * h)) * tau

    sys[0][0] = -(-1 + args1[2] - 2 * args1[0] / (h * h)) * tau
    sys[0][1] = -(args1[0] / (h * h) + args1[1] / (2 * h)) * tau
    sys[-1][-1] = -(-1 + args1[2] - 2 * args1[0] / (h * h)) * tau
    sys[-1][-2] = -(args1[0] / (h * h) - args1[1] / (2 * h)) * tau

    for t in range(1, k):
        tmp = list(np.zeros(N))
        for x in range(1, N - 1):
            tmp[x] = -n[t - 1][x] - f(x * h, t * tau) * tau
        tmp[0] = -phi0(t * tau) * h + n[t - 1][1] + f(x * h, t * tau) * tau
        tmp[-1] = phil(t * tau) * h + n[t - 1][-1] + f(x * h, t * tau) * tau
        n.append(list(np.linalg.solve(sys, tmp)))
    return n


t1, x1 = np.mgrid[0:1:100j, 0:np.pi:10j]
z2 = np.array(implit(1,np.pi,100,10,[1,0,0], [1,0,1,0],
          lambda t: np.exp(-5*t),lambda t:-np.exp(-5*t), lambda x:np.sin(x), lambda x,t: 0))

fig = plt.figure()
ax = fig.add_subplot(111, projection='3d')
ax.plot_surface(x1, t1, z2, cmap='inferno')
plt.show()
