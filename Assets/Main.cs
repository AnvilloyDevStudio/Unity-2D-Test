using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public GameObject sqPrefab;
    public GameObject crPrefab;
    public TMPro.TextMeshProUGUI dirText;
    public TMPro.TextMeshProUGUI fpsText;
    public TMPro.TextMeshProUGUI tickMsText;

    public static Direction dir = Direction.Down;

    public float deltaTime;
    public float deltaTimeTick;

    public enum Direction
    { Left, Right, Up, Down }

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.gravity = new Vector2(0, -50);
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        while (true)
        {
            Instantiate(sqPrefab, GetRandomPosition(), Quaternion.identity).transform.SetParent(GameObject.Find("Canvas").transform, false);
            Instantiate(crPrefab, GetRandomPosition(), Quaternion.identity).transform.SetParent(GameObject.Find("Canvas").transform, false);
            yield return new WaitForSeconds(0.1f);
        }
    }

    Vector3 GetRandomPosition()
    {
        switch (dir)
        {
            case Direction.Down:
                return new Vector3(Random.Range(-450, 450), 250, 0);
            case Direction.Up:
                return new Vector3(Random.Range(-450, 450), -250, 0);
            case Direction.Left:
                return new Vector3(500, Random.Range(-200, 200), 0);
            case Direction.Right:
                return new Vector3(-500, Random.Range(-200, 200), 0);
            default:
                return Vector3.zero;
        }
    }

    // Update is called once per frame
    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = "FPS: " + Mathf.Ceil(fps).ToString();
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            dir = Direction.Up;
            Physics2D.gravity = new Vector2(0, 50);
            UpdateRender();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            dir = Direction.Down;
            Physics2D.gravity = new Vector2(0, -50);
            UpdateRender();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            dir = Direction.Left;
            Physics2D.gravity = new Vector2(-50, 0);
            UpdateRender();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            dir = Direction.Right;
            Physics2D.gravity = new Vector2(50, 0);
            UpdateRender();
        }

        deltaTimeTick += (Time.deltaTime - deltaTimeTick) * 0.1f;
        float tps = 1.0f / deltaTimeTick;
        tickMsText.text = Mathf.Ceil(deltaTimeTick*1000.0f).ToString() + "ms/tick TPS: " + (int) tps;
    }

    private void UpdateRender()
    {
        dirText.text = "Direction: "+dir.ToString();
    }
}
