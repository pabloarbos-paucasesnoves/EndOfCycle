using UnityEngine;
using UnityEngine.InputSystem;

namespace EndOfCycle
{
    [RequireComponent(typeof(CharacterController))]
    [DisallowMultipleComponent]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] [Min(0f)] private float _lateralSpeed = 10f;
        [SerializeField] [Min(0f)] private float _forwardSpeed = 5f;
        [SerializeField] private InputActionReference _moveAction;
        
        [SerializeField] private Collider _groundCollider;
        private float _minCenterX;
        private float _maxCenterX;
        
        private CharacterController _characterController;
        
        private void Awake()
        {
            if (!_groundCollider)
            {
                Debug.LogError($"{nameof(PlayerMovement)}: {nameof(_groundCollider)} is not assigned", this);
                enabled = false;
                return;
            }

            if (!_moveAction)
            {
                Debug.LogError($"{nameof(PlayerMovement)}: {nameof(_moveAction)} is not assigned", this);
                enabled = false;
                return;
            }

            _characterController = GetComponent<CharacterController>();

            _minCenterX = _groundCollider.bounds.min.x + _characterController.radius;
            _maxCenterX = _groundCollider.bounds.max.x - _characterController.radius;
        }

        private void Update()
        {
            float value = _moveAction.action.ReadValue<float>();
            
            // 1. Lateral displacement this frame (meters)
            float lateralDisplacement = value * _lateralSpeed * Time.deltaTime;

            // 2. Target X if nothing limited it (position)
            float targetX = transform.position.x + lateralDisplacement;

            // 3. Target X limited to the allowed range (position)
            float clampedX = Mathf.Clamp(targetX, _minCenterX, _maxCenterX);

            // 4. Allowed displacement (meters): from where I am to where I may end up
            float allowedDisplacement = clampedX - transform.position.x;
            
            Vector3 movement = new Vector3(allowedDisplacement, 0f, _forwardSpeed * Time.deltaTime);
            
            _characterController.Move(movement);
        }

        private void OnEnable()
        {
            _moveAction.action.Enable();
        }

        private void OnDisable()
        {
            if (!_moveAction)
            {
                return;
            }

            _moveAction.action.Disable();
        }
    }
}

