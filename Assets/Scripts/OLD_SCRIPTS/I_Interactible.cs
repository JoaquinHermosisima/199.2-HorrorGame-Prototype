using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I_Interactible
{
    public string InteractionPrompt { get; }

    public bool Interact(Interactor interactor);
}
