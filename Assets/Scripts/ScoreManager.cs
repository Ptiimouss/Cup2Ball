using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text comboText;
    public Text blueText;
    public Text greenText;
    public Text redText;
    public Text timeText;
    public Text finalScore;
    public Text timeChosen;
    public Image endScreen;
    public Image startScreen;
    int score = 0;
    int combo = 1;
    public Slider slider;
    public float timeRemaining;
    public bool timerIsRunning = false;

    private void Awake()
    {
        blueText.gameObject.SetActive(false);
        blueText.color = Color.blue;
        greenText.gameObject.SetActive(false);
        greenText.color = Color.green;
        redText.gameObject.SetActive(false);
        redText.color = Color.red;
        endScreen.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = false;
        scoreText.text = score.ToString() + " pts";
        comboText.text = "x" + combo.ToString();
    }
    private void Update()
    {
        scoreText.text = score.ToString() + " pts";
        comboText.text = "x" + combo.ToString();
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                endScreen.gameObject.SetActive(true);
                finalScore.text = score.ToString() + " points";
                Time.timeScale = 0f;
                timeRemaining = 0;
                timerIsRunning = false;
            }
            if (timeRemaining <= 10)
            {
                timeText.color = Color.red;
            }
        }
    }
    public void Play()
    {
        Time.timeScale = 1f;
        timerIsRunning = true;
        startScreen.gameObject.SetActive(false);
    }
    public void Leave()
    {
        Application.Quit();
    }
    public void PlayAgain()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1f;
    }
    public void ApplyTime()
    {
        timeRemaining = slider.value;
        timeChosen.text = slider.value.ToString() + "s";
        return;
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public int AddScore()
    {
        score += combo;
        combo++;
        return score;
    }
    public int ResetCombo()
    {
        combo = 1;
        return score;
    }
    public IEnumerator Animation(Text text)
    {
        var c = combo - 1;
        text.gameObject.SetActive(true);
        text.text = "+" + c.ToString();
        LeanTween.moveY(text.gameObject, 250, 0.5f);
        LeanTween.scale(text.gameObject, Vector2.one * 1.1f, 0.5f);
        yield return new WaitForSeconds(0.5f);
        LeanTween.moveY(text.gameObject, 220, 0);
        LeanTween.scale(text.gameObject, Vector2.one / 1.1f, 0);
        text.gameObject.SetActive(false);
    }
    public void ShowScore(string tag)
    {
        if (tag == "Blue")
        {
            StartCoroutine(Animation(blueText));

        }
        else if (tag == "Green")
        {
            StartCoroutine(Animation(greenText));
        }
        else if (tag == "Red")
        {
            StartCoroutine(Animation(redText));
        }
    }
}
