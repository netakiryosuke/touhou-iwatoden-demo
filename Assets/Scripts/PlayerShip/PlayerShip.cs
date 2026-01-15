using System.Collections;
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
        [SerializeField] private float respawnY = -3.5f;
        [SerializeField] private float returnY = -2.5f;
        [SerializeField] private Vector2 minLimit = new(-6f, -5f);
        [SerializeField] private Vector2 maxLimit = new(1f, 5f);
        private Vector2 _moveInputValue;
        private bool _isSlowMove;
        private bool _canControl = true;
        private bool _isInvincible;
        private SpriteRenderer _spriteRenderer;
        private Coroutine _dieAndRespawnCoroutine;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        
        private void Update()
        {
            if (_canControl)
            {
                Move();
            }
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
            float speed = _isSlowMove ? slowSpeed : normalSpeed;

            Vector3 nextPos = transform.position +
                              new Vector3(_moveInputValue.x, _moveInputValue.y, 0f) * speed * Time.deltaTime;

            nextPos.x = Mathf.Clamp(nextPos.x, minLimit.x, maxLimit.x);
            nextPos.y = Mathf.Clamp(nextPos.y, minLimit.y, maxLimit.y);

            transform.position = nextPos;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_isInvincible || _dieAndRespawnCoroutine != null) return;

            if (other.CompareTag("EnemyDanmaku") || other.CompareTag("Enemy"))
            {
                _dieAndRespawnCoroutine = StartCoroutine(DieAndRespawn());
            }
        }

        private IEnumerator DieAndRespawn()
        {
            _canControl = false;
            _isInvincible = true;

            transform.position = new Vector3(0f, respawnY, 0f);

            StartCoroutine(Blink());

            while (transform.position.y < returnY)
            {
                transform.position += Vector3.up * (2f * Time.deltaTime);
                yield return null;
            }

            _canControl = true;

            yield return new WaitForSeconds(2f);
            _isInvincible = false;
            _dieAndRespawnCoroutine = null;
        }

        private IEnumerator Blink()
        {
            while (_isInvincible)
            {
                _spriteRenderer.color = new Color(1, 1, 1, 0.3f);
                yield return new WaitForSeconds(0.1f);
                _spriteRenderer.color = Color.white;
                yield return new WaitForSeconds(0.1f);
            }

            _spriteRenderer.color = Color.white;
        }
    }
}
