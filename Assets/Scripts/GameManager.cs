using Unity.Mathematics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform playerSpawnPosition;
    [SerializeField] private GameObject playerPrefab;

    [SerializeField] private Transform doorTransform;

    private GameObject _player;
    private PlayerManager _playerManager;
    private void Start()
    {
        _player = Instantiate(playerPrefab, playerSpawnPosition.position, quaternion.identity);
        _player.GetComponentInParent<Transform>().LookAt(doorTransform);
        _playerManager = _player.GetComponent<PlayerManager>();
    }

    public void StartShooting()
    {
        _playerManager.StartShooting(doorTransform);
    }

    public void StopShooting()
    {
        _playerManager.StopShooting(doorTransform);
    }
}
