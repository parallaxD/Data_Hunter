using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Common.Game
{
    public class LiftTrigger : MonoBehaviour
    {
        private Animator _elevatorAnim;
        private int _finalCountdownValue = 5;
        [SerializeField] private ElevatorTrigger _elevatorTrigger;

        [SerializeField] private bool _startLevelLift;
        [SerializeField] private float _animSpeed;

        private void Awake()
        {
            _elevatorAnim = GetComponent<Animator>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<CharacterController>() != null)
            {
                _elevatorAnim.SetFloat("openSpeed", _animSpeed);
                _elevatorAnim.Play("ElevatorOpen");
                if (!_startLevelLift)
                {
                    StartCoroutine(FinalCountdown());
                }
            }
        }

        private IEnumerator FinalCountdown()
        {
            yield return new WaitForSeconds(_finalCountdownValue);
            SceneManager.LoadScene(_elevatorTrigger.SceneToLoad);
        }
    }
}
