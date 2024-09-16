using UnityEngine;

[RequireComponent(typeof(InputController))]
public class PlayersCatchingAbility : MonoBehaviour {
    [SerializeField] private InputController playerController;
    [SerializeField] private float maximumTimeToCatch;

    private bool triesToCatch;
    private float timeToCatch;

    private void Awake() {
        timeToCatch = maximumTimeToCatch;
    }
    
    private void Update() {
        triesToCatch = playerController.RetrieveCatchInput();
        
        // buffer input
        if (triesToCatch) {
            timeToCatch = maximumTimeToCatch;
        }

        if (timeToCatch >= 0f) {
            timeToCatch -= Time.deltaTime;
            triesToCatch = true;
        }
        else {
            triesToCatch = false;
        }
    }

    public void InBodgersRadius(Transform bodgerTransform) {
        if (!triesToCatch) return;
        triesToCatch = false;
        Debug.Log("caught bodger");
    }
}
