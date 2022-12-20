#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define pf printf
#define sf scanf_s

int main()
{
	pf("Task 3, concatenate two strings:\n");

	char firstName[50], secondName[50];

	pf("Enter First Name:\n");
	sf("%s", &firstName, 50);
	pf("Enter Second Name:\n");
	sf("%s", &secondName, 50);

	pf("Your concatenated string is: ");
	pf("%s\n", strcat(strcat(firstName, " "), secondName));
}