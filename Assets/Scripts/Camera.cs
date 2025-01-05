using Unity.VisualScripting;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player; // Ссылка на объект игрока (куб)
    public float mouseSensitivity = 5f; // Чувствительность мыши
    public float maxRotationX = 60f; // Максимальный угол наклона камеры
    public float minRotationX = -60f; // Минимальный угол наклона камеры

    private float rotationX = 0f;
    private float rotationY = 0f;

    void Update()
    {
        RotateCamera();
    }

    void RotateCamera()
    {
        // Получаем движение мыши по осям X и Y
        rotationX -= Input.GetAxis("Mouse Y") * mouseSensitivity; // Вращение по вертикали (вверх/вниз)
        rotationX = Mathf.Clamp(rotationX, minRotationX, maxRotationX); // Ограничиваем поворот

        rotationY += Input.GetAxis("Mouse X") * mouseSensitivity; // Вращение по горизонтали (влево/вправ)

        // Применяем повороты на объект (камеру)
        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0);
    }
}