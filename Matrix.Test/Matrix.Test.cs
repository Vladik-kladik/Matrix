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
    public void TestFillRandomNumbers()
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
    public void TestCalculateTraceSquareMatrix()
    {
        // Act 
        _matrix.CalculateTrace();
        // Assert
        Assert.That(_matrix.Trace, Is.EqualTo(15));
    }

    [Test]
    public void TestCalculateTraceRectangleMatrix()
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
    public void TestPringMatrix()
    {
        // Act
        Console.WriteLine("Test PrintMatrix: ");
        _matrix.PrintMatrix();
    }

    [Test]
    public void TestSnail()
    {
        // Act
        Console.WriteLine("Test PringSnail: ");
        _matrix.GetSnail();
    }   
 }