using DG.Tweening;
using UnityEngine;

namespace Common.Animation
{
    public class ShootAnimation : MonoBehaviour, IAnimator
    {

        [SerializeField] private ParticleSystem particle;
        [SerializeField] private GameObject gameModel; 
        
        public void RunAnimation()
        {
            particle.Play();
            gameModel.transform
                .DOShakePosition(0.15f, 0.2f, 1, 1f, false, true, ShakeRandomnessMode.Harmonic)
                .SetEase(Ease.InOutBounce);
        }
    }
}