using NUnit.Framework;

namespace Test.ValueInjecter.Tests.Mics
{
    public static class TestingTools
    {
        public static void IsEqualTo(this object o, object to)
        {
            Assert.AreEqual(to, o);
        }

        public static void IsNotNull(this object o)
        {
            Assert.IsNotNull(o);
        }
    }
}