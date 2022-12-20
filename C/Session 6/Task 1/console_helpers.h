#include <Windows.h>
#include <stdio.h>
#include <conio.h>

unsigned short GetCharInput();
void TextAttr(int i);
void GoToXY(short column, short row);
void BuildMenu(int current_row, char menu_options[MAIN_MENU_SIZE][100]);
void BuildNewForm();
char* LineEditor(int x, int y, char start_char, char end_char, int size);
void HighlightEntry(int x, int y, char* data, int size);
int HandleLineEditorEnter(int target, int current_needed);
void HandleLineEditorLeft(int start, int *current_column, int y);
void HandleLineEditorRight(int end, int *current_column, int current_needed, int y);


unsigned short GetCharInput(){
    unsigned short key_pressed = _getch();
    if (key_pressed == 0xE0)
    {
        key_pressed = key_pressed << 8;
        key_pressed += _getch();
    }

    return key_pressed;
}

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

        GoToXY(50, (short)(10 + (i * 2)));
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

char* LineEditor(int x, int y, char start_char, char end_char, int size){
    TextAttr(HighLightPen);

    char *data = (char*) malloc(size + 1);
    for (int i = 0; i < size; ++i) data[i] = '_';
    data[size] = '\0';

    HighlightEntry(x, y, data, size);

    int current_column = x, current_needed = x, target = x + size, finish = 0, override=0;

    while(!finish){
        if(!override)
            GoToXY((short)current_column, (short)y);
        override = 0;
        unsigned short s = GetCharInput();
        switch (s) {
            case ENTER: {
                finish = HandleLineEditorEnter(target, current_needed);
                break;
            }

            case ESC:{ exit(0); }

            case LEFT:{
                HandleLineEditorLeft(x, &current_column, y);
                break;
            }

            case RIGHT:{
                HandleLineEditorRight(x+size, &current_column, current_needed, y);
                break;
            }

            case HOME:{
                GoToXY((short)x,(short)y);
                current_column = x;
                override = 1;
                break;
            }

            case END:{
                GoToXY((short)current_needed ,(short)y);
                current_column = current_needed;
                override = 1;
                break;
            }
            /*
            case DEL:{

                break;
            }

            case INSERT:{

                break;
            }
            */

            default:{
                if(current_column == current_needed && current_needed == target) break;
                char c = (char)((s<<8) >> 8);
                if((start_char <= c && c <= end_char) || (c == ' ' && 'a' == start_char && end_char == 'z')){
                    data[current_column - x] = c;
                    printf("%c", c);
                    if(current_needed == current_column) current_needed++;

                    current_column++;
                }

                break;
            }
        }
    }

    TextAttr(NormalPen);
    return data;
}

void HighlightEntry(int x, int y, char* data, int size){
    for (int i = 0; i < size; ++i) {
        GoToXY((short)(x+i),(short)y);
        printf("%c", data[i]);
    }
}

int HandleLineEditorEnter(int target, int current_needed){
    return target == current_needed;
}

void HandleLineEditorLeft(int start, int *current_column, int y){
    if(*current_column == start) return;
    else{
        (*current_column)--;
        GoToXY((short)*current_column, (short)y);
    }
}

void HandleLineEditorRight(int end, int *current_column, int current_needed, int y){
    if(*current_column == end || (*current_column)+1 >= current_needed) return;
    else{
        (*current_column) ++;
        GoToXY((short)*current_column, (short)y);
    }
}