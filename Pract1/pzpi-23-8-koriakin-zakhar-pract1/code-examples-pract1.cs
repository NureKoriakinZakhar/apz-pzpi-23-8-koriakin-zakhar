// 1. Сучасний Цільовий інтерфейс (Target)
public interface ITarget 
{
    string GetEmployeeDataJson();
}

// 2. Застаріла система (Adaptee)
public class LegacySystem 
{
    public string GetXmlData() 
    {
        Console.WriteLine("LegacySystem: Звернення до старої БД...");
        return "<employee><name>John Doe</name><role>Developer</role></employee>";
    }
}

// 3. Адаптер (Adapter)
public class XmlToJsonAdapter : ITarget 
{
    private readonly LegacySystem _legacySystem;

    public XmlToJsonAdapter(LegacySystem legacySystem) 
    {
        _legacySystem = legacySystem;
    }

    public string GetEmployeeDataJson() 
    {
        string xmlData = _legacySystem.GetXmlData();
        Console.WriteLine("Adapter: Конвертація XML у JSON...");
        
        // Імітація конвертації даних
        string jsonData = "{ \"employee\": { \"name\": \"John Doe\", \"role\": \"Developer\" } }";
        return jsonData;
    }
}

// 4. Клієнтський код (Client)
class Program 
{
    static void Main() 
    {
        // Створюємо об'єкт застарілої системи
        LegacySystem oldSystem = new LegacySystem();
        
        // Використовуємо адаптер для сумісності з новим інтерфейсом
        ITarget adapter = new XmlToJsonAdapter(oldSystem);

        // Клієнт працює через інтерфейс ITarget
        string result = adapter.GetEmployeeDataJson();
        Console.WriteLine($"Client отримав: {result}");
    }
}

/*
Запити до ШІ (Gemini 3.1 Pro):
- Наведи три реальні приклади із сучасної інженерної практики (наприклад, інтеграція різних платіжних шлюзів або робота із застарілими базами даних), де застосування патерна "Адаптер" є найбільш архітектурно виправданим рішенням.
- Згенеруй структурований теоретичний опис структурного шаблона проєктування "Адаптер" (Adapter) згідно з класифікацією GoF, включаючи його призначення, передумови застосування, ключові переваги та недоліки.
- Розроби приклад програмного коду мовою C#, який наочно демонструє класичну реалізацію патерна "Адаптер" (на прикладі конвертації даних з формату XML у JSON) для інтеграції у презентацію як доповнення до UML-діаграми.
- Додай детальні пояснювальні коментарі до розробленого C#-коду, щоб чітко розмежувати відповідальність кожного класу та продемонструвати дотримання Принципів єдиної відповідальності (SRP) та відкритості/закритості (OCP)
*/