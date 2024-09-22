using UnityEngine;

public class ObstacleDeletion : MonoBehaviour {
    [SerializeField] private float timeBeforeDeletion;

    private void Update()
    {
        timeBeforeDeletion -= Time.deltaTime;

        if (timeBeforeDeletion <= 0) {
            Destroy(gameObject);
        }
    }
}
