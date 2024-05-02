using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [Header("Personaje")]
    public Player pl;
    public int posicionZ;
    public int lateral;
    public float velocidad;
    private int rango=4;
    private int maxAtras = 4;

    public Vector3 posObjetivo;
    public int carril;

    public Mundo mundo;
    public Transform grafico;

    public LayerMask obstaculos;//suelo
    public LayerMask agua;
    private float distanciaVista = 1f;
    private float escalaInicial = 0.8f;
    public float incremento;

    private void Start()
    {
        Time.timeScale = escalaInicial;
        InvokeRepeating("MirarAgua",1,0.3f);
    }

    void Update()
    {
        if (!pl.vivo || pl.pausado)
        {
            return;
        }
        ActualizarPosicion();
        Inputs();
    }

    public void Inputs() {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Avanzar();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Retroceder();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Laterales(-1);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Laterales(1);
        }
    }

    public void ActualizarPosicion() {
        posObjetivo = new Vector3(lateral, 0, posicionZ);
        transform.position = Vector3.Lerp(transform.position,posObjetivo, velocidad* Time.deltaTime)  ;
    }

    public void Avanzar() {
        
        Rotacion(0);
        if (Mirar())
        {
            return;
        }
        posicionZ++;
        if (posicionZ > carril) {
            carril = posicionZ;
            mundo.CrearCarril();
            AumentoVelocidad();
            pl.AumentarPuntos();
        }
    }

    void AumentoVelocidad() {
        Time.timeScale = escalaInicial + incremento * carril;
    }

    public void Retroceder()
    {
        Rotacion(2);
        if (Mirar())
        {
            return;
        }
        if (posicionZ > carril- maxAtras)
        {
            posicionZ--;
        }
    }

    public void Laterales(int cuanto)
    {
        Rotacion(cuanto);
        if (Mirar()) {
            return;
        }
        //positivo negativo segun el lado
        lateral += cuanto;
        //limites
        lateral = Mathf.Clamp(lateral,-rango, rango);
    }

    void Rotacion(int i) {
        //frente 0 atras 2 izq -1 der 1
        if (i == 0) {
            grafico.eulerAngles = new Vector3(0,0,0);
        } else if (i == 2)
        {
            grafico.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (i == -1)
        {
            grafico.eulerAngles = new Vector3(0, -90, 0);
        }
        else if (i == 1)
        {
            grafico.eulerAngles = new Vector3(0, 90, 0);
        }
    }

    public bool Mirar() {

        RaycastHit hit;
        Ray rayo = new Ray(grafico.position+Vector3.up * 0.5f, grafico.forward);

        if (Physics.Raycast(rayo, out hit, distanciaVista, obstaculos)) {

            return true;
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(grafico.position + Vector3.up * 0.5f, grafico.position + Vector3.up * 0.5f + grafico.forward*distanciaVista);
    }

    public bool MirarAgua()
    {

        RaycastHit hit;
        Ray rayo = new Ray(grafico.position + Vector3.up * 0.5f, Vector3.down);

        if (Physics.Raycast(rayo, out hit, distanciaVista, agua))
        {
            if (hit.collider.CompareTag("Agua"))
            {
                pl.chof();
                pl.muere();
            }
            return true;
        }
        return false;
    }

}
