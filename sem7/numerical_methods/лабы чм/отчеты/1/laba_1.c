#include <stdio.h>
#include <stdlib.h>
#include <math.h>

#include "../libs/my_lib/laba_lib.h"

double phi(double x)
{
    return -exp(-1*x)*(cos(1*x)+sin(1*x));
} 
double phil(double x)
{
    return exp(-1*x)*(cos(1*x)+sin(1*x));
} 
double ksi(double x)
{
    return cos(x);
}
double f(double x, double t)
{
    return 0;
}

void get_first_layer_explicit(int pr, int k, int N, double l, double T/*поставишь 1 - умрешь*/, double *args1, double *args2, matrix *grid, double(*phi)(double), double(*phil)(double), double(*ksi)(double), double(*f)(double, double))
{
    double tau = T/k, h = l/(N-1), mu = args1[1]*tau/(2*h);
    double b0, c0, bN, aN, d0, dN;
    /*Заполняем сетку в момент времени 0*/
    for(int i=0; i<N; i++)
        *get_element(grid, 0, i) = ksi(i*h);
    /*Заполним центральный сигмент таблицы*/
    for(int i=1; i<k; i++)
        for(int j=1; j<N-1; j++)
            *get_element(grid, i, j) = *get_element(grid, i-1, j+1)*(T + mu)+(*get_element(grid, i-1, j)*(1-2*T+ tau*args1[2]))+(*get_element(grid, i-1, j-1)*(T-mu));
    /*заполнияе крайние значения с применением граничных условий*/
    switch (pr)
    {
    case 1://по двум точкам с 1 точностью
        for(int i=1; i<k; i++)
        {
            *get_element(grid, i, 0) = (*get_element(grid, i, 1)*(-args2[0]/h)+phi(tau*k))/(args2[1] - args2[0] / h);
            *get_element(grid, i, N-1) = (*get_element(grid, i, N-2)*(args2[2]/h)+phil(tau*k))/(args2[3] + args2[2] / h);
        }
        break;
    case 2://по треим точкам с 2 точностью
        for(int i=1; i<k; i++)
        {
            *get_element(grid, i, 0) = ((*get_element(grid, i, 1)*4-*get_element(grid, i, 2))*(-args2[0]/(2*h))+phi(tau*k))/(args2[1] - 3*args2[0]/(2*h));
            *get_element(grid, i, N-1) = ((*get_element(grid, i, N-3)-*get_element(grid, i, N-2)*4)*(-args2[2]/(2*h))+phil(tau*k))/(args2[3] + 3*args2[2]/(2*h));
        }
        break;
    case 3://по двум точкам с 2 точностью
        b0 = 2*args1[0]/h + h/tau - h*args1[2] - args2[1]/args2[0]*(2*args1[0] - args1[1]*h);
        c0 = -2*args1[0]/h;
        bN = 2*args1[0]/h + h/tau - h*args1[2] + args2[3]/args2[2]*(2*args1[0] + args1[1]*h);
        aN = -2*args1[0]/h;
        for(int i=1; i<k; i++)
        {
            d0 = h/tau * (*get_element(grid, i-1, 0)) - phi(tau*(k + 1)) * (2*args1[0] - args1[1]*h) / args2[0];
            dN = h/tau * (*get_element(grid, i-1, N-1))+ phil(tau*(k + 1)) * (2*args1[0] - args1[1]*h) / args2[2];
            *get_element(grid, i, 0) = (d0 - c0 * (*get_element(grid, i, 1))) / b0;
            *get_element(grid, i, N-1) = (dN - aN * (*get_element(grid, i, N-2))) / bN;
        }
        break;
    }
}

