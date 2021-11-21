using NUnit.Framework;
using System.Collections.Generic;

// Tests from https://github.com/AppsLab2019
namespace GildedRose
{
    class Tests
    {
        private Item agedBrie;
        private Item backstagePasses;
        private Item dexterityVest;
        private Item elixir;
        private Item sulfuras;
        private Item conjured;
        private Inventory sut;
        private List<Item> items;

        [SetUp]
        public void Initialize()
        {
            dexterityVest = new Item("+5 Dexterity Vest");
            agedBrie = new Item("Aged Brie");
            elixir = new Item("Elixir of the Mongoose");
            sulfuras = new Item("Sulfuras, Hand of Ragnaros");
            backstagePasses = new Item("Backstage passes to a TAFKAL80ETC concert");
            conjured = new Item("Conjured Mana Cake");
            items = new List<Item> { dexterityVest, agedBrie, elixir, sulfuras, backstagePasses, conjured };
            sut = new Inventory(items);
        }

        [Test]
        public void DexterityVest()
        {
            dexterityVest.SellIn = 10;
            dexterityVest.Quality = 20;
            sut.UpdateQuality();
            Assert.AreEqual(9, dexterityVest.SellIn,
                $"It's expected that SellIn is decreased in a day by 1 for input [SellIn: {dexterityVest.SellIn}, Quality: {dexterityVest.Quality}]");
            Assert.AreEqual(19, dexterityVest.Quality,
                $"It's expected that Quality is decreased in a day by 1 for input [SellIn: {dexterityVest.SellIn}, Quality: {dexterityVest.Quality}]");
            dexterityVest.SellIn = 0;
            dexterityVest.Quality = 19;
            sut.UpdateQuality();
            Assert.AreEqual(-1, dexterityVest.SellIn,
                $"It's expected that SellIn is decreased in a day by 1 for input [SellIn: {dexterityVest.SellIn}, Quality: {dexterityVest.Quality}]");
            Assert.AreEqual(17, dexterityVest.Quality,
                $"It's expected that Quality is decreased in a day by 2 for input [SellIn: {dexterityVest.SellIn}, Quality: {dexterityVest.Quality}]");
            dexterityVest.SellIn = 0;
            dexterityVest.Quality = 0;
            sut.UpdateQuality();
            Assert.AreEqual(-1, dexterityVest.SellIn,
                $"It's expected that SellIn is decreased in a day by 1 for input [SellIn: {dexterityVest.SellIn}, Quality: {dexterityVest.Quality}]");
            Assert.AreEqual(0, dexterityVest.Quality,
                $"It's expected that Quality is not negative. Input [SellIn: {dexterityVest.SellIn}, Quality: {dexterityVest.Quality}]");
        }

        [Test]
        public void AgedBrie()
        {
            agedBrie.SellIn = 2;
            agedBrie.Quality = 0;
            sut.UpdateQuality();
            Assert.AreEqual(1, agedBrie.SellIn,
                $"It's expected that SellIn is decreased in a day by 1 for input [SellIn: {agedBrie.SellIn}, Quality: {agedBrie.Quality}]");
            Assert.AreEqual(1, agedBrie.Quality,
                $"It's expected that Quality is increased in a day by 1 for input [SellIn: {agedBrie.SellIn}, Quality: {agedBrie.Quality}]");
            agedBrie.SellIn = 0;
            agedBrie.Quality = 0;
            sut.UpdateQuality();
            Assert.AreEqual(-1, agedBrie.SellIn,
                $"It's expected that SellIn is decreased in a day by 1 for input [SellIn: {agedBrie.SellIn}, Quality: {agedBrie.Quality}]");
            Assert.AreEqual(2, agedBrie.Quality,
                $"It's expected that Quality is increased in a day by 2 for input [SellIn: {agedBrie.SellIn}, Quality: {agedBrie.Quality}]");
            agedBrie.SellIn = 0;
            agedBrie.Quality = 50;
            sut.UpdateQuality();
            Assert.AreEqual(-1, agedBrie.SellIn,
                $"It's expected that SellIn is decreased in a day by 1 for input [SellIn: {agedBrie.SellIn}, Quality: {agedBrie.Quality}]");
            Assert.AreEqual(50, agedBrie.Quality,
                $"It's expected that Quality is not higher than 50. Input [SellIn: {agedBrie.SellIn}, Quality: {agedBrie.Quality}]");
        }

        [Test]
        public void Elixir()
        {
            elixir.SellIn = 5;
            elixir.Quality = 7;
            sut.UpdateQuality();
            Assert.AreEqual(4, elixir.SellIn,
                $"It's expected that SellIn is decreased in a day by 1 for input [SellIn: {elixir.SellIn}, Quality: {elixir.Quality}]");
            Assert.AreEqual(6, elixir.Quality,
                $"It's expected that Quality is decreased in a day by 1 for input [SellIn: {elixir.SellIn}, Quality: {elixir.Quality}]");
            elixir.SellIn = 0;
            elixir.Quality = 19;
            sut.UpdateQuality();
            Assert.AreEqual(-1, elixir.SellIn,
                $"It's expected that SellIn is decreased in a day by 1 for input [SellIn: {elixir.SellIn}, Quality: {elixir.Quality}]");
            Assert.AreEqual(17, elixir.Quality,
                $"It's expected that Quality is decreased in a day by 2 for input [SellIn: {elixir.SellIn}, Quality: {elixir.Quality}]");
            elixir.SellIn = 0;
            elixir.Quality = 0;
            sut.UpdateQuality();
            Assert.AreEqual(-1, elixir.SellIn,
                $"It's expected that SellIn is decreased in a day by 1 for input [SellIn: {elixir.SellIn}, Quality: {elixir.Quality}]");
            Assert.AreEqual(0, elixir.Quality,
                $"It's expected that Quality is not negative. Input [SellIn: {elixir.SellIn}, Quality: {elixir.Quality}]");
            elixir.SellIn = -1;
            elixir.Quality = 0;
            sut.UpdateQuality();
            Assert.AreEqual(-2, elixir.SellIn,
                $"It's expected that SellIn is decreased in a day by 1 for input [SellIn: {elixir.SellIn}, Quality: {elixir.Quality}]");
            Assert.AreEqual(0, elixir.Quality,
                $"It's expected that Quality is not negative. Input [SellIn: {elixir.SellIn}, Quality: {elixir.Quality}]");
        }

