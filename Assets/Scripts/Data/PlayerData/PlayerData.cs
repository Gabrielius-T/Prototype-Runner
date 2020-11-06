using UnityEngine;

public class PlayerData
{
    [SerializeField]
    public int money;

    [SerializeField]
    public int maxDistance;

    [SerializeField]
    public int livesAmount;

    public PlayerData(int _money, int _lives)
    {
        money = _money;
        livesAmount = _lives;
    }
}
