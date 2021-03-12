using System;
using System.IO;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using MyLib;

namespace MyLibTests
{
    public class TestBase {
        public TestBase(ITestOutputHelper output)
        {
            var converter = new Converter(output);
            Console.SetOut(converter);
        }
    }

    class Converter : TextWriter
    {
        private readonly ITestOutputHelper _output;

        private readonly StringBuilder stringBuilder;

        public Converter(ITestOutputHelper output)
        {
            _output = output;
            stringBuilder = new StringBuilder();
        }
        public override Encoding Encoding
        {
            get { return Encoding.Unicode; }
        }

        public override void Write(char c)
        {
            if ('\n'.Equals(c)) {
                this._output.WriteLine(
                    stringBuilder.ToString().TrimEnd('\r'));
                stringBuilder.Clear();
            } else {
                stringBuilder.Append(c);
            }
            
        }
    }
}