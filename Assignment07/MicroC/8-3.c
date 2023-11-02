void main() {
    // Test preinc and predec on integer
    int i;
    i = 3;
    print i; // 3
    ++i;
    print i; // 4
    --i;
    print i; // 3

    // Test preinc and predec on array
    int a[3];
    a[0] = 1;
    a[1] = 2;
    a[2] = 3;
    
    int j;
    j = 0;
    printArray(a, 3); // 1 2 3
    ++a[++j];
    printArray(a, 3); // 1 3 3
    --a[--j];
    printArray(a, 3); // 0 3 3
}

void printArray(int a[], int size) {
    int i;
    i = 0;
    while (i < size) {
        print a[i];
        ++i;
    }
}
