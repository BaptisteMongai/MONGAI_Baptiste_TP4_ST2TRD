using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void Should_Increase_Quality_Of_Aged_Brie_By_One_Before_SellIn_When_Day_Passes()
        {
            // Arrange
            var brie = new Item {Name = "Aged Brie", SellIn = 1, Quality = 0};
            IList<Item> Items = new List<Item> {brie};
            GildedRose app = new GildedRose(Items);
            
            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(brie.Quality, 1);
        }
        
        [Test]
        public void Should_Increase_Quality_Of_Aged_Brie_By_Two_After_SellIn_When_Day_Passes()
        {
            // Arrange
            var brie = new Item {Name = "Aged Brie", SellIn = 0, Quality = 0};
            IList<Item> Items = new List<Item> {brie};
            GildedRose app = new GildedRose(Items);
            
            // Act
            app.UpdateQuality(); 
            
            // Assert
            Assert.AreEqual(brie.Quality, 2);
        }
        
        [Test]
        public void Should_Quality_Of_Sulfuras_Not_Change_When_Day_Passes()
        {
            // Arrange
            var sulfuras = new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 1, Quality = 80};
            IList<Item> Items = new List<Item> {sulfuras};
            GildedRose app = new GildedRose(Items);
            
            // Act
            app.UpdateQuality(); 
            
            // Assert
            Assert.AreEqual(sulfuras.Quality, 80);
        }
        
        [Test]
        public void Should_SellIn_Of_Sulfuras_Not_Change_When_Day_Passes()
        {
            // Arrange
            var sulfuras = new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 1, Quality = 80};
            IList<Item> Items = new List<Item> {sulfuras};
            GildedRose app = new GildedRose(Items);
            
            // Act
            app.UpdateQuality(); 
            
            // Assert
            Assert.AreEqual(sulfuras.SellIn, 1);
        }
        
        [Test]
        public void Should_Quality_Of_Backstage_Passes_Increase_By_One_When_Day_Passes_And_SellIn_Higher_Than_Ten()
        {
            // Arrange
            var backstage = new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 0};
            IList<Item> Items = new List<Item> {backstage};
            GildedRose app = new GildedRose(Items);
            
            // Act
            app.UpdateQuality(); 
            
            // Assert
            Assert.AreEqual(backstage.Quality, 1);
        }
        
        [Test]
        public void Should_Quality_Of_Backstage_Passes_Increase_By_Two_When_Day_Passes_And_SellIn_Between_Five_And_Ten()
        {
            // Arrange
            var backstage = new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 8, Quality = 0};
            IList<Item> Items = new List<Item> {backstage};
            GildedRose app = new GildedRose(Items);
            
            // Act
            app.UpdateQuality(); 
            
            // Assert
            Assert.AreEqual(backstage.Quality, 2);
        }
        
        [Test]
        public void Should_Quality_Of_Backstage_Passes_Increase_By_Three_When_Day_Passes_And_SellIn_Lower_Than_Five()
        {
            // Arrange
            var backstage = new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 0};
            IList<Item> Items = new List<Item> {backstage};
            GildedRose app = new GildedRose(Items);
            
            // Act
            app.UpdateQuality(); 
            
            // Assert
            Assert.AreEqual(backstage.Quality, 3);
        }
        [Test]
        public void Should_Quality_Of_Backstage_Passes_Drop_To_Zero_When_SellIn_Lower_Than_Zero()
        {
            // Arrange
            var backstage = new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 50};
            IList<Item> Items = new List<Item> {backstage};
            GildedRose app = new GildedRose(Items);
            
            // Act
            app.UpdateQuality(); 
            
            // Assert
            Assert.AreEqual(backstage.Quality, 0);
        }
        [Test]
        public void Quality_Never_Higher_Than_Fifty()
        {
            // Arrange
            var backstage = new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 49};
            var brie = new Item {Name = "Aged Brie", SellIn = -5, Quality = 49};
            IList<Item> Items = new List<Item>{backstage, brie};
            GildedRose app = new GildedRose(Items);
            
            // Act
            app.UpdateQuality(); 
            
            // Assert
            Assert.AreEqual(backstage.Quality, 50);
            Assert.AreEqual(brie.Quality, 50);
        }
        
        [Test]
        public void Quality_Never_Lower_Than_Zero()
        {
            // Arrange
            var randomObject = new Item {Name = "Random object", SellIn = -2, Quality = 0};
            var conjuredObject = new Item {Name = "Random Conjured object", SellIn = -2, Quality = 1};
            IList<Item> Items = new List<Item>{randomObject, conjuredObject};
            GildedRose app = new GildedRose(Items);
            
            // Act
            app.UpdateQuality(); 
            
            // Assert
            Assert.AreEqual(randomObject.Quality, 0);
            Assert.AreEqual(conjuredObject.Quality, 0);
        }
        
        //This Test doesn't work now but it is normal, after part 3 it will work.
        [Test]
        public void Should_Quality_Of_Object_Decrease_Two_Times_Faster_For_A_Conjured_Object_When_Day_Passes()
        {
            // Arrange
            var conjuredObject = new Item {Name = "Conjured object", SellIn = 4, Quality = 10};
            IList<Item> Items = new List<Item> {conjuredObject};
            GildedRose app = new GildedRose(Items);
            
            // Act
            app.UpdateQuality(); 
            
            // Assert
            Assert.AreEqual(conjuredObject.Quality, 8);
        }
        
    }
}
