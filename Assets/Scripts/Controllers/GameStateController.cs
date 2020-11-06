using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameStateController : MonoBehaviour
{
    [SerializeField]
    private PlayerStatsController playerStatsController;

    [SerializeField]
    private GameObject gameOverPanel;

    [SerializeField]
    private GameObject character;

    [SerializeField]
    private Text distance;

    [SerializeField]
    private Text money;

    private bool gameOver;
	
	private void Update ()
    {
	    if (playerStatsController.pd.livesAmount == 0 && !gameOver)
        {
            gameOver = true;
            StartCoroutine(StopGameGradually());
        }
	}

    private IEnumerator StopGameGradually()
    {
        while (Time.timeScale > 0.1f)
        {
            Time.timeScale -= Time.deltaTime * 2f;
            yield return null;
        }
        Time.timeScale = 0f;
        character.SetActive(false);
        ShowStats();
    }
    
    private void ShowStats()
    {
        distance.text = playerStatsController.pd.maxDistance.ToString()+ "m";
        money.text = playerStatsController.pd.money.ToString() + "$";
        gameOverPanel.SetActive(true);
    }
}
