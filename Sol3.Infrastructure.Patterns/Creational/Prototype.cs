namespace Sol3.Infrastructure.Patterns.Creational
{
    public abstract class Prototype
    {
        // Constructor
        public Prototype(string id) { this.Id = id; }

        // Gets id
        public string Id { get; }

        public abstract Prototype Clone();
    }



    /// <summary>
    /// Sample: A 'ConcretePrototype' class 
    /// </summary>
    class ConcretePrototype1 : Prototype
    {
        // Constructor
        public ConcretePrototype1(string id) : base(id) { }


        // Returns a shallow copy
        public override Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone();
        }
    }
}
