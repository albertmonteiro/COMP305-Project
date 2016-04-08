using UnityEngine;
using System.Collections;

[System.Serializable]
public class Speed {
	public float minSpeed, maxSpeed;
}

[System.Serializable]
public class Boundary {
	public float xMin, xMax, yMin, yMax;
}


public class EnemyController : MonoBehaviour {
	// PUBLIC INSTANCE VARIABLES
	public Speed speed;
	public Boundary boundary;

    //public float minHoriSpeed = -2f;
    //public float maxHoriSpeed = 2f;

    // PRIVATE INSTANCE VARIABLES
    private float _CurrentSpeed;
	private float _CurrentDrift;

    //private Vector2 _currentPosition;

    //private float _horizontalSpeed;

    // Use this for initialization
    void Start () {
		this._Reset ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 currentPosition = gameObject.GetComponent<Transform> ().position;
		currentPosition.y -= this._CurrentSpeed;
		gameObject.GetComponent<Transform> ().position = currentPosition;
		
		// Check bottom boundary
		if (currentPosition.y <= boundary.yMin) {
			this._Reset();
		}
	}

	// resets the gameObject
	private void _Reset() {
		this._CurrentSpeed = Random.Range (speed.minSpeed, speed.maxSpeed);
		Vector2 resetPosition = new Vector2 (Random.Range(boundary.xMin, boundary.xMax), boundary.yMax);
		gameObject.GetComponent<Transform> ().position = resetPosition;
	}

    //void update()
    //{
    //    this._currentPosition = this._transform.position;

    //    this._currentPosition -= new Vector2(this._horizontalSpeed, this._verticalDrift);
    //    this._transform.position = this._currentPosition;
    //}

    void OnCollisionEnter2D(Collision2D otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Player"))
        {
            this._Reset();
        }

        if(otherCollider.gameObject.CompareTag("PlatformLevel1"))
        {

        }
    }
}
