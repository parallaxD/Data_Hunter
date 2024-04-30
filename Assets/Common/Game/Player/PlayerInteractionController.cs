using Common.Core.Interactable;
using Common.Core.Interactable.Item.Usable;
using Common.Storage;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Game.Player
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
        [SerializeField] private EntityInventory inventory;
        [SerializeField] private Image pointer;
        
        private bool IsInteracted => Input.GetKeyDown(_use);

        private void Update()
        {
            TryInteract();
            TryUseItem();
            TryAlternativeUseItem();
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

        private void TryUseItem()
        {
            if (!Input.GetMouseButtonUp(0))
                return;
            
            UseItem(ActionType.General);
        }

        private void UseItem(ActionType type)
        {
            var item = inventory.GetSelected();
            if (item == null)
                return;

            var isUsable = item.Item.gameObject.TryGetComponent(out IUsableItem usableItem);
            if (!isUsable)
                return;

            usableItem.Use(playerCamera.gameObject, type);
        }

        private void TryAlternativeUseItem()
        {
            if (!Input.GetKeyUp(KeyCode.R))
                return;
            
            UseItem(ActionType.Alternative);
        }
    }
}