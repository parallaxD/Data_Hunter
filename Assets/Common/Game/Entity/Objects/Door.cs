using UnityEngine;

namespace Common.GameEntity.Objects
{
    public class Door : MonoBehaviour
    {
        public bool isOpen = false;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Enemy")
            {
                if (!isOpen)
                {
                    OpenDoor();
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Enemy")
            {
                if (isOpen)
                {
                    CloseDoor();
                }
            }
        }

        public void OpenDoor()
        {   
            // �������� �������� �����
            isOpen = true;
            print($"Door is open: {isOpen}");
        }

        public void CloseDoor()
        {
            // �������� �������� �����
            isOpen = false;
        }
    }
}