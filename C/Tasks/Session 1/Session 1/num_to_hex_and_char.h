#include <stdio.h>

#define sf scanf_s
#define pf printf

void NumToHexAndChar(){
    int num;
    pf("Enter a number:\n");
    sf("%d", &num);
    pf("Hexa: 0x%x\n", num);
    pf("Char: %c\n", num);
}