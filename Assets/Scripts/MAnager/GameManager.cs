using Assets.Scripts.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UniRx;
using TMPro;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField] EnemyLevelManager levelManager;
    [SerializeField] int currentLvl;
    [SerializeField] Vector2 enemyObjectsRangeCount;
    [SerializeField] Vector2 enemyObjectsSpawnPeriod;
    [SerializeField] TMP_Text enemyCountTx;
    [SerializeField] float loadSceneAfter;
    


    GameData gameData;
    ReactiveProperty< bool> gameStatus;
    int asterCount;
    int enemyCount;
    private int enemyCountTxt;

    void Start()
    {
        gameData = DataWork.GetGameData();
        levelManager = Instantiate(levelManager, transform);
        
        Level level = gameData.GetLevel(currentLvl);
        if ( level != null&&level.IsInit())
        {
            SetLevelManager(level);
        }
        else
        {
            level.EnemyCount = Mathf.FloorToInt(Random.Range(enemyObjectsRangeCount.x, enemyObjectsRangeCount.y));
            level.AsteroidCount = Mathf.FloorToInt(Random.Range(enemyObjectsRangeCount.x, enemyObjectsRangeCount.y));
            level.EnemySpanPeriod = Random.Range(enemyObjectsSpawnPeriod.x, enemyObjectsSpawnPeriod.y);
            level.AsteroidSpanPeriod = Random.Range(enemyObjectsSpawnPeriod.x, enemyObjectsSpawnPeriod.y);

            SetLevelManager(level);

            gameData.UpdateLevel(level, currentLvl);
            DataWork.Save(gameData);
        }

        levelManager.Initcialaze();
        gameStatus = new ReactiveProperty<bool>(true);

        //gameStatus.ObserveEveryValueChanged(g => gameStatus).Where(gs => gs.Value == false).Select(a=>a.Value==false).Subscribe(_ => StartCoroutine(LoadMainScene()));

        var ob = Observable.EveryUpdate().Where(_=> Input.GetButtonDown("Cancel")).RepeatUntilDestroy(this).Subscribe(_ => StartCoroutine(LoadMainScene()));

        enemyCountTxt = levelManager.EnemyCount;
        enemyCountTx.text = enemyCountTxt.ToString();
    }

    public bool isPlaying => gameStatus.Value;

    public void Win()
    {
        StartCoroutine(LoadMainScene());
    }

    private void UpdateData()
    {
        gameData.UpdateIndicators(enemyCount, asterCount);
        DataWork.Save(gameData);
        gameStatus.Value = false;       
    }

    public void Loose()
    {
        StartCoroutine(LoadMainScene());
    }

    public void AddAstr() => asterCount++;
    public void AddEnemy() => enemyCount++;

    public void ChangeEnemyCount()
    {
        enemyCountTxt--;
        enemyCountTx.text = enemyCountTxt.ToString();

        if (enemyCountTxt <= 0 && gameStatus.Value == true)
        {
            Win();
        }
    }

    void SetLevelManager(Level level)
    {
        levelManager.EnemyCount = level.EnemyCount;
        levelManager.AsteroidAmount = level.AsteroidCount;
        levelManager.AsteroidSpanPeriod = level.AsteroidSpanPeriod;
        levelManager.EnemySpawnPeriod = level.EnemySpanPeriod;
    }


    IEnumerator LoadMainScene()
    {
        UpdateData();
        yield return new  WaitForSeconds(loadSceneAfter);
        
        SceneManager.LoadScene(0);
    }

    void OnDestroy()
    {
        DOTween.Clear(destroy: true);
    }

}
