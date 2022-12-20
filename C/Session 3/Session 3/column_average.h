int ColumnAverage() {
    pf("Task 4:\n");

    float arr[3][3], sum[3]={0.0};

    for (int i = 0; i < 3; ++i) {
        for (int j = 0; j < 3; ++j){
            pf("Enter number of cell [%d,%d]:", i+1, j+1);
            sf("%f",&arr[i][j]);

            sum[j]+=arr[i][j];
        }
    }

    pf("Average of each row is: ");

    for (int i = 0; i < 3; ++i) {
        pf("%f ", sum[i]/3.0);
    }

    pf("\n");
}
