using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    //Scrolling Speed
    [SerializeField] float backgroundScrollSpeed = 0.02f;
    //Material Texture
    Material myMaterial;
    //offSet movement
    Vector2 offSet;

    // Start is called before the first frame update
    void Start()
    {
        //Gets the material
        myMaterial = GetComponent<Renderer>().material;
        //scrolls in the y axis at speed
        offSet = new Vector2(0f, backgroundScrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        //moves the material by offSet every frame
        myMaterial.mainTextureOffset += offSet * Time.deltaTime;
    }
}
