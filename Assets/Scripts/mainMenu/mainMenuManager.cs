using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuManager : MonoBehaviour
{
    public GameObject optionsPage;
    public GameObject extrasPage;
    public GameObject mainPage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        SceneManager.LoadScene("testScene");
    }

    public void options()
    {
        mainPage.SetActive(false);
        optionsPage.SetActive(true);
    }

    public void extras()
    {
        mainPage.SetActive(false);
        extrasPage.SetActive(true);
    }

    public void Back()
    {
        extrasPage.SetActive(false);
        optionsPage.SetActive(false);
        mainPage.SetActive(true);
    }
}
