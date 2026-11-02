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
            _characterController = GetComponent<CharacterController>();

            _minCenterX = _groundCollider.bounds.min.x + _characterController.radius;
            _maxCenterX = _groundCollider.bounds.max.x - _characterController.radius;
        }

        private void Update()
        {
            float value = _moveAction.action.ReadValue<float>();
            
            Vector3 movement = new Vector3(value * _lateralSpeed, 0f, _forwardSpeed) * Time.deltaTime;
            
            _characterController.Move(movement);
        }

        private void OnEnable()
        {
            _moveAction.action.Enable();
        }

        private void OnDisable()
        {
            _moveAction.action.Disable();
        }
    }
}

