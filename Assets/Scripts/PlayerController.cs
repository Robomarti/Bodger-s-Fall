using UnityEngine;

public abstract class InputController : ScriptableObject {
    public abstract float RetrieveMovementInput();
    public abstract bool RetrieveHoldGlideInput();
    public abstract bool RetrieveLetGoGlideInput();
}

[CreateAssetMenu(fileName = "PlayerController", menuName = "PlayerController")]
public class PlayerController : InputController {
    public override float RetrieveMovementInput() {
        return Input.GetAxis("Horizontal");
    }

    public override bool RetrieveHoldGlideInput() {
        return Input.GetKey(KeyCode.S);
    }

    public override bool RetrieveLetGoGlideInput() {
        return Input.GetKeyUp(KeyCode.S);
    }
}
