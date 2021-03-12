using System;
using System.IO;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using MyLib;


namespace MyLibTests
{




    public class UnitTest1 : TestBase
    {

        public UnitTest1(ITestOutputHelper output) : base(output) {}

        [Fact]
        public void Test1()
        {
            new Class1().Foo();
        }

        [Fact]
        public void Test2()
        {
            new Class1().Foo();
        }
    }



}
