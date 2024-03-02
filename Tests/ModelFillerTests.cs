using DataAccess;
using MongoDB.Bson;
using ParserGradusov;
using Xunit;

namespace Tests;

public class ModelFillerTests
{
    private readonly SqlModelFill _sqlModelFill = new();
    private readonly NoSqlModelFill _noSqlModelFill = new();
    
    [Fact]
    public void SqlModelFiller_Should_ReturnCorrectModel_WhenItemsLengthIs5()
    {
        //Arrange
        string[] items =
        [
            "1","Dmitrii Zaitsev","Adress","Period","45.00"
        ];
        //Act
        var result = (FullLineUser)_sqlModelFill.FillModel(items);
        //Assert
        Assert.NotNull(result);
        Assert.Equal(1,result.Id);
        Assert.Equal("Dmitrii Zaitsev",result.FIO);
        Assert.Equal("Adress",result.Adress);
        Assert.Equal("Period",result.Period);
        Assert.Equal(45,result.Sum);
        Assert.Null(result.GasId);
        Assert.Null(result.GasMeterReads);
    }

    [Fact]
    public void SqlModelFiller_Should_ReturnCorrectModel_WhenItemsLengthIs7()
    {
        //Arrange
        string[] items =
        [
            "1","Dmitrii Zaitsev","Adress","Period","45.00","319319591 SVG","2521.00"
        ];
        //Act
        var result = (FullLineUser)_sqlModelFill.FillModel(items);
        //Assert
        Assert.NotNull(result);
        Assert.Equal(1,result.Id);
        Assert.Equal("Dmitrii Zaitsev",result.FIO);
        Assert.Equal("Adress",result.Adress);
        Assert.Equal("Period",result.Period);
        Assert.Equal(45,result.Sum);
        Assert.Equal("319319591 SVG",result.GasId);
        Assert.Equal(2521,result.GasMeterReads);
    }
    [Fact]
    public void NoSqlModelFiller_Should_ReturnCorrectModel_WhenItemsLengthIs5()
    {
        //Arrange
        string[] items =
        {
            "1","Dmitrii Zaitsev","Adress","Period","45.00"
        };
        //Act
        var result = (BsonDocument)_noSqlModelFill.FillModel(items);
        //Assert
        Assert.NotNull(result);
        Assert.Equal("1",result["Id"].AsString);
        Assert.Equal("Dmitrii Zaitsev",result["FIO"].AsString);
        Assert.Equal("Adress",result["Address"].AsString);
        Assert.Equal("Period",result["Period"].AsString);
        Assert.Equal("45.00",result["Sum"].AsString);
        Assert.Equal("",result["GasId"].AsString);
        Assert.Equal("",result["GasMeterReads"].AsString);
    }
    [Fact]
    public void NoSqlModelFiller_Should_ReturnCorrectModel_WhenItemsLengthIs7()
    {
        //Arrange
        string[] items =
        {
            "1","Dmitrii Zaitsev","Adress","Period","45.00","319319591 SVG","2521.00"
        };
        //Act
        var result = (BsonDocument)_noSqlModelFill.FillModel(items);
        //Assert
        Assert.NotNull(result);
        Assert.Equal("1",result["Id"].AsString);
        Assert.Equal("Dmitrii Zaitsev",result["FIO"].AsString);
        Assert.Equal("Adress",result["Address"].AsString);
        Assert.Equal("Period",result["Period"].AsString);
        Assert.Equal("45.00",result["Sum"].AsString);
        Assert.Equal("319319591 SVG",result["GasId"].AsString);
        Assert.Equal("2521.00",result["GasMeterReads"].AsString);
    }
}