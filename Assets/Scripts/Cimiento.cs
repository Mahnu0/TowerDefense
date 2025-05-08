using UnityEngine;

public class Cimiento : MonoBehaviour
{
    [SerializeField] GameObject prefabTorreArqueros;
    [SerializeField] GameObject prefabTorreMagica;
    [SerializeField] GameObject prefabTorreCanyones;
    Torre torreConstruida;

    public void ConstruyeTorreArqueros()
    {
        GameObject nuevaTorre = Instantiate(prefabTorreArqueros, transform.position, transform.rotation);
        torreConstruida = nuevaTorre.GetComponent<Torre>();
    }

    public void ConstruyeTorreMagica()
    {
        GameObject nuevaTorre = Instantiate(prefabTorreMagica, transform.position, transform.rotation);
        torreConstruida = nuevaTorre.GetComponent<Torre>();
    }

    public void ConstruyeTorreCanyones()
    {
        GameObject nuevaTorre = Instantiate(prefabTorreCanyones, transform.position, transform.rotation);
        torreConstruida = nuevaTorre.GetComponent<Torre>();
    }

    public bool HayTorreConstruida()
    {
        return torreConstruida != null;
    }
}
