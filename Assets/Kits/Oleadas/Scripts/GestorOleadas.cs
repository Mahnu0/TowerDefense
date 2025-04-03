using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GestorOleadas : MonoBehaviour
{
    [System.Serializable]
    public class LineaGuion
    {
        [SerializeField] public float espera;
        [SerializeField] public DefinicionOleada oleada;
    }

    [System.Serializable]
    public class GuionOleadas
    {
        [SerializeField] public LineaGuion[] lineas;
    }

    public GuionOleadas guion;


    private void Start()
    {
        //LeeGuion(lineas);
    }

    IEnumerator LeeGuion(LineaGuion[] lineas)
    {
        foreach (LineaGuion linea in lineas)
        {

        }
        yield return new WaitForSeconds(5);
    }

    IEnumerator LanzaOleadas()
    {
        yield return new WaitForSeconds(5);
    }
}
