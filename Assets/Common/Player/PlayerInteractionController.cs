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
            TryInteract();
        }
        
        private void TryInteract()
        {
            var interactable = FindInteractable();
            if (interactable != null && IsInteracted)
                interactable.GetInteractionHandler(_inventory.gameObject).Interact();
        }

        private IInteractable FindInteractable()
        {
            var ray = new Ray(_camera.position, _camera.forward);
            if (!Physics.Raycast(ray, out var hit)) 
                return null;
            
            
            var isInteractable = hit.transform.TryGetComponent<IInteractable>(out var interactable);
            if (hit.distance < maxInteractionDistance && isInteractable)
            {
                _pointer.sprite = usePointer;
                return interactable;
            }
            
            _pointer.sprite = normalPointer;
            return null;
        }
    }
}