// File Intro/SimpleExpr.java
// Java representation of expressions as in lecture 1
// sestoft@itu.dk * 2010-08-29
// File extended and modified by students frgm & mhsi for Assignment01. More specifically exercise 1.4 from PLC.

import java.util.Map;
import java.util.HashMap;

abstract class Expr { 
  abstract public int eval(Map<String,Integer> env);
  abstract public String fmt();
  abstract public String fmt2(Map<String,Integer> env);
  abstract public Expr simplify();
}

class CstI extends Expr { 
  protected final int i;

  public CstI(int i) { 
    this.i = i; 
  }

  public int eval(Map<String,Integer> env) {
    return i;
  } 

  public String fmt() {
    return ""+i;
  }

  public String fmt2(Map<String,Integer> env) {
    return ""+i;
  }
  public Expr simplify() {
    return this;
  }
}

class Var extends Expr { 
  protected final String name;

  public Var(String name) { 
    this.name = name; 
  }

  public int eval(Map<String,Integer> env) {
    return env.get(name);
  } 

  public String fmt() {
    return name;
  } 

  public String fmt2(Map<String,Integer> env) {
    return ""+env.get(name);
  }
  public Expr simplify() {
    return this;
  }
}

class Prim extends Expr { 
  protected final String oper;
  protected final Expr e1, e2;

  public Prim(String oper, Expr e1, Expr e2) { 
    this.oper = oper; this.e1 = e1; this.e2 = e2;
  }

  public int eval(Map<String,Integer> env) {
    switch (oper) {
      case "+":
        return e1.eval(env) + e2.eval(env);
      case "*":
        return e1.eval(env) * e2.eval(env);
      case "-":
        return e1.eval(env) - e2.eval(env);
      default:
        throw new RuntimeException("unknown primitive");
    }
  }

  public String fmt() {
    return "(" + e1.fmt() + oper + e2.fmt() + ")";
  } 

  public String fmt2(Map<String,Integer> env) {
    return "(" + e1.fmt2(env) + oper + e2.fmt2(env) + ")";
  } 
  public Expr simplify() {
    Expr newE1 = e1.simplify();
    Expr newE2 = e2.simplify();
    boolean e1IsCst = newE1 instanceof CstI;
    boolean e2IsCst = newE2 instanceof CstI;
    int e1v = 0;
    int e2v = 0;
    if (e1IsCst) e1v = newE1.eval(new HashMap());
    if (e2IsCst) e2v = newE2.eval(new HashMap());
    switch (oper) {
      case "+":
        if (e1IsCst && e1v == 0) return newE2;
        if (e2IsCst && e2v == 0) return newE1;
      break;
      case "*":
        if ((e1IsCst && e1v == 0) || (e2IsCst && e2v == 0)) return new CstI(0);
        if (e1IsCst && e1v == 1) return newE2;
        if (e2IsCst && e2v == 1) return newE1;
      break;
      case "-":
        if (e2IsCst && e2v == 0) return newE1;
        if (e1IsCst && e2IsCst && e2v == e1v) return new CstI(0);
      default:
        throw new RuntimeException("unknown primitive");
    }
    return this;
  }
}

public class SimpleExpr {
  public static void main(String[] args) {
    Expr e1 = new CstI(17);
    Expr e2 = new Prim("+", new CstI(3), new Var("a"));
    Expr e3 = new Prim("+", new Prim("*", new Var("b"), new CstI(9)), 
		            new Var("a"));
    Expr e4 = new Prim("*", new Prim("+", new CstI(1), new CstI(0)), new Prim("+", new Var("x"), new CstI(0)));
    Map<String,Integer> env0 = new HashMap<String,Integer>();
    env0.put("a", 3);
    env0.put("c", 78);
    env0.put("baf", 666);

    env0.put("b", 111);

    System.out.println("Env: " + env0.toString());

    System.out.println(e1.fmt() + " = " + e1.fmt2(env0) + " = " + e1.eval(env0));
    System.out.println(e2.fmt() + " = " + e2.fmt2(env0) + " = " + e2.eval(env0));
    System.out.println(e3.fmt() + " = " + e3.fmt2(env0) + " = " + e3.eval(env0));

    // Simplify testing
    System.out.println(e1.fmt() + " simplifies to " + e1.simplify().fmt());
    System.out.println(e2.fmt() + " simplifies to " + e2.simplify().fmt());
    System.out.println(e3.fmt() + " simplifies to " + e3.simplify().fmt());
    System.out.println(e4.fmt() + " simplifies to " + e4.simplify().fmt());
  }
}
