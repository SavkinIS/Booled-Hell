using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using UnityEngine.UIElements;

public class ShipView : MonoBehaviour
{
    [SerializeField] List<GameObject> lives;

    GameManager gameManager;

    public bool TakeDamage { get; set; }
    
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        TakeDamage = false;
    }
    public void RenderLives(int value)
    {
        if (value < lives.Count)
        {
            var last = lives.Last();
            lives.Remove(last);
            Destroy(last.gameObject);
            if (value == 0) Debug.Log("GameOver");
        }
    }

     public void Die()
    {
        gameObject.SetActive(false);
        gameManager.Loose();
    }




}
