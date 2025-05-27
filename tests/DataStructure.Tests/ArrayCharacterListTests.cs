using DataStructure.Implementation;

namespace DataStructure.Tests;

public class ArrayCharacterListTests
    {
        [Fact]
        public void Constructor_InitializesEmptyList()
        {
            // Arrange & Act
            var list = new ArrayCharacterList();
            
            // Assert
            Assert.Equal(0, list.Length());
        }
        
        [Fact]
        public void Append_SingleElement_IncreasesLengthAndAddsElement()
        {
            // Arrange
            var list = new ArrayCharacterList();
            
            // Act
            list.Append('a');
            
            // Assert
            Assert.Equal(1, list.Length());
            Assert.Equal('a', list.GetDataAt(0));
        }
        
        [Fact]
        public void Append_MultipleElements_AddsInCorrectOrder()
        {
            // Arrange
            var list = new ArrayCharacterList();
            
            // Act
            list.Append('a');
            list.Append('b');
            list.Append('c');
            
            // Assert
            Assert.Equal(3, list.Length());
            Assert.Equal('a', list.GetDataAt(0));
            Assert.Equal('b', list.GetDataAt(1));
            Assert.Equal('c', list.GetDataAt(2));
        }
        
        [Fact]
        public void Append_MoreThanInitialCapacity_GrowsArrayCorrectly()
        {
            // Arrange
            var list = new ArrayCharacterList();
            
            // Act - Add more than initial capacity of 4
            for (int i = 0; i < 10; i++)
            {
                list.Append((char)('a' + i));
            }
            
            // Assert
            Assert.Equal(10, list.Length());
            for (int i = 0; i < 10; i++)
            {
                Assert.Equal((char)('a' + i), list.GetDataAt(i));
            }
        }
        
        [Theory]
        [InlineData(0, 'x')]
        [InlineData(1, 'y')]
        [InlineData(2, 'z')]
        public void Insert_AtValidIndex_InsertsCorrectly(int index, char element)
        {
            // Arrange
            var list = new ArrayCharacterList();
            list.Append('a');
            list.Append('b');
            list.Append('c');
            
            // Act
            list.Insert(element, index);
            
            // Assert
            Assert.Equal(4, list.Length());
            Assert.Equal(element, list.GetDataAt(index));
        }
        
        [Fact]
        public void Insert_AtEnd_BehavesLikeAppend()
        {
            // Arrange
            var list = new ArrayCharacterList();
            list.Append('a');
            list.Append('b');
            
            // Act
            list.Insert('c', 2);
            
            // Assert
            Assert.Equal(3, list.Length());
            Assert.Equal('c', list.GetDataAt(2));
        }
        
        [Theory]
        [InlineData(-1)]
        [InlineData(4)]
        public void Insert_AtInvalidIndex_ThrowsArgumentOutOfRangeException(int invalidIndex)
        {
            // Arrange
            var list = new ArrayCharacterList();
            list.Append('a');
            list.Append('b');
            list.Append('c');
            
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => list.Insert('x', invalidIndex));
        }
        
        [Fact]
        public void Delete_ValidIndex_RemovesAndReturnsElement()
        {
            // Arrange
            var list = new ArrayCharacterList();
            list.Append('a');
            list.Append('b');
            list.Append('c');
            
            // Act
            char deleted = list.Delete(1);
            
            // Assert
            Assert.Equal('b', deleted);
            Assert.Equal(2, list.Length());
            Assert.Equal('a', list.GetDataAt(0));
            Assert.Equal('c', list.GetDataAt(1));
        }
        
        [Theory]
        [InlineData(-1)]
        [InlineData(3)]
        public void Delete_InvalidIndex_ThrowsArgumentOutOfRangeException(int invalidIndex)
        {
            // Arrange
            var list = new ArrayCharacterList();
            list.Append('a');
            list.Append('b');
            list.Append('c');
            
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => list.Delete(invalidIndex));
        }
        
        [Fact]
        public void DeleteAll_ExistingElements_RemovesAllOccurrences()
        {
            // Arrange
            var list = new ArrayCharacterList();
            list.Append('a');
            list.Append('b');
            list.Append('a');
            list.Append('c');
            list.Append('a');
            
            // Act
            list.DeleteAll('a');
            
            // Assert
            Assert.Equal(2, list.Length());
            Assert.Equal('b', list.GetDataAt(0));
            Assert.Equal('c', list.GetDataAt(1));
        }
        
        [Fact]
        public void DeleteAll_NonExistingElement_DoesNothing()
        {
            // Arrange
            var list = new ArrayCharacterList();
            list.Append('a');
            list.Append('b');
            list.Append('c');
            
            // Act
            list.DeleteAll('x');
            
            // Assert
            Assert.Equal(3, list.Length());
        }
        
        [Theory]
        [InlineData(-1)]
        [InlineData(3)]
        public void GetDataAt_InvalidIndex_ThrowsArgumentOutOfRangeException(int invalidIndex)
        {
            // Arrange
            var list = new ArrayCharacterList();
            list.Append('a');
            list.Append('b');
            list.Append('c');
            
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => list.GetDataAt(invalidIndex));
        }
        
        [Fact]
        public void Clone_CreatesIndependentCopy()
        {
            // Arrange
            var original = new ArrayCharacterList();
            original.Append('a');
            original.Append('b');
            original.Append('c');
            
            // Act
            var clone = (ArrayCharacterList)original.Clone();
            clone.Append('d');
            
            // Assert
            Assert.Equal(3, original.Length());
            Assert.Equal(4, clone.Length());
            Assert.Equal('a', clone.GetDataAt(0));
            Assert.Equal('b', clone.GetDataAt(1));
            Assert.Equal('c', clone.GetDataAt(2));
            Assert.Equal('d', clone.GetDataAt(3));
        }
        
        [Fact]
        public void Reverse_EvenNumberOfElements_ReversesCorrectly()
        {
            // Arrange
            var list = new ArrayCharacterList();
            list.Append('a');
            list.Append('b');
            list.Append('c');
            list.Append('d');
            
            // Act
            list.Reverse();
            
            // Assert
            Assert.Equal('d', list.GetDataAt(0));
            Assert.Equal('c', list.GetDataAt(1));
            Assert.Equal('b', list.GetDataAt(2));
            Assert.Equal('a', list.GetDataAt(3));
        }
        
        [Fact]
        public void Reverse_OddNumberOfElements_ReversesCorrectly()
        {
            // Arrange
            var list = new ArrayCharacterList();
            list.Append('a');
            list.Append('b');
            list.Append('c');
            
            // Act
            list.Reverse();
            
            // Assert
            Assert.Equal('c', list.GetDataAt(0));
            Assert.Equal('b', list.GetDataAt(1));
            Assert.Equal('a', list.GetDataAt(2));
        }
        
        [Fact]
        public void FindFirst_ExistingElement_ReturnsCorrectIndex()
        {
            // Arrange
            var list = new ArrayCharacterList();
            list.Append('a');
            list.Append('b');
            list.Append('a');
            list.Append('c');
            
            // Act
            int index = list.FindFirst('a');
            
            // Assert
            Assert.Equal(0, index);
        }
        
        [Fact]
        public void FindFirst_NonExistingElement_ReturnsMinusOne()
        {
            // Arrange
            var list = new ArrayCharacterList();
            list.Append('a');
            list.Append('b');
            list.Append('c');
            
            // Act
            int index = list.FindFirst('x');
            
            // Assert
            Assert.Equal(-1, index);
        }
        
        [Fact]
        public void FindLast_ExistingElement_ReturnsCorrectIndex()
        {
            // Arrange
            var list = new ArrayCharacterList();
            list.Append('a');
            list.Append('b');
            list.Append('a');
            list.Append('c');
            
            // Act
            int index = list.FindLast('a');
            
            // Assert
            Assert.Equal(2, index);
        }
        
        [Fact]
        public void FindLast_NonExistingElement_ReturnsMinusOne()
        {
            // Arrange
            var list = new ArrayCharacterList();
            list.Append('a');
            list.Append('b');
            list.Append('c');
            
            // Act
            int index = list.FindLast('x');
            
            // Assert
            Assert.Equal(-1, index);
        }
        
        [Fact]
        public void Clear_RemovesAllElements()
        {
            // Arrange
            var list = new ArrayCharacterList();
            list.Append('a');
            list.Append('b');
            list.Append('c');
            
            // Act
            list.Clear();
            
            // Assert
            Assert.Equal(0, list.Length());
        }
        
        [Fact]
        public void Extend_WithAnotherList_AddsAllElements()
        {
            // Arrange
            var list1 = new ArrayCharacterList();
            list1.Append('a');
            list1.Append('b');
            
            var list2 = new ArrayCharacterList();
            list2.Append('c');
            list2.Append('d');
            
            // Act
            list1.Extend(list2);
            
            // Assert
            Assert.Equal(4, list1.Length());
            Assert.Equal('a', list1.GetDataAt(0));
            Assert.Equal('b', list1.GetDataAt(1));
            Assert.Equal('c', list1.GetDataAt(2));
            Assert.Equal('d', list1.GetDataAt(3));
        }
    }