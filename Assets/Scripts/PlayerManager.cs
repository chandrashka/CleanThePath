using Unity.Mathematics;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform shootPosition;
    
    private GameObject _currentBullet;
    
    public void StartShooting(Transform doorTransform)
    {
        _currentBullet = Instantiate(bulletPrefab, shootPosition.position, quaternion.identity);
        _currentBullet.transform.LookAt(doorTransform);
    }

    public void StopShooting(Transform doorTransform)
    {
        _currentBullet.GetComponentInChildren<BulletLogic>().Shoot(doorTransform);
    }
}
