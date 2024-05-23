namespace decorator_pattern
{
    //A demonstration of the Decorator / Wrapper pattern in C#
    public class Program
    {
        static void Main(string[] args)
        {
            IDoSomething doSomething = new DoSomething();
            doSomething.Something();

            Console.WriteLine("-----");

            IDoSomething doSomethingElse = new DoSomethingElse(doSomething);
            doSomethingElse.Something();

            Console.WriteLine("-----");

            IDoSomething doSomethingDifferent = new DoSomethingElse(doSomething);
            doSomethingDifferent.Something();

            Console.WriteLine("-----");

            IDoSomething doSomethingDifferent2 = new DoSomethingElse(doSomethingDifferent);
            doSomethingDifferent2.Something();

            /* OUTPUT
             * 
             *  Do something
                -----
                Do something
                Do something else
                -----
                Do something
                Do something else
                -----
                Do something
                Do something else
                Do something else

             */
        }
    }

    public interface IDoSomething
    {
        public void Something();
    }

    //The base class
    public class DoSomething : IDoSomething
    {
        public void Something()
        {
            Console.WriteLine("Do something");
        }
    }

    //Each of these classes also implement the interface, but also take in the original DoSomething class
    //so it can call the original method, as well as performing it's own logic
    public class DoSomethingElse : IDoSomething
    {
        private IDoSomething doSomething;

        public DoSomethingElse(IDoSomething doSomething)
        {
            this.doSomething = doSomething;
        }

        public void Something()
        {
            doSomething.Something();
            Console.WriteLine("Do something else");
        }
    }

    public class DoSomethingDifferent : IDoSomething
    {
        private IDoSomething doSomething;

        public DoSomethingDifferent(IDoSomething doSomething)
        {
            this.doSomething = doSomething;
        }

        public void Something()
        {
            doSomething.Something();
            Console.WriteLine("Do something different");
        }
    }
}
