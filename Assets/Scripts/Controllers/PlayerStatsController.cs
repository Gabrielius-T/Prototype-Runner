using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsController : MonoSingleton<PlayerStatsController>
{
    [SerializeField] Text playerMoney;
    [SerializeField] List<Image> livesImages;

    internal PlayerData pd;

    void Start ()
    {
        pd = new PlayerData(0, 3);
        playerMoney.text = pd.money.ToString();
	}

    public void RemoveLife()
    {
        if (pd.livesAmount > 0)
        {
            pd.livesAmount -= 1;
            UpdateLivesUi();
        }
    }

    void UpdateLivesUi()
    {
        for (int _i = 0; _i < pd.livesAmount; _i++)
        {
            livesImages[_i].color = Color.white;
        }
        for (int _i = pd.livesAmount; _i < livesImages.Count; _i++)
        {
            livesImages[_i].color = new Color(1f, 1f, 1f, 0.25f);
        }
    }

    public void AddLife()
    {
        if(pd.livesAmount < 3)
        {
            pd.livesAmount += 1;
            UpdateLivesUi();
        }
    }

    public void AddMoney(int _money)
    {
        pd.money += _money;
        UpdateMoneyText();
    }

    void UpdateMoneyText()
    {
        playerMoney.text = pd.money.ToString();
    }
}
