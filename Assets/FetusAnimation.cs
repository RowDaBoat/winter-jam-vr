using UnityEngine;

public class FetusAnimation : MonoBehaviour
{
	public float angularSpeed = 10;
	public float waveSpeed = 2f;
	public float waveAmplitude = 2f;

	float t;
	float waveStart;

	void Start()
	{
		waveStart = transform.position.y;
		t = Random.Range(0f, 360f) / waveSpeed;
	}
	
	void Update () {
		transform.Rotate(0, 0, angularSpeed * Time.deltaTime);
		t += Time.deltaTime;
		
		transform.position = new Vector3(
			transform.position.x,
			waveStart + waveAmplitude * Mathf.Sin(waveSpeed * t),
			transform.position.z
		);
	}
}
