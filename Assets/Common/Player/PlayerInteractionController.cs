using Common.Interactable;
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
        [SerializeField] private double maxInteractionDistance = 3d;

        [Header("Components")]
        [SerializeField] private Camera playerCamera;
        [SerializeField] private Storage.Inventory inventory;
        [SerializeField] private Image pointer;
        
        private bool IsInteracted => Input.GetKeyDown(_use);

        private void Update()
        {
            TryInteract();
        }
        
        private void TryInteract()
        {
            var interactable = FindInteractable();
            if (interactable != null && IsInteracted)
                interactable.GetInteractionHandler(inventory.gameObject).Interact();
        }

        private IInteractable FindInteractable()
        {
            var cameraTransform = playerCamera.transform;
            var ray = new Ray(cameraTransform.position, cameraTransform.forward);
            if (!Physics.Raycast(ray, out var hit)) 
                return null;
            
            
            var isInteractable = hit.transform.TryGetComponent<IInteractable>(out var interactable);
            if (hit.distance < maxInteractionDistance && isInteractable)
            {
                pointer.sprite = usePointer;
                return interactable;
            }
            
            pointer.sprite = normalPointer;
            return null;
        }
    }
}