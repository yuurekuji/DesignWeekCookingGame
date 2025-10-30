using UnityEngine;

public class Flame : MonoBehaviour
{

    public float size;
    public float growth;
    public float rate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
    }
}
