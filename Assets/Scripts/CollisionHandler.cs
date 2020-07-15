using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [Tooltip("In seconds")][SerializeField] float levelLoadDelay = 1f;
    [Tooltip("Particle Effects")][SerializeField] GameObject playerDeathFX;

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        playerDeathFX.SetActive(true);
        SendMessage("OnPlayerDeath");
        Invoke("ReloadLevel", levelLoadDelay);        
    }

    private void ReloadLevel() // String referenced
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
