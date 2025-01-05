using Unity.VisualScripting;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player; // ������ �� ������ ������ (���)
    public float mouseSensitivity = 5f; // ���������������� ����
    public float maxRotationX = 60f; // ������������ ���� ������� ������
    public float minRotationX = -60f; // ����������� ���� ������� ������

    private float rotationX = 0f;
    private float rotationY = 0f;

    void Update()
    {
        RotateCamera();
    }

    void RotateCamera()
    {
        // �������� �������� ���� �� ���� X � Y
        rotationX -= Input.GetAxis("Mouse Y") * mouseSensitivity; // �������� �� ��������� (�����/����)
        rotationX = Mathf.Clamp(rotationX, minRotationX, maxRotationX); // ������������ �������

        rotationY += Input.GetAxis("Mouse X") * mouseSensitivity; // �������� �� ����������� (�����/�����)

        // ��������� �������� �� ������ (������)
        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0);
    }
}