using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform playerSpawnPosition;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private float playerStarterSize;
    
    [Space]
    [SerializeField] private Transform doorTransform;
    [SerializeField] private Transform doorEntranceTransform;
    
    [Space]
    [SerializeField] private LineRenderer lineRenderer;

    [Space] 
    [SerializeField] private UIManager uiManager;
    [SerializeField] private InputManager inputManager;

    private GameObject _player;
    private PlayerManager _playerManager;

    public void StartGame()
    {
        SetPlayer();

        DrawPath();
        
        uiManager.StartGame();
        inputManager.StartGame();
    }

    private void SetPlayer()
    {
        _player = Instantiate(playerPrefab, playerSpawnPosition.position, quaternion.identity);
        _player.GetComponentInParent<Transform>().LookAt(doorTransform);
        _playerManager = _player.GetComponent<PlayerManager>();
        _playerManager.SetPlayerSize(playerStarterSize);
    }


    private void DrawPath()
    {
        var playerPosition = _player.transform.position;
        var playerOnFloorPosition = new Vector3(playerPosition.x, 0.2f, playerPosition.z);
        
        var corners = new[] { playerOnFloorPosition, doorEntranceTransform.position };
        lineRenderer.SetPositions(corners);
        lineRenderer.startWidth = playerStarterSize;
    }

    public void StartShooting()
    {
        _playerManager.StartShooting(doorTransform);
    }

    public void StopShooting()
    {
        _playerManager.StopShooting(doorTransform);
    }

    public void SetLineWidth(float lineWidth)
    {
        lineRenderer.startWidth = lineWidth;
    }

    public void GameLose()
    {
        uiManager.GameLose();
        EndGame();
    }

    public void GameWin()
    {
        uiManager.GameWin();
        EndGame();
    }

    private void EndGame()
    {
        uiManager.EndGame();
        inputManager.EndGame();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
