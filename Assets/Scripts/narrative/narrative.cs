using UnityEngine;
using System.Collections;
using TMPro;

public class narrative : MonoBehaviour
{
    public GameObject dialogue;
    [SerializeField] private TextMeshProUGUI text;

    public void Update()
    {
        //dialogue.SetActive(false);


        //Cutscene 1
        if (Input.GetKey("m"))
        {
            //shows dialogue
            dialogue.SetActive(true);
            text.text = "ALERT! ALERT! HOSTILE CONTACT WITH UNIDENTIFIED VESSEL ESTABLISHED!";
        }
        if (Input.GetKey("n"))
        {
            text.text = "PROPULSION SYSTEMS OFFLINE! DEFENSIVE COUNTERMEASURES RECHARGING!";
        }
        if (Input.GetKey("b"))
        {
            text.text = "ANTI-RAGNAROK PROTOCOL IS ACTIVE! ALIEN THREAT MUST BE NEUTRALIZED!";
        }

        //Intro
        if (Input.GetKey("l"))
        {
            //shows dialogue
            dialogue.SetActive(true);
            text.text = "Good morning, DRENGR-087. I hope your cryogenic stasis was pleasant for your organic faculties.";
        }
        if (Input.GetKey("k"))
        {
            text.text = "The SDC Bark Endeavour has docked with a hostile alien vessel of unknown origin.";
        }
        if (Input.GetKey("j"))
        {
            text.text = "Analysis indicates its occupants are an invasion force intended to exterminate the citizens of the UCS.";
        }
        if (Input.GetKey("h"))
        {
            text.text = "Your objective is to dispatch them with extreme prejudice.";
        }


        //Intro
        if (Input.GetKey("p"))
        {
            //shows dialogue
            dialogue.SetActive(true);
            text.text = "You have been armed with an SP-12. Aim it using your mouse.";
        }
        if (Input.GetKey("o"))
        {
            text.text = "Place the crosshair on the enemy to line up your shot.";
        }
        if (Input.GetKey("i"))
        {
            text.text = "Use the [LEFT MOUSE BUTTON] to fire the weapon when you have a clear shot.";
        }

        //intro part 2
        if (Input.GetKey("z"))
        {
            //shows dialogue
            dialogue.SetActive(true);
            text.text = "Alert. Structural damage detected inside alien vessel.";
        }
        if (Input.GetKey("x"))
        {
            text.text = "Avoid exposed plasma conduits and elevated barriers by pressing [SPACEBAR] to jump over them.";
        }
        if (Input.GetKey("c"))
        {
            text.text = "Your enhanced synthetic muscle structure should allow you to clear these obstacles.";
        }

        //end of first chapter
        if (Input.GetKey("u"))
        {
            //shows dialogue
            dialogue.SetActive(true);
            text.text = "ALERT! I am detecting signal interf[ERROR] rence.The @@@~@@7@~@lien vessel has begun to-tO-t-";
        }
        if (Input.GetKey("y"))
        {
            text.text = "reEEeEEEgenerate its shIELds. I am un@b 6******* maint___n communica*#(%%^$%^11&***5s link.";
        }
        if (Input.GetKey("t"))
        {
            text.text = "D-D-D-o not engage in conversation with the ^(#9(#%####%22%%%~~~_~~~~_~~~.";
        }
        if (Input.GetKey("r"))
        {
            text.text = "[TRANSMISSION TERMINATED.UNABLE TO ACQUIRE SIGNAL]";
        }

        //remove window
        if (Input.GetKey("v"))
        {
            dialogue.SetActive(false);
        }
    }
}


