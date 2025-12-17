using NUnit.Framework;

using System;
using System.Collections.Generic;

namespace TestApp.UnitTests;

public class ExceptionTests
{
    private Exceptions _exceptions = null!;

    [SetUp]
    public void SetUp()
    {
        this._exceptions = new();
    }

    // TODO: finish test
    [Test]
    public void Test_Reverse_ValidString_ReturnsReversedString()
    {
        // Arrange
        string input = "abc";
        string expected = "cba";

        // Act
        string result = _exceptions.ArgumentNullReverse(input);
        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    // TODO: finish test
    [Test]
    public void Test_Reverse_NullString_ThrowsArgumentNullException()
    {
        // Arrange
        string input = null!;
        string expectedMessage = "String cannot be null.";
        // Act & Assert
        Assert.That(() => this._exceptions.ArgumentNullReverse(input), Throws.ArgumentNullException);
        //addition testing of error message
        try
        {
            //Act -> throw exception
            _exceptions.ArgumentNullReverse(input);
        }
        catch (ArgumentException ex)
        {
            Assert.That(ex.Message, Does.Contain(expectedMessage));
        }
    }

    [Test]
    public void Test_CalculateDiscount_ValidInput_ReturnsDiscountedPrice()
    {
        // Arrange
        decimal totalPrice = 100;
        decimal discount = 10;
        decimal expected = 90;
        // Act
        decimal result = _exceptions.ArgumentCalculateDiscount(totalPrice, discount);
        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    // TODO: finish test
    [Test]
    public void Test_CalculateDiscount_NegativeDiscount_ThrowsArgumentException()
    {
        // Arrange
        decimal totalPrice = 100;
        decimal discount = -5;
        // Act & Assert
        Assert.That(() => this._exceptions.ArgumentCalculateDiscount(totalPrice, discount), Throws.ArgumentException);
    }

    // TODO: finish test
    [Test]
    public void Test_CalculateDiscount_DiscountOver100_ThrowsArgumentException()
    {
        // Arrange
        decimal totalPrice = 100.0m;
        decimal discount = 110.0m;

        // Act & Assert
        Assert.That(() => this._exceptions.ArgumentCalculateDiscount(totalPrice, discount), Throws.ArgumentException);
    }

    [Test]
    public void Test_GetElement_ValidIndex_ReturnsElement()
    {
        // Arrange
        int[] array = { 10, 20, 30, 40, 50 };
        int index = 2;
        int expected = 30;

        // Act
        int resut = _exceptions.IndexOutOfRangeGetElement(array, index);

        // Assert
        Assert.That(resut, Is.EqualTo(expected));

    }

    // TODO: finish test
    [Test]
    public void Test_GetElement_IndexLessThanZero_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] array = { 10, 20, 30, 40, 50 };
        int index = -2;

        // Act & Assert
        Assert.That(() => this._exceptions.IndexOutOfRangeGetElement(array, index), Throws.InstanceOf<IndexOutOfRangeException>());
    }

