#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define pf printf
#define sf scanf_s

int main()
{
	pf("Task 2, character by character string:\n");

	char str[100], c = '0';
	int i = 0;

	pf("Enter your string:\n");

	while (c != 13) {
		c = getche();

		str[i] = (c == 13) ? '\0' : c;
		i++;
	}

	pf("\n\nYour string is: ");
	i = 0;

	while (str[i] != '\0') {
		pf("%c", str[i]);
		i++;
	}

	pf("\n");
}