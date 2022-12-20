#include <stdio.h>
#include "goto_x_y.h"
#include "magic_box_static.h"
#include "magic_box_dynamic.h"
#include "num_exceeds_100.h"
#include "menu_3_choice.h"

#define pf printf

int main() {
    pf("Task 1, Magic Box Static:\n");
    MagicBoxStatic();

    if (getch("%c") == 13) system("cls");

    pf("Task 2, Magic Box Dynamic:\n");
    MagicBoxDynamic();

    if (getch("%c") == 13) system("cls");

    pf("Task 3, Number Exceeds 100:\n");
    NumExceeds100();

    if (getch("%c") == 13) system("cls");

    pf("Task 4, Menu 3 Choice:\n");
    Menu3Choice();
}