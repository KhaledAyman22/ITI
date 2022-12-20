#define pf printf

void MagicBoxStatic(){
    int maxr=6, maxc=13;
    int r=1,c=3/2+1;

    for(int i=1;i<10;i++){
        GoToXY(maxc-((3-c)*3),maxr-((3-r)*2));
        pf("%d", i);

        if(i%3==0)
            r = (r+1==4)? 1:r+1;
        else{
            r = (r-1==0)? 3:r-1;
            c = (c-1==0)? 3:c-1;
        }
    }
}