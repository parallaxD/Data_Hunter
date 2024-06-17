using Common.Animation;
using DG.Tweening;
using UnityEngine;

namespace Common.Game.Items.Weapon
{
    public class ShootAnimation : MonoBehaviour, IAnimator
    {

        [SerializeField] private Animator animator;
        
        public void RunAnimation()
        {
            animator.SetBool("shooting", true);
        }
    }
}