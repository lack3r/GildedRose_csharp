using NUnit.Framework;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        private GildedRose _app;

        // Set to true, when the CONJURED item is added
        // When True, the tests that are related to Conjured items will run
        private const bool IsConjuredImplemented = false;


        private string NORMAL = "Normal";
        private string AGED_BRIE = "Aged Brie";
        private string BACKSTAGE = "Backstage passes to a TAFKAL80ETC concert";
        private string SULFURAS = "Sulfuras, Hand of Ragnaros";
        private string CONJURED = "Conjured";


        // Do NOT delete unless you are sure that it is not used anymore.
        // At the time of writing, this method is used by the @EnabledIf annotation on the tests below.
        // @EnabledIf annotation at Junit 5.7.1 expects a method name to be passed in as a string.
        // Thus, It can not, at this stage, get a boolean parameter, but a boolean method.
        // This is the reason this method was implemented.
        // When IS_CONJURED_IMPLEMENTED becomes true, the tests regarding CONJURED items will run
        // We also use the annotation @SuppressWarnings("unused"), because it is a false alert.
        // The method is actually used by JUnit EnabledIf annotation
        private bool isConjuredImplemented()
        {
            return IsConjuredImplemented;
        }

        // Test Normal Item
        public void ConstructItem(string itemDescription, int sellIn, int quality)
        {
            Item item = new Item
            {
                Name = itemDescription,
                SellIn = sellIn,
                Quality = quality
            };
            Item[] items = new[] {item};

            _app = new GildedRose(items);
        }

        [Test]
        public void updateQuality_whenItemIsConjuredAndSellInIsOneAndQualityIsPositiveThenSellInValueIsReducedByOneAndQualityIsReducedByTwo()
        {
            if (!isConjuredImplemented())
            {
                Assert.Ignore("Conjured is not implemented yet.  Omitting.");
            }

            ConstructItem(CONJURED, 1, 2);
            _app.UpdateQuality();
            Assert.AreEqual(0, _app.Items[0].SellIn);
            Assert.AreEqual(0, _app.Items[0].Quality);
        }

        // Generic Tests
        [Test]

        public void CheckThatNameIsTheSameAfterUpdatingQuality()
        {
            ConstructItem(NORMAL, 0, 0);
            _app.UpdateQuality();
            Assert.AreEqual("Normal", _app.Items[0].Name);
        }

        // SELL IN NEGATIVE. QUALITY ZERO.

        [Test]
        public void
            updateQuality_whenItemIsNormalAndSellInIsNegativeAndQualityIsZeroThenSellInValueIsReducedByOneAndQualityStaysZero()
        {
            ConstructItem(NORMAL, -1, 0);
            _app.UpdateQuality();
            Assert.AreEqual(-2, _app.Items[0].SellIn);
            Assert.AreEqual(0, _app.Items[0].Quality);
        }

        [Test]
        public void
            updateQuality_whenItemIsAgedBrieAndSellInIsNegativeAndQualityIsZeroThenSellInValueIsReducedByOneButQualityBecomesTwo()
        {
            ConstructItem(AGED_BRIE, -1, 0);
            _app.UpdateQuality();
            Assert.AreEqual(-2, _app.Items[0].SellIn);
            Assert.AreEqual(2, _app.Items[0].Quality);
        }

        [Test]
        public void
            updateQuality_whenItemIsBackstageAndSellInIsNegativeAndQualityIsZeroThenSellInValueIsReducedByOneAndQualityStaysZero()
        {
            ConstructItem(BACKSTAGE, -1, 0);
            _app.UpdateQuality();
            Assert.AreEqual(-2, _app.Items[0].SellIn);
            Assert.AreEqual(0, _app.Items[0].Quality);
        }

        [Test]
        public void updateQuality_whenItemIsSulfurasAndSellInIsNegativeAndQualityIsZeroThenSellInValueAndQualityDoNotChange()
        {
            ConstructItem(SULFURAS, -1, 0);
            _app.UpdateQuality();
            Assert.AreEqual(-1, _app.Items[0].SellIn);
            Assert.AreEqual(0, _app.Items[0].Quality);
        }

        [Test]

        public void
            updateQuality_whenItemIsSulfurasAndSellInIsNegativeAndQualityIsZeroThenSellInValueIsReducedByOneAndQualityBecomesZero()
        {
            if (!isConjuredImplemented())
            {
                Assert.Ignore("Conjured is not implemented yet.  Omitting.");
            }

            ConstructItem(CONJURED, -1, 0);
            _app.UpdateQuality();
            Assert.AreEqual(-2, _app.Items[0].SellIn);
            Assert.AreEqual(0, _app.Items[0].Quality);
        }

        // SELL IN NEGATIVE. QUALITY ONE.

        [Test]
        public void
            updateQuality_whenItemIsNormalAndSellInIsNegativeAndQualityIsOneThenSellInValueIsReducedByOneAndQualityStaysZero()
        {
            ConstructItem(NORMAL, -1, 1);
            _app.UpdateQuality();
            Assert.AreEqual(-2, _app.Items[0].SellIn);
            Assert.AreEqual(0, _app.Items[0].Quality);
        }

        [Test]
        public void
            updateQuality_whenItemIsAgedBrieAndSellInIsNegativeAndQualityIsOneThenSellInValueIsReducedByOneButQualityBecomesTwo()
        {
            ConstructItem(AGED_BRIE, -1, 1);
            _app.UpdateQuality();
            Assert.AreEqual(-2, _app.Items[0].SellIn);
            Assert.AreEqual(3, _app.Items[0].Quality);

        }

        [Test]
        public void
            updateQuality_whenItemIsBackstageAndSellInIsNegativeAndQualityIsOneThenSellInValueIsReducedByOneAndQualityStaysZero()
        {
            ConstructItem(BACKSTAGE, -1, 1);
            _app.UpdateQuality();
            Assert.AreEqual(-2, _app.Items[0].SellIn);
            Assert.AreEqual(0, _app.Items[0].Quality);
        }

        [Test]
        public void updateQuality_whenItemIsSulfurasAndSellInIsNegativeAndQualityIsOneThenSellInValueAndQualityDoNotChange()
        {
            ConstructItem(SULFURAS, -1, 1);
            _app.UpdateQuality();
            Assert.AreEqual(-1, _app.Items[0].SellIn);
            Assert.AreEqual(1, _app.Items[0].Quality);
        }

        [Test]

        public void
            updateQuality_whenItemIsConjuredAndSellInIsNegativeAndQualityIsOneThenSellInValueIsReducedByOneAndQualityBecomesZero()
        {
            if (!isConjuredImplemented())
            {
                Assert.Ignore("Conjured is not implemented yet.  Omitting.");
            }

            ConstructItem(CONJURED, -1, 1);
            _app.UpdateQuality();
            Assert.AreEqual(-2, _app.Items[0].SellIn);
            Assert.AreEqual(0, _app.Items[0].Quality);
        }

        // SELL IN NEGATIVE. QUALITY GREATER THAN ONE.

        [Test]
        public void
            updateQuality_whenItemIsNormalAndSellInIsNegativeAndQualityIsGreaterThanOneThenSellInValueIsReducedByOneAndQualityStaysZero()
        {
            ConstructItem(NORMAL, -1, 10);
            _app.UpdateQuality();
            Assert.AreEqual(-2, _app.Items[0].SellIn);
            Assert.AreEqual(8, _app.Items[0].Quality);
        }

        [Test]
        public void
            updateQuality_whenItemIsAgedBrieAndSellInIsNegativeAndQualityIsGreaterThanOneThenSellInValueIsReducedByOneButQualityBecomesTwo()
        {
            ConstructItem(AGED_BRIE, -1, 2);
            _app.UpdateQuality();
            Assert.AreEqual(-2, _app.Items[0].SellIn);
            Assert.AreEqual(4, _app.Items[0].Quality);

        }

        [Test]
        public void
            updateQuality_whenItemIsBackstageAndSellInIsNegativeAndQualityIsGreaterThanOneThenSellInValueIsReducedByOneAndQualityBecomesZero()
        {
            ConstructItem(BACKSTAGE, -1, 2);
            _app.UpdateQuality();
            Assert.AreEqual(-2, _app.Items[0].SellIn);
            Assert.AreEqual(0, _app.Items[0].Quality);
        }

        [Test]
        public void
            updateQuality_whenItemIsSulfurasAndSellInIsNegativeAndQualityIsGreaterThanOneThenSellInValueAndQualityDoNotChange()
        {
            ConstructItem(SULFURAS, -1, 2);
            _app.UpdateQuality();
            Assert.AreEqual(-1, _app.Items[0].SellIn);
            Assert.AreEqual(2, _app.Items[0].Quality);
        }

        [Test]

        public void
            updateQuality_whenItemIsConjuredAndSellInIsNegativeAndQualityIsGreaterThanOneThenSellInValueIsReducedByOneAndQualityBecomesZero()
        {
            if (!isConjuredImplemented())
            {
                Assert.Ignore("Conjured is not implemented yet.  Omitting.");
            }

            ConstructItem(CONJURED, -1, 2);
            _app.UpdateQuality();
            Assert.AreEqual(-2, _app.Items[0].SellIn);
            Assert.AreEqual(0, _app.Items[0].Quality);
        }

        // SELL IN ZERO. QUALITY ZERO.
        [Test]
        public void
            updateQuality_whenItemIsNormalAndSellInIsZeroAndQualityIsZeroThenSellInValueIsReducedByOneAndQualityStaysZero()
        {
            ConstructItem(NORMAL, 0, 0);
            _app.UpdateQuality();
            Assert.AreEqual(-1, _app.Items[0].SellIn);
            Assert.AreEqual(0, _app.Items[0].Quality);
        }

        [Test]
        public void
            updateQuality_whenItemIsAgedBrieAndSellInIsZeroAndQualityIsZeroThenSellInValueIsReducedByOneButQualityBecomesTwo()
        {
            ConstructItem(AGED_BRIE, 0, 0);
            _app.UpdateQuality();
            Assert.AreEqual(-1, _app.Items[0].SellIn);
            Assert.AreEqual(2, _app.Items[0].Quality);
        }

        [Test]
        public void
            updateQuality_whenItemIsBackstageAndSellInIsZeroAndQualityIsZeroThenSellInValueIsReducedByOneAndQualityStaysZero()
        {
            ConstructItem(BACKSTAGE, 0, 0);
            _app.UpdateQuality();
            Assert.AreEqual(-1, _app.Items[0].SellIn);
            Assert.AreEqual(0, _app.Items[0].Quality);
        }

        [Test]
        public void updateQuality_whenItemIsSulfurasAndSellInIsZeroAndQualityIsZeroThenSellInValueAndQualityDoNotChange()
        {
            ConstructItem(SULFURAS, 0, 0);
            _app.UpdateQuality();
            Assert.AreEqual(0, _app.Items[0].SellIn);
            Assert.AreEqual(0, _app.Items[0].Quality);
        }

        [Test]

        public void
            updateQuality_whenItemIsConjuredAndSellInIsZeroAndQualityIsZeroThenSellInValueIsReducedByOneAndQualityStaysZero()
        {
            if (!isConjuredImplemented())
            {
                Assert.Ignore("Conjured is not implemented yet.  Omitting.");
            }

            ConstructItem(CONJURED, 0, 0);
            _app.UpdateQuality();
            Assert.AreEqual(-1, _app.Items[0].SellIn);
            Assert.AreEqual(0, _app.Items[0].Quality);
        }

        // SELL IN ONE. QUALITY ZERO.
        [Test]
        public void updateQuality_whenItemIsNormalAndSellInIsPositiveAndQualityIsZeroThenSellInValueIsReducedByOneAndQualityStaysZero()
        {
            ConstructItem(NORMAL, 1, 0);
            _app.UpdateQuality();
            Assert.AreEqual(0, _app.Items[0].SellIn);
            Assert.AreEqual(0, _app.Items[0].Quality);
        }

        [Test]
        public void updateQuality_whenItemIsAgedBrieAndSellInIsPositiveAndQualityIsZeroThenSellInValueIsReducedByOneButQualityBecomesTwo()
        {
            ConstructItem(AGED_BRIE, 1, 0);
            _app.UpdateQuality();
            Assert.AreEqual(0, _app.Items[0].SellIn);
            Assert.AreEqual(1, _app.Items[0].Quality);
        }

        [Test]
        public void updateQuality_whenItemIsBackstageAndSellInIsPositiveAndQualityIsZeroThenSellInValueIsReducedByOneAndQualityStaysZero()
        {
            ConstructItem(BACKSTAGE, 1, 0);
            _app.UpdateQuality();
            Assert.AreEqual(0, _app.Items[0].SellIn);
            Assert.AreEqual(3, _app.Items[0].Quality);
        }

        [Test]
        public void updateQuality_whenItemIsSulfurasAndSellInIsPositiveAndQualityIsZeroThenSellInValueAndQualityDoNotChange()
        {
            ConstructItem(SULFURAS, 1, 0);
            _app.UpdateQuality();
            Assert.AreEqual(1, _app.Items[0].SellIn);
            Assert.AreEqual(0, _app.Items[0].Quality);
        }

        [Test]

        public void updateQuality_whenItemIsConjuredAndSellInIsPositiveAndQualityIsZeroThenSellInValueIsReducedByOneAndQualityStaysZero()
        {
            if (!isConjuredImplemented())
            {
                Assert.Ignore("Conjured is not implemented yet.  Omitting.");
            }

            ConstructItem(CONJURED, 1, 0);
            _app.UpdateQuality();
            Assert.AreEqual(0, _app.Items[0].SellIn);
            Assert.AreEqual(0, _app.Items[0].Quality);
        }

        // SELL IN ONE. QUALITY ONE.
        [Test]
        public void
            updateQuality_whenItemIsNormalAndSellInIsOneAndQualityIsOneThenSellInValueIsReducedByOneAndQualityStaysZero()
        {
            ConstructItem(NORMAL, 1, 1);
            _app.UpdateQuality();
            Assert.AreEqual(0, _app.Items[0].SellIn);
            Assert.AreEqual(0, _app.Items[0].Quality);
        }

        [Test]
        public void
            updateQuality_whenItemIsAgedBrieAndSellInIsOneAndQualityIsOneThenSellInValueIsReducedByOneButQualityBecomesTwo()
        {
            ConstructItem(AGED_BRIE, 1, 1);
            _app.UpdateQuality();
            Assert.AreEqual(0, _app.Items[0].SellIn);
            Assert.AreEqual(2, _app.Items[0].Quality);

        }

        [Test]
        public void
            updateQuality_whenItemIsBackstageAndSellInIsOneAndQualityIsOneThenSellInValueIsReducedByOneAndQualityStaysZero()
        {
            ConstructItem(BACKSTAGE, 1, 1);
            _app.UpdateQuality();
            Assert.AreEqual(0, _app.Items[0].SellIn);
            Assert.AreEqual(4, _app.Items[0].Quality);

        }

        [Test]
        public void updateQuality_whenItemIsSulfurasAndSellInIsOneAndQualityIsOneThenSellInValueAndQualityDoNotChange()
        {
            ConstructItem(SULFURAS, 1, 1);
            _app.UpdateQuality();
            Assert.AreEqual(1, _app.Items[0].SellIn);
            Assert.AreEqual(1, _app.Items[0].Quality);
        }

        [Test]

        public void
            updateQuality_whenItemIsConjuredAndSellInIsOneAndQualityIsOneThenSellInValueIsReducedByOneAndQualityBecomesZero()
        {
            if (!isConjuredImplemented())
            {
                Assert.Ignore("Conjured is not implemented yet.  Omitting.");
            }

            ConstructItem(CONJURED, 1, 1);
            _app.UpdateQuality();
            Assert.AreEqual(0, _app.Items[0].SellIn);
            Assert.AreEqual(0, _app.Items[0].Quality);
        }



        // SELL IN ONE. QUALITY TWO.
        [Test]
        public void updateQuality_whenItemIsNormalAndSellInIsOneAndQualityIsPositiveThenSellInValueIsReducedByOneAndQualityStaysZero()
        {
            ConstructItem(NORMAL, 1, 2);
            _app.UpdateQuality();
            Assert.AreEqual(0, _app.Items[0].SellIn);
            Assert.AreEqual(1, _app.Items[0].Quality);
        }

        [Test]
        public void updateQuality_whenItemIsAgedBrieAndSellInIsOneAndQualityIsPositiveThenSellInValueIsReducedByOneButQualityBecomesTwo()
        {
            ConstructItem(AGED_BRIE, 1, 2);
            _app.UpdateQuality();
            Assert.AreEqual(0, _app.Items[0].SellIn);
            Assert.AreEqual(3, _app.Items[0].Quality);

        }

        [Test]
        public void updateQuality_whenItemIsBackstageAndSellInIsOneAndQualityIsPositiveThenSellInValueIsReducedByOneAndQualityStaysZero()
        {
            ConstructItem(BACKSTAGE, 1, 2);
            _app.UpdateQuality();
            Assert.AreEqual(0, _app.Items[0].SellIn);
            Assert.AreEqual(5, _app.Items[0].Quality);

        }

        [Test]
        public void updateQuality_whenItemIsSulfurasAndSellInIsOneAndQualityIsPositiveThenSellInValueAndQualityDoNotChange()
        {
            ConstructItem(SULFURAS, 1, 2);
            _app.UpdateQuality();
            Assert.AreEqual(1, _app.Items[0].SellIn);
            Assert.AreEqual(2, _app.Items[0].Quality);
        }




        // TESTING BACKSTAGE BOUNDARIES

        [Test]
        public void updateQuality_whenItemIsBackstageAndSellIsFourAndQualityIsIncreasedByThree()
        {
            ConstructItem(BACKSTAGE, 4, 10);
            _app.UpdateQuality();
            Assert.AreEqual(3, _app.Items[0].SellIn);
            Assert.AreEqual(13, _app.Items[0].Quality);
        }

        [Test]
        public void updateQuality_whenItemIsBackstageAndSellIsFiveAndQualityIsIncreasedByThree()
        {
            ConstructItem(BACKSTAGE, 5, 10);
            _app.UpdateQuality();
            Assert.AreEqual(4, _app.Items[0].SellIn);
            Assert.AreEqual(13, _app.Items[0].Quality);
        }

        [Test]
        public void updateQuality_whenItemIsBackstageAndSellIsSixAndQualityIsIncreasedByTwo()
        {
            ConstructItem(BACKSTAGE, 6, 10);
            _app.UpdateQuality();
            Assert.AreEqual(5, _app.Items[0].SellIn);
            Assert.AreEqual(12, _app.Items[0].Quality);
        }

        [Test]
        public void updateQuality_whenItemIsBackstageAndSellIsNineAndQualityIsIncreasedByTwo()
        {
            ConstructItem(BACKSTAGE, 9, 10);
            _app.UpdateQuality();
            Assert.AreEqual(8, _app.Items[0].SellIn);
            Assert.AreEqual(12, _app.Items[0].Quality);
        }

        [Test]
        public void updateQuality_whenItemIsBackstageAndSellIsTenAndQualityIsIncreasedByTwo()
        {
            ConstructItem(BACKSTAGE, 10, 10);
            _app.UpdateQuality();
            Assert.AreEqual(9, _app.Items[0].SellIn);
            Assert.AreEqual(12, _app.Items[0].Quality);
        }

        [Test]
        public void updateQuality_whenItemIsBackstageAndSellIsElevenAndQualityIsIncreasedByOne()
        {
            ConstructItem(BACKSTAGE, 11, 10);
            _app.UpdateQuality();
            Assert.AreEqual(10, _app.Items[0].SellIn);
            Assert.AreEqual(11, _app.Items[0].Quality);
        }

        // Test Around the 50 Quality Boundary
        [Test]
        public void updateQuality_whenItemIsAgedBrieAndQualityIsFortyNineThenQualityIsIncreasedByOne()
        {
            ConstructItem(AGED_BRIE, 10, 49);
            _app.UpdateQuality();
            Assert.AreEqual(9, _app.Items[0].SellIn);
            Assert.AreEqual(50, _app.Items[0].Quality);
        }

        [Test]
        public void updateQuality_whenItemIsAgedBrieAndQualityIsFiftyThenQualityIsNotIncreased()
        {
            ConstructItem(AGED_BRIE, 10, 50);
            _app.UpdateQuality();
            Assert.AreEqual(9, _app.Items[0].SellIn);
            Assert.AreEqual(50, _app.Items[0].Quality);
        }
    }
}