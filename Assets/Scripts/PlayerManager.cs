using Unity.Mathematics;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform shootPosition;
    [SerializeField] private GameObject player;
    
    [Space]
    [SerializeField] private float scaler = 0.1f;
    [SerializeField] private Vector3 minimumPlayerScale;
    
    [Space]
    [SerializeField] private LayerMask enemyLayerMask;
    
    private GameObject _currentBullet;
    private bool _isShooting;
    private bool _canShoot = true;
    private const int MaxRaycastDistance = 100;

    private GameManager _gameManager;
    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void FixedUpdate()
    {
        if(!Physics.Raycast(player.transform.position, player.transform.forward * MaxRaycastDistance, 
               MaxRaycastDistance, enemyLayerMask))
        {
            MoveToTheEnd();
        }
    }

    private void MoveToTheEnd()
    {
        _canShoot = false;
        
        
    }

    private void Update()
    {
        if (!_isShooting || !_canShoot) return;

        if (!(player.transform.localScale.x > minimumPlayerScale.x)) _gameManager.GameLose();
        
        ChangeBulletSize();
        ChangePlayerSize();
    }

    private void ChangeBulletSize()
    {
        _currentBullet.transform.localScale += new Vector3(scaler, scaler, scaler) * Time.deltaTime;
    }

    private void ChangePlayerSize()
    {
        player.transform.localScale -= new Vector3(scaler, scaler, scaler) * Time.deltaTime;
    }

    public void StartShooting(Transform doorTransform)
    {
        _currentBullet = Instantiate(bulletPrefab, shootPosition.position, quaternion.identity);
        _currentBullet.transform.LookAt(doorTransform);
        _isShooting = true;
    }

    public void StopShooting(Transform doorTransform)
    {
        if (_currentBullet == null) return;
        
        _currentBullet.GetComponentInChildren<BulletLogic>().Shoot(doorTransform);
        _isShooting = false;

        _gameManager.SetLineWidth(player.transform.localScale.x);
    }

    public void SetPlayerSize(float playerStarterSize)
    {
        player.transform.localScale = new Vector3(playerStarterSize, playerStarterSize, playerStarterSize);
    }
}