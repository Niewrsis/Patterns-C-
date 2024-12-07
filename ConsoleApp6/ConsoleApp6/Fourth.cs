namespace Fourth
{
    // Этот паттерн используется для построения сложных объектов пошагово.   
    // Применяется в случаях, когда объект состоит из большого количества частей, и порядок их сборки важен.
    public class Product
    {
        public List<object> parts = new List<object>();
        public void Add(object part) { parts.Add(part); }

        public override string ToString()
        {
            string result = "Product parts:\n";
            foreach (var part in parts)
            {
                result += part + "\n";
            }
            return result;
        }
    }

    public abstract class Builder
    {
        public abstract void BuildPartA();
        public abstract void BuildPartB();
        public abstract void BuildPartC();
        public abstract Product GetResult();
    }

    public class ConcreteBuilder : Builder
    {
        private Product product = new Product();

        public override void BuildPartA() { product.Add("Part A"); }
        public override void BuildPartB() { product.Add("Part B"); }
        public override void BuildPartC() { product.Add("Part C"); }
        public override Product GetResult() { return product; }
    }

    public class Director
    {
        private Builder builder;

        public Director(Builder builder)
        {
            this.builder = builder;
        }

        public void Construct()
        {
            builder.BuildPartA();
            builder.BuildPartB();
            builder.BuildPartC();
        }
    }

    public class Client
    {
        public static void Main(string[] args)
        {
            ConcreteBuilder builder = new ConcreteBuilder();
            Director director = new Director(builder);
            director.Construct();
            Product product = builder.GetResult();
            Console.WriteLine(product);

        }
    }
}