using System.Text;
using UnityEngine;

public static class NamesGenerator
{
    private static string[] _names = new string[] { "Urhagha", "Kelas", "Ysicha", "Grilliaba", "Toneer", "Abianamir", "Uncyronand", "July", "Lli", "Filff", "Iusett", "Miyannyse",
                                                     "Oveoniabe", "Tamikora", "Zono", "Nnteb", "Kainane", "Korryd", "Jeam", "Nanekoa", "Malam", "Zen", "Xtombal", "Roch", "Renimi",
                                                     "Terleighna", "Wenid", "Fimaerur"
                                                   };

    public static string GetName()
    {
        return _names[Random.Range(0, _names.Length)];
    }
}
