using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScroll : MonoBehaviour
{

public float scrollSpeed = 0.1f;

private MeshRenderer mesh;

    void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Scroll();
    }

    void Scroll()
    {
        x_Scroll = Time.time * scrollSpeed;

        Vector2 offset = new Vector2(x_Scroll, 0f);
        mesh.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