    // TODO: finish test
    [Test]
    public void Test_GetElement_IndexEqualToArrayLength_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] array = { 10, 20, 30, 40, 50 };
        int index = array.Length;

        // Act & Assert
        Assert.That(() => this._exceptions.IndexOutOfRangeGetElement(array, index), Throws.InstanceOf<IndexOutOfRangeException>());

    }

    [Test]
    public void Test_GetElement_IndexGreaterThanArrayLength_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] array = { 10, 20, 30, 40, 50 };
        int index = array.Length+3;

        // Act & Assert
        Assert.That(() => this._exceptions.IndexOutOfRangeGetElement(array, index), Throws.InstanceOf<IndexOutOfRangeException>());

    }

    [Test]
    public void Test_PerformSecureOperation_UserLoggedIn_ReturnsUserLoggedInMessage()
    {
        //Arrange
        bool isLoggedIn = true;
        //Act 
        string result = _exceptions.InvalidOperationPerformSecureOperation(isLoggedIn);
        Assert.That(result, Is.EqualTo("User logged in."));
    }

    [Test]
    public void Test_PerformSecureOperation_UserNotLoggedIn_ThrowsInvalidOperationException()
    {
        //Arrange
        bool isLoggedIn = false;
        //Act 
        
        Assert.That(()=> this._exceptions.InvalidOperationPerformSecureOperation(isLoggedIn),Throws.InstanceOf<InvalidOperationException>());
    }

    [Test]
    public void Test_ParseInt_ValidInput_ReturnsParsedInteger()
    {
        // Arrange
        string input = "5";

        // Act
        int result = _exceptions.FormatExceptionParseInt(input);
        // Assert
        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void Test_ParseInt_InvalidInput_ThrowsFormatException()
    {
        // Arrange
        string input = "abc";

        // Act & Assert
        Assert.That(()=>this._exceptions.FormatExceptionParseInt(input), Throws.InstanceOf<FormatException>());
    }

    [Test]
    public void Test_FindValueByKey_KeyExistsInDictionary_ReturnsValue()
    {
        //Arrange 
        Dictionary<string, int> dInput = new Dictionary<string, int>();
        dInput["first"]=1;
        dInput.Add("second", 2);
        dInput.Add("third", 3);
        string key = "second";
        //Act
        int result = _exceptions.KeyNotFoundFindValueByKey(dInput, key);
        //Assert
        Assert.That(result, Is.EqualTo((int)2));

    }

    [Test]
    public void Test_FindValueByKey_KeyDoesNotExistInDictionary_ThrowsKeyNotFoundException()
    {
        //Arrange 
        Dictionary<string, int> dInput = new Dictionary<string, int>();
        dInput.Add("first", 1);
        dInput.Add("second", 2);
        dInput.Add("third", 3);
        string key = "tenhth";
        //Act & Assert
        Assert.That(() => this._exceptions.KeyNotFoundFindValueByKey(dInput, key), Throws.InstanceOf<KeyNotFoundException>());
        //Assert.Throws<KeyNotFoundException>(() => this._exceptions.KeyNotFoundFindValueByKey(dInput, key));
        try
        {
            _exceptions.KeyNotFoundFindValueByKey(dInput, key);
        }
        catch (KeyNotFoundException ex)
        {
            Assert.That(ex.Message, Does.Contain("The specified key was not found in the dictionary."));
        }
    }

    [Test]
    public void Test_AddNumbers_NoOverflow_ReturnsSum()
    {
        //Arrange 
        int a = 10;
        int b = 20;
        int expected = 30;
        //Act
        int result = _exceptions.OverflowAddNumbers(a, b);
        //Assert
        Assert.That(expected, Is.EqualTo(result));
    }

    [Test]
    public void Test_AddNumbers_PositiveOverflow_ThrowsOverflowException()
    {
        //Arrange 
        int a = 10;
        int b = int.MaxValue;
        //Act & Assert
        Assert.That(()=>this._exceptions.OverflowAddNumbers(a,b), Throws.InstanceOf<OverflowException>());

    }

    [Test]
    public void Test_AddNumbers_NegativeOverflow_ThrowsOverflowException()
    {
        //Arrange 
        int a = -10;
        int b = int.MinValue;
        //Act & Assert
        Assert.That(() => this._exceptions.OverflowAddNumbers(a, b), Throws.InstanceOf<OverflowException>());

    }

    [Test]
    public void Test_DivideNumbers_ValidDivision_ReturnsQuotient()
    {
        //Arrange 
        int dividend = 10;
        int divisor = 5;
        //Act
        int result = _exceptions.DivideByZeroDivideNumbers(dividend, divisor);
        //Assert
        Assert.That(result, Is.EqualTo(2));

    }

    [Test]
    public void Test_DivideNumbers_DivideByZero_ThrowsDivideByZeroException()
    {
        //Arrange 
        int dividend = 10;
        int divisor = 0;
        //Act & Assert
        Assert.That(() => this._exceptions.DivideByZeroDivideNumbers(dividend, divisor), Throws.InstanceOf<DivideByZeroException>());

    }

    [Test]
    public void Test_SumCollectionElements_ValidCollectionAndIndex_ReturnsSum()
    {
        // Arrange
        int[] collection = new int[] { 1, 2, 3 };
        int idx = 2;
        // Act
        int result = this._exceptions.SumCollectionElements(collection, idx);
        // Assert
        Assert.That(result, Is.EqualTo(6));
    }

    [Test]
    public void Test_SumCollectionElements_NullCollection_ThrowsArgumentNullException()
    {
        // Arrange
        int[] collection = null;
        int idx = 2;
        // Act & Assert
        Assert.That(() => this._exceptions.SumCollectionElements(collection, idx), Throws.InstanceOf<ArgumentNullException>());
    }

    [Test]
    public void Test_SumCollectionElements_IndexOutOfRange_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] collection = new int[] { 1, 2, 3 };
        int idx = collection.Length +3 ;
        // Act & Assert
        Assert.That(() => this._exceptions.SumCollectionElements(collection, idx), Throws.InstanceOf<IndexOutOfRangeException>());
    }

    [Test]
    public void Test_GetElementAsNumber_ValidKey_ReturnsParsedNumber()
    {
        //Arrange 
        Dictionary<string, string> dInput = new Dictionary<string, string>();
        dInput["first"] = "1";
        dInput.Add("second","2");
        dInput.Add("third","3");
        string key = "third";
        //Act
        int result = _exceptions.GetElementAsNumber(dInput, key);
        //Assert
        Assert.That(result, Is.EqualTo((int)3));
    }

    [Test]
    public void Test_GetElementAsNumber_KeyNotFound_ThrowsKeyNotFoundException()
    {
        //Arrange 
        Dictionary<string, string> dInput = new Dictionary<string, string>();
        dInput["first"] = "1";
        dInput.Add("second", "2");
        dInput.Add("third", "3");
        string key = "tenth";
        //Act & Assert
        Assert.That(()=> this._exceptions.GetElementAsNumber(dInput,key), Throws.InstanceOf<KeyNotFoundException>());
    }

    [Test]
    public void Test_GetElementAsNumber_InvalidFormat_ThrowsFormatException()
    {
        //Arrange 
        Dictionary<string, string> dInput = new Dictionary<string, string>();
        dInput["first"] = "first1";
        dInput.Add("second", "2");
        dInput.Add("third", "3");
        string key = "first";
        //Act & Assert
        Assert.That(() => this._exceptions.GetElementAsNumber(dInput, key), Throws.InstanceOf<FormatException>());
    }
}
