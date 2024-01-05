void main() {
  int max;
  max = 5;
  int n;
  n = 10;
  int ns[10];
  ns[0] = 1;
  ns[1] = 2;
  ns[2] = 1;
  ns[3] = 1;
  ns[4] = 4;
  ns[5] = 0;
  ns[6] = 4;
  ns[7] = 4;
  ns[8] = 0;
  ns[9] = 4;

  int freq[5];
  freq[0] = 0;
  freq[1] = 0;
  freq[2] = 0;
  freq[3] = 0;
  freq[4] = 0;
  
  histogram(n, ns, max, freq);

  int i;
  i = 0;
  while (i < max) {
    print freq[i];
    i = i + 1;
  }
  println;
}

void histogram(int n, int ns[], int max, int freq[]) {
  int i;
  i = 0;
  while (i < n) {
    freq[ns[i]] = freq[ns[i]] + 1;
    i = i + 1;
  }
}
