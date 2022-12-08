package numerical_analysis;

import java.util.ArrayList;

public class InterpolationMethod {

    static ArrayList<Double> x = new ArrayList<Double>();
    static ArrayList<Double> y = new ArrayList<Double>();

    String array_x, array_y, resu;

    int number, column, row;

    static ArrayList<Double> convert = new ArrayList<Double>();// ArrayList to storage Double numbers

    void calculate() {

        int n = number;// 6 represents number of x&y elements;

        //String test    = "5.00 , 10.00 , 15.00 , 20.00 , 25.00 , 30.00";
        convert.clear();
        converToDouble(array_x);
        for (int i = 0; i < convert.size(); i++) {
            x.add(convert.get(i));
        }

        //String test2    = "9962.00 , 9848.00 , 9659.00 , 9397.00 , 9063.00 , 8660.00";
        convert.clear();
        converToDouble(array_y);

        for (int i = 0; i < convert.size(); i++) {
            y.add(convert.get(i));
        }

        int c, r;

        c = column;//4

        r = row;//1

        if (c <= 0 || c >= n) {
            System.out.println("Invalid");
            System.exit(0);
        }
        double q = For_ward(c, r);
        this.resu = "The result is : " + q;
        System.out.println("The result is : " + q);
    }

    static double For_ward(int degree, int value) {
        if (degree == 1) {
            return (y.get(value) - y.get(value - 1));
        }
        int p1 = degree;
        int p2 = value;
        double a = For_ward(--p1, ++value);
        double b = For_ward(--degree, p2);
        return a - b;
    }

    static double[] convert(String x) {

        double[] ss = null;

        return ss;
    }

    static void converToDouble(String test) {
        String[] result = test.split(",");
        for (int i = 0; i < result.length; i++) {
            double value = Double.parseDouble(result[i]);
            convert.add(value);
        }
    }
}
