using UnityEngine;
using System.Collections;

public class Level3EnemyControlller : MonoBehaviour {

	private Vector3 pos1 = new Vector3(2100, 12.219f, 0);
	private Vector3 pos2 = new Vector3(2430, 12.219f, 0);
	private float secondsForOneLength = 5.0f;
	private Transform _transform;

	private bool _facingLeft;
	// Update is called once per frame
	void Update()
	{
		transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time / secondsForOneLength, 1f));

	}
	void FixedUpdate(){
		if(_transform.position.x==2100){
			this._flip ();
			this._facingLeft = true;
		}
		if(_transform.position.x==2420){
			this._flip ();
			this._facingLeft = false;
		}
	}



	// Use this for initialization
	void Start () {
		this._facingLeft = true;
		this._transform = gameObject.GetComponent<Transform>();

	}
	public void _flip()
	{
		
		if (this._facingLeft)
		{
			this._transform.localScale = new Vector2(-2f, 1.5f);
		}
		else
		{
			this._transform.localScale = new Vector2(2f, 1.5f);
		}
	}
	


}
