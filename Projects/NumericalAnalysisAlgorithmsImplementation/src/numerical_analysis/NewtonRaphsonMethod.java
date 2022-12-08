package numerical_analysis;

import tokenizer.AbstractTreeBuilder;
import tokenizer.TokenizerException;

public class NewtonRaphsonMethod {

    public static String findRootByNewtonRaphsonMethod(String equation, String initial) throws TokenizerException {
        AbstractTreeBuilder equationTree = new AbstractTreeBuilder(equation);

        double EPS = 1E-7;
        double x0 = 0;
        double x1 = Double.parseDouble(initial);

        while (Math.abs(x0 - x1) > EPS) {
            /* Swap */
            double temp = x0;
            x0 = x1;
            x1 = temp;

            double fx = equationTree.getTree().getNumericResult(x0);
            double dfx = equationTree.getTree().getDerivative().getNumericResult(x0);

            if (dfx == 0 || Double.isNaN(fx) || Double.isNaN(dfx)) {
                return "Impossible to find the root of this function using Newton-Raphson Method.";
            }

            x1 = x0 - (fx / dfx);
        }
        return "Root = " + String.format("%.7f", x1);
    }

}
