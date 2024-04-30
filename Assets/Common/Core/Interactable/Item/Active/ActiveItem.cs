using Common.Core.Storage;

namespace Common.Core.Interactable.Item.Active
{
    public abstract class ActiveItem : GameItem, IActiveItem
    {

        private bool _isActive;
        private IHand _hand;
        
        private void Update()
        {
            if (_isActive)
                Handle();
        }

        protected abstract void Handle();
        
        public virtual void SetActive(bool isActive)
        {
            _isActive = isActive;
        }

        public void SetHand(IHand hand)
        {
            _hand = hand;
        }
    }
}