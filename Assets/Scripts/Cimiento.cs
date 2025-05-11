using UnityEngine;

public class Cimiento : MonoBehaviour
{
    [Header("Torres Arqueros")]
    [SerializeField] GameObject prefabTorreArquerosLv0;
    [SerializeField] GameObject prefabTorreArquerosLv1;
    [SerializeField] GameObject prefabTorreArquerosLv2;
    
    [Header("Torres Magicas")]
    [SerializeField] GameObject prefabTorreMagicaLv0;
    [SerializeField] GameObject prefabTorreMagicaLv1;
    [SerializeField] GameObject prefabTorreMagicaLv2;
    
    [Header("Torres Canyones")]
    [SerializeField] GameObject prefabTorreCanyonesLv0;
    [SerializeField] GameObject prefabTorreCanyonesLv1;
    [SerializeField] GameObject prefabTorreCanyonesLv2;

    Torre torreConstruida;
    GameObject nuevaTorre;

    string tipoTorre;

    public void ConstruyeTorreArquerosLv(int level)
    {
        DestruyeTorre();

        if (level == 0)
            nuevaTorre = Instantiate(prefabTorreArquerosLv0, transform.position, transform.rotation);
        else if (level == 1)
            nuevaTorre = Instantiate(prefabTorreArquerosLv1, transform.position, transform.rotation);
        else
            nuevaTorre = Instantiate(prefabTorreArquerosLv2, transform.position, transform.rotation);

        torreConstruida = nuevaTorre.GetComponent<Torre>();
        tipoTorre = "TorreArqueros";
    }

    public void ConstruyeTorreMagicaLv(int level)
    {
        DestruyeTorre();

        if (level == 0)
            nuevaTorre = Instantiate(prefabTorreMagicaLv0, transform.position, transform.rotation);
        else if (level == 1)
            nuevaTorre = Instantiate(prefabTorreMagicaLv1, transform.position, transform.rotation);
        else
            nuevaTorre = Instantiate(prefabTorreMagicaLv2, transform.position, transform.rotation);

        torreConstruida = nuevaTorre.GetComponent<Torre>();
        tipoTorre = "TorreMagica";
    }

    public void ConstruyeTorreCanyonesLv(int level)
    {
        DestruyeTorre();

        if (level == 0)
            nuevaTorre = Instantiate(prefabTorreCanyonesLv0, transform.position, transform.rotation);
        else if (level == 1)
            nuevaTorre = Instantiate(prefabTorreCanyonesLv1, transform.position, transform.rotation);
        else
            nuevaTorre = Instantiate(prefabTorreCanyonesLv2, transform.position, transform.rotation);

        torreConstruida = nuevaTorre.GetComponent<Torre>();
        tipoTorre = "TorreCanyones";
    }

    public void DestruyeTorre()
    {
        if (torreConstruida)
            Destroy(torreConstruida.gameObject);
    }

    public bool HayTorreConstruida()
    {
        return torreConstruida != null;
    }

    public string TipoTorre()
    {
        return tipoTorre;
    }
}
