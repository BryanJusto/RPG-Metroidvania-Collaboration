using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public SimpleHealthBar healthBar;
    public SimpleHealthBar manaBar;
    public Image pause;

    public int maxHealth;
    public int maxMana;
    private int currentHealth;
    private int currentMana;

    private float savedTimeScale;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;

        healthBar.UpdateBar(currentHealth, maxHealth);
        manaBar.UpdateBar(currentMana, maxMana);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) && Time.timeScale != 0)
            ShowPause();
        else if(Input.GetKeyDown(KeyCode.P) && Time.timeScale == 0)
            HidePause();
    }

    public void updateHealth(int currentHealth)
    {
        healthBar.UpdateBar(currentHealth, maxHealth);
    }

    public void updateMana(int currentMana)
    {
        manaBar.UpdateBar(currentMana, maxMana);
    }

    //Saves time scale of game and then sets it to 0 (stop), enables pasue screen
    void ShowPause()
    {
        savedTimeScale = Time.timeScale;
        Time.timeScale = 0;
        pause.gameObject.SetActive(true);

    }

    //Reverts time scale back and disables pause screen
    void HidePause()
    {
        Time.timeScale = savedTimeScale;
        pause.gameObject.SetActive(false);
    }
}
