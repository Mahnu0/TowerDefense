using UnityEngine;
using UnityEngine.Events;

public class BotonAlSoltar : MonoBehaviour
{
    public UnityEvent accion;
    MenuDesplegable menuDesplegable;

    private void Awake()
    {
        menuDesplegable = GetComponentInParent<MenuDesplegable>();
    }

    public void EntraPuntero()
    {
        menuDesplegable.EstableceEvento(accion);
    }

    public void SalePuntero()
    {
        menuDesplegable.EstableceEvento(null);
    }
}
