namespace DataStructure.Abstraction;

public abstract class BaseList
{
    public abstract int Length();
    public abstract void Append(char element);
    public abstract void Insert(char element, int index);
    public abstract char Delete(int index);
    public abstract void DeleteAll(char element);
    public abstract char GetDataAt(int index);
    public abstract BaseList Clone();
    public abstract void Reverse();
    public abstract int FindFirst(char element);
    public abstract int FindLast(char element);
    public abstract void Clear();
    public abstract void Extend(BaseList elements);
    public abstract void Display();
}