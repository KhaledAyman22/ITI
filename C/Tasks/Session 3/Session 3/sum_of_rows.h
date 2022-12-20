int SumofRows() {
    pf("Task 3:\n");

    int arr[3][3], sum[3]={0};

    for (int i = 0; i < 3; ++i) {
        for (int j = 0; j < 3; ++j){
            pf("Enter number of cell [%d,%d]:", i+1, j+1);
            sf("%d",&arr[i][j]);

            sum[i]+=arr[i][j];
        }
    }

    pf("Sum of each row is: ");

    for (int i = 0; i < 3; ++i) {
        pf("%d ", sum[i]);
    }

    pf("\n");
}
