using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopAdventurers : MonoBehaviour
{
    public Vector3 position;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();    
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Loop());
    }

    IEnumerator Loop() {
        yield return new WaitForSeconds(10f);
        transform.position = position;
        animator.SetTrigger("Restart");
        StartCoroutine(Loop());
    }
}
