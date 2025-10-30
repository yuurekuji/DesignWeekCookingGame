using UnityEditor.AssetImporters;
using UnityEngine;
using UnityEngine.UI;

public class Flame : MonoBehaviour
{

    public float size;
    public float growth;
    public float rate;

    public GameObject flame;

    float maxVal = 100;

    public Slider thermost;

    Vector3 flameSize;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        flameSize = flame.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {

        if (size >= 0 && size <= 100)
        {
            size -= Time.deltaTime * rate;
        }
        if (size >= 100)
        {
            size = 100;
        }
        if (size <= 0)
        {
            size = 0;
        }



        if (Input.GetKeyDown(KeyCode.L))
        {
            size += growth;
        }
        Debug.Log(size);

        flame.transform.localScale = flameSize*size / 20f;

        
        thermost.value = size;
    }
}
