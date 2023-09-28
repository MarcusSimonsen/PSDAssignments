public class Exercises {
    public static void main(String[] args) {
        int[] xs = {3, 5, 12};
        int[] ys = {2, 3, 4, 7};

        int[] zs = merge(xs, ys);

        for (int i = 0; i < zs.length; i++) {
            System.out.print(zs[i] + " ");
        }
        System.out.println();
    }
    public static int[] merge(int[] xs, int[] ys) {
        int[] zs = new int[xs.length + ys.length];
        int i = 0, j = 0, k = 0;
        while (i < xs.length && j < ys.length) {
            if (xs[i] < ys[j]) {
                zs[k] = xs[i];
                i++;
            } else {
                zs[k] = ys[j];
                j++;
            }
            k++;
        }
        while (i < xs.length) {
            zs[k] = xs[i];
            i++;
            k++;
        }
        while (j < ys.length) {
            zs[k] = ys[j];
            j++;
            k++;
        }
        return zs;
    }
}
