package numerical_analysis;

import java.math.RoundingMode;
import java.text.DecimalFormat;

import net.objecthunter.exp4j.ExpressionBuilder;

public class BisectionMethod {

    public double x;
    public double y;
    String function;
             
    void calculate() {

        String a = null, b = null;
        double Ans1 = 0, Ans2 = 0, Ans3 = 0, Ans4 = 0, Ans5 = 0;
        String ans1 = null, ans2 = null, ans3 = null, ans4 = null, ans5 = null;
        double x = 0, y = 0;
        ExpressionBuilder exp = new ExpressionBuilder(function);
        exp.variable("x");

        DecimalFormat dff = new DecimalFormat("#.###");
        dff.setRoundingMode(RoundingMode.DOWN);
        String number;
        double llll;
        DecimalFormat dff2 = new DecimalFormat("#.###");
        dff.setRoundingMode(RoundingMode.DOWN);
        String number2;
        double llll2;
        for (int n = 0; n <= 10000; n++) {
            a = null;
            double jjjj = 0.001 * n;
            number = dff.format(jjjj);
            llll = Double.parseDouble(number);
            double i = llll;
            double jjjj2 = i + 0.001;
            number2 = dff2.format(jjjj2);
            llll2 = Double.parseDouble(number2);
            double j = llll2;
            x = i;
            LimitCalculator lim = new LimitCalculator(x, exp.build());
            ans1 = lim.evalLimit();
            Ans1 = Double.valueOf(ans1);
            if (Ans1 > 0.000000000000001) {
                a = "+";
            } else {
                a = "-";
            }
            y = j;

            LimitCalculator lim2 = new LimitCalculator(y, exp.build());
            ans2 = lim2.evalLimit();
            Ans2 = Double.valueOf(ans2);
            if (Ans2 > 0.000000000000001) {
                b = "+";

            } else {
                b = "-";
            }
            if (!a.equals(b)) {
                break;
            }
        }
        for (int i = 0; i < 100; i++) {
            double mid;
            mid = (x + y) / 2;
            LimitCalculator lim3 = new LimitCalculator(mid, exp.build());
            ans3 = lim3.evalLimit();
            Ans3 = Double.valueOf(ans3);
            if (Ans3 > 0.000000000000001) {
                y = mid;
            } else {
                x = mid;
            }

            if (x == y) {

                break;
            }
        }
        x *= 100000;
        x = (int) x;
        x /= 100000;
        y *= 100000;
        y = (int) y;
        y /= 100000;
        this.x = x;
        this.y = y;
        //System.out.println(x);
        //System.out.println(y);

    }

}
