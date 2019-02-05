using System;
using NUnit.Framework;

namespace mass
{
    [TestFixture]
    public class Tests
    {
        /*
         * Проверка функции Эратосфена
         */

        [Test]
        public void Test1()
        {
            Assert.AreEqual(new[] {2}, Program.Eratosfen(2));
            Assert.AreEqual(new[] {2, 3}, Program.Eratosfen(3));
            Assert.AreEqual(new[] {2, 3}, Program.Eratosfen(4));
            Assert.AreEqual(new[] {2, 3, 5}, Program.Eratosfen(5));
            Assert.AreEqual(new[] {2, 3, 5}, Program.Eratosfen(6));
            Assert.AreEqual(new[] {2, 3, 5, 7, 11, 13, 17, 19}, Program.Eratosfen(20));
            Assert.AreEqual(
                new[]
                {
                    2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97
                }, Program.Eratosfen(100));
        }

        [Test]
        public void get_simple_numbers()
        {
            Assert.AreEqual(new[] {2, 3}, Program.get_simple_numbers_in_array(new []{1, 2, 3, 4}, 4));
        }
    }
}