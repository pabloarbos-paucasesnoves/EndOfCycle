using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace EndOfCycle
{
    [RequireComponent(typeof(CharacterController))]
    [DisallowMultipleComponent]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] [Min(0f)] private float _lateralSpeed = 5f;
        [SerializeField] private InputActionReference _moveAction;

        private CharacterController _characterController;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            float value = _moveAction.action.ReadValue<float>();
            
            Vector3 displacement = new Vector3(value, 0, 0) * (_lateralSpeed * Time.deltaTime);
            
            _characterController.Move(displacement);
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

