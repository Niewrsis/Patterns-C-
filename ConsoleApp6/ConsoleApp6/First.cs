namespace First
{
    // Этот паттерн позволяет создавать новые объекты, копируя существующие.
    // Применяется в случаях, когда создание объектов обходится дорого, требуется создание похожих объектов или объекты должны иметь определенную структуру.

    public abstract class Prototype
    {
        public int Id { get; set; }

        public abstract Prototype Clone();

        public Prototype(int id)
        {
            Id = id;
        }
    }

    public class ConcretePrototype1 : Prototype
    {
        public ConcretePrototype1(int id) : base(id) { }

        public override Prototype Clone()
        {
            // Этот метод создает глубокую копию объекта ConcretePrototype1.
            return new ConcretePrototype1(this.Id);
        }
    }

    public class ConcretePrototype2 : Prototype
    {
        public ConcretePrototype2(int id) : base(id) { }


        public override Prototype Clone()
        {
            // Этот метод создает глубокую копию объекта ConcretePrototype2.
            return new ConcretePrototype2(this.Id);
        }
    }

    public class Client
    {
        public Client() { }

        public void Operation()
        {
            // Создаем прототип
            ConcretePrototype1 prototype1 = new ConcretePrototype1(1);
            //Создаем копию прототипа
            ConcretePrototype1 clonedPrototype1 = (ConcretePrototype1)prototype1.Clone();

            // Создаем другой прототип
            ConcretePrototype2 prototype2 = new ConcretePrototype2(2);
            //Создаем копию прототипа
            ConcretePrototype2 clonedPrototype2 = (ConcretePrototype2)prototype2.Clone();

            Console.WriteLine($"Prototype 1 ID: {prototype1.Id}, Cloned Prototype 1 ID: {clonedPrototype1.Id}");
            Console.WriteLine($"Prototype 2 ID: {prototype2.Id}, Cloned Prototype 2 ID: {clonedPrototype2.Id}");
        }
    }


    public class Program
    {
        public static void Main(string[] args)
        {
            Client client = new Client();
            client.Operation();
        }
    }
}