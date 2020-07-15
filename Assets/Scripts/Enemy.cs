using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [Tooltip("Particle Effects")] [SerializeField] GameObject enemyDeathFX;
    [SerializeField] Transform parent;
    [SerializeField] private int score = 12;

    ScoreBoard scoreBoard;

    private void Start()
    {
        AddNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void OnParticleCollision(GameObject other)
    {
        scoreBoard.ScoreHit(score);
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
