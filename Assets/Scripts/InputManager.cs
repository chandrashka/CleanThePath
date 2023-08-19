using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    private bool _isGameOn;

    private void Update()
    {
        if (!_isGameOn) return;
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            gameManager.StartShooting();
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            gameManager.StopShooting();
        }
    }

    public void StartGame()
    {
        _isGameOn = true;
    }

    public void EndGame()
    {
        _isGameOn = false;
    }
}
