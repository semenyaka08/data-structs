using DataStructure.Abstraction;

namespace DataStructure.Implementation;

public class DoublyLinkedCharacterList : BaseList
{
    private class Node(char data)
    {
        public readonly char Data = data;
        public Node? Next;
        public Node? Prev;
    }
    
    private Node? _head;
    private Node? _tail;
    private int _count;

    public override int Length()
    {
        return _count;
    }
    
    public override void Append(char element)
    {
        var newNode = new Node(element);
        
        if (_head == null)
        {
            _head = _tail = newNode;
        }
        else
        {
            _tail!.Next = newNode;
            newNode.Prev = _tail;
            _tail = newNode;
        }
        _count++;
    }
    
    public override void Insert(char element, int index)
    {
        if (index < 0 || index > _count)
            throw new ArgumentOutOfRangeException(nameof(index), "Invalid index for insertion");
        
        if (index == _count)
        {
            Append(element);
            return;
        }
        
        Node newNode = new Node(element);
        
        if (index == 0)
        {
            if (_head == null)
            {
                _head = _tail = newNode;
            }
            else
            {
                newNode.Next = _head;
                _head.Prev = newNode;
                _head = newNode;
            }
        }
        else
        {
            Node current = GetNodeAt(index);
            newNode.Next = current;
            newNode.Prev = current.Prev;
            current.Prev!.Next = newNode;
            current.Prev = newNode;
        }
        _count++;
    }
    
    public override char Delete(int index)
    {
        if (index < 0 || index >= _count)
            throw new ArgumentOutOfRangeException(nameof(index), "Invalid index for deletion");
        
        var nodeToDelete = GetNodeAt(index);
        var deletedValue = nodeToDelete.Data;
        
        if (_count == 1)
        {
            _head = _tail = null;
        }
        else if (nodeToDelete == _head)
        {
            _head = _head.Next;
            _head!.Prev = null;
        }
        else if (nodeToDelete == _tail)
        {
            _tail = _tail.Prev;
            _tail!.Next = null;
        }
        else
        {
            nodeToDelete.Prev!.Next = nodeToDelete.Next;
            nodeToDelete.Next!.Prev = nodeToDelete.Prev;
        }
        
        _count--;
        return deletedValue;
    }
    
    public override void DeleteAll(char element)
    {
        var current = _head;

        while (current != null)
        {
            var next = current.Next;

            if (current.Data == element)
            {
                if (current == _head && current == _tail)
                {
                    _head = _tail = null;
                }
                else if (current == _head)
                {
                    _head = _head.Next;
                    if (_head != null)
                        _head.Prev = null;
                }
                else if (current == _tail)
                {
                    _tail = _tail.Prev;
                    if (_tail != null)
                        _tail.Next = null;
                }
                else
                {
                    current.Prev!.Next = current.Next;
                    current.Next!.Prev = current.Prev;
                }

                _count--;
            }

            current = next;
        }
    }
    
    public override char GetDataAt(int index)
    {
        if (index < 0 || index >= _count)
            throw new ArgumentOutOfRangeException(nameof(index), "Invalid index to retrieve element");
        
        return GetNodeAt(index).Data;
    }
    
    public override BaseList Clone()
    {
        var clone = new DoublyLinkedCharacterList();
        var current = _head;
        
        while (current != null)
        {
            clone.Append(current.Data);
            current = current.Next;
        }
        
        return clone;
    }
    
    public override void Reverse()
    {
        if (_count <= 1) return;

        var current = _head;
        Node? temp = null;

        while (current != null)
        {
            temp = current.Prev;
            current.Prev = current.Next;
            current.Next = temp;
            current = current.Prev;
        }

        if (temp != null)
        {
            _tail = _head;
            _head = temp.Prev!;
        }
    }
    
    public override int FindFirst(char element)
    {
        var current = _head;
        int index = 0;
        
        while (current != null)
        {
            if (current.Data == element)
                return index;
            current = current.Next;
            index++;
        }
        
        return -1;
    }
    
    public override int FindLast(char element)
    {
        var current = _tail;
        int index = _count - 1;
        
        while (current != null)
        {
            if (current.Data == element)
                return index;
            current = current.Prev;
            index--;
        }
        
        return -1;
    }
    
    public override void Clear()
    {
        _head = _tail = null;
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
        var current = _head;
        bool first = true;
        
        while (current != null)
        {
            if (!first) Console.Write(", ");
            Console.Write($"'{current.Data}'");
            current = current.Next;
            first = false;
        }
        Console.WriteLine("]");
    }
    
    private Node GetNodeAt(int index)
    {
        Node current;
        
        if (index < _count / 2)
        {
            current = _head!;
            for (int i = 0; i < index; i++)
                current = current.Next!;
        }
        else
        {
            current = _tail!;
            for (int i = _count - 1; i > index; i--)
                current = current.Prev!;
        }
        
        return current;
    }
}