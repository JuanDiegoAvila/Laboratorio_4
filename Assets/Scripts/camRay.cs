using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class camRay : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip destroy;
    public AudioClip shot;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Color rayColor;
        

        

        if (Input.GetMouseButtonDown(0))
        {

            rayColor = Color.red;

            Ray myray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(myray.origin, myray.direction * 50000000, rayColor);
            RaycastHit hitInfo;
            

            if (Physics.Raycast(myray, out hitInfo))
            {
                if (hitInfo.collider.tag == "Crystals")
                {
                    Manager.crystals++;
                    audioSource.PlayOneShot(destroy, 1);
                    audioSource.PlayOneShot(shot, 1);

                    targets.destroyed();

                    Destroy(hitInfo.transform.gameObject);
                    
                }    
            }
        }
    }
}
