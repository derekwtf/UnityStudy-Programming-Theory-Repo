using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton { private set; get; }
    public float BestScore { private set; get; }
    public float GameLife { private set; get; }
    public float GameScore { private set; get; }

    private bool isGetScore;
    public bool IsGameOver { private set; get; }

    [SerializeField] BasketController[] baskets;
    private GameObject currentBasket;

    private void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
            DontDestroyOnLoad(singleton);
        }
        else
        {
            Destroy(gameObject);
        }

        //������Ϸ����
        LoadGame();
        
    }

    //��Ϸ��ʼ��
    public void GameInit()
    {
        GameLife = 5;
        //UpdateDifficulty(0);
    }

    //��Ѫ
    public void LifeCheck()
    {
        if (isGetScore)
        {
            isGetScore = false;
        }
        else
        {
            if (GameLife > 1)
            {
                GameLife -= 1;
            }
            else
            {
                GameOver();
            }
        }        
    }

    //�Ʒ�
    public void UpdateScore(int score)
    {
        GameScore += score;
        isGetScore = true;

        Debug.Log("update to new score: " + GameScore);

        if (GameScore > BestScore)
        {
            BestScore = GameScore;
        }

        //�����Ѷ�
        if (GameScore > 10)
        {
            UpdateDifficulty(2);
        }
        else if (GameScore > 5)
        {
            UpdateDifficulty(1);
        }
    }

    //�����Ѷ�
    public void UpdateDifficulty(int difficulty)
    {
        
        if (currentBasket != null)
        {
            Destroy(currentBasket.gameObject);
        }

        currentBasket = Instantiate(baskets[difficulty].gameObject, new Vector3(0, 10, 30), baskets[0].transform.rotation);      
    }

    //��Ϸ����
    public void GameOver()
    {
        IsGameOver = true;
        SaveGame();
    }



    //�洢��
    [Serializable]
    class SaveData
    {
        public float Best;
    }

    //�洢����
    public void SaveGame()
    {
        SaveData data = new SaveData();
        data.Best = BestScore;

        string saveStr = JsonUtility.ToJson(data);
        string path = Application.persistentDataPath + "/save.json";

        File.WriteAllText(path, saveStr);
    }

    //��������
    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/save.json";
        if (File.Exists(path))
        {
            string saveStr = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(saveStr);
            BestScore = data.Best;
        }
    }


}
