using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject winningText;
    public TextMeshProUGUI countText;

    public int count;
    private float movementX;
    private float movementY;
    // before the first execution of Update after the MonoBehaviour is created
    public float speed = 0;
    void Start()
    {
        winningText.SetActive(false);


        rb = GetComponent<Rigidbody>();
        count = 0;

        setcountText();
    }

    private void FixedUpdate()

    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);

    }

    void OnTriggerEnter(Collider other)
    {








        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);

            count = count + 1;

            setcountText();

        }

    }



    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;

    }

    void setcountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 7)
        {
            winningText.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            Destroy(gameObject);

            winningText.gameObject.SetActive(true);

            winningText.GetComponent<TextMeshProUGUI>().text = "You Lose!";
        }


    }


}
