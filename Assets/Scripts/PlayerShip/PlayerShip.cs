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
        private Vector2 _moveInputValue;
        private bool _isSlowMove;
        private bool _canControl = true;
        private bool _isInvincible;
        private SpriteRenderer _spriteRenderer;

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
            if (_isSlowMove)
            {
                transform.position += new Vector3(_moveInputValue.x, _moveInputValue.y, 0) * (slowSpeed * Time.deltaTime);
            }
            else
            {
                transform.position += new Vector3(_moveInputValue.x, _moveInputValue.y, 0) * (normalSpeed * Time.deltaTime);
            }
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_isInvincible) return;

            if (other.CompareTag("EnemyDanmaku") || other.CompareTag("Enemy"))
            {
                StartCoroutine(DieAndRespawn());
            }
        }

        private IEnumerator DieAndRespawn()
        {
            _canControl = false;
            _isInvincible = true;

            // 一旦消す
            gameObject.SetActive(false);
            yield return null;

            // リスポーン位置
            transform.position = new Vector3(0f, respawnY, 0f);
            gameObject.SetActive(true);

            StartCoroutine(Blink());

            // 上昇復帰
            while (transform.position.y < returnY)
            {
                transform.position += Vector3.up * (2f * Time.deltaTime);
                yield return null;
            }

            _canControl = true;

            yield return new WaitForSeconds(2f);
            _isInvincible = false;
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
