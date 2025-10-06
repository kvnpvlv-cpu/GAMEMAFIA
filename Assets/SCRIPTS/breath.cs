using UnityEngine;

public class Breathing : MonoBehaviour
{
    public float speed = 2f;       // �������� �������
    public float scaleAmount = 0.05f; // ��������� ������ ���������� ������

    private Vector3 startScale;

    void Start()
    {
        startScale = transform.localScale;
    }

    void Update()
    {
        float scale = 1 + Mathf.Sin(Time.time * speed) * scaleAmount;
        transform.localScale = new Vector3(startScale.x, startScale.y * scale, startScale.z);
    }
}
