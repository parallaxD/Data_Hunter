using UnityEngine;

public class ElevatorPlatform : MonoBehaviour
{
    public Transform platform;           
    public float liftHeight = 5f;  
    public float speed = 2f;           
    private Vector3 initialPosition;      
    private Vector3 targetPosition;      
    private bool playerOnPlatform = false;

    private void Start()
    {
        initialPosition = platform.position;
        targetPosition = initialPosition + Vector3.up * liftHeight;
    }

    private void Update()
    {
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
        if (other.CompareTag("Player"))
        {
            playerOnPlatform = true;
            other.transform.SetParent(platform); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnPlatform = false;
            other.transform.SetParent(null);
        }
    }
}
