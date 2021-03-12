using System;
using System.IO;
using System.Text;

namespace MyLib
{
    public class Class1
    {
        public void Foo()
        {
            for (int i = 0; i < 10; i++) {
                StringBuilder sb = new StringBuilder();
                for (int j = 0; j < 10; j++) {
                    sb.Append($"Hello World {j}\n");
                }
                Console.WriteLine(sb.ToString());
            }
        }
    }
}
