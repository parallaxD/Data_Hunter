using UnityEngine;

namespace Resources.Game.Item.Weapon
{
    public class ShootingAnimation : StateMachineBehaviour
    {
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool("shooting", false);
        }
    }
}
