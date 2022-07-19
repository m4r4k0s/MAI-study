import numpy as np
import math


def get_mat(file):
    mat = []
    with open(file) as file_handler:
        for line in file_handler:
            row = list(map(int, line.split(',')[:-1]))
            mat.append(row)
        mat = np.asarray(mat)
    return mat


def get_angle(mat, i, j):
    if mat[i, i] == mat[j, j]:
        return math.PI / 4
    else:
        return 0.5 * math.atan(2 * mat[i, j] / (mat[i, i] - mat[j, j]))


def get_max(mat):
    index = [0, 1]
    mat_size = mat[:, 0].size
    mat_tmp = np.abs(mat.copy())
    max_elem = mat_tmp[index[0], index[1]]
    for i in np.arange(0, mat_size):
        for j in np.arange(0, mat_size):
            if i == j:
                continue
            else:
                if max_elem < mat_tmp[i, j]:
                    max_elem = mat_tmp[i, j]
                    index = [i, j]
                else:
                    pass

    return index


def norm_matrix_non_diag(matrix):
    norm = 0
    mat_size = matrix[:, 0].size
    for i in np.arange(0, mat_size):
        for j in np.arange(0, mat_size):
            if i == j:
                continue
            else:
                norm += matrix[i, j] * matrix[i, j]
    return np.sqrt(norm)


def transpose(matr):
    res = []
    n = len(matr)
    m = len(matr[0])
    for j in range(m):
        tmp = []
        for i in range(n):
            tmp = tmp + [matr[i][j]]
        res = res + [tmp]
    return np.array(res)


epsilon = 0.001
mat = get_mat("test.txt")
print(mat)
mat_test = mat.copy()
mat_size = mat[:, 0].size
X = np.eye(mat_size)
k = 0
while True:
    max_index = get_max(mat)
    angle = get_angle(mat, max_index[0], max_index[1])
    U = np.eye(mat_size).copy()
    U[max_index[0], max_index[0]] = math.cos(angle)
    U[max_index[0], max_index[1]] = -math.sin(angle)
    U[max_index[1], max_index[0]] = math.sin(angle)
    U[max_index[1], max_index[1]] = math.cos(angle)
    X = np.dot(X.copy(), U.copy())
    mat = np.dot(transpose(U.copy()), mat.copy())
    mat = np.dot(mat.copy(), U.copy())
    p = norm_matrix_non_diag(mat)
    k += 1
    if epsilon > p or angle == 0 or k > 100:
        break

print(np.diagonal(mat))
print(X)
print(np.linalg.eig(mat_test))