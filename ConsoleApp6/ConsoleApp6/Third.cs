namespace Third
{
    // Этот паттерн предоставляет абстрактный класс для создания семейств связанных или зависимых объектов, не указывая их конкретных классов.
    // Применяется когда необходимо создать семейство объектов, связанных между собой, и клиентский код не должен зависеть от конкретных реализаций этих объектов.


    public abstract class AbstractProductA { public abstract void OperationA(); }
    public abstract class AbstractProductB { public abstract void OperationB(); }
    public class ProductA1 : AbstractProductA
    {
        public override void OperationA() { Console.WriteLine("ProductA1 OperationA"); }
    }
    public class ProductA2 : AbstractProductA
    {
        public override void OperationA() { Console.WriteLine("ProductA2 OperationA"); }
    }
    public class ProductB1 : AbstractProductB
    {
        public override void OperationB() { Console.WriteLine("ProductB1 OperationB"); }
    }
    public class ProductB2 : AbstractProductB
    {
        public override void OperationB() { Console.WriteLine("ProductB2 OperationB"); }
    }
    public abstract class AbstractFactory
    {
        public abstract AbstractProductA CreateProductA();
        public abstract AbstractProductB CreateProductB();
    }

    public class ConcreteFactory1 : AbstractFactory
    {
        public override AbstractProductA CreateProductA() { return new ProductA1(); }
        public override AbstractProductB CreateProductB() { return new ProductB1(); }
    }

    public class ConcreteFactory2 : AbstractFactory
    {
        public override AbstractProductA CreateProductA() { return new ProductA2(); }
        public override AbstractProductB CreateProductB() { return new ProductB2(); }
    }

    public class Client
    {
        private AbstractProductA abstractProductA;
        private AbstractProductB abstractProductB;

        public Client(AbstractFactory factory)
        {
            abstractProductA = factory.CreateProductA();
            abstractProductB = factory.CreateProductB();
        }

        public void Run()
        {
            abstractProductA.OperationA();
            abstractProductB.OperationB();
        }

        public static void Main(string[] args)
        {
            Client client1 = new Client(new ConcreteFactory1());
            client1.Run();

            Client client2 = new Client(new ConcreteFactory2());
            client2.Run();
        }
    }
}