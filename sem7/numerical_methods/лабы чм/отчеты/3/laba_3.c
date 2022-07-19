#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>

#include "../libs/my_lib/laba_lib.h"

double u0y(double y)
{
    return exp(-y)*cos(y);
}
double uly(double y)
{
    return 0;
}
double u0x(double x)
{
    return cos(x);
}
double ulx(double x)
{
    return 0;
}

double eror(matrix *U1, double *U2)
{
    double err=0;
    for(int i=0; i<U1->rows; i++)
        for(int j=0; j<U1->columns; j++)
            if(err < fabs((*get_element(U1,i,j))-U2[i*(U1->columns) + j]))
                err = fabs((*get_element(U1,i,j))-U2[i*(U1->columns) + j]);
    return err;
}

void liebmann_method(int N, int K, double Lx, double Ly, double eps, double omg, double *args, matrix *grid, double(*f_args[4])(double))
{
    double hx = Lx/(N-1), hy = Ly/(K-1);
    double delta = 1/(2/pow(hx, 2) + 2/pow(hy,2) + args[2]);
    double hhx = 1/pow(hx,2);
    double ahx = args[0]/2/hx;
    double hhy = 1/pow(hy,2);
    double bhy = args[1]/2/hy;
    for(int i=0; i<K; i++)
    {
            *get_element(grid, i, 0) = f_args[2](hx*i);
            *get_element(grid, i, N-1) = f_args[3](hx*i);
    }
    for(int i=0; i<N; i++)
    {
            *get_element(grid, 0, i) = f_args[0](hy*i);
            *get_element(grid, K-1, i) = f_args[1](hy*i);
    }   
    for(int i=1; i<K-1; i++)
        for(int j=1; j<N-1; j++)
        {
            double alpha = (j * hy) / Ly;
            *get_element(grid, i, j) = f_args[2](i * hx)*(1 - alpha) + f_args[3](i * hx) * alpha;
        }
    int n = 0;
    double err = eps*100;
    double *U2;
    do
    {
        n++;
        U2=malloc(N*K*sizeof(double));
        for(int i=0; i<grid->rows; i++)
            for(int j=0; j<grid->columns; j++)
                U2[i*(grid->columns)+ j] = *get_element(grid, i, j);
        
        for(int i=1; i<K-1; i++)
            for(int j=1; j<N-1; j++)
                *get_element(grid, i, j) = delta * ((hhx + ahx) * U2[(i - 1)*N+ j] + (hhx - ahx) * U2[(i + 1)*N+ j] + (hhy + bhy) * U2[i*N+ (j-1)] + (hhy - bhy) * U2[i*N+ (j+1)]);
        err = eror(grid, U2);
        free(U2);
    } while((err > eps) && (n<10000));
    printf("%d", n);
}

void seidel_method(int N, int K, double Lx, double Ly, double eps, double omg, double *args, matrix *grid, double(*f_args[4])(double))
{
    double hx = Lx/(N-1), hy = Ly/(K-1);
    double delta = 1/(2/pow(hx, 2) + 2/pow(hy,2) + args[2]);
    double hhx = 1/pow(hx,2);
    double ahx = args[0]/2/hx;
    double hhy = 1/pow(hy,2);
    double bhy = args[1]/2/hy;
    for(int i=0; i<K; i++)
    {
            *get_element(grid, i, 0) = f_args[2](hx*i);
            *get_element(grid, i, N-1) = f_args[3](hx*i);
    }
    for(int i=0; i<N; i++)
    {
            *get_element(grid, 0, i) = f_args[0](hy*i);
            *get_element(grid, K-1, i) = f_args[1](hy*i);
    }   
    for(int i=1; i<K-1; i++)
        for(int j=1; j<N-1; j++)
        {
            double alpha = (j * hy) / Ly;
            *get_element(grid, i, j) = f_args[2](i * hx)*(1 - alpha) + f_args[3](i * hx) * alpha;
        }
    int n = 0;
    double err = eps*100;
    double *U2;
    do
    {
        n++;
        U2=malloc(N*K*sizeof(double));
        for(int i=0; i<grid->rows; i++)
            for(int j=0; j<grid->columns; j++)
                U2[i*(grid->columns)+ j] = *get_element(grid, i, j);
        
        for(int i=1; i<K-1; i++)
            for(int j=1; j<N-1; j++)
                *get_element(grid, i, j) = delta * ((hhx + ahx) * (*get_element(grid, i-1, j)) + (hhx - ahx) * (*get_element(grid, i+1, j)) + (hhy + bhy) * (*get_element(grid, i, j-1)) + (hhy - bhy) * (*get_element(grid, i, j+1)));
        err = eror(grid, U2);
        free(U2);
    } while((err > eps) && (n<10000));
    printf("%d", n);
}

