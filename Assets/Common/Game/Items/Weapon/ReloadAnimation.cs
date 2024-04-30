using Common.Animation;
using DG.Tweening;
using UnityEngine;

namespace Common.Game.Items.Weapon
{
    public class ReloadAnimation : MonoBehaviour, IAnimator
    {
        [SerializeField] private GameObject gameModel; 
    
        public void RunAnimation()
        {
            gameModel.transform
                .DOShakePosition(0.5f);
        }
    }
}