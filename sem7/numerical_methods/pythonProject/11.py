import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
from mpl_toolkits.mplot3d import Axes3D


t1, x1 = np.mgrid[0:1:100j, 0:np.pi:10j]

z1 = np.exp(-5*t1)*np.cos(x1 + 3*t1)

fig = plt.figure()
ax = fig.add_subplot(111, projection='3d')
ax.plot_surface(x1, t1, z1, cmap='inferno')
plt.show()
