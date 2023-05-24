using UnityEngine;

public class Language : MonoBehaviour
{
    private void Start()
    {
        var language = Application.systemLanguage;

        Debug.Log(language + " | " + language.ToString());

        Lean.Localization.LeanLocalization.SetCurrentLanguageAll(language.ToString());
    }
}
