using UnityEngine;
using UnityEngine.UI;

public class MapController : MonoBehaviour
{
    public GameObject mapUI; // Panel con el mapa
    public Transform player; // Referencia al jugador
    public Button openMapButton; // Botón para abrir el mapa
    public Button closeMapButton; // Botón para cerrar el mapa

    [System.Serializable]
    public class Location
    {
        public string name;
        public Transform targetTransform; // El objeto con la ubicación
        public Button locationButton; // Botón en el mapa
    }

    public Location[] locations; // Lista de ubicaciones en el mapa

    void Start()
    {
        // Asegurar que el mapa está oculto al inicio
        mapUI.SetActive(false);

        // Asignar eventos a los botones
        openMapButton.onClick.AddListener(OpenMap);
        closeMapButton.onClick.AddListener(CloseMap);

        // Asignar eventos a cada botón de ubicación
        foreach (var loc in locations)
        {
            loc.locationButton.onClick.AddListener(() => TeleportToLocation(loc.targetTransform));
        }
    }

    public void OpenMap()
    {
        mapUI.SetActive(true);
        closeMapButton.gameObject.SetActive(true);  // Activa el botón de cerrar
        openMapButton.gameObject.SetActive(false);  // Desactiva el botón de abrir
    }

     public void CloseMap()
    {
        mapUI.SetActive(false);
        closeMapButton.gameObject.SetActive(false);  // Desactiva el botón de cerrar
        openMapButton.gameObject.SetActive(true);  // Activa el botón de abrir
    }

    public void TeleportToLocation(Transform target)
    {
        if (target != null)
        {
            player.position = target.position; // Teletransportar al jugador
        }
        CloseMap();
    }
}
