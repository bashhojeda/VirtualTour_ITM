using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereTextureChanger : MonoBehaviour
{
    public Texture[] textures;
    private int currentIndex = 0;
    private Material sphereMaterial;

    void Start()
    {
        sphereMaterial = GetComponent<Renderer>().material;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeTexture();
        }
    }

    void ChangeTexture()
    {
        currentIndex = (currentIndex + 1) % textures.Length;
        sphereMaterial.mainTexture = textures[currentIndex];
    }
}
