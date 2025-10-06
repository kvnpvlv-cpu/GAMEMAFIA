using UnityEngine;
using UnityEngine.UI;

public class SoundToggleUI : MonoBehaviour
{
    public Image soundOnButton;   // �������� ������ Sound On
    public Image soundOffButton;  // �������� ������ Sound Off

    public Color activeColor = Color.green;   // ���� �������� ������
    public Color inactiveColor = Color.white; // ���� ���������� ������

    private bool isSoundOn = true; // ������� ��������� �����

    void Start()
    {
        UpdateButtonColors(); // ��� ������� �������� ���������� �����
    }

    public void SetSoundOn()
    {
        isSoundOn = true;
        UpdateButtonColors();
        AudioListener.pause = false; // �������� ����
    }

    public void SetSoundOff()
    {
        isSoundOn = false;
        UpdateButtonColors();
        AudioListener.pause = true; // ��������� ����
    }

    private void UpdateButtonColors()
    {
        soundOnButton.color = isSoundOn ? activeColor : inactiveColor;
        soundOffButton.color = isSoundOn ? inactiveColor : activeColor;
    }
}
