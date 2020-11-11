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
}
