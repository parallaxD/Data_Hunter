using Common.Game.Player;
using UnityEngine;
using UnityEngine.UI;

namespace Common.UI
{
    public class BloodSprite : MonoBehaviour
    {
        [SerializeField] private PlayerHpController _hpController;

        private Image _bloodSpriteImage;

        void Start()
        {
            _hpController.OnHealthChanged += HandleHealthChange;
            _bloodSpriteImage = GetComponent<Image>();
        }

        private void HandleHealthChange(int currentHp, int maxHp)
        {
            // if (currentHp <= 100)
            // {
            Color color = _bloodSpriteImage.color;
            color.a = 1 - (float)currentHp / maxHp;
            _bloodSpriteImage.color = color;
            // }
            // else
            // {
            //     Color color = _bloodSpriteImage.color;
            //     color.a = 0;
            //     _bloodSpriteImage.color = color;
            // }
        }
    }
}
