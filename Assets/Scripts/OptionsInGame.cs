using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsInGame : MonoBehaviour
{
    public Player pl;
    public GameObject puntos;
    public GameObject optionsMenu;
    public GameObject optionsBack;

    private void Start()
    {
        optionsMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Opciones(true);
        }
    }

    public void OpcionesBack(bool vivo) {
        optionsBack.GetComponent<Button>().interactable=vivo;
    }

    public void Opciones(bool vivo) {
        pl.pausado = true;
        optionsMenu.SetActive(true);
        OpcionesBack(vivo);
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
