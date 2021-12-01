using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UniRx;
using Assets.Scripts.Data;
using UnityEngine.SceneManagement;
using System;

public class DataView : MonoBehaviour
{
    [SerializeField] Button level1; 
    [SerializeField] Button level2; 
    [SerializeField] Button level3; 
    [SerializeField] Button randomLevel;
    [SerializeField] Button reset;
    [SerializeField] TMP_Text totalEnemyKilled;
    [SerializeField] TMP_Text totalAsteroidDestroyed;

    GameData gameData; 

    private void Start()
    {
        //Assign methods to buttons
        level1.OnClickAsObservable().RepeatUntilDestroy(this).Subscribe(sc => LoadScene(1));  
        level2.OnClickAsObservable().RepeatUntilDestroy(this).Subscribe(sc => LoadScene(2));  
        level3.OnClickAsObservable().RepeatUntilDestroy(this).Subscribe(sc => LoadScene(3));
        randomLevel.OnClickAsObservable().RepeatUntilDestroy(this).Subscribe(sc => LoadScene(4));
        reset.OnClickAsObservable().RepeatUntilDestroy(this).Subscribe(sc => Reset());
        ResetValues +=()=> SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SetActiveLevel1(bool flag)
    {
        level1.gameObject.SetActive(flag);
    }
    public void SetActiveLevel2(bool flag)
    {
        level2.gameObject.SetActive(flag);
    }
    public void SetActiveLevel3(bool flag)
    {
        level3.gameObject.SetActive(flag);
    }

    public void SetTextEnemyKilled(string text)
    {
        totalEnemyKilled.text = text;
    }
    public void SetTextAsteroidDestroyed(string text)
    {
        totalAsteroidDestroyed.text = text;
    }

    void LoadScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }


    void Reset()
    {
        Debug.Log("reset");
        ResetValues?.Invoke();
    }

    public event Action ResetValues; 
}
