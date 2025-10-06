using UnityEngine;
using UnityEngine.UI;

public class MusicToggleUI : MonoBehaviour
{
    public Image musicOnButton;   // ������ Music On
    public Image musicOffButton;  // ������ Music Off

    public Color activeColor = Color.green;   // �������� ������
    public Color inactiveColor = Color.white; // ���������� ������

    private bool isMusicOn = true; // �������� �� ������

    void Start()
    {
        UpdateButtonColors();
    }

    public void SetMusicOn()
    {
        isMusicOn = true;
        UpdateButtonColors();
        // ��� ����� �������� ������ (�������� ����� AudioSource)
        AudioListener.pause = false;
    }

    public void SetMusicOff()
    {
        isMusicOn = false;
        UpdateButtonColors();
        // ��� ����� ��������� ������
        AudioListener.pause = true;
    }

    private void UpdateButtonColors()
    {
        musicOnButton.color = isMusicOn ? activeColor : inactiveColor;
        musicOffButton.color = isMusicOn ? inactiveColor : activeColor;
    }
}
