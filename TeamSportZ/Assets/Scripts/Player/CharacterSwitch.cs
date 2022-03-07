using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitch : MonoBehaviour
{
    public List<GameObject> characters = new List<GameObject>();
    public List<RuntimeAnimatorController> controller = new List<RuntimeAnimatorController>();

    private int previousIndex = 0;

    public void SwitchCharacter(int index)
    {
        Debug.Log("SWITCH CHARACTER");
        characters[previousIndex].gameObject.SetActive(false);
        this.GetComponent<Animator>().runtimeAnimatorController = controller[index];
        characters[index].gameObject.SetActive(true);
        previousIndex = index;
    }
}
