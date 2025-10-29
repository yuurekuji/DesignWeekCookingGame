using UnityEngine;

public class IngredientBounce : MonoBehaviour
{

    public Rigidbody rb;
    public Vector3 force;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        force = new Vector3(200, 200, 0);

        rb.AddForce(force, ForceMode.Force);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
