int StaticMatrixMultiply() {
    pf("Task 5:\n");

    int m1[3][2], m2[2][1], m3[3][1]={{0},{0},{0}};

    pf("\nEnter Matrix 1\n\n");
    for (int i = 0; i < 3; ++i) {
        for (int j = 0; j < 2; ++j){
            pf("Enter number of cell [%d,%d]:", i+1, j+1);
            sf("%d",&m1[i][j]);
        }
    }

    pf("\nEnter Matrix 2\n\n");
    for (int i = 0; i < 2; ++i) {
        for (int j = 0; j < 1; ++j){
            pf("Enter number of cell [%d,%d]:", i+1, j+1);
            sf("%d",&m2[i][j]);
        }
    }

    for (int i = 0; i < 3; ++i) {
        for (int j = 0; j < 1; ++j) {
            for (int k = 0; k < 2; ++k) {
                m3[i][j] += m1[i][k] * m2[k][j];
            }
        }
    }

    pf("Answer is:\n");

    for (int i = 0; i < 3; ++i) {
        for (int j = 0; j < 1; ++j){
            pf("%d ",m3[i][j]);
        }
        pf("\n");
    }
}
