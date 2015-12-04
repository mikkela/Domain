using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Mikadocs.Domain.UnitTests
{
    class ValueObjectTest
    {
        private class MyValueObject : ValueObject<string>
        {
            public MyValueObject(string value)
                : base(value)
            {
            }
        }

        private class MyOtherValueObject : MyValueObject
        {
            public MyOtherValueObject(string value)
                : base(value)
            {
            }
        }

        [Test]
        public void
            Given_a_value_object_When_constructed_from_the_value_Then_the_value_can_be_read_from_Value()
        {
            const string value = "3443";
            var sut = new MyValueObject(value);

            Assert.AreEqual(value, sut.Value);
        }

        [Test]
        public void
            Given_two_value_objects_with_same_values_When_compared_Then_they_are_considered_equal()
        {
            const string value = "3443";
            var sut1 = new MyValueObject(value);
            var sut2 = new MyValueObject(value);

            Assert.IsTrue(sut1.Equals(sut2));
            Assert.IsTrue(sut2.Equals(sut1));
            Assert.IsTrue(sut1.GetHashCode() == sut2.GetHashCode());
        }

        [Test]
        public void
            Given_two_value_objects_with_different_values_When_compared_Then_they_are_not_considered_equal()
        {
            const string value = "3443";
            var sut1 = new MyValueObject(value);
            var sut2 = new MyValueObject(value + "2");

            Assert.IsFalse(sut1.Equals(sut2));
            Assert.IsFalse(sut2.Equals(sut1));
            Assert.IsFalse(sut1.GetHashCode() == sut2.GetHashCode());
        }

        [Test]
        public void
            Given_two_value_objects_with_same_values_but_different_subtype_When_compared_Then_they_are_not_considered_equal_but_with_same_hash_code()
        {
            const string value = "3443";
            var sut1 = new MyValueObject(value);
            var sut2 = new MyOtherValueObject(value);

            Assert.IsFalse(sut1.Equals(sut2));
            Assert.IsFalse(sut2.Equals(sut1));
            Assert.IsTrue(sut1.GetHashCode() == sut2.GetHashCode());
        }

        [Test]
        public void Given_a_value_object_and_null_When_compared_Then_they_are_not_considered_equal()
        {
            const string value = "3443";
            var sut = new MyValueObject(value);

            Assert.IsFalse(sut.Equals(null as object));
        }

        [Test]
        public void Given_a_value_object_When_compared_with_itself_Then_they_are_considered_equal()
        {
            const string value = "3443";
            var sut = new MyValueObject(value);

            Assert.IsTrue(sut.Equals(sut as object));
        }
    }
}
