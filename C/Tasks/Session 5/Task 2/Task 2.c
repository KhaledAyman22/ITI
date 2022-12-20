#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <conio.h>
#include <Windows.h>

#define pf printf
#define sf scanf
#define NormalPen 0x0F
#define HighLightPen 0XF0
#define Enter 0x0D
#define ESC 0x1B
#define UP 0xE048
#define DOWN 0xE050
#define MENU_SIZE 3

struct Employee {
	int id, age;
	char gender, name[100], address[200];
	double salary, overtime, tax;
};


int main()
{
	struct Employee emp;
	pf("Enter employee ID: ");
	sf("%d", &emp.id);


	
	pf("Enter employee age: ");
	sf("%d", &emp.age);



	pf("Enter employee gender: ");
	sf(" %c", &emp.gender);



	pf("Enter employee neme: ");
	sf("%s", &emp.name);



	pf("Enter employee address: ");
	sf("%s", &emp.address);



	pf("Enter employee salary: ");
	sf("%lf", &emp.salary);



	pf("Enter employee overtime: ");
	sf("%lf", &emp.overtime);



	pf("Enter employee tax: ");
	sf("%lf", &emp.tax);


	

	pf("*********************************************\n");


	pf("Employee ID is: %d\n", emp.id);
	pf("Employee name is: %s\n", emp.name);
	pf("Employee net is: %lf\n", emp.salary + emp.overtime - emp.tax);
}

