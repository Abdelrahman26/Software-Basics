package numerical_analysis;

import java.math.RoundingMode;
import java.text.DecimalFormat;

import net.objecthunter.exp4j.Expression;

public class LimitCalculator {

    private final double x;
    private final Expression op;
    private final int PRECISION = 7;
    private final double ABS_SCRAP = 0.1;
    private DecimalFormat d = new DecimalFormat("#.#######");

    public LimitCalculator(double x, Expression op) {
        if (op == null) {
            throw new IllegalArgumentException();
        }
        this.x = x;
        this.op = op;
        d.setRoundingMode(RoundingMode.CEILING);
    }

    public double leftLimit() {
        double round = x - 0.1;
        Double eval = null;
        for (int i = 1; i != PRECISION; i++) {
            try {
                eval = op.setVariable("x", round).evaluate();
                round = x - (0.1 / Math.pow(10, i));
            } catch (Exception e) {
                break;
            }
        }
        return eval;
    }

    public double rightLimit() {
        double round = x + 0.1;
        Double eval = null;
        for (int i = 1; i != PRECISION; i++) {
            try {
                eval = op.setVariable("x", round).evaluate();
                round = x + (0.1 / Math.pow(10, i));
            } catch (Exception e) {
                break;
            }
        }

        return eval;
    }

    public boolean exists() {
        return (Math.abs(leftLimit()) - Math.abs(rightLimit()) < ABS_SCRAP);
    }

    public String evalLimit() {
        if (!exists()) {
            throw new IllegalStateException("Limit does not exist");
        }
        double left = leftLimit();
        double right = rightLimit();
        return d.format((left + right) / 2);
    }

}
