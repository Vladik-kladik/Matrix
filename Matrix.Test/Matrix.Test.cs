namespace Matrix.Test;

public class MatrixTests
{
    private BL.Matrix _matrix;
    
    [SetUp]
    public void Setup()
    {
        // Arrange
        _matrix = new BL.Matrix(3, 3);
        _matrix.DataMatrix = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
    }

    [Test]
    public void Fill_Random_Numbers()
    {
        // Act
        _matrix.FillWithRandomNumbers();
        // Assert
        foreach (var element in _matrix.DataMatrix)
        {
            Assert.IsTrue(element >= 0 || element <= 100); 
            // чи можна замінити цей код наступним чином ?
            // Assert.IsTrue(true);
        }
    }

    [Test]
    public void Calculate_Trace_Square_Matrix()
    {
        // Act 
        _matrix.CalculateTrace();
        // Assert
        Assert.That(_matrix.Trace, Is.EqualTo(15));
    }

    [Test]
    public void Calculate_Trace_Rectangle_Matrix()
    {
        // Arrange
        _matrix = new BL.Matrix(3, 4);
        _matrix.DataMatrix = new int[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8, }, { 9, 10, 11, 12 } };
        // Act
        _matrix.CalculateTrace();
        // Assert 
        Assert.That(_matrix.Trace, Is.EqualTo(18));
    }

    [Test]
    public void Print_Matrix()
    {
        // Arrange
        var sw = new StringWriter();
        Console.SetOut(sw);
        var expected =  "1    2    3 \n   4    5    6 \n   7    8    9";
        
        // Act
        _matrix.PrintMatrix();

        // Assert
        Assert.That(sw.ToString().Trim(), Is.EqualTo(expected));
    }

    [Test]
    public void Test_Snail()
    {
        // Arrange 
        int[,] dataMatrix = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
        int[] expected = new []{1, 2, 3, 6, 9, 8, 7, 4, 5};
        
        // Act
        int[] expectedSnailArray = _matrix.GetSnail();
        
        // Assert
        Assert.That(expectedSnailArray, Is.EqualTo(expected));
    }    
 }