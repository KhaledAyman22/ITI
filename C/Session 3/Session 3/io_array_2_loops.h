int IOArray2Loops() {
    pf("Task 1:\n");

    int arr[5];

    for (int i = 0; i < 5; ++i) {
        pf("Enter number %d/5:", i+1);
        sf("%d",&arr[i]);
    }

    pf("Your numbers are: ");

    for (int i = 0; i < 5; ++i) {
        pf("%d ", arr[i]);
    }

    pf("\n");
}
