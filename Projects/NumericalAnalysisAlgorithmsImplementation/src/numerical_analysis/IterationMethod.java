package numerical_analysis;

import net.objecthunter.exp4j.ExpressionBuilder;

public class IterationMethod {

    public double x;
    String function;
    double[] ans;

    void calculate() {

        String formula = this.function;

        double x0 = this.x;
        ans = succiveIteration(formula, x0);

    }

    public static double[] succiveIteration(String formula, double x0) {
        final int MAX_NUMBER_OF_ITERATIONS = 1000000;
        final int MIN_NUMBER_OF_REPETATIONS = 5;
        final int NUMBER_OF_DIGITS_AFTER_FLOATING_POINT = 5;
        final double PRECISION = 0.000001;
        double[] x = new double[MAX_NUMBER_OF_ITERATIONS];
        x[0] = x0;
        ExpressionBuilder exp = new ExpressionBuilder(formula.substring(2));
        exp.variable("x");
        int cntr = 0, k = 1;
        for (int i = 1; ((i < MAX_NUMBER_OF_ITERATIONS) && (cntr < MIN_NUMBER_OF_REPETATIONS)); ++i, k++) {
            LimitCalculator lim = new LimitCalculator(x[i - 1], exp.build());
            x[i] = Double.valueOf(lim.evalLimit());
            if (Math.abs(x[i] - x[i - 1]) < PRECISION) {
                cntr++;
            } else {
                cntr = 1;
            }
        }
        if (cntr < MIN_NUMBER_OF_REPETATIONS) {
            double[] ans = new double[1];
            return ans;
        }
        double[] ans = new double[k];
        for (int i = 0; i < k; ++i) {
            ans[i] = showLimitedDigits(x[i], NUMBER_OF_DIGITS_AFTER_FLOATING_POINT);
        }
        return ans;
    }

    private static double showLimitedDigits(double d, int n) {
        int place = 1;
        for (int i = 0; i < n; ++i) {
            place *= 10;
        }

        d *= place;
        d = (int) d;
        d /= place;

        return d;
    }

}
