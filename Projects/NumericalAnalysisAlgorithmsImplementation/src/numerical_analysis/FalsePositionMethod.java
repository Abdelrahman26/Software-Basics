package numerical_analysis;

import tokenizer.AbstractTreeBuilder;
import tokenizer.TokenizerException;

public class FalsePositionMethod {

    FalsePositionMethod() {
    }

    ;
    
        public String findRootByFalsePositionMethod(String equation, String lowerBound, String upperBound) throws TokenizerException {
        AbstractTreeBuilder equationTree = new AbstractTreeBuilder(equation);

        double EPS = 1E-7;
        double x0 = Double.parseDouble(lowerBound);
        double x1 = Double.parseDouble(upperBound);

        while (true) {
            double fx0 = equationTree.getTree().getNumericResult(x0);
            double fx1 = equationTree.getTree().getNumericResult(x1);

            double x2 = x0 - ((x1 - x0) / (fx1 - fx0)) * fx0;
            double fx2 = equationTree.getTree().getNumericResult(x2);

            if (Math.abs(x2 - x1) <= EPS) {
                break;
            }

            if (fx0 * fx2 < 0) {
                x1 = x2;
            } else if (fx1 * fx2 < 0) {
                x0 = x1;
                x1 = x2;
            } else {
                return "Impossible to find the root of this function using False-Position Method.";
            }
        }
        return "Root = " + String.format("%.7f", x1);
    }
}
