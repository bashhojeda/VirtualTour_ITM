using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotspot : MonoBehaviour
{
    public Renderer esfera360;
    public Texture nuevaTextura;
    public GameObject[] nuevosHotspots;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Detecta clic izquierdo
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform) // Si hizo clic en este objeto
                {
                    CambiarEscena();
                }
            }
        }
    }

    void CambiarEscena()
    {
        if (esfera360 != null)
        {
            esfera360.material.mainTexture = nuevaTextura;
        }
        else
        {
            Debug.LogError("Esfera 360 no asignada en el Inspector");
        }

        foreach (GameObject hs in GameObject.FindGameObjectsWithTag("hotspot"))
        {
            hs.SetActive(false);
        }

        foreach (GameObject hs in nuevosHotspots)
        {
            hs.SetActive(true);
        }
    }
}
