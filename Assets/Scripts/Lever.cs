using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lever : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private KeyCode interactKey = KeyCode.E;
    [SerializeField] private GameObject unflipped;
    [SerializeField] private GameObject flipped;
    //[SerializeField] private Interactable linked;
    private bool isFlipped;
    private Collider2D col;

    void Start()
    {
        col = gameObject.GetComponent<Collider2D>();
        isFlipped = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(interactKey))
        {
            if (col.IsTouchingLayers(LayerMask.GetMask("Bees")))
            {
                isFlipped = !isFlipped;
                unflipped.SetActive(!isFlipped);
                flipped.SetActive(isFlipped);
                //linked.trigger(isFlipped);
            }
        }
    }


}
