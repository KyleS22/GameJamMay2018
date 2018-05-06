﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {

    public int maxHealth;
    public int currentHealth;
    public BarScript UI = null;

	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
	}

    public void Damage()
    {
        currentHealth--;
        if(UI != null){
            updateUI();
            GetComponentInChildren<SpriteRenderer>().color = Color.red;
            Invoke("clearColor",0.2f);
        }
        if(currentHealth <= 0)
        {
            Kill();
        }
    }

    private void clearColor(){
        GetComponentInChildren<SpriteRenderer>().color = Color.white;
    }

    public void heal(){
        currentHealth = currentHealth + maxHealth/4;
        updateUI();
    }

    void updateUI(){
        UI.setBar(currentHealth*1f/maxHealth);
    }

    public virtual void Kill()
    {
        if(CompareTag("enemy")){
            Debug.Log(gameObject.name);
            MetaScript.GetStat().addKill(gameObject.name);
            GlobalValues.numCreatures--;
        }
        Destroy(gameObject);
        if (CompareTag("anchor"))
        {
            SceneManager.LoadScene("DeathScene", LoadSceneMode.Single);
        }
        
    }
}

