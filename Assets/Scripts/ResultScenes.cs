using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultScenes : MonoBehaviour
{
    public Text resultText;
    public Text livesText;

    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager.lives == 0)
        {
            livesText.text = "Плохо";
        }
        if (gameManager.lives == 1)
        {
            livesText.text = "Норм";
        }
        if (gameManager.lives == 2)
        {
            livesText.text = "Хорошо";
        }
        if (gameManager.lives == 3)
        {
            livesText.text = "Превосходно";
        }
        resultText.text = gameManager.correctAnswers + "/" + gameManager.questions.Count;

        Destroy(gameManager.gameObject);
    }

    public void Restart(int index)
    {
        SceneManager.LoadScene(index);
    }

}
