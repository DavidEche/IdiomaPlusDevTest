using UnityEngine;

public class UndestroyableSingleton : MonoBehaviour
{
	private static UndestroyableSingleton _instance;

	private void Awake() {
		if (_instance == null) {
			_instance = this;
			DontDestroyOnLoad(this.gameObject);
		} else if (_instance != this) {
			Destroy(this.gameObject);
		}
	}
}
