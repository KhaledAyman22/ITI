#include <stdio.h>

void SwapByValue(int x, int y){
    printf("X is %d\n", x);
    printf("Y is %d\n", y);

    int tmp = x;
    x = y;
    y = tmp;

    printf("X is %d\n", x);
    printf("Y is %d\n", y);
}


void SwapByAddress(int* x, int* y){
    printf("X is %d\n", *x);
    printf("Y is %d\n", *y);

    int z = *x;
    *x = *y;
    *y = z;
}

void IOArray(int *arr, int size){
    int* ptr = arr;

    for (int i = 0; i < 5; ++i) {
        scanf("%d", ptr+i);
    }

    printf("your numbers are\n");

    for (int i = 0; i < 5; ++i) {
        printf("%d", *(ptr+i));
    }
}

int main() {
    int arr[5], x=1, y=2;
    SwapByValue(1,2);
    printf("\n\n");
    printf("\n\n");

    SwapByAddress(&x, &y);
    printf("X is %d\n", x);
    printf("Y is %d\n", y);

    printf("\n\n");
    printf("\n\n");

    IOArray(arr, 5);
    return 0;
}
