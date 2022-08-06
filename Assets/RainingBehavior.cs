using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainingBehavior : MonoBehaviour
{
    public GameObject objectPrefab;
    public Rigidbody2D gravity;

    // Start is called before the first frame update
    void Start()
    {
        this.name = "F"+GetInstanceID();
        GameObject.Find(this.name+"/O").GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        gravity = objectPrefab.AddComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(this.transform.position.x +";"+ this.transform.position.y);
        if (this.transform.position.x < -200 || this.transform.position.x > 1100 || this.transform.position.y < -200 || this.transform.position.y > 600)
        {
            Destroy(objectPrefab);
        }
    }
}
