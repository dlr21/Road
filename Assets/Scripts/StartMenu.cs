using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    public GameObject firstMenu;
    public GameObject playMenu;
    public GameObject optionsMenu;


    private void Start()
    {
        //firstMenu.SetActive(true);
        playMenu.SetActive(false);
        optionsMenu.SetActive(false);
    }

    public void Classic()
    {
        SceneManager.LoadScene("ClassicScene");
    }

    public void Dark()
    {
        SceneManager.LoadScene("DarkScene");
    }

    public void Caos()
    {
        SceneManager.LoadScene("CaosScene");
    }

    public void PlayMenu() {
        firstMenu.SetActive(false);
        playMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void OptionsMenu()
    {
        firstMenu.SetActive(false);
        playMenu.SetActive(false);
        optionsMenu.SetActive(true);
        GameObject.Find("SonidoPermanente").GetComponent<SonidoEntreEscenas>().setAudioSliders();
    }

    public void backPlay()
    {
        firstMenu.SetActive(true);
        playMenu.SetActive(false);
        optionsMenu.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

}
