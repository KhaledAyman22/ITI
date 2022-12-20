int DynamicMatrixMultiply() {
pf("Task 6:\n");

    int m1d1,m1d2=0,m2d1=1,m2d2;
    while(1){
        pf("Enter M1D1: ");
        sf("%d",&m1d1);
        pf("Enter M1D2: ");
        sf("%d",&m1d2);
        pf("Enter M2D1: ");
        sf("%d",&m2d1);
        pf("Enter M2D2: ");
        sf("%d",&m2d2);

        if (m1d2 != m2d1)
            pf("Matrix 1 number of columns must equal Matrix 2 number of rows!!\n\n");
        else break;
    }

    int m3d1 = m1d1, m3d2 = m2d2;


    int** m1 = (int**)malloc(m1d1 * sizeof(int*));
    int** m2 = (int**)malloc(m2d1 * sizeof(int*));
    int** m3 = (int**)malloc(m3d1 * sizeof(int*));

    for (int i = 0; i < m1d1; i++) m1[i] = (int*)malloc(m1d2 * sizeof(int));
    for (int i = 0; i < m2d1; i++) m2[i] = (int*)malloc(m2d2 * sizeof(int));
    for (int i = 0; i < m3d1; i++) m3[i] = (int*)malloc(m3d2 * sizeof(int));


    for (int i = 0; i < m3d1; ++i)
        for (int j = 0; j < m3d2; ++j)
            m3[i][j] = 0;

    pf("\nEnter Matrix 1\n\n");
    for (int i = 0; i < m1d1; ++i) {
        for (int j = 0; j < m1d2; ++j){
            pf("Enter number of cell [%d,%d]:", i+1, j+1);
            sf("%d",&m1[i][j]);
        }
    }

    pf("\nEnter Matrix 2\n\n");
    for (int i = 0; i < m2d1; ++i) {
        for (int j = 0; j < m2d2; ++j){
            pf("Enter number of cell [%d,%d]:", i+1, j+1);
            sf("%d",&m2[i][j]);
        }
    }

    for (int i = 0; i < m1d1; ++i) {
        for (int j = 0; j < m2d2; ++j) {
            for (int k = 0; k < m1d2; ++k) {
                m3[i][j] += m1[i][k] * m2[k][j];
            }
        }
    }

    pf("Answer is:\n");

    for (int i = 0; i < m1d1; ++i) {
        for (int j = 0; j < m2d2; ++j){
            pf("%d ",m3[i][j]);
        }
        pf("\n");
    }
}
