namespace Fifth
{
    // Паттерн Singleton гарантирует, что у класса будет только один экземпляр, и предоставляет глобальную точку доступа к нему.
    // Используется когда нужен только один экземпляр класса.
    public sealed class Singleton
    {
        private static readonly Singleton singletonInstance = new Singleton();
        public static Singleton GetInstance()
        { return singletonInstance; }
        public void SomeMethod() { Console.WriteLine("Singleton method called."); }
    }
    public class Client
    {
        public static void Main(string[] args)
        {
            Singleton singleton1 = Singleton.GetInstance();
            Singleton singleton2 = Singleton.GetInstance();

            if (singleton1 == singleton2) 
                Console.WriteLine("Both variables point to the same instance.");

            singleton1.SomeMethod();
        }
    }
}