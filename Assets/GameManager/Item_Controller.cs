using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Item_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Collider2D c;
        if (!TryGetComponent(out c)) 
        {
            c = gameObject.AddComponent<BoxCollider2D>(); 
        }
        c.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Text txt = GameObject.Find("/Canvas/Text Legacy").GetComponent<Text>();
        GameManager.nScore++;
        txt.text = "" + GameManager.nScore;
        Destroy(gameObject);
    }
    private void Update()
    {
        
    }
}
