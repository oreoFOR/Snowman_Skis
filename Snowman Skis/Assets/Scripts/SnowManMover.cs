using UnityEngine;

public class SnowManMover : MonoBehaviour
{
    public float speed;
    public bool hasHit;
    bool move;
    public float speedX;
    float x;
    public bool gameOver;
    public bool gameStarted;
    public Transform body;
    public GameObject crackedBottomBall;
    public GameObject bottomBall;
    public Rigidbody head;
    public Rigidbody[] arms;
    public GameManager manager;
    public FeverManager feverManager;

    public Vector3 lastRot;
    public Vector3 lastBodyRot;

    bool firstTap;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            move = true;
            firstTap = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            move = false;
        }
        if (!gameOver && gameStarted)
        {
            if (move && !firstTap)
            {
                float yRot = transform.rotation.eulerAngles.y;
                if ((yRot < 80 && yRot >= 0)||(yRot < 360 && yRot > 280))
                {
                    lastRot = transform.localEulerAngles;
                    lastBodyRot = body.localEulerAngles;
                    x = Input.GetAxis("Mouse X") * speedX;
                    transform.Rotate(Vector3.up * x);
                    body.Rotate(Vector3.back * x / 2f);
                }
                else
                {
                    transform.localEulerAngles = lastRot;
                    body.localEulerAngles = lastBodyRot;
                }
            }
            else
            {
                firstTap = false;
            }
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !gameOver)
        {
            collision.gameObject.GetComponentInParent<Body>().Smash();
            Death();
        }
        else if (collision.gameObject.CompareTag("Fever"))
        {
            Destroy(collision.gameObject);
            feverManager.ActivateFever();
        }
    }
    void Death()
    {
        manager.GameOver(false);
        gameOver = true;
        head.isKinematic = false;
        arms[0].isKinematic = false;
        arms[1].isKinematic = false;
        arms[2].isKinematic = false;
        arms[3].isKinematic = false;
        Instantiate(crackedBottomBall, bottomBall.transform.position, Quaternion.identity);
        Destroy(bottomBall);
    }
}
