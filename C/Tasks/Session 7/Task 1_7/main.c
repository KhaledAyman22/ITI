#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

int main() {
    int ** marks, *sum, *avg, stud_num, sub_num;

    printf("Enter Number of students:\n");
    scanf("%d", &stud_num);
    printf("Enter Number of subjects:\n");
    scanf("%d", &sub_num);


    marks = (int**)malloc(sizeof(int*) * stud_num);
    sum = malloc(sizeof(int) * stud_num);
    avg = malloc(sizeof(int) * sub_num);

    for (int i = 0; i < stud_num; ++i) sum[i] = 0;
    for (int i = 0; i < sub_num; ++i) avg[i] = 0;


    for (int i = 0; i < stud_num; ++i) {
        marks[i] = malloc(sizeof(int) * sub_num);
    }


    for (int i = 0; i < stud_num; ++i) {
        for (int j = 0; j < sub_num; ++j) {
            printf("Enter student %d/%d subject %d/%d grade:\n", i+1, stud_num, j+1, sub_num);
            scanf("%d", &(marks[i][j]));
            sum[i] += marks[i][j];
            avg[j] += marks[i][j];
        }
    }

    for (int i = 0; i < sub_num; ++i) avg[i] /= stud_num;


    for (int i = 0; i < stud_num; ++i)
        printf("Sum for student %d/%d is: %d\n", i+1, stud_num ,sum[i]);

    for (int i = 0; i < sub_num; ++i)
        printf("Subject %d/%d average is: %d\n", i+1, sub_num ,avg[i]);

    free(sum);
    free(avg);
    for (int i = 0; i < stud_num; ++i) free(marks[i]);
    free(marks);

    _getch();
    return 0;
}
