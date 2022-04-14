using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(-1f, 1f)]
    public float scrollSpeed = 0.5f;
    private float offset;
    private Material mat;
    bool changedir;
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        changedir = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (changedir == false){
            offset += (Time.deltaTime * scrollSpeed) / 10f;
            mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        }
        if (changedir == true)
        {
            offset -= (Time.deltaTime * scrollSpeed) / 10f;
            mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        }
        if (offset > 0.145)
        {
            changedir = true;
      
        }
        if (offset < -0.17)
        {
            changedir = false;
        }
    }
}
