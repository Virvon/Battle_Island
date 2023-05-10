using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Language : MonoBehaviour
{
    private void Start()
    {
        Lean.Localization.LeanLocalization.SetCurrentLanguageAll("English");
    }
}
