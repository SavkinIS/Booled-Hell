using Assets.Scripts.Controller;
using Assets.Scripts.Model;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UniRx;

public class EnemyLevelManager : MonoBehaviour
{

    [Tooltip("������������� ��������")]
    [SerializeField] float shootRate;
    [Tooltip("�������� ���������� �������")]
    [SerializeField] float speedZEnemy;
    [Tooltip("�������� ������")]
    [SerializeField] EmemyManagerView  ememyManagerView;
    [Tooltip("�������� ����������")]
    [SerializeField] AsteroidManagerView  asteroidsManagerView;
    [Tooltip("������������ ��������� �� ��� Z")]
    [SerializeField] float maxRangeZ;
    [Tooltip("�������� �� ��� �")]
    [SerializeField] float xRangePos;
    [Tooltip("�������� ��������")]
    [SerializeField] float speedZAster;

    /// <summary>
    /// Number of asteroids
    /// </summary>
    int asteroidAmount;
    float asteroidSpanPeriod;
    /// <summary>
    /// Number of enemy
    /// </summary>
    int enemyCount;
    float enemySpawnPeriod;

    EnemyManagerController enemyManagerController;
    EnemyManagerModel enemyManagerModel;
    EmemyManagerView viewENMan;

    AsteroidManagerController asteroidManagerController;
    AsteroidManagerModel asteroidManagerModel;

    GameManager gameManager;

    int enemyCountTxt;

    public int EnemyCount { get => enemyCount; set => enemyCount = value; }
    public int AsteroidAmount { get => asteroidAmount; set => asteroidAmount = value; }
    public float AsteroidSpanPeriod { get => asteroidSpanPeriod; set => asteroidSpanPeriod = value; }
    public float EnemySpawnPeriod { get => enemySpawnPeriod; set => enemySpawnPeriod = value; }

    private void Start()
    {
        //Initcialaze();
    }

    /// <summary>
    /// Initialization, assigning values to viewmodels, defining a controller
    /// </summary>
    public void Initialization()
    {
        gameManager = FindObjectOfType<GameManager>();
        enemyManagerModel = new EnemyManagerModel(xRangePos, shootRate, speedZEnemy, maxRangeZ, enemySpawnPeriod, enemyCount);
        viewENMan = Instantiate(ememyManagerView, transform);
        enemyManagerController = new EnemyManagerController(viewENMan, enemyManagerModel);
        var viewAstrMan = Instantiate(asteroidsManagerView, transform);
        asteroidManagerModel = new AsteroidManagerModel(xRangePos, maxRangeZ, speedZAster, asteroidSpanPeriod, asteroidAmount);
        asteroidManagerController = new AsteroidManagerController(asteroidManagerModel, viewAstrMan);
    }

}
