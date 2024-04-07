using System;
using Common.Inventory;
using Common.Item;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Player
{
    public class PlayerInteractionController : MonoBehaviour
    {
        [Header("Controls")]
        [SerializeField] private KeyCode _use = KeyCode.F;

        [Header("Pointers")]
        [SerializeField] private Sprite normalPointer;
        [SerializeField] private Sprite usePointer;
        
        private bool IsInteracted => Input.GetKeyDown(_use);
        
        private Transform _camera;
        private Transform _inventory;
        private Image _pointer;

        private void Start()
        {
            var parent = transform.parent;
            _camera = parent.GetComponentInChildren<Camera>().transform;
            _inventory = parent.Find("PlayerInventory");
            _pointer = transform.Find("Canvas").Find("Pointer").GetComponent<Image>();
        }

        private void Update()
        {
            findInteractable();
        }
        
        private void interact()
        {
            
        }

        private void findInteractable()
        {
            var ray = new Ray(_camera.position, _camera.forward);
            if (!Physics.Raycast(ray, out var hit)) 
                return;
            
            var isInteractable = hit.transform.TryGetComponent<IInteractable>(out var interactable);
            if (isInteractable)
            {
                _pointer.sprite = usePointer;
                if (IsInteracted)
                    interactable.GetInteractionHandler(_inventory.gameObject).Interact();
            }
            else
            {
                _pointer.sprite = normalPointer;
            }
        }
    }
}