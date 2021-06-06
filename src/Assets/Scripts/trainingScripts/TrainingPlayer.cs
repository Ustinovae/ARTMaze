using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingPlayer : MonoBehaviour
{
    private float playerSpeed;
    private Vector3 dir;
    private Vector3 previosDir;
    private bool inMove;
    private Color color;
    private SpriteRenderer currentCube;
    private bool block = false;
    private bool blockChangeColor = false;

    

    public TrainingPlayer()
    {
        inMove = false;
        color = new Color(1f, 0.03137255f, 0.03137255f);
        playerSpeed = 4f;
    }

    public void SetBlockChancgeColor(bool b)
    {
        blockChangeColor = b;
    }

    public void SetBlock(bool l)
    {
        block = l;
    }

    public Color GetCurrentColor() =>
        color;

    public void Move(Vector3 dir)
    {
        if (dir != previosDir && !block)
        {
            inMove = true;
            this.dir = dir;
        }
    }

    public void ChangeColor(Color color)
    {
        if (!blockChangeColor)
        {
            this.color = color;
            if (currentCube != null)
                currentCube.color = color;
        }
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
