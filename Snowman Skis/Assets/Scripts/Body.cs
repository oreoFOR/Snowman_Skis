using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public GameObject bottomBall;
    public GameObject crackedBottomBall;
    public Rigidbody topBall;
    public Transform[] features;
    public enum BodyType
    {
        snowman,
        tree
    }
    public BodyType bodyType = BodyType.snowman;
    public void Smash()
    {
        if(bodyType == BodyType.snowman)
        {
            for (int i = 0; i < features.Length; i++)
            {
                features[i].parent = null;
                features[i].GetComponent<Rigidbody>().isKinematic = false;
            }
            if (topBall != null)
                topBall.constraints = RigidbodyConstraints.None;
            Instantiate(crackedBottomBall, bottomBall.transform.position, Quaternion.identity);
            Destroy(bottomBall);
        }
    }
    public void EnemySmash()
    {
        if(bodyType == BodyType.snowman)
        {
            for (int i = 0; i < features.Length; i++)
            {
                features[i].parent = null;
                features[i].GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
}
