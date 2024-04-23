using UnityEngine;

namespace Common.GameEntity.Objects
{
    public class VideoCamera : MonoBehaviour
    {
        [SerializeField] private GameObject _player;

        private void Update()
        {
            var vectorToPlayer = _player.transform.position - gameObject.transform.position;

            var xAngle = Mathf.Atan2(vectorToPlayer.z, vectorToPlayer.y) * Mathf.Rad2Deg;
            var yAngle = Mathf.Atan2(vectorToPlayer.x, vectorToPlayer.y) * Mathf.Rad2Deg;

            xAngle = Mathf.Clamp(xAngle, 25f, 0f);

            transform.rotation = Quaternion.Euler(xAngle, yAngle, 0f);
        }
    }
}