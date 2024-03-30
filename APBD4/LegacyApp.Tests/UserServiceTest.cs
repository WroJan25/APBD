using System;
using JetBrains.Annotations;
using LegacyApp;
using Xunit;


namespace LegacyApp.Tests;

[TestSubject(typeof(UserService))]
public class UserServiceTest
{

    [Fact]
    public void AddUser_Should_Return_False_When_FirstName_Is_Missing()
    {
        //Arrange 
        var userService = new UserService();
        //Act
        var addResult = userService.AddUser("", "Doe", "johnDone@gmail.com", DateTime.Parse("1988 12 12"), 1);
        //Assert
        Assert.False(addResult);
        //Assert.Equal(false,addResult);
    }
    
    [Fact]
    public void AddUser_Should_Return_False_When_LastName_Is_Missing()
    {
        //Arrange 
        var userService = new UserService();
        //Act
        var addResult = userService.AddUser("John", "", "johnDone@gmail.com", DateTime.Parse("1988 12 12"), 1);
        //Assert
        Assert.False(addResult);
        //Assert.Equal(false,addResult);
    }
    [Fact]
    public void AddUser_Should_Return_False_When_Credit_Limit_Is_Too_Low()
    {
        //Arrange 
        var userService = new UserService();
        //Act
        var addResult = userService.AddUser("Jan", "Kowalski", "kowalski@wp.pl", DateTime.Parse("1988 12 12"), 1);
        //Assert
        Assert.False(addResult);
        //Assert.Equal(false,addResult);
    }
    [Fact]
    public void AddUser_Should_Return_False_When_Client_Is_NOT_OF_AGE()
    {
        //Arrange 
        var userService = new UserService();
        //Act
        var addResult = userService.AddUser("John", "Doe", "kowalski@wp.pl", DateTime.Parse("2003 12 12"), 3);
        //Assert
        Assert.False(addResult);
        //Assert.Equal(false,addResult);
    }
    
    [Fact]
    public void AddUser_Should_Return_True_When_Client_Is_OF_AGE()
    {
        //Arrange 
        var userService = new UserService();
        //Act
        var addResult = userService.AddUser("John", "Doe", "kowalski@wp.pl", DateTime.Parse("2003 02 02"), 3);
        //Assert
        Assert.True(addResult);
        //Assert.Equal(false,addResult);
    }
    [Fact]
    public void AddUser_Should_Return_False_When_EMAIL_Is_Valid()
    {
        //Arrange 
        var userService = new UserService();
        //Act
        var addResult = userService.AddUser("John", "Doe", "kowalskiwppl", DateTime.Parse("2020 12 12"), 3);
        //Assert
        Assert.False(addResult);
        //Assert.Equal(false,addResult);
    }
    

    
    
  

    
    
    
    
}