using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using TMPro;


public class GameManager : MonoBehaviour
{
    public int score;
    public int highscore;
    int maxScoreList = 10;
    public string highscorePlayer;
    public string playerName;

    //public Dictionary<int, string> highscoreDictionary;
    public List<int> scoreList;
    public List<string> playerList;



    public int lineCount;
    public float maxVelocity;
    public float paddleSpeed;
    public float acceleration;
    public float initialSpeed;


    public static GameManager instance;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        //highscoreDictionary = new Dictionary<int, string>();
        scoreList = new List<int>();
        playerList = new List<string>();
        LoadGame();
        LoadSettings();
        LoadScore();
        if (scoreList.Count < maxScoreList)
        {
            SaveDefaultScore();
            LoadScore();
        }
    }

    public void SetName(string newname)
    {
        playerName = newname;
    }

    public void CompareHighScore(int score, string playerName)
    {
        if (score > highscore)
        {
            highscore = score;
            highscorePlayer = playerName;
            SaveGame();
        }
        if (scoreList.Count < maxScoreList)
        {
            for (int i = 0; i < scoreList.Count; i++)
            {
                if (score > scoreList[i])
                {
                    playerList.Insert(i, playerName);
                    scoreList.Insert(i, score);
                    break;
                }
                else if (i == scoreList.Count - 1)
                {
                    playerList.Add(playerName);
                    scoreList.Add(score);
                    break;
                }
            }
            if (scoreList.Count == 0)
            {
                playerList.Add(playerName);
                scoreList.Add(score);
            }
        }
        else if (score > scoreList[scoreList.Count - 1])
        {
            playerList.RemoveAt(scoreList.Count - 1);
            scoreList.RemoveAt(scoreList.Count - 1);
            for (int i = 0; i < scoreList.Count; i++)
            {
                if (score > scoreList[i])
                {
                    playerList.Insert(i, playerName);
                    scoreList.Insert(i, score);
                    break;
                }
            }
        }
        SaveScore();
    }

    [System.Serializable]
    class SaveData
    {
        public int highscore;
        public string highscorePlayer;
    }

    public void SaveGame()
    {
        SaveData data = new SaveData();
        data.highscore = highscore;
        data.highscorePlayer = highscorePlayer;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savegame.json", json);
    }

    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/savegame.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highscore = data.highscore;
            highscorePlayer = data.highscorePlayer;
        }
    }

    [System.Serializable]
    class SettingsData
    {
        public int lineCount;
        public float maxVelocity;
        public float paddleSpeed;
        public float acceleration;
        public float initialSpeed;
    }

    //class DefaultSettings
    //{
    //    public float step = 0.6f;
    //    public int lineCount = 6;
    //    public float maxVelocity = 3.0f;
    //    public float paddleSpeed = 2.0f;
    //    public float acceleration = 0.01f;
    //    public float initialSpeed = 2.0f;
    //}

    public void SaveSettings()
    {
        SettingsData data = new SettingsData();
        data.lineCount = lineCount;
        data.maxVelocity = maxVelocity;
        data.paddleSpeed = paddleSpeed;
        data.acceleration = acceleration;
        data.initialSpeed = initialSpeed;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/settings.json", json);
    }

    public void SaveDefault()
    {
        SettingsData data = new SettingsData();
        data.lineCount = 6;
        data.maxVelocity = 3.0f;
        data.paddleSpeed = 2.0f;
        data.acceleration = 0.01f;
        data.initialSpeed = 2.0f;


        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/settings.json", json);
    }

    public void LoadSettings()
    {
        string path = Application.persistentDataPath + "/settings.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SettingsData data = JsonUtility.FromJson<SettingsData>(json);
            lineCount = data.lineCount;
            maxVelocity = data.maxVelocity;
            paddleSpeed = data.paddleSpeed;
            acceleration = data.acceleration;
            initialSpeed = data.initialSpeed;
        }
        else
        {
            RestoreDefault();
        }
    }

    public void RestoreDefault()
    {
        SaveDefault();
        LoadSettings();
    }

    [System.Serializable]
    class ScoreData
    {
        public string player1; public int score1;
        public string player2; public int score2;
        public string player3; public int score3;
        public string player4; public int score4;
        public string player5; public int score5;
        public string player6; public int score6;
        public string player7; public int score7;
        public string player8; public int score8;
        public string player9; public int score9;
        public string player10; public int score10;
    }

    public void SaveScore()
    {
        Debug.Log(scoreList);
        Debug.Log(playerList);
        ScoreData data = new ScoreData();
        data.player1 = playerList[0];
        data.player2 = playerList[1];
        data.player3 = playerList[2];
        data.player4 = playerList[3];
        data.player5 = playerList[4];
        data.player6 = playerList[5];
        data.player7 = playerList[6];
        data.player8 = playerList[7];
        data.player9 = playerList[8];
        data.player10 = playerList[9];
        data.score1 = scoreList[0];
        data.score2 = scoreList[1];
        data.score3 = scoreList[2];
        data.score4 = scoreList[3];
        data.score5 = scoreList[4];
        data.score6 = scoreList[5];
        data.score7 = scoreList[6];
        data.score8 = scoreList[7];
        data.score9 = scoreList[8];
        data.score10 = scoreList[9];

        //if (playerList[0] != null)
        //{
        //    data.player1 = playerList[0];
        //}
        //if (playerList[1] != null) {
        //    data.player2 = playerList[1];
        //}
        //if (playerList[2] != null) {
        //    data.player3 = playerList[2];
        //}
        //if (playerList[3] != null) {
        //    data.player4 = playerList[3];
        //}
        //if (playerList[4] != null) {
        //    data.player5 = playerList[4];
        //}
        //if (playerList[5] != null) {
        //    data.player6 = playerList[5];
        //}
        //if (playerList[6] != null) {
        //    data.player7 = playerList[6];
        //}
        //if (playerList[7] != null) {
        //    data.player8 = playerList[7];
        //}
        //if (playerList[8] != null) {
        //    data.player9 = playerList[8];
        //}
        //if (playerList[9] != null) {
        //    data.player10 = playerList[9];
        //}
        //if (scoreList[0] != null) {
        //    data.score1 = scoreList[0];
        //}
        //if (scoreList[1] != null) {
        //    data.score2 = scoreList[1];
        //}
        //if (scoreList[3] != null) {
        //    data.score3 = scoreList[2];
        //}
        //if (scoreList[4] != null) {
        //    data.score4 = scoreList[3];
        //}
        //if (scoreList[5] != null) {
        //    data.score5 = scoreList[4];
        //}
        //if (scoreList[6] != null) {
        //    data.score6 = scoreList[5];
        //}
        //if (scoreList[7] != null) {
        //    data.score7 = scoreList[6];
        //}
        //if (scoreList[8] != null) {
        //    data.score8 = scoreList[7];
        //}
        //if (scoreList[9] != null) {
        //    data.score9 = scoreList[8];
        //}
        //if (scoreList[10] != null)
        //{
        //    data.score10 = scoreList[9];
        //}

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/highscores.json", json);

    }

    public void SaveDefaultScore()
    {
        ScoreData data = new ScoreData();
        data.player1 = "player1";
        data.player2 = "player2";
        data.player3 = "player3";
        data.player4 = "player4";
        data.player5 = "player5";
        data.player6 = "player6";
        data.player7 = "player7";
        data.player8 = "player8";
        data.player9 = "player9";
        data.player10 = "player10";
        data.score1 = 10;
        data.score2 = 9;
        data.score3 = 8;
        data.score4 = 7;
        data.score5 = 6;
        data.score6 = 5;
        data.score7 = 4;
        data.score8 = 3;
        data.score9 = 2;
        data.score10 = 1;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/highscores.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/highscores.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            ScoreData data = JsonUtility.FromJson<ScoreData>(json);
            playerList.Add(data.player1);
            playerList.Add(data.player2);
            playerList.Add(data.player3);
            playerList.Add(data.player4);
            playerList.Add(data.player5);
            playerList.Add(data.player6);
            playerList.Add(data.player7);
            playerList.Add(data.player8);
            playerList.Add(data.player9);
            playerList.Add(data.player10);
            scoreList.Add(data.score1);
            scoreList.Add(data.score2);
            scoreList.Add(data.score3);
            scoreList.Add(data.score4);
            scoreList.Add(data.score5);
            scoreList.Add(data.score6);
            scoreList.Add(data.score7);
            scoreList.Add(data.score8);
            scoreList.Add(data.score9);
            scoreList.Add(data.score10);
            //playerList[0] = data.player1;
            //playerList[1] = data.player2;
            //playerList[2] = data.player3;
            //playerList[3] = data.player4;
            //playerList[4] = data.player5;
            //playerList[5] = data.player6;
            //playerList[6] = data.player7;
            //playerList[7] = data.player8;
            //playerList[8] = data.player9;
            //playerList[9] = data.player10;
            //scoreList[0] = data.score1;
            //scoreList[1] = data.score2;
            //scoreList[2] = data.score3;
            //scoreList[3] = data.score4;
            //scoreList[4] = data.score5;
            //scoreList[5] = data.score6;
            //scoreList[6] = data.score7;
            //scoreList[7] = data.score8;
            //scoreList[8] = data.score9;
            //scoreList[9] = data.score10;
        }
    }

}
