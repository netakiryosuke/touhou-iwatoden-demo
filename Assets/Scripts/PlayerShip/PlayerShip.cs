using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerShip
{
    public class PlayerShip : MonoBehaviour
    {
        [SerializeField] private InputAction moveInput;
        [SerializeField] private InputAction slowMoveInput;
        [SerializeField] private float normalSpeed = 4f;
        [SerializeField] private float slowSpeed = 2f;
        private Vector2 _moveInputValue;
        private bool _isSlowMove;

        private void Update()
        {
            Move();
        }
        
        private void OnEnable()
        {
            moveInput.performed += OnMove;
            moveInput.canceled += OnMove;
            moveInput.Enable();

            slowMoveInput.performed += OnSlowMove;
            slowMoveInput.canceled += OnSlowMove;
            slowMoveInput.Enable();
        }
        
        private void OnDisable()
        {
            moveInput.performed -= OnMove;
            moveInput.canceled -= OnMove;
            moveInput.Disable();
            
            slowMoveInput.performed -= OnSlowMove;
            slowMoveInput.canceled -= OnSlowMove;
            slowMoveInput.Disable();
        }

        private void OnMove(InputAction.CallbackContext context)
        {
            _moveInputValue = context.ReadValue<Vector2>();
        }

        private void OnSlowMove(InputAction.CallbackContext context)
        {
            _isSlowMove = context.ReadValueAsButton();
        }
        
        private void Move()
        {
            if (_isSlowMove)
            {
                transform.position += new Vector3(_moveInputValue.x, _moveInputValue.y, 0) * (slowSpeed * Time.deltaTime);
            }
            else
            {
                transform.position += new Vector3(_moveInputValue.x, _moveInputValue.y, 0) * (normalSpeed * Time.deltaTime);
            }
        }
    }
}

