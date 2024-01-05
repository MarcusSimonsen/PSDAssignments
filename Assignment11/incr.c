void main() {
    int arr[3];
    arr[0] = 0;
    arr[1] = 1;
    arr[2] = 2;

    int i;
    i = -1;
    while (i < 2) {
        ++arr[++i];
    }

    i = 0;
    while (i < 3) {
        print i;
        print arr[i];
        println;
        i = i + 1;
    }
}
