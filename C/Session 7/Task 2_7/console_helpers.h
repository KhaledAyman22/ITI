#include <Windows.h>
#include <stdio.h>
#include <conio.h>

unsigned short GetCharInput();
void TextAttr(int i);
void GoToXY(short column, short row);
void BuildMenu(int current_row, char menu_options[MAIN_MENU_SIZE][100]);
void BuildNewForm();
char** LineEditor(int* x_pos, int* y_pos, char* char_set, int* data_size);
void HighlightEntry(int* x, int* y, char** data);
void HandleLineEditorLeft(int start, int *current_column, int y);
void HandleLineEditorRight(int end, int *current_column, int y);


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

char** LineEditor(int* x_pos, int* y_pos, char* char_set, int* data_size){
    TextAttr(HighLightPen);

    char **data;
    data = (char **) malloc(sizeof(char*) * 8);
    for (int i = 0; i < 8; ++i) {
        data[i] = malloc(sizeof(char) * (data_size[i] + 1));
    }

    for (int i = 0; i < 8; ++i){
        for (int j = 0; j < data_size[i]; ++j) {
            data[i][j] = '_';
        }
        data[i][data_size[i]] = '\0';
    }

    HighlightEntry(x_pos, y_pos, data);

    int current_column = x_pos[0], override=0, pos_i=0;

    while(1){
        int target = x_pos[pos_i] + data_size[pos_i];

        if(!override)
            GoToXY((short)current_column, (short)y_pos[pos_i]);
        override = 0;
        unsigned short s = GetCharInput();
        switch (s) {
            case ENTER: { TextAttr(NormalPen); return data; }

            case ESC:{ exit(0); }

            case LEFT:{
                HandleLineEditorLeft(x_pos[pos_i], &current_column, y_pos[pos_i]);
                break;
            }

            case RIGHT:{
                HandleLineEditorRight(x_pos[pos_i]+data_size[pos_i], &current_column, y_pos[pos_i]);
                break;
            }

            case HOME:{
                GoToXY((short)x_pos[pos_i],(short)y_pos[pos_i]);
                current_column = x_pos[pos_i];
                override = 1;
                break;
            }

            case END:{
                GoToXY((short)(x_pos[pos_i] + data_size[pos_i] - 1),(short)y_pos[pos_i]);
                current_column = x_pos[pos_i] + data_size[pos_i] - 1;
                override = 1;
                break;
            }

            case UP:{
                pos_i = pos_i == 0? 7 : pos_i-1;
                current_column = x_pos[pos_i];
                break;
            }

            case DOWN:{
                pos_i = pos_i == 7? 0 : pos_i+1;
                current_column = x_pos[pos_i];
                break;
            }

            case TAB:{
                pos_i = pos_i == 7? 0 : pos_i+1;
                current_column = x_pos[pos_i];
                break;
            }

            default:{
                if(current_column == target) break;
                char c = (char)((s<<8) >> 8), start_char, end_char;

                if(char_set[pos_i] == '0'){
                    start_char = '0';
                    end_char = '9';
                }
                else{
                    start_char = 'a';
                    end_char = 'z';
                }

                if((start_char <= c && c <= end_char) || (c == ' ' && 'a' == start_char)){
                    data[pos_i][current_column - x_pos[pos_i]] = c;
                    printf("%c", c);

                    current_column++;
                }

                break;
            }
        }
    }
}

void HighlightEntry(int* x, int* y, char** data){
    for (int i = 0; i < 8; ++i) {
        GoToXY((short)(x[i]),(short)y[i]);
        printf("%s", data[i]);
    }
}

void HandleLineEditorLeft(int start, int *current_column, int y){
    if(*current_column == start) return;
    else{
        (*current_column)--;
        GoToXY((short)*current_column, (short)y);
    }
}

void HandleLineEditorRight(int end, int *current_column, int y){
    if(*current_column == end) return;
    else{
        (*current_column) ++;
        GoToXY((short)*current_column, (short)y);
    }
}