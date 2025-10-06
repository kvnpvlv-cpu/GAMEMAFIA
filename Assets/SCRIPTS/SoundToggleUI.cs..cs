using UnityEngine;
using UnityEngine.UI;

public class SoundToggleUI : MonoBehaviour
{
    public Image soundOnButton;   // Картинка кнопки Sound On
    public Image soundOffButton;  // Картинка кнопки Sound Off

    public Color activeColor = Color.green;   // Цвет активной кнопки
    public Color inactiveColor = Color.white; // Цвет неактивной кнопки

    private bool isSoundOn = true; // Текущее состояние звука

    void Start()
    {
        UpdateButtonColors(); // При запуске выставим правильные цвета
    }

    public void SetSoundOn()
    {
        isSoundOn = true;
        UpdateButtonColors();
        AudioListener.pause = false; // Включаем звук
    }

    public void SetSoundOff()
    {
        isSoundOn = false;
        UpdateButtonColors();
        AudioListener.pause = true; // Выключаем звук
    }

    private void UpdateButtonColors()
    {
        soundOnButton.color = isSoundOn ? activeColor : inactiveColor;
        soundOffButton.color = isSoundOn ? inactiveColor : activeColor;
    }
}
