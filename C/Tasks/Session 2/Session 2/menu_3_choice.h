#include <stdlib.h>
#define pf printf
#define sf scanf_s

void Menu3Choice(){
    int i;
    while(1){
        pf("Press 1 to print Hello World\nPress 2 to print a random number\nPress 3 to exit\n");
        sf("%d",&i);

        if(i==1)
            pf("Hello World!\n");
        else if(i==2)
            pf("%d\n", rand());
        else if(i==3)
            break;
        else
            pf("Invalid choice\n");

        pf("\n");
    }
}