using UnityEngine;

namespace EndOfCycle
{
    [DisallowMultipleComponent]
    public class CameraFollow : MonoBehaviour
    {
        [Header("Camera settings")]
        [SerializeField] private Transform _target;
        [SerializeField, Min(0f)] private float _height = 9f;
        [SerializeField, Min(0f)] private float _distanceFromTarget = 7f;

        private void Awake()
        {
            if (!_target)
            {
                Debug.LogError("CameraFollow: target is not assigned", this);
                enabled = false;
            }
        }

        private void LateUpdate()
        {
            // Position (not a distance): where the camera must be on Z
            float cameraZ = _target.position.z - _distanceFromTarget;

            transform.position = new Vector3(transform.position.x, _height, cameraZ);
        }
    }
}
