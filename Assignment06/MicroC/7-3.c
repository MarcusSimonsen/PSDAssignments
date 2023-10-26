void main() {
    // 7.3 i
    int arr[4];
    arr[0] = 7;
    arr[1] = 9;
    arr[2] = 13;
    arr[3] = 8;

    int sum;
    sum = 0;
    arrsum(4, arr, &sum);
    print sum;

    // 7.3 ii
    int arr2[20];
    squares(20, arr2);

    int sum2;
    sum2 = 0;
    arrsum(20, arr2, &sum2);
    print sum2;

    // 7.3 iii
    int arr3[7];
    arr3[0] = 1;
    arr3[1] = 2;
    arr3[2] = 1;
    arr3[3] = 1;
    arr3[4] = 1;
    arr3[5] = 2;
    arr3[6] = 0;

    int freq[4];
    freq[0] = 0;
    freq[1] = 0;
    freq[2] = 0;
    freq[3] = 0;

    histogram(7, arr3, 3, freq);

    printarr(4, freq);
}

// 7.3 i
void arrsum(int n, int arr[], int *sump) {
    int i;
    i = 0; 
    while (n > i) {
        *sump = *sump + arr[i];
        i = i + 1;
    }
}

// 7.3 ii
void squares(int n, int arr[]) {
    int i;
    i = 0; 
    while (n > i) {
        arr[i] = (i+1) * (i+1);
        i = i + 1;
    }
}

// 7.3 iii
void histogram(int n, int ns[], int max, int freq[]) {
    int i;
    i = 0; 
    while (n > i) {
        freq[ns[i]] = freq[ns[i]] + 1;
        i = i + 1;
    }
}

// Helper method to print an array
void printarr(int n, int arr[]) {
    int i;
    i = 0;
    while (i < n) {
        print arr[i];
        i = i + 1;
    }
}
