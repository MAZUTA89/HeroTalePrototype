using UnityEngine;

public class CameraSetup : MonoBehaviour
{
    public Camera mainCamera;

    void Start()
    {
        // ���������, ��� ������ ��������� ���������
        mainCamera.orthographicSize = Screen.height / 100f;

        // ��������� �������� � ����������� �� ����������
        foreach (var sprite in FindObjectsOfType<SpriteRenderer>())
        {
            sprite.transform.localScale = new Vector3(Screen.width / 800, Screen.height / 600f, 1f);
        }
    }
}