void relax_method(int N, int K, double Lx, double Ly, double eps, double omg, double *args, matrix *grid, double(*f_args[4])(double))
{
    double hx = Lx/(N-1), hy = Ly/(K-1);
    double delta = 1/(2/pow(hx, 2) + 2/pow(hy,2) + args[2]);
    double hhx = 1/pow(hx,2);
    double ahx = args[0]/2/hx;
    double hhy = 1/pow(hy,2);
    double bhy = args[1]/2/hy;
    for(int i=0; i<K; i++)
    {
            *get_element(grid, i, 0) = f_args[2](hx*i);
            *get_element(grid, i, N-1) = f_args[3](hx*i);
    }
    for(int i=0; i<N; i++)
    {
            *get_element(grid, 0, i) = f_args[0](hy*i);
            *get_element(grid, K-1, i) = f_args[1](hy*i);
    }   
    for(int i=1; i<K-1; i++)
        for(int j=1; j<N-1; j++)
        {
            double alpha = (j * hy) / Ly;
            *get_element(grid, i, j) = f_args[2](i * hx)*(1 - alpha) + f_args[3](i * hx) * alpha;
        }
    int n = 0;
    double err = eps*100;
    double *U2;
    do
    {
        n++;
        U2=malloc(N*K*sizeof(double));
        for(int i=0; i<grid->rows; i++)
            for(int j=0; j<grid->columns; j++)
                U2[i*(grid->columns)+ j] = *get_element(grid, i, j);
        
        for(int i=1; i<K-1; i++)
            for(int j=1; j<N-1; j++)
                *get_element(grid, i, j) = (*get_element(grid, i, j)) + omg * (delta * ((hhx + ahx) * (*get_element(grid, i-1, j)) + (hhx - ahx) * U2[(i + 1)*N+ j] + (hhy + bhy) * (*get_element(grid, i, j-1)) +(hhy - bhy) * U2[i*N+ (j+1)]) - (*get_element(grid, i, j)));
        err = eror(grid, U2);
        free(U2);
    } while((err > eps) && (n<10000));
    printf("%d", n);
}

int main()
{
    int  K=100, N=100, m=0;
    double *args1, Lx=1.57079632679, Ly=1.57079632679, eps = 0.00001, omg=1.5;
    args1 = malloc(sizeof(double)*3);
    args1[0] = 0; args1[1] = -2; args1[2] = -3;
    double(*f_args[4])(double) = {u0y,uly,u0x,ulx};
    matrix A = create_matrix(K, N);
    //liebmann_method(N, K, Lx, Ly, eps, omg, args1, &A, f_args); 
    //seidel_method(N, K, Lx, Ly, eps, omg, args1, &A, f_args); 
    relax_method(N, K, Lx, Ly, eps, omg, args1, &A, f_args); 
    FILE *fp;
    fp = fopen("res.csv", "w");
    for (int i=-1; i<A.rows; i++)
    {
        for (int j=0; j<A.columns; j++)
        {
            if(i>-1)
                fprintf(fp, "%lf", *get_element(&A, i, j));
            else
                fprintf(fp, "%d", j);
            if(j!=A.columns-1)
                fprintf(fp,",");
        }
        fprintf(fp,"\n");
    }
    fclose(fp);
}
//if ($?) { gcc -c laba_3.c; gcc -o laba_3  laba_3.o ../libs/my_lib/laba_lib.a; rm laba_3.o  } ; if ($?) { .\laba_3 }