void get_first_layer_implicit(int pr, int k, int N, double l, double T/*поставишь 1 - умрешь*/, double *args1, double *args2, matrix *grid, double(*phi)(double), double(*phil)(double), double(*ksi)(double), double(*f)(double, double))
{
    double tau = T/k, h = l/(N-1);
    matrix system = create_matrix(N, N);
    matrix D = create_matrix(1,N);
    /*Заполняем сетку в момент времени 0*/
    for(int i=0; i<N; i++)
        *get_element(grid, 0, i) = ksi(i*h);
    /*заполним центральную часть системы уравнений*/
    for (int i=1; i<N-1; i++)
    {
        *get_element(&system, i, i-1) = args1[0]*tau/pow(h,2)-args1[1]*tau/(2*h);
        *get_element(&system, i, i) = -2*args1[0]*tau/pow(h,2)+args1[2]*tau-1;
        *get_element(&system, i, i+1) = args1[0]*tau/pow(h,2)+args1[1]*tau/(2*h);
    }
    /*заполним краевые значения*/
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
        *get_element(&system, 0, 0) = 2 * args1[0] / h + h / tau - h * args1[2] - args2[1] / args2[0] * (2 * args1[0] - args1[1] * h);
        *get_element(&system, 0, 1) = -2 * args1[0] / h;
        *get_element(&system, N-1, N-2) = -2 * args1[0] / h;
        *get_element(&system, N-1, N-1) = 2 * args1[0] / h + h / tau - h * args1[2] + args2[3] / args2[2] * (2 * args1[0] + args1[1] * h);
        break;
    }
    for(int i=1; i<k; i++)
    {
        for(int j=1; j<N-1; j++)
            *get_element(&D, 0, j) = -(*get_element(grid, i-1, j));
        switch (pr)
        {
        case 1:
            *get_element(&D, 0, 0) = phi(i*tau);
            *get_element(&D, 0, N-1) = phil(i*tau);
            insert_matrix_line(grid, run_method(system, D, N), i);
            break;
        case 2:
            *get_element(&D, 0, 0) = phi(i*tau);
            *get_element(&D, 0, N-1) = phil(i*tau);
            insert_matrix_line(grid, LU_method(system, D, N), i);
            break;
        case 3:
            *get_element(&D, 0, 0) = h / tau * (*get_element(grid, i-1, 0)) - phi(tau*i) * (2 * args1[0] - args1[1] * h) / args2[0];
            *get_element(&D, 0, N-1) = h / tau * (*get_element(grid, i-1, N-1)) + phil(tau*i) * (2 * args1[0] + args1[1] * h) / args2[2];
            insert_matrix_line(grid, run_method(system, D, N), i);
            break;
        }
    }
    //destroy_matrix(&system); destroy_matrix(&D); destroy_matrix(&tmp);
}

void get_first_layer_CrankNicolson(int pr, int k, int N, double sgm, double l, double T/*поставишь 1 - умрешь*/, double *args1, double *args2, matrix *grid, double(*phi)(double), double(*phil)(double), double(*ksi)(double), double(*f)(double, double))
{
    matrix grid1 = create_matrix(k,N);
    matrix grid2 = create_matrix(k,N);
    get_first_layer_explicit(pr, k, N, l, T, args1, args2, &grid1, phi, phil, ksi, f);
    get_first_layer_implicit(pr, k, N, l, T, args1, args2, &grid2, phi, phil, ksi, f);
    printf("y");
    for (int i=0; i<k; i++)
        for (int j=0; j<N; j++)
            *get_element(grid, i, j) = *get_element(&grid1, i, j)*(1-sgm)+*get_element(&grid2, i, j)*sgm;
}


int main()
{
    matrix A = create_matrix(1000,100);
    double *args1, *args2;
    args1 = malloc(sizeof(double)*3); args2 = malloc(sizeof(double)*4);
    args1[0] = 1; args1[1] = 1; args1[2] = 0;
    args2[0] = 1; args2[1] = -1; args2[2] = 1; args2[3] = -1;
    //get_first_layer_explicit(3, 1000, 100, 3.14, 0.4, args1, args2, &A, phi, phil, ksi, f);
    get_first_layer_implicit(3, 1000, 100, 3.14, 0.4, args1, args2, &A, phi, phil, ksi, f);
    //get_first_layer_CrankNicolson(3, 1000, 100, 0.5, 3.14, 0.4, args1, args2, &A, phi, phil, ksi, f);
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
//{ gcc -c laba_1.c; gcc -o laba_1  laba_1.o ../libs/my_lib/laba_lib.a; rm laba_1.o   }