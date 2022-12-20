#include <stdlib.h>
#include <conio.h>
#include "globals.h"
#include "console_helpers.h"
#include "employee.h"
#include "navigation_helpers.h"

struct Employee employees[EMPLOYEE_COUNT];

unsigned short GetMainInput();
void HandleSubMenu(int row);

int main()
{
    for (int i = 0; i < EMPLOYEE_COUNT; ++i) employees[i].id = -1;

    char menu_options[MAIN_MENU_SIZE][100] = {{"New\0"}, {"Display\0"}, {"Display All\0"}, {"Delete by ID\0"}, {"Delete by name\0"}, {"Exit\0"} };
    int current_row = 0, exit = 0;

    while (exit == 0) {

        BuildMenu(current_row, menu_options);

        switch (GetMainInput())
        {
            case Enter: {
                if (current_row == 5) exit = 1;
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
        case 0: {
            BuildNewForm();
            ReadEmployeeData(employees);
            break;
        }

        //Display
        case 1: { PrintEmployeeData(employees); break; }

        //Display All
        case 2: { PrintEmployeesData(employees); break; }

        //Delete by ID
        case 3: { DeleteEmployeeById(employees); break; }

        //Delete by Name
        case 4: { DeleteEmployeeByName(employees); break; }

        default: break;
    }
}