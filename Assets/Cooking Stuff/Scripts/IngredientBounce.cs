using UnityEngine;

public class IngredientBounce : MonoBehaviour
{

    public Rigidbody rb;
    public Vector3 force;

    public float time = 0;
    public float rate = 1;

    public GameObject Flame;
    float multiplyRate;

    public float cookingSpeed;
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

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Pan")
        {
            multiplyRate = Flame.GetComponent<Flame>().size;

            time += Time.deltaTime * multiplyRate * cookingSpeed;

            Debug.Log(time);
        }
    }

    
}
