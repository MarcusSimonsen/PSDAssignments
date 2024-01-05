void main() {
  int i;
  i = -1;
  switch (1+1) {
    case 0:
      { i = 0; }
    case 1:
      { i = 1; }
    case 2:
      { i = 2; }
    case 3:
      { i = 3; }
  }
  print i;
}