using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject menuCanvas;
    [SerializeField] private GameObject gameCanvas;
    [SerializeField] private GameObject endGameCanvas;

    [SerializeField] private TextMeshProUGUI endText;

    private const string LooseText = "You loose!";
    private const string WinText = "You win!";

    private void Start()
    {
        menuCanvas.SetActive(true);
        gameCanvas.SetActive(false);
        endGameCanvas.SetActive(false);
    }

    public void StartGame()
    {
        menuCanvas.SetActive(false);
        gameCanvas.SetActive(true);
        endGameCanvas.SetActive(false);
    }

    public void EndGame()
    {
        menuCanvas.SetActive(false);
        gameCanvas.SetActive(false);
        endGameCanvas.SetActive(true);
    }

    public void GameLose()
    {
        endText.text = LooseText;
    }

    public void GameWin()
    {
        endText.text = WinText;
    }
}
