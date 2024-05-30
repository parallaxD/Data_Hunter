using UnityEngine;

public class ElevatorPlatform : MonoBehaviour
{
    public Transform platform;           // Платформа, которая будет подниматься и опускаться
    public float liftHeight = 5f;         // Высота, на которую платформа будет подниматься
    public float speed = 2f;              // Скорость поднятия и опускания
    private Vector3 initialPosition;      // Начальная позиция платформы
    private Vector3 targetPosition;       // Целевая позиция платформы
    private bool playerOnPlatform = false;// Флаг, указывающий на нахождение игрока на платформе

    private void Start()
    {
        initialPosition = platform.position;
        targetPosition = initialPosition + Vector3.up * liftHeight;
    }

    private void Update()
    {
        // Если игрок на платформе, поднимаем её к целевой позиции, иначе опускаем обратно
        if (playerOnPlatform)
        {
            platform.position = Vector3.MoveTowards(platform.position, targetPosition, speed * Time.deltaTime);
        }
        else
        {
            platform.position = Vector3.MoveTowards(platform.position, initialPosition, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, если игрок вошел на платформу
        if (other.CompareTag("Player"))
        {
            playerOnPlatform = true;
            other.transform.SetParent(platform);  // Устанавливаем платформу родителем игрока
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Проверяем, если игрок покинул платформу
        if (other.CompareTag("Player"))
        {
            playerOnPlatform = false;
            other.transform.SetParent(null);  // Сбрасываем родителя игрока
        }
    }
}
