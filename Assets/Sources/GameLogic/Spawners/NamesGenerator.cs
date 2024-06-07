using System.Collections.Generic;
using UnityEngine;

public static class NamesGenerator
{
    private static string[] _englishNames = new string[] { "Oliver", "Jack", "Harry", "Jacob", "Charley", "Thomas", "George", "Walter", "Oscar", "Filff", "Wade", "Dave",
                                                     "Seth", "Ivan", "Riley", "Gilbert", "Jorge", "Dan", "Brian", "Roberto", "Ramon", "Miles", "Liam", "Nathaniel", "Ethan",
                                                     "Lewis", "Milton", "Joshua"
                                                   };

    private static string[] _russianNames = new string[] { "Федя", "Петр", "Кирилл", "Маша", "Алексей", "Ирина", "Витя", "Юля", "Дмитрий", "Вадим", "Радомир", "Рада",
                                                     "София", "Валя", "Ева", "Кира", "Антон", "Аня", "Артем", "Влада", "Давид", "Богуслав", "Богумил", "Егор", "Катя",
                                                     "Зина", "Надежда", "Миша"
                                                   };

    private static string[] _turkiyeNames = new string[] { "Abdullah", "Abdurrahman", "Ahmet", "Ali", "Bekir", "Ayse", "Fatma", "Dag", "Hatice", "Mehmet", "Mustafa", "Ramazan",
                                                     "Gok", "Deniz", "Aynur", "Gun", "Yildiz", "Pinar", "Meric", "Tuna", "Dicle", "Firat", "Yildirim", "Senay", "Koray",
                                                     "Gunes"
                                                   };

    private static Dictionary<string, string[]> _names = new Dictionary<string, string[]> {
        { "Russian", _russianNames},
        { "English", _englishNames},
        { "Turkiye", _turkiyeNames}
    };

    public static string GetName()
    {
        string[] names = _names[Lean.Localization.LeanLocalization.GetFirstCurrentLanguage()];

        return names[Random.Range(0, names.Length)];
    }
}