        [Test]
        public void Sulfuras()
        {
            sulfuras.SellIn = 0;
            sulfuras.Quality = 80;
            sut.UpdateQuality();
            Assert.AreEqual(0, sulfuras.SellIn,
                $"It's expected that SellIn is not changed. Input [SellIn: {sulfuras.SellIn}, Quality: {sulfuras.Quality}]");
            Assert.AreEqual(80, sulfuras.Quality,
                $"It's expected that Quality is not changed. Input [SellIn: {sulfuras.SellIn}, Quality: {sulfuras.Quality}]");
        }

        [Test]
        public void BackstagePasses()
        {
            backstagePasses.SellIn = 15;
            backstagePasses.Quality = 10;
            sut.UpdateQuality();
            Assert.AreEqual(14, backstagePasses.SellIn,
                $"It's expected that SellIn is decreased in a day by 1 for input [SellIn: {backstagePasses.SellIn}, Quality: {backstagePasses.Quality}]");
            Assert.AreEqual(11, backstagePasses.Quality,
                $"It's expected that Quality is increased in a day by 1 for input [SellIn: {backstagePasses.SellIn}, Quality: {backstagePasses.Quality}]");
            backstagePasses.SellIn = 10;
            backstagePasses.Quality = 10;
            sut.UpdateQuality();
            Assert.AreEqual(9, backstagePasses.SellIn,
                $"It's expected that SellIn is decreased in a day by 1 for input [SellIn: {backstagePasses.SellIn}, Quality: {backstagePasses.Quality}]");
            Assert.AreEqual(12, backstagePasses.Quality,
                $"It's expected that Quality is increased in a day by 2 for input [SellIn: {backstagePasses.SellIn}, Quality: {backstagePasses.Quality}]");
            backstagePasses.SellIn = 5;
            backstagePasses.Quality = 10;
            sut.UpdateQuality();
            Assert.AreEqual(4, backstagePasses.SellIn,
                $"It's expected that SellIn is decreased in a day by 1 for input [SellIn: {backstagePasses.SellIn}, Quality: {backstagePasses.Quality}]");
            Assert.AreEqual(13, backstagePasses.Quality,
                $"It's expected that Quality is increased in a day by 3 for input [SellIn: {backstagePasses.SellIn}, Quality: {backstagePasses.Quality}]");
            backstagePasses.SellIn = 0;
            backstagePasses.Quality = 10;
            sut.UpdateQuality();
            Assert.AreEqual(-1, backstagePasses.SellIn,
                $"It's expected that SellIn is decreased in a day by 1 for input [SellIn: {backstagePasses.SellIn}, Quality: {backstagePasses.Quality}]");
            Assert.AreEqual(0, backstagePasses.Quality,
                $"It's expected that Quality drops to 0 for input [SellIn: {backstagePasses.SellIn}, Quality: {backstagePasses.Quality}]");
        }

        [Test]
        public void Conjured()
        {
            conjured.SellIn = 3;
            conjured.Quality = 10;
            sut.UpdateQuality();
            Assert.AreEqual(2, conjured.SellIn,
                $"It's expected that SellIn is decreased in a day by 1 for input [SellIn: {conjured.SellIn}, Quality: {conjured.Quality}]");
            Assert.AreEqual(8, conjured.Quality,
                $"It's expected that Quality is decreased in a day by 2 for input [SellIn: {conjured.SellIn}, Quality: {conjured.Quality}]");
            conjured.SellIn = 0;
            conjured.Quality = 10;
            sut.UpdateQuality();
            Assert.AreEqual(-1, conjured.SellIn,
                $"It's expected that SellIn is decreased in a day by 1 for input [SellIn: {conjured.SellIn}, Quality: {conjured.Quality}]");
            Assert.AreEqual(6, conjured.Quality,
                $"It's expected that Quality is decreased in a day by 4 for input [SellIn: {conjured.SellIn}, Quality: {conjured.Quality}]");
            conjured.SellIn = 0;
            conjured.Quality = 0;
            sut.UpdateQuality();
            Assert.AreEqual(-1, conjured.SellIn,
                $"It's expected that SellIn is decreased in a day by 1 for input [SellIn: {conjured.SellIn}, Quality: {conjured.Quality}]");
            Assert.AreEqual(0, conjured.Quality,
                $"It's expected that Quality is not negative. Input [SellIn: {conjured.SellIn}, Quality: {conjured.Quality}]");
        }
    }
}
