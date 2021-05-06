using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingPlayer : MonoBehaviour
{
    public float playerSpeed;
    public Color color;
    public GameObject continueButton;
    
    private Vector3 dir;
    private Vector3 previosDir;
    private bool inMove = false;
    private SpriteRenderer currentCube;

    public void Move(Vector3 dir)
    {
        if (dir != previosDir)
        {
            inMove = true;
            this.dir = dir;
        }
    }

    public void ChangeColor(Color color)
    {
        this.color = color;
        currentCube.color = color;
    }

    public bool InMove() => inMove;

    void Start()
    {
        dir = Vector3.zero;
    }

    void Update()
    {
        transform.position += dir * playerSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("level1.1"))
            continueButton.SetActive(true);

        if (collision.transform.parent.CompareTag("colorCube"))
        {
            currentCube = collision.gameObject.GetComponent<SpriteRenderer>();
            collision.gameObject.GetComponent<SpriteRenderer>().color = color;
        }
        if (collision.transform.parent.CompareTag("wall"))
        {
            if (dir != Vector3.zero)
                previosDir = dir;
            dir = Vector3.zero;
            inMove = false;
            if (currentCube != null)
                transform.position = new Vector3(currentCube.transform.position.x, currentCube.transform.position.y, transform.position.z);
        }
    }
}
