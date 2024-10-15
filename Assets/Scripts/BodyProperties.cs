using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyProperties : MonoBehaviour
{
    public float mass;
    public float radius;
    public Vector3 position;
    public Vector3 velocity;
    public Vector3 rotation;
    private Rigidbody rigidbody;
    public GameManager gameManager;
    public int index;
    public ParticleSystem explosion;
    public bool isDestroyed = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        gameManager = GetComponent<GameManager>();
        transform.localScale = radius * Vector3.one;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotation, Space.Self);
    }

    void OnTriggerEnter(Collider other)
    {
        explosion.Play();
        StartCoroutine("MoveOutOfSceneAfterSeconds", 1.0f);
    }

    IEnumerator MoveOutOfSceneAfterSeconds(int seconds)
    {
        if(mass < 1e+30f)
        {
            isDestroyed = true;
            yield return new WaitForSeconds(seconds);
            transform.Translate(new Vector3(0, 10000, 0));
        }
    }
}
