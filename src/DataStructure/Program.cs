using DataStructure.Abstraction;
using DataStructure.Implementation;

namespace DataStructure;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("=== Лабораторна робота: Типізований список символів ===\n");
        
        // Демонстрація двобічно зв'язаного списку
        Console.WriteLine("1. ДЕМОНСТРАЦІЯ ДВОБІЧНО ЗВ'ЯЗАНОГО СПИСКУ:");
        Console.WriteLine("=" + new string('=', 50));
        DemonstrateList(new DoublyLinkedCharacterList(), "Двобічно зв'язаний список");
        
        Console.WriteLine("\n" + new string('=', 60) + "\n");
        
        // Демонстрація списку на базі масиву
        Console.WriteLine("2. ДЕМОНСТРАЦІЯ СПИСКУ НА БАЗІ МАСИВУ:");
        Console.WriteLine("=" + new string('=', 50));
        DemonstrateList(new ArrayCharacterList(), "Список на базі масиву");
        
        Console.WriteLine("\n=== Кінець демонстрації ===");
        Console.WriteLine("Натисніть будь-яку клавішу для завершення...");
        Console.ReadKey();
    }
    
    private static void DemonstrateList(BaseList list, string listType)
    {
        Console.WriteLine($"Тип списку: {listType}\n");
        
        try
        {
            // 1. Перевірка довжини порожнього списку
            Console.WriteLine("1. Перевірка довжини порожнього списку:");
            Console.WriteLine($"   Довжина: {list.Length()}");
            list.Display();
            
            // 2. Додавання елементів в кінець
            Console.WriteLine("\n2. Додавання елементів (append):");
            char[] elementsToAdd = {'H', 'e', 'l', 'l', 'o'};
            foreach (char c in elementsToAdd)
            {
                list.Append(c);
                Console.WriteLine($"   Додано '{c}', довжина: {list.Length()}");
            }
            Console.Write("   Результат: ");
            list.Display();
            
            // 3. Вставка елементів
            Console.WriteLine("\n3. Вставка елементів (insert):");
            list.Insert('!', 0); // На початок
            Console.WriteLine("   Вставлено '!' на позицію 0");
            list.Insert(' ', 6); // В середину
            Console.WriteLine("   Вставлено ' ' на позицію 6");
            list.Insert('K', list.Length()); // В кінець
            Console.WriteLine("   Вставлено 'K' в кінець");
            Console.Write("   Результат: ");
            list.Display();
            
            // 4. Отримання елементів
            Console.WriteLine("\n4. Отримання елементів (get):");
            for (int i = 0; i < Math.Min(list.Length(), 5); i++)
            {
                Console.WriteLine($"   Елемент на позиції {i}: '{list.GetDataAt(i)}'");
            }
            
            // 5. Пошук елементів
            Console.WriteLine("\n5. Пошук елементів:");
            char searchChar = 'l';
            int firstIndex = list.FindFirst(searchChar);
            int lastIndex = list.FindLast(searchChar);
            Console.WriteLine($"   Перше входження '{searchChar}': {firstIndex}");
            Console.WriteLine($"   Останнє входження '{searchChar}': {lastIndex}");

            // 6. Клонування
            Console.WriteLine("\n6. Клонування списку:");
            var clonedList = list.Clone();
            Console.Write("   Оригінал: ");
            list.Display();
            Console.Write("   Клон: ");
            clonedList.Display();
            
            // 7. Обернення
            Console.WriteLine("\n7. Обернення списку:");
            Console.Write("   До обернення: ");
            list.Display();
            list.Reverse();
            Console.Write("   Після обернення: ");
            list.Display();
            
            // 8. Видалення за індексом
            Console.WriteLine("\n8. Видалення елементів за індексом:");
            if (list.Length() > 0)
            {
                char deleted = list.Delete(0);
                Console.WriteLine($"   Видалено елемент на позиції 0: '{deleted}'");
                Console.Write("   Результат: ");
                list.Display();
            }
            
            // 9. Розширення списку
            Console.WriteLine("\n9. Розширення списку (extend):");
            var extensionList = new DoublyLinkedCharacterList();
            extensionList.Append('W');
            extensionList.Append('o');
            extensionList.Append('r');
            extensionList.Append('l');
            extensionList.Append('d');
            
            Console.Write("   Список для розширення: ");
            extensionList.Display();
            
            list.Extend(extensionList);
            Console.Write("   Після розширення: ");
            list.Display();
            
            // 10. Видалення всіх входжень
            Console.WriteLine("\n10. Видалення всіх входжень символу:");
            list.Append('l'); // Додаємо ще один 'l' для демонстрації
            list.Append('l');
            Console.Write("    До видалення: ");
            list.Display();
            
            list.DeleteAll('l');
            Console.WriteLine("    Видалено всі входження 'l'");
            Console.Write("    Після видалення: ");
            list.Display();
            
            // 11. Очищення списку
            Console.WriteLine("\n11. Очищення списку:");
            Console.WriteLine($"    Довжина до очищення: {list.Length()}");
            list.Clear();
            Console.WriteLine($"    Довжина після очищення: {list.Length()}");
            Console.Write("    Результат: ");
            list.Display();
            
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
        
        // 12. Демонстрація обробки помилок
        Console.WriteLine("\n12. Демонстрація обробки помилок:");
        try
        {
            list.GetDataAt(10); // Некоректний індекс
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($" Перехоплено помилку: {ex.Message}");
        }
        
        try
        {
            list.Insert('X', -1); // Некоректний індекс
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"    Перехоплено помилку: {ex.Message}");
        }
    }
}