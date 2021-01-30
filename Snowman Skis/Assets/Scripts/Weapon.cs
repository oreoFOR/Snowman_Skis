using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject crackedBall;
    public SnowManMover mover;
    bool hasHit;
    List<GameObject> currentCracked = new List<GameObject>();
    public ScoreManager scoreManager;
    public FeverManager feverManager;
    public enum WeaponType
    {
        arms,
        fever
    }
    public WeaponType weaponType;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !hasHit && !mover.gameOver)
        {
            Body body = collision.gameObject.GetComponentInParent<Body>();
            body.EnemySmash();
            StartCoroutine(ResetTime());
            GameObject latestObj = Instantiate(crackedBall, collision.gameObject.transform.position, Quaternion.identity);
            currentCracked.Add(latestObj);
            Time.timeScale = 0.85f;
            mover.hasHit = true;
            if (body.bodyType == Body.BodyType.snowman)
            {
                print("col");
                Destroy(collision.gameObject);
                scoreManager.IncrementScore(1);
                if(weaponType == WeaponType.fever)
                {
                    //feverManager.DeactivateFever();
                }
                else
                {
                    hasHit = true;
                }
            }
        }
    }
    IEnumerator ResetTime()
    {
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 1;
        hasHit = false;
        mover.hasHit = false;
        yield return new WaitForSeconds(1f);
        if (!mover.gameOver)
        {
            print("des");
            GameObject latestObj = currentCracked[0];
            currentCracked.RemoveAt(0);
            Destroy(latestObj);
        }
    }
}
