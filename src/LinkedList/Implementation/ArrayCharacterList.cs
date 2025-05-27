using LinkedList.Abstraction;

namespace LinkedList.Implementation;

public class ArrayCharacterList : BaseList
{
    private char[] _array;
    private int _count;
    private int _capacity;
    
    public ArrayCharacterList()
    {
        _capacity = 4;
        _array = new char[_capacity];
        _count = 0;
    }
    
    public override int Length()
    {
        return _count;
    }
    
    public override void Append(char element)
    {
        EnsureCapacity();
        _array[_count] = element;
        _count++;
    }
    
    public override void Insert(char element, int index)
    {
        if (index < 0 || index > _count)
            throw new ArgumentOutOfRangeException(nameof(index), "Invalid index for insertion");
        
        EnsureCapacity();
        
        for (int i = _count; i > index; i--)
        {
            _array[i] = _array[i - 1];
        }
        
        _array[index] = element;
        _count++;
    }
    
    public override char Delete(int index)
    {
        if (index < 0 || index >= _count)
            throw new ArgumentOutOfRangeException(nameof(index), "Invalid index for deletion");
        
        var deletedValue = _array[index];
        
        for (int i = index; i < _count - 1; i++)
        {
            _array[i] = _array[i + 1];
        }
        
        _count--;
        return deletedValue;
    }
    
    public override void DeleteAll(char element)
    {
        int writeIndex = 0;
        
        for (int readIndex = 0; readIndex < _count; readIndex++)
        {
            if (_array[readIndex] != element)
            {
                _array[writeIndex] = _array[readIndex];
                writeIndex++;
            }
        }
        
        _count = writeIndex;
    }
    
    public override char GetDataAt(int index)
    {
        if (index < 0 || index >= _count)
            throw new ArgumentOutOfRangeException(nameof(index), "Invalid index for getting element");
        
        return _array[index];
    }
    
    public override BaseList Clone()
    {
        var clone = new ArrayCharacterList
        {
            _capacity = this._capacity,
            _array = new char[this._capacity],
            _count = this._count
        };

        for (int i = 0; i < _count; i++)
        {
            clone._array[i] = this._array[i];
        }
        
        return clone;
    }
    
    public override void Reverse()
    {
        for (int i = 0; i < _count / 2; i++)
        {
            (_array[i], _array[_count - 1 - i]) = (_array[_count - 1 - i], _array[i]);
        }
    }
    
    public override int FindFirst(char element)
    {
        for (int i = 0; i < _count; i++)
        {
            if (_array[i] == element)
                return i;
        }
        return -1;
    }
    
    public override int FindLast(char element)
    {
        for (int i = _count - 1; i >= 0; i--)
        {
            if (_array[i] == element)
                return i;
        }
        return -1;
    }
    
    public override void Clear()
    {
        _count = 0;
    }
    
    public override void Extend(BaseList elements)
    {
        for (int i = 0; i < elements.Length(); i++)
        {
            Append(elements.GetDataAt(i));
        }
    }
    
    public override void Display()
    {
        Console.Write("[");
        for (int i = 0; i < _count; i++)
        {
            if (i > 0) Console.Write(", ");
            Console.Write($"'{_array[i]}'");
        }
        Console.WriteLine("]");
    }
    
    private void EnsureCapacity()
    {
        if (_count >= _capacity)
        {
            _capacity *= 2;
            char[] newArray = new char[_capacity];
            
            for (int i = 0; i < _count; i++)
            {
                newArray[i] = _array[i];
            }
            
            _array = newArray;
        }
    }
}