using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [Space]
    
    [SerializeField] private GameObject menuCanvas;
    [SerializeField] private GameObject gameCanvas;
    [SerializeField] private GameObject endGameCanvas;
    [Space]
    
    [SerializeField] private TextMeshProUGUI endText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI bulletsLeftText;
    
    private const string LooseText = "You loose!";
    private const string WinText = "You win! Your score: ";

    private bool _isGameOn;

    private void Start()
    {
        menuCanvas.SetActive(true);
        gameCanvas.SetActive(false);
        endGameCanvas.SetActive(false);
    }

    private void Update()
    {
        if(!_isGameOn) return;
        scoreText.text = gameManager.GetScore().ToString();
        bulletsLeftText.text = gameManager.GetBulletsLeft().ToString();
    }

    public void StartGame()
    {
        menuCanvas.SetActive(false);
        gameCanvas.SetActive(true);
        endGameCanvas.SetActive(false);

        _isGameOn = true;
    }

    public void EndGame()
    {
        menuCanvas.SetActive(false);
        gameCanvas.SetActive(false);
        endGameCanvas.SetActive(true);

        _isGameOn = false;
    }

    public void GameLose()
    {
        endText.text = LooseText;
    }

    public void GameWin()
    {
        endText.text = WinText + scoreText.text;
    }
}
