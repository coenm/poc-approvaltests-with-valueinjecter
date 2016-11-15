using System;
using System.Runtime.CompilerServices;
using ApprovalTests;
using NUnit.Framework;
using Omu.ValueInjecter;
using Omu.ValueInjecter.Injections;
using Test.JsonTestHelpers;
using Test.ValueInjecter.Tests.Entities;
using Test.ValueInjecter.Tests.Mics;

namespace Test.ValueInjecter.Tests
{
    /// <summary>
    /// Tests https://github.com/omuleanu/ValueInjecter/blob/master/Tests/FlatteningTest.cs refactored to use ApprovalTests.
    /// All expected outcomes are manually approved and are automatically saved in the directory 'Approvals'
    /// </summary>
    [TestFixture]
    [ApprovalTests.Reporters.UseReporter(typeof(ApprovalTests.Reporters.DiffReporter))]
    [ApprovalTests.Namers.UseApprovalSubdirectory("Approvals")]
    public class FlatteningTestWithAprovalTest
    {
        [Test]
        [MethodImpl(MethodImplOptions.NoInlining)]
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

            //unflat.Foo1.Foo2.Foo1.Name.IsEqualTo("cool");
            //unflat.Foo1.Name.IsEqualTo("abc");
            //unflat.Foo2.Name.IsEqualTo("123");
            Approvals.Verify(TestJson.SerializeForApprovalTests(unflat));
        }

        [Test]
        [MethodImpl(MethodImplOptions.NoInlining)]
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

            //flat.Foo2NameZype.IsEqualTo("aaa");
            Approvals.Verify(TestJson.SerializeForApprovalTests(flat));
        }

        [Test]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public void GenericFlatTest()
        {
            var foo = new Foo { Foo1 = new Foo { Age = 18 } };
            var flat = new FlatFoo();

            flat.InjectFrom<IntToStringFlat>(foo);
            //flat.Foo1Age.IsEqualTo("18");
            Approvals.Verify(TestJson.SerializeForApprovalTests(flat));
        }

        [Test]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public void BasicTest()
        {
            var customer = GetCustomer();
            var res = new CustomerInput();

            res.InjectFrom<FlatLoopInjection>(customer);
            res.InjectFrom<UnflatLoopInjection>(customer);
            Approvals.Verify(TestJson.SerializeForApprovalTests(customer));
        }

        private static Customer GetCustomer()
        {
            var customer = new Customer
            {
                FirstName = "Art",
                LastName = "Vandelay",
                Id = 123,
                RegDate = (new DateTime(2000, 11, 15, 14, 15, 55, 10, DateTimeKind.Utc).AddTicks(3798807))
            };
            return customer;
        }
    }
}