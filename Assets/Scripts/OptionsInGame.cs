using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsInGame : MonoBehaviour
{

    public GameObject optionsMenu;
    public Player pl;
    public GameObject puntos;

    private void Start()
    {
        optionsMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Opciones();
        }
    }

    public void Opciones() {
        pl.pausado = true;
        optionsMenu.SetActive(true);
        puntos.GetComponent<TMPro.TextMeshProUGUI>().text=pl.getPuntos().ToString();
    }

    public void backPlay()
    {
        optionsMenu.SetActive(false);
        pl.pausado = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Home()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
