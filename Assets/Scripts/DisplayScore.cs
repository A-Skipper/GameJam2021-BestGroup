using TMPro;
using UnityEngine;

public class DisplayScore : MonoBehaviour
{
    private TMP_Text scoreText;

    public int scoreNumber;
    private void Awake()
    {
        scoreText = GetComponent<TMP_Text>();
        scoreNumber = 0;
        scoreText.text = scoreNumber.ToString();
    }

    private void Update()
    {
        scoreText.text = scoreNumber.ToString();
    }

    public void addScore(int score)
    {
        scoreNumber += score;
    }
}
