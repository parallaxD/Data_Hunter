using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Common.Game
{
    public class ElevatorTrigger : MonoBehaviour
    {
        private Animator _animator;

        
        [field: SerializeField] public string SceneToLoad { get;private set; }

        //public AsyncOperation AsyncOperation { get; private set; } Õ≈ œŒÀ”◊»ÀŒ—‹ –≈¿À»«Œ¬¿“‹

        private void Awake()
        {
            _animator = GetComponentInParent<Animator>();
            _animator.enabled = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<CharacterController>() != null)
            {
                //AsyncOperation = SceneManager.LoadSceneAsync(SceneToLoad);
                //AsyncOperation.allowSceneActivation = false;
                _animator.enabled = true;
                _animator.Play("ElevatorOpen");
            }
        }
    }
}
