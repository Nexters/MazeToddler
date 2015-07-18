using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject[] patterns;
	public GameObject patternA;
	public GameObject patternB;
	public GameObject backCloudPrefab;
	public GameObject frontCloudPrefab;
	public GameObject backCloudA;
	public GameObject backCloudB;
	public GameObject frontCloud;

	public float patternA_x = 0f;
	public float patternB_x = 15f;
	public float frontCloudSpawn_x = 16.5f;
	public float frontCloudDestroy_x = -18f;

	public float stepSpeed = 5f;
	public float backCloudSpeed = 0.5f;
	public float frontCloudSpeed = 10f;

	void Update () {
		if (patternA != null) {
			patternA.transform.position += Vector3.left * Time.deltaTime * stepSpeed;
		}
		if (patternB != null) {
			patternB.transform.position += Vector3.left * Time.deltaTime * stepSpeed;
		}
		if (patternB.transform.position.x <= patternA_x) {
			if(patternA != null) Destroy (patternA);
			patternA = patternB;
			patternB = Instantiate (patterns[Random.Range(0,patterns.Length)], new Vector3(patternB_x,0,0), Quaternion.identity) as GameObject;
		}

		if (backCloudA != null) {
			backCloudA.transform.position += Vector3.left * Time.deltaTime * backCloudSpeed;
		}
		if (backCloudB != null) {
			backCloudB.transform.position += Vector3.left * Time.deltaTime * backCloudSpeed;
		}
		if (backCloudB.transform.position.x <= patternA_x) {
			if(backCloudA != null) Destroy (backCloudA);
			backCloudA = backCloudB;
			backCloudB = Instantiate (backCloudPrefab, new Vector3(patternB_x,0,0), Quaternion.identity) as GameObject;
		}

		if (frontCloud != null) {
			frontCloud.transform.position += Vector3.left * Time.deltaTime * frontCloudSpeed;
		}
		if (frontCloud.transform.position.x <= frontCloudDestroy_x) {
			Destroy(frontCloud);
			frontCloud = Instantiate (frontCloudPrefab, new Vector3(frontCloudSpawn_x, 0f, 0f), Quaternion.identity) as GameObject;
		}
	}
}
