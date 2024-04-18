using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneTrigger : MonoBehaviour
{
    [SerializeField] private SceneController _sceneController;
    [SerializeField] private string _sceneToLoad;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Player")) _sceneController.ChangeScene(_sceneToLoad);
    }
}
