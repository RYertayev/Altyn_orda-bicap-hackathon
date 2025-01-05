using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 8f; // Скорость движения куба вперед
    public float strafeSpeed = 3f; // Скорость движения влево и вправо
    public float rotationSpeed = 100f; // Скорость вращения камеры
    public float maxRotationX = 60f; // Максимальный угол поворота по оси X
    public float minRotationX = -60f; // Минимальный угол поворота по оси X

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
            // Движение куба вперед по направлению, куда смотрит камера
            Vector3 forwardMovement = transform.forward * moveSpeed * Time.deltaTime;
            rb.MovePosition(rb.position + forwardMovement);

            // Движение куба влево и вправо
            float horizontalInput = Input.GetAxis("Horizontal"); // A и D
            Vector3 strafeMovement = transform.right * horizontalInput * strafeSpeed * Time.deltaTime * 3;
            rb.MovePosition(rb.position + strafeMovement);
        }
    }

    
}
