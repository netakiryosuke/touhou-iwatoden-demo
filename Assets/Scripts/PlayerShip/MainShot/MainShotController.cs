using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerShip.MainShot
{
    public class MainShotController : MonoBehaviour
    {
        [SerializeField] private InputAction shotInput;
        [SerializeField] private GameObject mainShotPrefab;
        [SerializeField] private Transform[] mainShotSpawnPoints;
        [SerializeField] private float mainShotInterval = 0.1f;
        [SerializeField] private AudioClip shotSE;
        private AudioSource _audioSource;
        private bool _isShooting;
        private float _mainShotTimer = 0.1f;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }
        
        private void Update()
        {
            _mainShotTimer += Time.deltaTime;
            
            if (_isShooting && _mainShotTimer >= mainShotInterval)
            {
                MainShot();
                _mainShotTimer = 0;
            }
        }
        
        private void OnEnable()
        {
            shotInput.performed += OnShot;
            shotInput.canceled += OnShot;
            shotInput.Enable();
        }
        
        private void OnDisable()
        {
            shotInput.performed -= OnShot;
            shotInput.canceled -= OnShot;
            shotInput.Disable();
        }

        private void OnShot(InputAction.CallbackContext context)
        {
            _isShooting = context.ReadValueAsButton();
        }

        private void MainShot()
        {
            foreach (var mainShotSpawnPoint in mainShotSpawnPoints)
            {
                Instantiate(mainShotPrefab, mainShotSpawnPoint.position, mainShotSpawnPoint.rotation);
            }
            
            _audioSource.PlayOneShot(shotSE);
        }
    }
}
