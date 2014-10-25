using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public  float   speed;
    private int     pickupCount;
    public  GUIText countText;

    void Start ()
    {
        pickupCount = 0;
        setCountText ();
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rigidbody.AddForce (movement * speed * Time.deltaTime);
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Pickup") {
            other.gameObject.SetActive (false);
            pickupCount++;
            setCountText ();
        }
    }

    void setCountText ()
    {
        countText.text = "Count: " + pickupCount.ToString ();    
    }
}
