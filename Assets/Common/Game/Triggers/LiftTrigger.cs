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
        private bool _sceneLoaded = false;

        private void Awake()
        {
            _elevatorAnim = GetComponent<Animator>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<CharacterController>() != null)
            {
                _elevatorAnim.SetFloat("openSpeed", -1.0f);
                _elevatorAnim.Play("ElevatorOpen");
                StartCoroutine(FinalCountdown());
            }
        }

        private IEnumerator FinalCountdown()
        {
            yield return new WaitForSeconds(_finalCountdownValue);
            SceneManager.LoadScene(_elevatorTrigger.SceneToLoad);
        }
    }
}
