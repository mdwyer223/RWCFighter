using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalController : MonoBehaviour {

    static bool loadLevel = false;

	void Start () {
        if(!loadLevel)
        {
            //.LoadScene("2dfighter");
            loadLevel = true;
        }
    }
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        if(Input.GetKeyDown(KeyCode.LeftAlt))
        {
            SceneManager.LoadScene("2dfighter");
        }
	}
}
