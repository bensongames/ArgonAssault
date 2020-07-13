using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadGame", 2f);
    }

    void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
}
