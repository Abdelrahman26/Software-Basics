package numerical_analysis;

import java.text.DecimalFormat;
import java.math.RoundingMode;

public class NumericalErrors {

    double function;
    double true_value;
    double approx_value;
    String rounding_off;
    String truncation;
    String absolute;
    String relative;
    String percentage;
    
    void set_data() {
        calculate_rounding_off();
        calculate_truncation();
        calculate_absolute();
        calculate_relative();
        calculate_percentage();
    }

    void calculate_rounding_off() {
        DecimalFormat df = new DecimalFormat("#.##");
        rounding_off = df.format(function);

    }

    void calculate_truncation() {
        DecimalFormat df = new DecimalFormat("#.##");
        df.setRoundingMode(RoundingMode.DOWN);
        truncation = df.format(function);

    }

    void calculate_absolute() {
        DecimalFormat df = new DecimalFormat("#.#######");
        double absolute1 = Math.abs(true_value - approx_value);
        absolute = df.format(absolute1);
    }

    void calculate_relative() {
        DecimalFormat df = new DecimalFormat("#.#######");
        double absolute1 = Math.abs(true_value - approx_value);
        double relative1 = absolute1 / true_value;
        relative = df.format(relative1);

    }

    void calculate_percentage() {
        DecimalFormat df = new DecimalFormat("#.###");
        df.setRoundingMode(RoundingMode.DOWN);
        double absolute1 = true_value - approx_value;
        double relative1 = absolute1 / true_value;
        double percentage1 = (relative1 * 100);
        percentage = df.format(percentage1) + "%";
    }

    public String toString() {
        return "rounding-off = " + this.rounding_off + "\ntruncation = " + this.truncation + "\nabsolute = " + this.absolute + "\nrelative = " + this.relative
                + "\npercentage = " + this.percentage;
    }

}
