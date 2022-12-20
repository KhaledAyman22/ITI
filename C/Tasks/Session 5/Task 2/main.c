#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include "globals.h"
#include "console_helpers.h"
#include "employee.h"
#include "navigation_helpers.h"

struct Employee employees[3];

unsigned short GetMainInput();
void HandleSubMenu(int row);
void HandleNew();
void HandleDisplay();

int main()
{
    for (int i = 0; i < 3; ++i) employees[i].id = -1;

    char menu_options[MAIN_MENU_SIZE][100] = {{"New\0"}, {"Display\0"}, {"Exit\0"} };
    int current_row = 0, exit = 0;


    while (exit == 0) {

        BuildMenu(current_row, menu_options);

        switch (GetMainInput())
        {
            case Enter: {
                if (current_row == 2) exit = 1;
                else HandleSubMenu(current_row);
                break;
            }

            case ESC: { exit = 1; break; }

            case UP: {
                current_row = UpKey(current_row);
                break;
            }

            case DOWN: {
                current_row = DownKey(current_row, MAIN_MENU_SIZE);
                break;
            }

            default: break;
        }

        TextAttr(NormalPen);
        system("cls");
    }
}

unsigned short GetMainInput(){
    unsigned short key_pressed = _getch();
    if (key_pressed == 0xE0)
    {
        key_pressed = key_pressed << 8;
        key_pressed += _getch();
    }

    return key_pressed;
}

void HandleSubMenu(int row) {
    TextAttr(NormalPen);
    system("cls");
    switch (row)
    {
        //New
        case 0: { HandleNew(); break; }

            //Display
        case 1: { HandleDisplay(); break; }

        default: break;
    }
}

void HandleNew(){
    ReadEmployeesData(employees);
    printf("Thank you. Returning to menu after 3 seconds...\n");
    Sleep(3000);
}

void HandleDisplay(){
    PrintEmployeesData(employees);
}