using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using TMPro;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TMP_InputField nameInput;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject scoreMenu;
    public Slider lineSlider;
    public Slider maxVelocitySlider;
    public Slider paddleSpeedSlider;
    public Slider accelerationSlider;
    public Slider initialSpeedSlider;

    public TextMeshProUGUI score1;
    public TextMeshProUGUI score2;
    public TextMeshProUGUI score3;
    public TextMeshProUGUI score4;
    public TextMeshProUGUI score5;
    public TextMeshProUGUI score6;
    public TextMeshProUGUI score7;
    public TextMeshProUGUI score8;
    public TextMeshProUGUI score9;
    public TextMeshProUGUI score10;


    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = "Best Score: " + GameManager.instance.highscorePlayer + " : " + GameManager.instance.highscore;
        UpdateSliders();
    }

    public void UpdateSliders()
    {
        lineSlider.value = GameManager.instance.lineCount;
        maxVelocitySlider.value = GameManager.instance.maxVelocity;
        paddleSpeedSlider.value = GameManager.instance.paddleSpeed;
        accelerationSlider.value = GameManager.instance.acceleration;
        initialSpeedSlider.value = GameManager.instance.initialSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetName()
    {
        GameManager.instance.SetName(nameInput.text);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
Application.Quit();
#endif
    }

    public void OpenHighscores()
    {
        mainMenu.SetActive(false);
        scoreMenu.SetActive(true);
        score1.text = "1. " + GameManager.instance.playerList[0] + " : " + GameManager.instance.scoreList[0];
        score2.text = "2. " + GameManager.instance.playerList[1] + " : " + GameManager.instance.scoreList[1];
        score3.text = "3. " + GameManager.instance.playerList[2] + " : " + GameManager.instance.scoreList[2];
        score4.text = "4. " + GameManager.instance.playerList[3] + " : " + GameManager.instance.scoreList[3];
        score5.text = "5. " + GameManager.instance.playerList[4] + " : " + GameManager.instance.scoreList[4];
        score6.text = "6. " + GameManager.instance.playerList[5] + " : " + GameManager.instance.scoreList[5];
        score7.text = "7. " + GameManager.instance.playerList[6] + " : " + GameManager.instance.scoreList[6];
        score8.text = "8. " + GameManager.instance.playerList[7] + " : " + GameManager.instance.scoreList[7];
        score9.text = "9. " + GameManager.instance.playerList[8] + " : " + GameManager.instance.scoreList[8];
        score10.text = "10. " + GameManager.instance.playerList[9] + " : " + GameManager.instance.scoreList[9];
    }

    public void CloseHighscores()
    {
        scoreMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void OpenSettings()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
        UpdateSliders();
    }

    public void ExitSettings()
    {
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void SaveSettings()
    {
        GameManager.instance.lineCount = (int)lineSlider.value;
        GameManager.instance.maxVelocity = maxVelocitySlider.value;
        GameManager.instance.paddleSpeed = paddleSpeedSlider.value;
        GameManager.instance.acceleration = accelerationSlider.value;
        GameManager.instance.initialSpeed = initialSpeedSlider.value;

        GameManager.instance.SaveSettings();
    }

    public void RestoreDefault()
    {
        GameManager.instance.RestoreDefault();
        UpdateSliders();
    }



}
