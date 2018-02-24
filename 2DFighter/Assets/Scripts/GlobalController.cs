using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalController : MonoBehaviour {

    static bool loadLevel = false;


    public GameObject bullet;
    bool bulletSpawn = true;

    public int timer = 200;
    public int ticker = 0;

	void Start () {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Debug.Log("Loaded bullet into scene");
            bullet = Resources.Load("Bullet") as GameObject;
            Debug.Log(bullet);
        }
        /*
         if (!loadLevel)
        {
            SceneManager.LoadScene("2DFighterUI");
            loadLevel = true;
        }
        */
    }
	
	void Update () {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (ticker < timer)
            {
                ticker++;
            }
            else
            {
                if (bulletSpawn)
                {
                    Debug.Log("Bullet Spawn");
                    Instantiate(bullet, new Vector3(0, 0, 0), Quaternion.identity);
                    //bulletSpawn = true;
                }
                ticker = 0;
            }


            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
        }

        /*
        if(Input.GetKeyDown(KeyCode.LeftAlt))
        {
            SceneManager.LoadScene("2DFighterUI");
        }
        */
	}
}
