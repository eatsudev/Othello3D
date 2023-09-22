using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI topText;

    [SerializeField] private TextMeshProUGUI blackScoreText;

    [SerializeField] private TextMeshProUGUI whiteScoreText;

    [SerializeField] private TextMeshProUGUI winnerText;

    [SerializeField] private Image blackOverlay;

    [SerializeField] private RectTransform playAgainButton;

    public Text roomStatus;

    public void SetPlayerText(Player currentPlayer)
    {
        if (currentPlayer == Player.Black)
        {
            topText.text = "<sprite name=DiscBlackUp> Black's Turn";
        }
        else if (currentPlayer == Player.White)
        {
            topText.text = "<sprite name=DiscWhiteUp> White's Turn";
        }
    }

    public void SetSkippedText(Player skippedPlayer)
    {
        if (skippedPlayer == Player.Black)
        {
            topText.text = "<sprite name=DiscBlackUp> Black Can't Move";
        }
        else if (skippedPlayer == Player.White)
        {
            topText.text = "<sprite name=DiscWhiteUp> White Can't Move";
        }
    }

    public void SetTopText(string message)
    {
        topText.text = message;
    }

    public void SetStatus(string status)
    {
        roomStatus.text = status;
    }

    private IEnumerator ScaleDown(RectTransform rect)
    {
        rect.LeanScale(Vector3.zero, 0.2f);
        yield return new WaitForSeconds(0.2f);
        rect.gameObject.SetActive(false);
    }

    private IEnumerator ScaleUp(RectTransform rect)
    {
        rect.gameObject.SetActive(true);
        rect.localScale = Vector3.zero;
        rect.LeanScale(Vector3.one, 0.2f);
        yield return new WaitForSeconds(0.2f);
    }

    public IEnumerator ShowScoreText()
    {
        yield return ScaleUp(blackScoreText.rectTransform);
        yield return ScaleUp(whiteScoreText.rectTransform);
    }

    public IEnumerator DisableStatusUI(float delay)
    {
        yield return delay;
        roomStatus.gameObject.SetActive(false);
    }


    public void SetBlackScoreText(int score)
    {
        blackScoreText.text = $"<sprite name=DiscBlackUp> {score}";
    }

    public void SetWhiteScoreText(int score)
    {
        whiteScoreText.text = $"<sprite name=DiscWhiteUp> {score}";
    }

    private IEnumerator ShowOverlay()
    {
        blackOverlay.gameObject.SetActive(true);
        blackOverlay.color = Color.clear;
        blackOverlay.rectTransform.LeanAlpha(0.8f, 1);
        yield return new WaitForSeconds(1);
    }

    private IEnumerator HideOverlay()
    {
        blackOverlay.rectTransform.LeanAlpha(0, 1);
        yield return new WaitForSeconds(1);
        blackOverlay.gameObject.SetActive(false);
    }

    public void SetWinnerText(Player winner)
    {
        switch (winner)
        {
            case Player.Black:
                winnerText.text = "Black Win!";
                break;
            case Player.White:
                winnerText.text = "White Win!";
                break;
            case Player.None:
                winnerText.text = "Tie!";
                break;
        }
    }

    public IEnumerator ShowEndScreen()
    {
        yield return ShowOverlay();
        yield return ScaleUp(winnerText.rectTransform);
        yield return ScaleUp(playAgainButton);
    }

    public IEnumerator HideEndScreen()
    {
        StartCoroutine(ScaleDown(winnerText.rectTransform));
        StartCoroutine(ScaleDown(blackScoreText.rectTransform));
        StartCoroutine(ScaleDown(whiteScoreText.rectTransform));
        StartCoroutine(ScaleDown(playAgainButton));

        yield return new WaitForSeconds(0.5f);
        yield return HideOverlay();
    }
}
