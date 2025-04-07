using System.Collections;
using UnityEngine;
using UnityEngine.Splines;

public class Test : MonoBehaviour
{
    [SerializeField] Enemigo[] enemigos;
    [SerializeField] SplineContainer[] rutas;
    [SerializeField] DefinicionOleada oleada;

    private void Start()
    {
        StartCoroutine(InstanciaEnemigo());
    }

    IEnumerator InstanciaEnemigo()
    {
        yield return null;

        Enemigo enemigo = Instantiate(
            oleada.bloques[0].tipoEnemigos,
            Vector3.zero,
            Quaternion.identity);

        enemigo.EstablecerRuta(rutas[Random.Range(0, rutas.Length)]);
    }
}
