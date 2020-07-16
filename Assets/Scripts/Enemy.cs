using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [Tooltip("Particle Effects")] [SerializeField] GameObject enemyDeathFX;
    [SerializeField] Transform parent;
    [SerializeField] private int score = 25;
    [SerializeField] private int hitPoints = 10;

    ScoreBoard scoreBoard;

    private void Start()
    {
        AddNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }
    void ProcessHit()
    {
        scoreBoard.ScoreHit(score);
        hitPoints -= hitPoints;
        if (hitPoints <= 0)
        {
            DestroyEnemy();
        }
    }

    private void DestroyEnemy()
    {
        GameObject fx = Instantiate(enemyDeathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }


    private void AddNonTriggerBoxCollider()
    {
        var boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

}
