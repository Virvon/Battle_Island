using Agava.WebUtility;
using UnityEngine;

public class InBackgroundRunner : MonoBehaviour
{
    private void OnEnable() => WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;

    private void OnDisable() => WebApplication.InBackgroundChangeEvent -= OnInBackgroundChange;

    private void OnInBackgroundChange(bool inBackground)
    {
        AudioListener.pause = inBackground;
        AudioListener.volume = inBackground ? 0 : 1;

        Time.timeScale = inBackground ? 0 : 1;
    }

    private void OnApplicationFocus(bool focus)
    {
        AudioListener.pause = !focus;
        AudioListener.volume = focus ? 1 : 0;

        Time.timeScale = focus ? 1 : 0;
    }
}
