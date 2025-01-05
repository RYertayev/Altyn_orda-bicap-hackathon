using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 8f; // �������� �������� ���� ������
    public float strafeSpeed = 3f; // �������� �������� ����� � ������
    public float rotationSpeed = 100f; // �������� �������� ������
    public float maxRotationX = 60f; // ������������ ���� �������� �� ��� X
    public float minRotationX = -60f; // ����������� ���� �������� �� ��� X

    private Rigidbody rb;
    private float rotationX;
    private float rotationY;
    public Collection collection;
    private bool isRun = true;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MoveCube();
        if (collection.slider.value <= 0)
        {
            isRun = false;
        }
    }

    void MoveCube()
    {
        if (isRun)
        {
            // �������� ���� ������ �� �����������, ���� ������� ������
            Vector3 forwardMovement = transform.forward * moveSpeed * Time.deltaTime;
            rb.MovePosition(rb.position + forwardMovement);

            // �������� ���� ����� � ������
            float horizontalInput = Input.GetAxis("Horizontal"); // A � D
            Vector3 strafeMovement = transform.right * horizontalInput * strafeSpeed * Time.deltaTime * 3;
            rb.MovePosition(rb.position + strafeMovement);
        }
    }

    
}
