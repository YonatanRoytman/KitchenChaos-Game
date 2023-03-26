using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI recipesDeliveredText;


    private void Start()
    {
        KitchenGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChanged;

        Hide();
    }

    private void KitchenGameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (KitchenGameManager.Instance.IsGameOver())
        {
            Show();

            recipesDeliveredText.text = DeliveryManager.Instance.GetSuccessfulRecipesAmount().ToString();

            StartCoroutine(WaitBeforeBackToMenu());
        }
        else
        {
            Hide();
        }
    }


    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);

    }
     private IEnumerator WaitBeforeBackToMenu()
    {
        yield return new WaitForSeconds(10);

        SceneManager.LoadScene(0);
    }
}
