package numerical_analysis;

public class FloatNumber {

    double mantessa;
    int power;

    public FloatNumber(String s) {
        String[] splited = s.split("e");
        mantessa = Double.parseDouble(splited[0]);
        power = Integer.parseInt(splited[1]);
        regulate();
    }

    public FloatNumber() {
        mantessa = 0.1;
        power = Integer.MIN_VALUE;
    }

    private void reduceTo4Digits() {
        mantessa = ((double) ((int) (mantessa * 10000))) / 10000;
    }

    public void regulate() {
        reduceTo4Digits();
        while (Math.abs(mantessa) > 1) {
            mantessa /= 10;
            power++;
        }
        while (Math.abs(mantessa) < 0.1) {
            mantessa *= 10;
            power--;
        }
        reduceTo4Digits();
    }

    public void regulateToPower(int n) {
        reduceTo4Digits();
        if (n == power) {
            return;
        }
        while (n > power) {
            power++;
            mantessa /= 10;
        }
        while (power > n) {
            power--;
            mantessa *= 10;
        }
        reduceTo4Digits();
    }

    String stringize() {
        regulate();

        char arr[] = new char[6];
        String s = new String("" + Math.abs(mantessa));
        int i;
        for (i = 0; i < 6 && i < s.length(); ++i) {
            arr[i] = s.charAt(i);
        }

        for (i = i; i < 6; ++i) {
            arr[i] = '0';
        }
        s = new String(arr);
        if (mantessa >= 0) {
            return new String(s + "e" + power);
        } else {
            return new String("-" + s + "e" + power);
        }
    }


    /* Operations on Floating-points Numers */
    public static String addFloatNumbers(String s1, String s2) {
        FloatNumber x = new FloatNumber(s1);
        FloatNumber y = new FloatNumber(s2);
        FloatNumber ans = new FloatNumber();

        if (x.power > y.power) {
            y.regulateToPower(x.power);
        } else {
            x.regulateToPower(y.power);
        }
        ans.power = x.power;
        ans.mantessa = x.mantessa + y.mantessa;
        return ans.stringize();
    }

    public static String subtractFloatNumbers(String s1, String s2) {
        FloatNumber x = new FloatNumber(s1);
        FloatNumber y = new FloatNumber(s2);
        FloatNumber ans = new FloatNumber();

        if (x.power > y.power) {
            y.regulateToPower(x.power);
        } else if (x.power < y.power) {
            x.regulateToPower(y.power);
        }
        ans.power = x.power;
        ans.mantessa = x.mantessa - y.mantessa;
        return ans.stringize();
    }

    public static String multiplyFloatNumbers(String s1, String s2) {
        FloatNumber x = new FloatNumber(s1);
        FloatNumber y = new FloatNumber(s2);
        FloatNumber ans = new FloatNumber();

        ans.power = x.power + y.power;
        ans.mantessa = x.mantessa * y.mantessa;
        return ans.stringize();
    }

    public static String divideFloatNumbers(String s1, String s2) {
        FloatNumber x = new FloatNumber(s1);
        FloatNumber y = new FloatNumber(s2);
        FloatNumber ans = new FloatNumber();

        ans.power = x.power - y.power;
        ans.mantessa = x.mantessa / y.mantessa;
        return ans.stringize();
    }

}
