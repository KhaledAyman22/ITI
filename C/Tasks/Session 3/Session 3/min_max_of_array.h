int MinMaxofArray() {
    pf("Task 2:\n");

    int arr[5], max = INT_MIN, min = INT_MAX;

    for (int i = 0; i < 5; ++i) {
        pf("Enter number %d/5:", i+1);
        sf("%d",&arr[i]);

        max = arr[i]>max? arr[i]:max;
        min = arr[i]<min? arr[i]:min;
    }

    pf("Your max is: %i\nYour min is: %i\n", max, min);
}
