#include <stdio.h>
#include <stdlib.h>
#include <limits.h>
#define pf printf
#define sf scanf_s

#include "io_array_2_loops.h"
#include "min_max_of_array.h"
#include "sum_of_rows.h"
#include "column_average.h"
#include "static_matrix_multiply.h"
#include "dynamic_matrix_multiply.h"



int main() {
    IOArray2Loops();
    pf("\n");

    if(getch("%c") == 13) system("cls");

    MinMaxofArray();
    pf("\n");

    if (getch("%c") == 13) system("cls");

    SumofRows();
    pf("\n");

    if (getch("%c") == 13) system("cls");

    ColumnAverage();
    pf("\n");

    if (getch("%c") == 13) system("cls");

    StaticMatrixMultiply();
    pf("\n");

    if (getch("%c") == 13) system("cls");

    DynamicMatrixMultiply();

    return 0;
}
