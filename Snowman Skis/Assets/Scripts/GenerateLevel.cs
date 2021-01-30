using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public int snowManNum;
    public GameObject[] snowmen;
    Transform currentMan;
    public Transform pos;
    public Vector2 minMaxDist;
    public float horizontalDist;
    public Vector2 edges;
    int type;
    public GameObject trigger;
    public GameObject finishLine;
    public ScoreManager scoreManager;
    public GameManager gameManager;
    public GameObject feverTrigger;
    bool spawnedFever;
    private void Start()
    {
        for (int i = 0; i < snowManNum; i++)
        {
            currentMan = Instantiate(snowmen[type], pos.position, pos.rotation).transform;
            float xRand = Random.Range(-horizontalDist,horizontalDist);
            float zrand = Random.Range(minMaxDist.x, minMaxDist.y);
            Vector3 offset = new Vector3(xRand, 0, 0);
            Vector3 position = new Vector3(Mathf.Clamp(pos.position.x + offset.x, edges.x, edges.y), pos.position.y, pos.position.z);
            currentMan.position = position + pos.forward * zrand;
            GenerateTrigger(pos.position, currentMan.position);
            GenerateFever(pos.position, currentMan.position);
            pos.position = currentMan.position;
            type = type == 1 ? 0 : 1;
            if(i == snowManNum - 1)
            {
                FinishLine finihsLine = Instantiate(finishLine, currentMan.position, Quaternion.identity).GetComponent<FinishLine>();
                finihsLine.manager = gameManager;
            }
        }
    }
    void GenerateTrigger(Vector3 lastPos, Vector3 currentPos)
    {
        GameObject col = Instantiate(trigger, (lastPos + currentPos) / 2, Quaternion.identity);
        col.transform.forward = currentPos - lastPos;
        col.GetComponent<Trigger>().manager = scoreManager;
        float posDist = (currentPos - lastPos).magnitude;
        col.transform.localScale = new Vector3(col.transform.localScale.x, col.transform.localScale.y, posDist);
    }
    void GenerateFever(Vector3 lastPos, Vector3 currentPos)
    {
        if (!spawnedFever)
        {
            int rand = Random.Range(0, 5);
            if (rand == 3)
            {
                GameObject col = Instantiate(feverTrigger, (lastPos + currentPos) / 2, Quaternion.Euler(115,0,0));
                float range = Random.Range(-4, 4);
                col.transform.position = new Vector3(col.transform.position.x + range, col.transform.position.y, col.transform.position.z);
                spawnedFever = true;
            }
        }
    }
}
