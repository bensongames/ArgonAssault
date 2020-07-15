using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [Tooltip("Particle Effects")] [SerializeField] GameObject enemyDeathFX;
    [SerializeField] Transform parent;

    private void Start()
    {
        AddNonTriggerBoxCollider();        
    }

    private void OnParticleCollision(GameObject other)
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
