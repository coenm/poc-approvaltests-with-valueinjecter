namespace Test.ValueInjecter.Tests.Entities
{
    public class FlatFoo
    {
        public string Foo1Foo2Foo1Name { get; set; }
        public string Foo1Name { get; set; }
        public string Foo2Name { get; set; }
        public string Foo2NameZype { get; set; }
        public string Foo1Age { get; set; }
        public bool Age { get; set; }
        public string FooRName { get; set; }

        public string Foo1Prop1
        {
            set
            {
                Foo1Name = value;
            }
        }
    }
}