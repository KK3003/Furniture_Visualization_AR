using System.Collections;
using UnityEngine;

public class AutoHide_Instruction : MonoBehaviour
{
    [SerializeField] GameObject Instructions;
    [SerializeField] int seconds;

    void Start()
    {
        StartCoroutine(RemoveAfterSeconds());
    }

    IEnumerator RemoveAfterSeconds()
    {
        yield return new WaitForSeconds(seconds);
        Instructions.SetActive(false);
    }
}
