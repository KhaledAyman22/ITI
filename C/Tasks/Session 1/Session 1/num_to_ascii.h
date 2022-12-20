#include <stdio.h>

#define sf scanf_s
#define pf printf

void NumToASCII(){
    char c;
    pf("Enter a character:\n");
    sf(" %c", &c);
    pf("%d\n", c);
}