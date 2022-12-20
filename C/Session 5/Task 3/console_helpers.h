#include <Windows.h>
#include <stdio.h>

void TextAttr(int i);
void GoToXY(short column, short row);
void BuildMenu(int current_row, char menu_options[MAIN_MENU_SIZE][100]);
void BuildNewForm();

void TextAttr(int i)
{
    SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), i);
}

void GoToXY(short column, short row)
{
    COORD coord;
    coord.X = column;
    coord.Y = row;
    SetConsoleCursorPosition(
            GetStdHandle(STD_OUTPUT_HANDLE),
            coord
    );
}

void BuildMenu(int current_row, char menu_options[MAIN_MENU_SIZE][100]){
    for (int i = 0; i < MAIN_MENU_SIZE; i++)
    {
        if (current_row == i) TextAttr(HighLightPen);
        else TextAttr(NormalPen);

        GoToXY(50, 10 + (i * 2));
        printf("%s", menu_options[i]);
    }
}

void BuildNewForm(){
    GoToXY(FORM_FIRST_COLUMN, FORM_START_ROW);
    printf("ID: ");
    GoToXY(FORM_FIRST_COLUMN, FORM_START_ROW+2);
    printf("Name: ");
    GoToXY(FORM_FIRST_COLUMN, FORM_START_ROW+4);
    printf("Age: ");
    GoToXY(FORM_FIRST_COLUMN, FORM_START_ROW+6);
    printf("Gender: ");

    GoToXY(FORM_SECOND_COLUMN, FORM_START_ROW);
    printf("Address: ");
    GoToXY(FORM_SECOND_COLUMN, FORM_START_ROW+2);
    printf("Salary: ");
    GoToXY(FORM_SECOND_COLUMN, FORM_START_ROW+4);
    printf("Overtime: ");
    GoToXY(FORM_SECOND_COLUMN, FORM_START_ROW+6);
    printf("Tax: ");
}