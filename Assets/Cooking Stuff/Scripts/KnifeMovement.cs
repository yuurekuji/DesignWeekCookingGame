using System.Collections.Generic;
using UnityEngine;

public class KnifeMovement : MonoBehaviour
{

    private List<Joycon> joycons;

    // Values made available via Unity
    public float[] stick;
    public Vector3 gyro;
    public Vector3 accel;
    public int jc_ind = 0;
    public Quaternion orientation;

    public float speed;

    public Rigidbody Rigidbody;

    [Header("Cutting")]

    public GameObject CutPiece;
    public GameObject Ingredient;


    int CutAmount;

    public int CutCounter;

    public int index;
    public GameObject IngredientManagerObj;

    public int indexIncrement;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gyro = new Vector3(0, 0, 0);
        accel = new Vector3(0, 0, 0);
        // get the public Joycon array attached to the JoyconManager in scene
        joycons = JoyconManager.Instance.j;
        if (joycons.Count < jc_ind + 1)
        {
            Destroy(gameObject);
        }

        Rigidbody = GetComponent<Rigidbody>();
        indexIncrement = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (joycons.Count > 0)
        {
            Joycon j = joycons[jc_ind];

            // Gyro values: x, y, z axis values (in radians per second)
            gyro = j.GetGyro();

            // Accel values:  x, y, z axis values (in Gs)
            accel = j.GetAccel();

            orientation = j.GetVector();

            Vector3 move = new Vector3( 0, gyro.y / speed, 0f);
            
            gameObject.transform.position += move * Time.deltaTime;

        }

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Roll")
        {

            Ingredient = collision.gameObject;
            CutPiece = Ingredient.GetComponent<IngredientCut>().CutPiece;
            CutAmount = Ingredient.GetComponent<IngredientCut>().NumOfCuts;

            

            float x = collision.transform.position.x;

            float y = collision.gameObject.transform.localScale.y;
            
            Instantiate(CutPiece);

            y -= 1f / CutAmount;
            x += 1f / CutAmount;

            CutCounter += 1;

            collision.transform.localScale = new Vector3(1,y,1);
            collision.transform.position = new Vector3(x,1.5f,1.4f);

            if (CutCounter == CutAmount)
            {
                
                Destroy(collision.gameObject);
                CutCounter = 0;

                IngredientManager ingredientManager = IngredientManagerObj.GetComponent<IngredientManager>();

                ingredientManager.IndexIncrease(indexIncrement);
                
                if(indexIncrement <= ingredientManager.SushiIngredients.Count-1)
                {
                    indexIncrement += 1;
                    ingredientManager.spawnSushiIngredients();

                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (CutCounter == CutAmount)
        {
            IngredientManager ingredientManager = IngredientManagerObj.GetComponent<IngredientManager>();
            ingredientManager.spawnSushiIngredients();

        }

    }

}
