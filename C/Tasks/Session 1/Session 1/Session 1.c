#include <stdio.h>
#include "hello_world.h"
#include "num_to_hex_and_char.h"
#include "num_to_ascii.h"


int main()
{
    pf("Task 1, Hello World:\n");
    HelloWorld();
    pf("\n");

    if (getch("%c") == 13) system("cls");

    pf("Task 2, Number to Hexa and Char:\n");
    NumToHexAndChar();
    pf("\n");

    if (getch("%c") == 13) system("cls");

    pf("Task 3, Number to ASCII:\n");
    NumToASCII();

    return 0;
}
