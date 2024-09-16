using UnityEngine;

public abstract class InputController : ScriptableObject {
    public abstract float RetrieveMovementInput();
    public abstract bool RetrieveHoldGlideInput();
    public abstract bool RetrieveLetGoGlideInput();
    
    public abstract bool RetrieveCatchInput();
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
    
    public override bool RetrieveCatchInput() {
        return Input.GetKeyDown(KeyCode.Space);
    }
}
