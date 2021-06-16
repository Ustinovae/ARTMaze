using UnityEngine;

public class Player : MonoBehaviour
{
    private readonly float playerSpeed;
    private Vector3 dir;
    private bool inMove;
    private Color color;
    private SpriteRenderer currentCube;

    private bool blockChangeColor = false;

    public Player()
    {
        inMove = false;
        playerSpeed = 4f;
    }

    public void SetBlockChancgeColor(bool b) =>
        blockChangeColor = b;

    public Color GetCurrentColor() =>
        color;

    public void Move(Vector3 dir)
    {
        inMove = true;
        this.dir = dir;
    }

    public void ChangeColor(Color color)
    {
        if (!blockChangeColor)
        {
            this.color = color;
            if(currentCube != null)
                currentCube.color = color;
        }
    }

    public bool InMove() =>
        inMove;

    void Start() =>
        dir = Vector3.zero;

    void Update() =>
        transform.position += dir * playerSpeed * Time.deltaTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent.CompareTag("colorCube"))
        {
            currentCube = collision.gameObject.GetComponent<SpriteRenderer>();
            collision.gameObject.GetComponent<SpriteRenderer>().color = color;
        }
        if (collision.transform.parent.CompareTag("wall"))
        {
            dir = Vector3.zero;
            inMove = false;
            if (currentCube != null)
                transform.position = new Vector3(currentCube.transform.position.x, currentCube.transform.position.y, transform.position.z);
        }
    }
}
