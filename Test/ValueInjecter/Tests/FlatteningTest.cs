using System;
using NUnit.Framework;
using Omu.ValueInjecter;
using Omu.ValueInjecter.Injections;
using Test.ValueInjecter.Tests.Entities;
using Test.ValueInjecter.Tests.Misc;

namespace Test.ValueInjecter.Tests
{
    /// <summary>
    /// Original tests https://github.com/omuleanu/ValueInjecter/blob/master/Tests/FlatteningTest.cs 
    /// All inner entities are moved to Entities directory.
    /// </summary>
    [TestFixture]
    public class FlatteningTest
    {
        [Test]
        public void Unflattening()
        {
            var flat = new FlatFoo
            {
                Foo1Foo2Foo1Name = "cool",
                Foo1Name = "abc",
                Foo2Name = "123",
            };

            var unflat = new Foo();

            unflat.InjectFrom<UnflatLoopInjection>(flat);

            unflat.Foo1.Foo2.Foo1.Name.IsEqualTo("cool");
            unflat.Foo1.Name.IsEqualTo("abc");
            unflat.Foo2.Name.IsEqualTo("123");
        }

        [Test]
        public void Flattening()
        {
            var unflat = new Foo
            {
                Name = "foo",
                Foo1 = new Foo
                {
                    Name = "abc",
                    Foo2 = new Foo { Foo1 = new Foo { Name = "inner" } }
                },
                Foo2 = new Foo { Name = "123", NameZype = "aaa" },
            };

            var flat = new FlatFoo();

            flat.InjectFrom<FlatLoopInjection>(unflat);

            flat.Foo2NameZype.IsEqualTo("aaa");
        }

        [Test]
        public void GenericFlatTest()
        {
            var foo = new Foo { Foo1 = new Foo { Age = 18 } };
            var flat = new FlatFoo();

            flat.InjectFrom<IntToStringFlat>(foo);
            flat.Foo1Age.IsEqualTo("18");
        }

        [Test]
        public void BasicTest()
        {
            var customer = GetCustomer();
            var res = new CustomerInput();

            res.InjectFrom<FlatLoopInjection>(customer);
            res.InjectFrom<UnflatLoopInjection>(customer);
        }

        private static Customer GetCustomer()
        {
            var customer = new Customer { FirstName = "Art", LastName = "Vandelay", Id = 123, RegDate = DateTime.UtcNow };
            return customer;
        }
    }
}