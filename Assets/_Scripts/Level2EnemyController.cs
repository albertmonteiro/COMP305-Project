using UnityEngine;
using System.Collections;

public class Level2EnemyController : MonoBehaviour
{
    private Vector3 pos1 = new Vector3(4330, 90, 0);
    private Vector3 pos2 = new Vector3(5475, 90, 0);
    private float secondsForOneLength = 5.0f;

    void Update()
    {
        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time / secondsForOneLength, 1f));
    }
}
