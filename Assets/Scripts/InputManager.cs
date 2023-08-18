using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            gameManager.StartShooting();
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            gameManager.StopShooting();
        }
    }
}
