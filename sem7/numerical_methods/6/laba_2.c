#include <stdio.h>
#include <stdlib.h>
#include <math.h>

#include "../libs/my_lib/laba_lib.h"

double phi0(double x)
{
    return exp(-x);
} 
double phil(double x)
{
    return -exp(-x);
} 
double ksi0(double x)
{
    return sin(x);
}
double ksi0_der(double x)
{
    return cos(x);
}
double ksi0_der2(double x)
{
    return -sin(x);
}
double ksil(double x)
{
    return -sin(x);
}
double f(double x, double t)
{
    return -cos(x)*exp(-t);
}

void explicit_solwer(int pr, int k, int N, double l, double T, double *args1, double *args2, matrix *grid, double(*f_args[6])(double), double(*f)(double, double))
{
    /*
    f_args[0] = phi0(t)
    f_args[1] = phil(t)
    f_args[2] = ksi0(x)
    f_args[3] = ksil(x)
    f_args[4] = ksi0'(x)
    f_args[5] = ksi0''(x)
    */
    double tau = T/(k-1), h = l/(N-1);
    /*заполним 0 уровень вреени*/
    for(int i=0; i<N; i++)
        *get_element(grid, 0, i) = f_args[2](i*h);
    /*заполним 1 уровень вреени*/
    switch (pr)
    {
        case 1: //по 2 точкам с точностью 1
        for(int i=0; i<N; i++)
            *get_element(grid, 1, i) = f_args[2](i*h)+f_args[3](i*h)*tau;
            //printf("1");
        break;

        default: //по 2 точкам с точностью 2
        for(int i=0; i<N; i++)
            *get_element(grid, 1, i) = f_args[2](i*h) + f_args[3](i*h)*(tau-args1[3]*pow(tau,2)/2) + (args1[0]*f_args[5](i*h) + args1[1]*f_args[4](i*h) + args1[2]*f_args[2](i*h)+f(i*h, tau))*(pow(tau,2)/2);
        break;
    }
    for(int i=2; i<k; i++)
    {
        for(int j=1; j<N-1; j++)
            *get_element(grid, i, j) = ( *get_element(grid, i-1, j-1)*(args1[0]/pow(h,2) - args1[1]/(2*h)) + *get_element(grid, i-1, j)*(args1[2] + 1/pow(tau,2) - 2*args1[0]/pow(h,2)) + *get_element(grid, i-1, j+1)*(args1[0]/pow(h,2) + args1[1]/(2*h)) + f(j*h, i*tau) ) / (1/pow(tau,2) + args1[3]/(2*tau));
        switch (pr)
        {
            case 1: //по 2 точкам с точностью 1
            *get_element(grid, i, 0) = (f_args[0](i*tau) - args2[0]/h *(*get_element(grid, i, 1)))/(args2[1]-args2[0]/h);
            *get_element(grid, i, N-1) = (f_args[1](i*tau) - args2[2]/h *(*get_element(grid, i, N-2)))/(args2[3]+args2[2]/h);
            //printf("hi1\n");
            break;

            case 2: //по 3 точкам с точностью 2
            *get_element(grid, i, 0) = (2*h*f_args[0](i*tau) + *get_element(grid, i, 2)*args2[0] - *get_element(grid, i, 1)*4*args2[0])/(2*h*args2[1]-3*args2[0]);
            *get_element(grid, i, N-1) = (2*h*f_args[1](i*tau) + *get_element(grid, i, N-2)*4*args2[2] - *get_element(grid, i, N-3)*args2[2])/(3*args2[2]+2*h*args2[3]);
            //printf("hi2\n");
            break;

            case 3: //по 2 точкам с точностью 2
            *get_element(grid, i, 0) = (f_args[0](i*tau) - args2[0]/h *(*get_element(grid, i, 1)))/(args2[1]-args2[0]/h);
            *get_element(grid, i, N-1) = (f_args[1](i*tau) - args2[2]/h *(*get_element(grid, i, N-2)))/(args2[3]+args2[2]/h);
            //printf("hi3\n");
            break;
        }
    }
}

