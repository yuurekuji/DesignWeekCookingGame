using UnityEngine;

public class IngredientBounce : MonoBehaviour
{

    public Rigidbody rb;
    public Vector3 force;

    public float CookingTime = 0;


    public GameObject Flame;
    public float multiplyRate;

    public float cookingSpeed;
    public GameObject IngredientManagerObj;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        force = new Vector3(200, 200, 0);

        rb.AddForce(force, ForceMode.Force);
        Flame = GameObject.FindGameObjectWithTag("Flame");
        IngredientManagerObj = GameObject.FindGameObjectWithTag("IngManager");

    }

    // Update is called once per frame
    void Update()
    {
        IngredientManager ingredientManager = IngredientManagerObj.GetComponent<IngredientManager>();

        if (gameObject.tag == "CutSushi")
        {
            cookingSpeed = 0.7f;
        }
        if (gameObject.tag == "CutSalmon")
        {
            cookingSpeed = 1.0f;
        }
        if (gameObject.tag == "CutTuna")
        {
            cookingSpeed = 1.2f;
        }
        multiplyRate = Flame.GetComponent<Flame>().size;


        if (CookingTime >= 1200)
        {
            Destroy(gameObject);

            ingredientManager.AmtIncrease(1);
        }

    }

    private void OnCollisionStay(Collision collision)
    {

        if(collision.gameObject.tag == "Pan")
        {
            CookingTime += Time.deltaTime * multiplyRate * cookingSpeed;

            Debug.Log(CookingTime);
        }
    }

    
}
