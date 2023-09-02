import java.util.Map;
import java.util.HashMap;

abstract class Expr {
    abstract public int eval(Map<String, Integer> env);
    abstract public String toString();
    abstract public Expr simplify();
    abstract public boolean equals(Object o);
}

class CstI extends Expr {
    private final int val;

    public CstI(int val) {
        this.val = val;
    }
    @Override
    public int eval(Map<String, Integer> env) {
        return val;
    }
    @Override
    public String toString() {
        return ""+val;
    }
    @Override
    public Expr simplify() {
        return this;
    }
    @Override
    public boolean equals(Object o) {
        if (o == this)
            return true;
        if (!(o instanceof CstI))
            return false;
        CstI other = (CstI) o;
        Map<String, Integer> emptyEnv = new HashMap<String, Integer>();
        return this.eval(emptyEnv) == other.eval(emptyEnv);
    }
}

class Var extends Expr {
    protected final String name;
    
    public Var(String name) {
        this.name = name;
    }
    @Override
    public int eval(Map<String, Integer> env) {
        return env.get(name);
    }
    @Override
    public String toString() {
        return this.name;
    }
    @Override
    public Expr simplify() {
        return this;
    }
    @Override
    public boolean equals(Object o) {
        if (o == this)
            return true;
        if (!(o instanceof Var))
            return false;
        Var other = (Var) o;
        return name.equals(other.name);
    }

}

abstract class Binop extends Expr {
    protected final Expr e1;
    protected final Expr e2;
    
    protected Binop(Expr e1, Expr e2) {
        this.e1 = e1;
        this.e2 = e2;
    }
}

class Add extends Binop {
    public Add(Expr e1, Expr e2) {
        super(e1, e2);
    }

    @Override
    public int eval(Map<String, Integer> env) {
        return e1.eval(env) + e2.eval(env);
    }
    @Override
    public String toString() {
        return "(" + e1.toString() + " + " + e2.toString() + ")";
    }
    @Override
    public Expr simplify() {
        Expr e1s = e1.simplify();
        Expr e2s = e2.simplify();
        Map<String, Integer> emptyEnv = new HashMap<String, Integer>();
        if (e1s instanceof CstI && e1s.eval(emptyEnv) == 0)
            return e2s;
        if (e2s instanceof CstI && e2s.eval(emptyEnv) == 0)
            return e1s;
        if (e1s instanceof CstI && e2s instanceof CstI)
            return new CstI(new Add(e1s, e2s).eval(emptyEnv));
        return new Add(e1s, e2s);
    }
    @Override
    public boolean equals(Object o) {
        if (o == this)
            return true;
        if (!(o instanceof Add))
            return false;
        Add other = (Add) o;
        return this.e1.equals(other.e1) && this.e2.equals(other.e2);
    }
}

class Sub extends Binop {
    public Sub(Expr e1, Expr e2) {
        super(e1, e2);
    }

    @Override
    public int eval(Map<String, Integer> env) {
        return e1.eval(env) - e2.eval(env);
    }
    @Override
    public String toString() {
        return "(" + e1.toString() + " - " + e2.toString() + ")";
    }
    @Override
    public Expr simplify() {
        Expr e1s = e1.simplify();
        Expr e2s = e2.simplify();
        Map<String, Integer> emptyEnv = new HashMap<String, Integer>();
        if (e2s instanceof CstI && e2s.eval(emptyEnv) == 0)
            return e1s;
        if (e1s.equals(e2s))
            return new CstI(0);
        if (e1s instanceof CstI && e2s instanceof CstI)
            return new CstI(new Sub(e1s, e2s).eval(emptyEnv));
        return new Sub(e1s, e2s);
    }
    @Override
    public boolean equals(Object o) {
        if (o == this)
            return true;
        if (!(o instanceof Sub))
            return false;
        Sub other = (Sub) o;
        return this.e1.equals(other.e1) && this.e2.equals(other.e2);
    }
}

class Mul extends Binop {
    public Mul(Expr e1, Expr e2) {
        super(e1, e2);
    }

    @Override
    public int eval(Map<String, Integer> env) {
        return e1.eval(env) * e2.eval(env);
    }
    @Override
    public String toString() {
        return e1.toString() + " * " + e2.toString();
    }
    @Override
    public Expr simplify() {
        Expr e1s = e1.simplify();
        Expr e2s = e2.simplify();
        Map<String, Integer> emptyEnv = new HashMap<String, Integer>();
        int e1v = 0;
        int e2v = 0;
        if (e1s instanceof CstI) e1v = e1s.eval(emptyEnv);
        if (e2s instanceof CstI) e2v = e2s.eval(emptyEnv);
        if ((e1 instanceof CstI && e1v == 0) || (e2 instanceof CstI && e2v == 0))
            return new CstI(0);
        if (e1v == 1) return e2s;
        if (e2v == 1) return e1s;
        return new Mul(e1s, e2s);
    }
    @Override
    public boolean equals(Object o) {
        if (o == this)
            return true;
        if (!(o instanceof Mul))
            return false;
        Mul other = (Mul) o;
        return this.e1.equals(other.e1) && this.e2.equals(other.e2);
    }
}

public class AExpr {
    public static void main(String[] args) {
        Map<String, Integer> env1 = new HashMap<String, Integer>();
        env1.put("x", 1);
        env1.put("y", 8);
        
        Expr e1 = new CstI(3);
        Expr e2 = new Add(new CstI(1), new CstI(2));
        Expr e3 = new Add(new CstI(1), new CstI(0));
        Expr e4 = new Sub(new Var("x"), new CstI(0));
        Expr e5 = new Sub(new Var("x"), new Var("x"));
        Expr e6 = new Mul(new Add(new CstI(1), new CstI(0)), new Add(new Var("x"), new CstI(0)));
        Expr e7 = new Add(new CstI(1), new Add(new CstI(2), new CstI(3)));
        Expr e8 = new Add(new Var("x"), new Var("y"));
        Expr e9 = new Sub(new Var("y"), new Add(new CstI(-1), new CstI(7)));

        System.out.println("Equations");
        System.out.println(e1);
        System.out.println(e2);
        System.out.println(e3);
        System.out.println(e4);
        System.out.println(e5);
        System.out.println(e6);
        System.out.println(e7);
        System.out.println(e8);
        System.out.println(e9);

        System.out.println("Equations evaluated in environment: " + env1);
        System.out.println(e1.toString() + " => " + e1.eval(env1));
        System.out.println(e2.toString() + " => " + e2.eval(env1));
        System.out.println(e3.toString() + " => " + e3.eval(env1));
        System.out.println(e4.toString() + " => " + e4.eval(env1));
        System.out.println(e5.toString() + " => " + e5.eval(env1));
        System.out.println(e6.toString() + " => " + e6.eval(env1));
        System.out.println(e7.toString() + " => " + e7.eval(env1));
        System.out.println(e8.toString() + " => " + e8.eval(env1));
        System.out.println(e9.toString() + " => " + e9.eval(env1));

        System.out.println("Equations simplified");
        System.out.println(e1.toString() + " => " + e1.simplify());
        System.out.println(e2.toString() + " => " + e2.simplify());
        System.out.println(e3.toString() + " => " + e3.simplify());
        System.out.println(e4.toString() + " => " + e4.simplify());
        System.out.println(e5.toString() + " => " + e5.simplify());
        System.out.println(e6.toString() + " => " + e6.simplify());
        System.out.println(e7.toString() + " => " + e7.simplify());
        System.out.println(e8.toString() + " => " + e8.simplify());
        System.out.println(e9.toString() + " => " + e9.simplify());
    }
}
