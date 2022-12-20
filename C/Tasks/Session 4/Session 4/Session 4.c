#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <conio.h>
#include <Windows.h>

#define pf printf
#define sf scanf_s
#define NormalPen 0x0F
#define HighLightPen 0XF0
#define Enter 0x0D
#define ESC 0x1B
#define UP 0xE048
#define DOWN 0xE050
#define MENU_SIZE 3

void textattr(int i)
{
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), i);
}

void GoToXY(int column, int row)
{
	COORD coord;
	coord.X = column;
	coord.Y = row;
	SetConsoleCursorPosition(
		GetStdHandle(STD_OUTPUT_HANDLE),
		coord
	);
}

void HandleSubMenu(int row) {
	system("cls");
	textattr(NormalPen);
	switch (row)
	{
		case 0: {
			char name[50];
			pf("Enter new name: \n");
			sf("%s", name, 50);
			pf("Thank you %s. Returnung to menu after 3 seconds...\n", name);
			Sleep(3000);
			break;
		}

		case 1: {
			pf("Nothing to save. Returnung to menu after 3 seconds...\n");
			Sleep(3000);
			break;
		}

		default:
			break;
	}
}

int main()
{
	char menu_options[MENU_SIZE][100] = { {"New\0"},{"Save\0"},{"Exit\0"} };
	int current_row = 0, exit = 0;
	

	while (exit == 0) {
		pf("Task 1, Interactive menu:\n");

		for (int i = 0; i < 3; i++)
		{
			if (current_row == i) textattr(HighLightPen);
			else textattr(NormalPen);

			GoToXY(50, 10 + (i * 2));
			pf("%s", menu_options[i]);
		}

		unsigned short key_pressed = _getch();
		if (key_pressed == 0xE0) 
		{ 
			key_pressed = key_pressed << 8;
			key_pressed += _getch();
		}

		switch (key_pressed)
		{
		case Enter:{
			if (current_row == 2) exit = 1;
			else HandleSubMenu(current_row);
			break;
		}

		case ESC:{
			exit = 1;
			break;
		}

		case UP: {
			current_row = current_row == 0 ? current_row : current_row - 1;
			break;
		}

		case DOWN:{
			current_row = current_row == MENU_SIZE-1 ? current_row : current_row + 1;
			break;
		}

		default:
			break;
		}

		textattr(NormalPen);
		system("cls");
	}

}