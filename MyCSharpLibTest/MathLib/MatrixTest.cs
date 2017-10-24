using System.Collections;
using System.Collections.Generic;
using Librafka.MathLib;
using Xunit;

namespace MyCSharpLibTest.MathLib {
  public class MatrixTest {
    class MatrixTestData : IEnumerable<object[]> {
      private readonly List<object[]> _testData;

      public MatrixTestData() {
        _testData = new List<object[]>();
        _testData.Add(new object[] {new Matrix(1, 0, 0, 0), 1.0});
        _testData.Add(new object[] {Matrix.Zero(1, 2), 0.0});
      }

      public IEnumerator<object[]> GetEnumerator() => _testData.GetEnumerator();

      IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [Theory]
    [ClassData(typeof(MatrixTestData))]
    public void MaxAbsoluteValueTest(Matrix m, double ans) => Assert.Equal(ans, m.MaxAbsoluteValue);
  }
}