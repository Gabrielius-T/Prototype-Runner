using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsController : MonoBehaviour
{
    public Text playerMoney;

    [SerializeField]
    private Image life1;

    [SerializeField]
    private Image life2;

    [SerializeField]
    private Image life3;

    [SerializeField]
    private CameraShaker cameraShaker;

    [SerializeField]
    private AudioSource ouchSound;

    [SerializeField]
    private ParticleSystem bloodParticles;

    [SerializeField]
    private GameObject character;

    internal PlayerData pd;

    private bool canRemoveLife = true;
    private bool canAddLife = true;
    private bool canAddMoney = true;

    private void Start ()
    {
        pd = new PlayerData(0, 3);
        playerMoney.text = pd.money.ToString();
	}

    public void RemoveLife()
    {
        if (pd.livesAmount > 0 && canRemoveLife)
        {
            pd.livesAmount -= 1;
            UpdateLivesUI();
            cameraShaker.StartCoroutine(cameraShaker.Shake(0.2f, 0.2f));
            Instantiate(bloodParticles, character.transform.position + new Vector3(0.5f, 0.2f, 0f), bloodParticles.transform.rotation);
            ouchSound.Play();
            canRemoveLife = false;
            StartCoroutine(WaitForNextLifeRemove());
        }
    }

    public void AddLife()
    {
        if(pd.livesAmount < 3 && pd.livesAmount > 0 && canAddLife)
        {
            pd.livesAmount += 1;
            UpdateLivesUI();
            canAddLife = false;
            StartCoroutine(WaitForNextLifeAdd());
        }
    }

    public void AddMoney(int money)
    {
        if (canAddMoney)
        {
            pd.money += money;
            UpdateMoneyText();
            canAddMoney = false;
            StartCoroutine(WaitForNextMoney());
        }
    }

    private void UpdateLivesUI()
    {
        switch (pd.livesAmount)
        {
            case 3:
                life1.gameObject.SetActive(true);
                life2.gameObject.SetActive(true);
                life3.gameObject.SetActive(true);
                break;
            case 2:
                life1.gameObject.SetActive(true);
                life2.gameObject.SetActive(true);
                life3.gameObject.SetActive(false);
                break;
            case 1:
                life1.gameObject.SetActive(true);
                life2.gameObject.SetActive(false);
                life3.gameObject.SetActive(false);
                break;
            case 0:
                life1.gameObject.SetActive(false);
                life2.gameObject.SetActive(false);
                life3.gameObject.SetActive(false);
                break;
        }
    }

    private void UpdateMoneyText()
    {
        playerMoney.text = pd.money.ToString();
    }

    private IEnumerator WaitForNextLifeRemove()
    {
        yield return new WaitForSeconds(0.5f);
        canRemoveLife = true;
    }

    private IEnumerator WaitForNextLifeAdd()
    {
        yield return new WaitForSeconds(0.1f);
        canAddLife = true;
    }

    private IEnumerator WaitForNextMoney()
    {
        yield return new WaitForSeconds(0.1f);
        canAddMoney = true;
    }
}