void implicit_solwer(int pr, int k, int N, double l, double T, double *args1, double *args2, matrix *grid, double(*f_args[6])(double), double(*f)(double, double))
{
    /*
    f_args[0] = phi0(t)
    f_args[1] = phil(t)
    f_args[2] = ksi0(x)
    f_args[3] = ksil(x)
    f_args[4] = ksi0'(x)
    f_args[5] = ksi0''(x)
    */
    double tau = T/(k-1), h = l/(N-1);
    matrix system = create_matrix(N, N);
    matrix D = create_matrix(1,N);
    /*заполним 0 уровень вреени*/
    for(int i=0; i<N; i++)
        *get_element(grid, 0, i) = f_args[2](i*h);
    /*заполним 1 уровень вреени*/
    switch (pr)
    {
        case 1: //по 2 точкам с точностью 1
        for(int i=0; i<N; i++)
            *get_element(grid, 1, i) = f_args[2](i*h)+f_args[3](i*h)*tau;
            printf("1");
        break;

        default: //по 2 точкам с точностью 2
        for(int i=0; i<N; i++)
            *get_element(grid, 1, i) = f_args[2](i*h) + f_args[3](i*h)*(tau-args1[3]*pow(tau,2)/2) + (args1[0]*f_args[5](i*h) + args1[1]*f_args[4](i*h) + args1[2]*f_args[2](i*h)+f(i*h, tau))*(pow(tau,2)/2);
        break;
    }

    /*заполним систему уравнений*/
    for (int i=1; i<N-1; i++)
    {
        *get_element(&system, i, i-1) = args1[0]/pow(h,2)-args1[1]/(2*h);
        *get_element(&system, i, i) = args1[2]-2*args1[0]/pow(h,2)-args1[3]/(2*tau)-1/pow(tau,2);
        *get_element(&system, i, i+1) = args1[0]/pow(h,2)+args1[1]/(2*h);
    }
    switch (pr)
    {
    case 1://по двум точкам с 1 точностью
        *get_element(&system, 0, 0) = args2[1] - args2[0] / h;
        *get_element(&system, 0, 1) = args2[0] / h;
        *get_element(&system, N-1, N-2) = - args2[2] / h;
        *get_element(&system, N-1, N-1) = args2[3] + args2[2] / h;
        break;
    case 2://по треим точкам с 2 точностью
        *get_element(&system, 0, 0) = args2[1] - 3*args2[0]/ h/ 2;
        *get_element(&system, 0, 1) = 2 * args2[0]/h;
        *get_element(&system, 0, 2) = - args2[0] / h /2;
        *get_element(&system, N-1, N-3) = args2[2] / h /2;
        *get_element(&system, N-1, N-2) = -2 * args2[2]/h;
        *get_element(&system, N-1, N-1) = args2[3] + 3*args2[2]/ h/ 2;
        break;
    case 3://по двум точкам с 2 точностью
        *get_element(&system, 0, 0) = args2[1] - args2[0] / h;
        *get_element(&system, 0, 1) = args2[0] / h;
        *get_element(&system, N-1, N-2) = - args2[2] / h;
        *get_element(&system, N-1, N-1) = args2[3] + args2[2] / h;
        break;
    }

    for(int i=2; i<k; i++)
    {
        for(int j=1; j<N-1; j++)
            *get_element(&D, 0, j) = *get_element(grid, i-2, j)*(1/pow(tau,2)-args1[3]/(2*tau)) - *get_element(grid, i-1, j)*2/pow(tau,2) - f(j*h, i*tau);
        switch (pr)
        {
        case 1:
            *get_element(&D, 0, 0) = f_args[0](i*tau);
            *get_element(&D, 0, N-1) = f_args[1](i*tau);
            insert_matrix_line(grid, run_method(system, D, N), i);
            break;
        case 2:
            *get_element(&D, 0, 0) = f_args[0](i*tau);
            *get_element(&D, 0, N-1) = f_args[1](i*tau);
            insert_matrix_line(grid, LU_method(system, D, N), i);
            break;
        case 3:
            *get_element(&D, 0, 0) = f_args[0](i*tau);
            *get_element(&D, 0, N-1) = f_args[1](i*tau);
            insert_matrix_line(grid, run_method(system, D, N), i);
            break;
        }
    }
}

int main()
{
    matrix A = create_matrix(1000,100);
    double *args1, *args2;
    args1 = malloc(sizeof(double)*4); args2 = malloc(sizeof(double)*4);
    double(*f_args[6])(double) = {phi0, phil, ksi0, ksil, ksi0_der, ksi0_der2};
    args1[0] = 1; args1[1] = 1; args1[2] = -1; args1[3] = 3;
    args2[0] = 1; args2[1] = 0; args2[2] = 1; args2[3] = 0;
    //explicit_solwer(2, 1000, 100, 3.14, 1, args1, args2, &A, f_args, f);
    implicit_solwer(2, 1000, 100, 3.14, 1, args1, args2, &A, f_args, f);
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
//if ($?) { gcc -c laba_2.c; gcc -o laba_2  laba_2.o ../libs/my_lib/laba_lib.a; rm laba_2.o  } ; if ($?) { .\laba_2 }