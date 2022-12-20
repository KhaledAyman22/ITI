#define pf printf
#define sf scanf_s

void NumExceeds100(){
    int sum=0,i;
    while(sum<101){
        pf("Enter a number:\n");
        sf("%d",&i);
        sum+=i;
    }
    pf("Sum: %d\n",sum);
}