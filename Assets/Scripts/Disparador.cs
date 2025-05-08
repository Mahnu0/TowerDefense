using System.Linq;
using UnityEngine;

public class Disparador : MonoBehaviour
{
    [SerializeField] private float radioDeteccion;
    [SerializeField] private float radioPerdidaDeObjetivo;
    [SerializeField] private string[] tagsObjetivos;
    [SerializeField] private GameObject prefabProyectil;
    [SerializeField] private float tiempoEntreProyectiles;
    [SerializeField] private Transform origenProyectil;
    [SerializeField] private float alturaSaltoProyectil;

    private Transform objetivo;
    private float tiempoParaSiguienteProyectil = 0f;

    private void Update()
    {
        if (!objetivo)
            DetectaObjetivo();
        else
        {
            tiempoParaSiguienteProyectil -= Time.deltaTime;

            if (tiempoParaSiguienteProyectil <= 0)
            {
                Dispara();
                tiempoParaSiguienteProyectil = tiempoEntreProyectiles;
            }

            CompruebaObjetivo();
        }
    }

    private void DetectaObjetivo()
    {
        // Obtener todos los ENEMIGOS en el radio de deteccion y asignar el MAS CERCANO
        Collider[] objetivosCercanos = Physics.OverlapSphere(transform.position, radioDeteccion);

        foreach (Collider c in objetivosCercanos)
        {
            if (tagsObjetivos.Contains(c.tag))
            {
                Transform posibleObjetivo = c.GetComponent<Transform>();

                float distanciaNueva;
                float distancia;

                if (objetivo)
                {
                    distanciaNueva = Vector3.Distance(transform.position, posibleObjetivo.position);
                    distancia = Vector3.Distance(transform.position, objetivo.position);

                    if (distanciaNueva < distancia)
                        objetivo = posibleObjetivo;
                }
                else
                    objetivo = posibleObjetivo;
            }
        }
    }

    private void CompruebaObjetivo()
    {
        // Comprobar que el ENEMIGO ASIGNADO siga a rango de la torre, sino, 
       bool sigueEnRadioDeDeteccion = false;

        Collider[] objetivosCercanos = Physics.OverlapSphere(transform.position, radioPerdidaDeObjetivo);

        foreach (Collider c in objetivosCercanos)
        {
            Transform t = c.GetComponent<Transform>();

            if (t == objetivo)
                sigueEnRadioDeDeteccion = true;
        }

        if (!sigueEnRadioDeDeteccion)
            objetivo = null;
    }

    private void Dispara()
    {
        Debug.Log("Shoot");

        GameObject go = Instantiate(prefabProyectil);
        Proyectil proyectil = go.GetComponent<Proyectil>();

        proyectil.Inicializar(origenProyectil.position, objetivo.position, alturaSaltoProyectil);
    }
}
