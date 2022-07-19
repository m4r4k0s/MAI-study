import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
from mpl_toolkits.mplot3d import Axes3D

t1, x1 = np.mgrid[0:1:1000j, 0:np.pi:100j]
z1 = np.exp(-t1)*np.sin(x1)
df = pd.DataFrame(z1)
df.to_csv("output.csv", index=False)
z2 = np.array(pd.read_csv('res.csv'), dtype=np.double)
print(x1.shape, z1.shape)


fig = plt.figure()
ax = fig.add_subplot(111, projection='3d')
ax.plot_surface(x1, t1, z2, cmap='inferno')
plt.show()