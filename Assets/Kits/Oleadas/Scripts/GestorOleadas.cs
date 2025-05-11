using System.Collections;
using UnityEngine;
using UnityEngine.Splines;

public class GestorOleadas : MonoBehaviour
{
    [System.Serializable]
    public class LineaGuion
    {
        public float espera;
        public DefinicionOleada oleada;
    }

    [System.Serializable]
    public class GuionOleadas
    {
        public LineaGuion[] lineas;
    }

    [SerializeField] GuionOleadas guion;
    [SerializeField] SplineContainer[] rutas;

    float contador = 0f;
    bool enemigoCreado = false;

    private void Start()
    {
        StartCoroutine(LeeGuion());
    }

    IEnumerator LeeGuion()
    {
        // Pasa por todas las LINEAS de GUION
        for (int i = 0; i < guion.lineas.Length; i++)
        {
            StartCoroutine(LanzaOleadas(guion.lineas[i].oleada));
            yield return new WaitForSeconds(guion.lineas[i].espera);
        }

        GameManager.Instance.NotificaUltimoEnemigoCreado();
    }

    IEnumerator LanzaOleadas(DefinicionOleada oleada)
    {
        // Pasa por todos los BLOQUES de la OLEADA
        for (int i = 0; i < oleada.bloques.Length; i++)
        {
            // Instancia la CANTIDAD de ENEMIGOS del BLOQUE con su RUTA
            for (int j = 0; j < oleada.bloques[i].cantidad; j++)
            {
                Enemigo enemigo = Instantiate(
                oleada.bloques[i].tipoEnemigos,
                Vector3.zero,
                Quaternion.identity);

                enemigo.EstablecerRuta(rutas[Random.Range(0, rutas.Length)]);

                yield return new WaitForSeconds(oleada.bloques[i].tiempoEntreEnemigos);
            }
        }
        
    }
}
