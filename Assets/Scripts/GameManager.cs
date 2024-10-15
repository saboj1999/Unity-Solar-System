using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> bodies;
    private float gravitationalConstant = (float)-6.67 * Mathf.Pow(10, -11);
    private float scaleFactor = (float)(1.0 / Mathf.Pow(10, 10));

    public float timeStep;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateBodies();
    }

    private void UpdateBodies()
    {
        foreach(GameObject bodyA in bodies)
        {
            float nextVX = 0;
            float nextVY = 0;
            float nextVZ = 0;

            foreach(GameObject bodyB in bodies)
            {
                if(bodyA != bodyB)
                {
                    float sameBaseDistanceDenominator = 
                    Mathf.Pow(bodyA.GetComponent<BodyProperties>().position.x - bodyB.GetComponent<BodyProperties>().position.x, 2)
                    + Mathf.Pow(bodyA.GetComponent<BodyProperties>().position.y - bodyB.GetComponent<BodyProperties>().position.y, 2)
                    + Mathf.Pow(bodyA.GetComponent<BodyProperties>().position.z - bodyB.GetComponent<BodyProperties>().position.z, 2);

                    float distance = Mathf.Pow(sameBaseDistanceDenominator, 1.0f/2.0f);
                    float denominator = Mathf.Pow(sameBaseDistanceDenominator, 3.0f/2.0f);

                    nextVX += (gravitationalConstant * bodyB.GetComponent<BodyProperties>().mass * 
                    (bodyA.GetComponent<BodyProperties>().position.x - bodyB.GetComponent<BodyProperties>().position.x) * timeStep) / denominator;
                    nextVY += (gravitationalConstant * bodyB.GetComponent<BodyProperties>().mass * 
                    (bodyA.GetComponent<BodyProperties>().position.y - bodyB.GetComponent<BodyProperties>().position.y) * timeStep) / denominator;
                    nextVZ += (gravitationalConstant * bodyB.GetComponent<BodyProperties>().mass * 
                    (bodyA.GetComponent<BodyProperties>().position.z - bodyB.GetComponent<BodyProperties>().position.z) * timeStep) / denominator;

                }
            }

            Vector3 newVelocity = new Vector3(nextVX, nextVY, nextVZ);

            bodyA.GetComponent<BodyProperties>().velocity += newVelocity;

            bodyA.GetComponent<BodyProperties>().position += bodyA.GetComponent<BodyProperties>().velocity * timeStep;

            if(!bodyA.GetComponent<BodyProperties>().isDestroyed)
            {
                bodyA.transform.position = bodyA.GetComponent<BodyProperties>().position * scaleFactor;
            }
        }
    }
}

                    