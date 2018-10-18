using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace AsyncCallbackDelegate

{

    public delegate int MyDelegate(int x);

    public class MyClass

    {

        //A method to be invoke by the delegate

        public int MyMethod(int x)

        {

            //simulate a long running proccess

            Thread.Sleep(10000);

            return x * x;

        }

    }

    class Program

    {

        static void Main(string[] args)

        {

            MyClass myClass1 = new MyClass();

            MyDelegate del = new MyDelegate(myClass1.MyMethod);

            //Invoke our methe in another thread

            IAsyncResult async = del.BeginInvoke(5, new AsyncCallback(MyCallBack), null);

            Console.WriteLine("Proccessing the Operation....");

            Console.ReadLine();

        }

        static void MyCallBack(IAsyncResult async)

        {

            Console.WriteLine("Operation Complete");

        }

    }

}
