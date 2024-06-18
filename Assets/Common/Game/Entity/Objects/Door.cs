using System;
using UnityEngine;

namespace Common.Game.Entity.Objects
{
    public class Door : MonoBehaviour
    {
        public bool isOpen = false;
        public event Action OnDoorOpen;
        public event Action OnDoorClose;
            
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                if (!isOpen)
                {
                    OpenDoor();
                    OnDoorOpen?.Invoke();
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                if (isOpen)
                {
                    CloseDoor();
                    OnDoorClose?.Invoke();
                }
            }
        }

        public void OpenDoor()
        {   
            // �������� �������� �����
            isOpen = true;
            // print($"Door is open: {isOpen}");
        }

        public void CloseDoor()
        {
            // �������� �������� �����
            isOpen = false;
        }
    }
}