using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjtacleCon : MonoBehaviour
{
    public bool upperRow = false;
    private PlayerCon player = null;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerCon>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnCollisionStay(Collision collision)
    {

        if (collision.collider.tag == "Finish")
        {
            this.transform.root.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.transform.root.gameObject.SetActive(false);
        }

        if (collision.collider.tag == "Player")
        {
            this.transform.root.GetComponent<Rigidbody>().velocity = Vector3.zero;
            collision.gameObject.GetComponentInParent<PlayerCon>().GameOver(upperRow);

        }


    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Finish" && player)
        {
            player.setScore();
        }
    }
}
