using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] GameObject powerUpIndicator;

    public bool pickedPowerUp = false;
    GameObject focalPoint;
    Rigidbody playerRb;
    // Use this for initialization
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        powerUpIndicator.transform.position = transform.position;
        float vertical = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * vertical * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("powerUp"))
        {
            pickedPowerUp = true;
            powerUpIndicator.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdown());
        }
    }

    private IEnumerator PowerUpCountdown()
    {
        yield return new WaitForSeconds(5);
        pickedPowerUp = false;
        powerUpIndicator.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && pickedPowerUp) {
            Debug.Log("With the power of power ups!");
            Rigidbody enenemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enenemyRb.AddForce(awayFromPlayer * 20, ForceMode.Impulse);
        }

    }
}
