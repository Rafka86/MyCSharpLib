namespace Librafka.MathLib.Algorithm {
  public abstract class Ode {
    public double StartTime { get; protected set; }
    public double EndTime { get; protected set; }
    public Vector InitialState { get; }

    protected Ode(Vector initialState) {
      InitialState = initialState;
    }

    public abstract Vector Feval(double t, Vector x);
  }
}