using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour {

    [SerializeField]
    private float fillAmount;

    [SerializeField]
    private Image content;

    public float MaxVal { get; set; }

    public float Value {
        set {
            fillAmount = MapHealth(value, MaxVal);
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        HandleBar();
	}

    public void HandleBar() {
        content.fillAmount = fillAmount;
    }

    private float MapHealth(float currentHealth, float maxHealth) {
        return currentHealth / maxHealth; 
    }
}
