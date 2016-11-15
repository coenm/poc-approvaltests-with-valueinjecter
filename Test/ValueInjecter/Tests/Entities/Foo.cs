namespace Test.ValueInjecter.Tests.Entities
{
    public class Foo
    {
        public Foo Foo1 { get; set; }
        public Foo Foo2 { get; set; }
        public string Name { get; set; }
        public string NameZype { get; set; }
        public int Age { get; set; }

        public Foo FooR
        {
            get
            {
                return null;
            }
        }

        public string Prop1
        {
            set
            {
                Name = value;
            }
        }
    }
}