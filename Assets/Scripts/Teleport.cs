using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
    


{
    public Image imgTeleport;
    public TextMesh text;
    

    public float totalTime = 2;
    bool gvrStatus;
    float gvrTimer;

    public int distanceOfRay = 10;
    private RaycastHit _hit;

    public GameObject corova, pauk, pingvin;
 

    bool flag_corova = false, flag_pauk = false, flag_pingvin = false , text1 = false;
    bool ivent1 = true, ivent2 = false, ivent3 = false, ivent4 = false;

    // Start is called before the first frame update
    void Start()
    {
       
    }
    
    // Update is called once per frame
    void Update()
    {
     if (gvrStatus)
        {
            gvrTimer += Time.deltaTime;
            imgTeleport.fillAmount = gvrTimer/totalTime;
        }
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if(Physics.Raycast(ray, out _hit, distanceOfRay))
        {
            if(imgTeleport.fillAmount == 1 && _hit.transform.CompareTag("Teleport"))
            {
                _hit.transform.gameObject.GetComponent<Move>().TeleportRig();
                text.text = ("Вы должны найти корову и съесть её");

                if (ivent1 == true)
                {
                   text.text = ("Вы должны найти корову и съесть её");
                    if (_hit.transform.name == "cowtp")
                    {
                        if (flag_corova == false)
                        {
                           
                           
                            corova.active = false;
                            flag_corova = true;
                            ivent1 = false;
                            ivent2 = true;
                        }
                    }
                }
                if(ivent2 == true)
                {
                    text.text=("Вы нашли корову! Найдите паука и съешьте его");
                    if (_hit.transform.name == "pauktp")
                    {
                        if (flag_pauk == false)
                        {
                            pauk.active = false;
                            
                            flag_pauk = true;
                            ivent2 = false;
                            ivent3 = true;
                        }
                    }
                }
                if (ivent3 == true)
                {
                    text.text = ("Вы нашли паука! Найдите пингвина и съешьте его");
                    if (_hit.transform.name == "pingtp")
                    {
                        if (flag_pingvin == false)
                        {
                            pingvin.active = false;
                            text.text = ("Вы нашли пингвина! Спасибо за игру! ");
                            flag_pingvin = true;
                            ivent3 = false;
                            Invoke("ivent4", 5);
                            ivent4 = true;
                        }
                    }
                }
                if (ivent4 == true)
                {
                    Application.Quit();
                }

            }
        }


    }

    public void GVROn()
    {
        gvrStatus = true;
    }

    public void GVRoff()
    {
        gvrStatus = false;
        gvrTimer = 0;
        imgTeleport.fillAmount = 0;
    }
}
