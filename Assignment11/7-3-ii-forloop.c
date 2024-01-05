void main(int n) {
  int nums[20];
  squares(n, nums);
  int sum;
  sum = 0;
  arrsum(n, nums, &sum);
  print sum;
  println;
}

void squares(int n, int arr[]) {
  int i;
  for (i = 0; i < n; i = i + 1) {
    arr[i] = i * i;
  }
}

void arrsum(int n, int arr[], int *sump)
{
  int i;
  for (i = 0; i < n; i = i + 1)
  {
    *sump = *sump + arr[i];
  }
}
