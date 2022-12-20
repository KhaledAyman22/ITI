#define pf printf
#define sf scanf_s

void MagicBoxDynamic(){
    int dimension;
    pf("Enter dimension:\n");
    sf("%d",&dimension);

    int r=1,c=dimension/2+1;
    int maxr = 7 + (2 * (dimension - 1)),
        maxc = (3 * (dimension - 1));

    int total = (dimension * dimension) + 1;

    for(int i=1; i< total; i++){
        GoToXY(maxc - ((3 - c) * 3),maxr - ((3 - r) * 2));
        pf("%d", i);

        if(i % dimension == 0)
            r = (r + 1 == dimension + 1)? 1 : r + 1;
        else{
            r = (r - 1 == 0)? dimension : r - 1;
            c = (c - 1 == 0)? dimension : c - 1;
        }
    }
}