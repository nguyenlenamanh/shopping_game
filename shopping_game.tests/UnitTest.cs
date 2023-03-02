using Microsoft.VisualStudio.TestTools.UnitTesting;
using shopping_game.Entities;
using System.Collections.Generic;

namespace shopping_game.tests
{
    [TestClass]
    public class UnitTest
    {
        readonly List<Rule> rules = new()
        {
            new AppleTVRule(),
            new SuperIpadRule(),
            new MacbookAndVGARule()
        };

        /// <summary>
        /// SKUs Scanned: atv, atv, atv, vga
        /// Total expected: $249.00
        /// </summary>
        [TestMethod]
        public void Scenario1()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product
                {
                    SKU = "atv",
                    Price = 109.50m
                },
                new Product
                {
                    SKU = "atv",
                    Price = 109.50m
                },
                new Product
                {
                    SKU = "atv",
                    Price = 109.50m
                },
                new Product
                {
                    SKU = "vga",
                    Price = 30m
                }
            };

            // Act
            Checkout checkout = new(rules);

            products.ForEach(product => checkout.Scan(product));

            var total = checkout.Total();

            // Asssert
            Assert.AreEqual(249.00m, total);
        }

        /// <summary>
        /// SKUs Scanned: atv, ipd, ipd, atv, ipd, ipd, ipd
        /// Total expected: $2718.95
        /// </summary>
        [TestMethod]
        public void Scenario2()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product
                {
                    SKU = "atv",
                    Price = 109.50m
                },
                new Product
                {
                    SKU = "ipd",
                    Price = 549.99m
                },
                new Product
                {
                    SKU = "ipd",
                    Price = 549.99m
                },
                new Product
                {
                    SKU = "atv",
                    Price = 109.50m
                },
                new Product
                {
                    SKU = "ipd",
                    Price = 549.99m
                },
                new Product
                {
                    SKU = "ipd",
                    Price = 549.99m
                },
                new Product
                {
                    SKU = "ipd",
                    Price = 549.99m
                },
            };

            // Act
            Checkout checkout = new(rules);

            products.ForEach(product => checkout.Scan(product));

            var total = checkout.Total();

            // Asssert
            Assert.AreEqual(2718.95m, total);
        }

        /// <summary>
        /// SKUs Scanned: mbp, vga, ipd
        /// Total expected: $1949.98
        /// </summary>
        [TestMethod]
        public void Scenario3()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product
                {
                    SKU = "mbp",
                    Price = 1399.99m
                },
                new Product
                {
                    SKU = "vga",
                    Price = 30.00m
                },
                new Product
                {
                    SKU = "ipd",
                    Price = 549.99m
                },
            };

            // Act
            Checkout checkout = new(rules);

            products.ForEach(product => checkout.Scan(product));

            var total = checkout.Total();

            // Asssert
            Assert.AreEqual(1949.98m, total);
        }

        /// <summary>
        /// 5 apples tv, 3 with discount: 219, 2 without discount: 109.5 + 109.5
        /// SKUs Scanned: atv, atv, atv, atv, atv
        /// Total expected: $438
        /// </summary>
        [TestMethod]
        public void Scenario4()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product
                {
                    SKU = "atv",
                    Price = 109.50m
                },
                new Product
                {
                    SKU = "atv",
                    Price = 109.50m
                },
                new Product
                {
                    SKU = "atv",
                    Price = 109.50m
                },
                new Product
                {
                    SKU = "atv",
                    Price = 109.50m
                },
                new Product
                {
                    SKU = "atv",
                    Price = 109.50m
                }
            };

            // Act
            Checkout checkout = new(rules);

            products.ForEach(product => checkout.Scan(product));

            var total = checkout.Total();

            // Asssert
            Assert.AreEqual(438m, total);
        }

        /// <summary>
        /// 3 macbook, 4 vga: 1399.99 * 3 + 30 = 4229.97
        /// SKUs Scanned: mbp, mbp, mbp, vga, vga, vga, vga
        /// Total expected: $4229.97
        /// </summary>
        [TestMethod]
        public void Scenario5()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product
                {
                    SKU = "mbp",
                    Price = 1399.99m
                },
                new Product
                {
                    SKU = "mbp",
                    Price = 1399.99m
                },
                new Product
                {
                    SKU = "mbp",
                    Price = 1399.99m
                },
                new Product
                {
                    SKU = "vga",
                    Price = 30m
                },
                new Product
                {
                    SKU = "vga",
                    Price = 30m
                },
                new Product
                {
                    SKU = "vga",
                    Price = 30m
                },
                new Product
                {
                    SKU = "vga",
                    Price = 30m
                }
            };

            // Act
            Checkout checkout = new(rules);

            products.ForEach(product => checkout.Scan(product));

            var total = checkout.Total();

            // Asssert
            Assert.AreEqual(4229.97m, total);
        }

        /// <summary>
        /// SKUs Scanned: ipd, ipd, ipd
        /// Total expected: $1649.97
        /// </summary>
        [TestMethod]
        public void Scenario6()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product
                {
                    SKU = "ipd",
                    Price = 549.99m
                },
                new Product
                {
                    SKU = "ipd",
                    Price = 549.99m
                },
                new Product
                {
                    SKU = "ipd",
                    Price = 549.99m
                }
            };

            // Act
            Checkout checkout = new(rules);

            products.ForEach(product => checkout.Scan(product));

            var total = checkout.Total();

            // Asssert
            Assert.AreEqual(1649.97m, total);
        }
    }
}