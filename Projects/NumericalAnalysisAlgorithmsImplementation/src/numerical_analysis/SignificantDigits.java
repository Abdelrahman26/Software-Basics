package numerical_analysis;

import java.util.ArrayList;

public class SignificantDigits {

    ArrayList findSignificantDigits(String n) {

        ArrayList<Integer> significant_digits = new ArrayList<Integer>();

        int length = n.length();
        int decimal_point_index = 0, left_most_significant_digit = -1, right_most_significant_digit = -1;

        for (int i = 0; i < length; i++) {
            if (n.charAt(i) == '.') {
                decimal_point_index = i;
            } else if (n.charAt(i) > '0' && left_most_significant_digit == -1) {
                left_most_significant_digit = i;
            } else if (n.charAt(i) > '0') {
                right_most_significant_digit = i;
            }
        }

        if (left_most_significant_digit == -1) {
            return significant_digits;
        }

        if (decimal_point_index == length - 1) {
            decimal_point_index = 0;
        }

        for (int i = 0; i < length; i++) {
            if (n.charAt(i) == '.') {
                continue;
            }

            if (n.charAt(i) > '0') {
                significant_digits.add(n.charAt(i) - '0');
                continue;
            }

            if (i < left_most_significant_digit) {
                continue;
            }

            if (decimal_point_index != 0 || i < right_most_significant_digit) {
                significant_digits.add(n.charAt(i) - '0');
            }
        }

        return significant_digits;
    }

}
