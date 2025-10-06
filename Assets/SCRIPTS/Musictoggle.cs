using UnityEngine;
using UnityEngine.UI;

public class MusicToggleUI : MonoBehaviour
{
    public Image musicOnButton;   // Кнопка Music On
    public Image musicOffButton;  // Кнопка Music Off

    public Color activeColor = Color.green;   // Активная кнопка
    public Color inactiveColor = Color.white; // Неактивная кнопка

    private bool isMusicOn = true; // Включена ли музыка

    void Start()
    {
        UpdateButtonColors();
    }

    public void SetMusicOn()
    {
        isMusicOn = true;
        UpdateButtonColors();
        // Тут можно включить музыку (например через AudioSource)
        AudioListener.pause = false;
    }

    public void SetMusicOff()
    {
        isMusicOn = false;
        UpdateButtonColors();
        // Тут можно выключить музыку
        AudioListener.pause = true;
    }

    private void UpdateButtonColors()
    {
        musicOnButton.color = isMusicOn ? activeColor : inactiveColor;
        musicOffButton.color = isMusicOn ? inactiveColor : activeColor;
    }
}
