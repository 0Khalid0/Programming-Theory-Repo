using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Cube;
    public GameObject Sphere;
    public GameObject Cylinder;

    [SerializeField] private float coolDown = 2;
    private float coolDownTimer;
    private bool isReadyToSpawn = true;

    public Vector3 m_ShapeScale = new Vector3(0.5f, 0.5f, 0.5f);
    public Vector3 ShapeScale //ENCAPSULATION
    {
        get { return m_ShapeScale; }
        private set
        {
            if (value.x > 1.0f || value.y > 1.0f || value.z > 1.0f)
            {
                Debug.LogError("Error. Shape scale X,Y,Z values cannot be greater than 1.0f");
                m_ShapeScale = new Vector3(1.0f, 1.0f, 1.0f);
            }
            else
            {
                m_ShapeScale = value;
            }
        }
    }

    [SerializeField] private GameObject SpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPoint = GameObject.Find("SpawnManager/SpawnPoint");
        coolDownTimer = coolDown;
    }

    private void Update()
    {
        if (coolDownTimer > 0)
        {
            coolDownTimer -= Time.deltaTime;
        }
        else if (coolDownTimer < 0)
        {
            coolDownTimer = 0;
        }

        if (!isReadyToSpawn && coolDownTimer == 0)
        {
            isReadyToSpawn = true;
            coolDownTimer = coolDown;
        }
    }

    //Spawn Cube Method //ABSTRACTION
    public void SpawnCube(int size)
    {
        if (isReadyToSpawn)
        {
            GameObject cubeObject = (GameObject)Instantiate(Cube, SpawnPoint.transform.position, Cube.transform.rotation);

            ScaleShape(cubeObject, size); //ABSTRACTION
            isReadyToSpawn = false;
        }
    }

    //Spawn Cylinder Method //ABSTRACTION
    public void SpawnCylinder(int size)
    {
        if (isReadyToSpawn)
        {
            GameObject cylinderObject = (GameObject)Instantiate(Cylinder, SpawnPoint.transform.position, Cylinder.transform.rotation);

            ScaleShape(cylinderObject, size); //ABSTRACTION
            isReadyToSpawn = false;
        }
    }

    //Spawn Sphere Method //ABSTRACTION
    public void SpawnSphere(int size)
    {
        if (isReadyToSpawn)
        {
            GameObject sphereObject = (GameObject)Instantiate(Sphere, SpawnPoint.transform.position, Sphere.transform.rotation);

            ScaleShape(sphereObject, size); //ABSTRACTION
            isReadyToSpawn = false;
        }
    }

    //Scale Shape Method
    private void ScaleShape(GameObject shapeObject, int size) //ABSTRACTION
    {
        float scaleSize;

        scaleSize = Sphere.GetComponent<Shapes>().GetShapeScale(size);
        ShapeScale = new Vector3(scaleSize, scaleSize, scaleSize);
        shapeObject.transform.localScale += new Vector3(scaleSize, scaleSize, scaleSize);
        shapeObject.GetComponent<Shapes>().SetShapeSize(size);
    }
}
