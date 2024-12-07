namespace SecondTask
{
    // Этот паттерн определяет абстрактный класс для создания объекта, но оставляет подклассам решение о том, какой класс инстанцировать.  
    // Применяется там, где нужно создать семейство похожих объектов, но тип объекта неизвестен на этапе компиляции.

    public abstract class Product { public virtual void Operation() { Console.WriteLine("Product"); } }

    public class ConcreteProductA : Product { public override void Operation() { Console.WriteLine("ConcreteProductA"); } }

    public class ConcreteProductB : Product { public override void Operation() { Console.WriteLine("ConcreteProductB"); } }

    public abstract class Creator { public abstract Product FactoryMethod(); }

    public class ConcreteCreatorA : Creator
    {
        public override Product FactoryMethod() { return new ConcreteProductA(); }
    }

    public class ConcreteCreatorB : Creator
    {
        public override Product FactoryMethod() { return new ConcreteProductB(); }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Creator creatorA = new ConcreteCreatorA();

            Product productA = creatorA.FactoryMethod();

            productA.Operation();

            Creator creatorB = new ConcreteCreatorB();

            Product productB = creatorB.FactoryMethod();

            productB.Operation();

        }

    }
}