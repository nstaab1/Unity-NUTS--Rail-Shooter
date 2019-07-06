using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadGame", 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
}
