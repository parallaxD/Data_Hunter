using Common.Core.Interactable;
using Common.Core.Interactable.Item.Usable;
using Common.Item;
using DG.Tweening;
using UnityEngine;

namespace Common.Game.Testing
{
    public class Button : MonoBehaviour, IInteractable
    {
        [SerializeField] public GameObject gg;
        
        public IInteractionHandler GetInteractionHandler(GameObject who)
        {
            return new ButtonHandler(this);
        }
        
        private class ButtonHandler : IInteractionHandler
        {
            private Button _mono;

            public ButtonHandler(Button mono)
            {
                _mono = mono;
            }

            public void Interact()
            {
                var upNormalized = _mono.gameObject.transform.position + Vector3.down * 3;
                _mono.gg.transform.DOMove(upNormalized, 2);
            }
        }
    }
}