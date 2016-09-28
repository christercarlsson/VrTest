/// DETTA SCRIPT SKA KOPPLAS SOM EN KOMPONENT TILL MOTTAGARFIGUREN SOM SPELAREN SKA GE SAKER TILL

using UnityEngine;
using System.Collections;
public class SadOrNot : MonoBehaviour
{

//Först skapar vi två variabler.-Båda skapar vi som en privata variabler eftersom inget annat script behöver komma åt dem
//Den första håller reda på om det är sant eller falskt att mottagaren är ledsen (inte har fått någon present)
    private bool sad;

//Den andra håller reda på hur många gåvor spelarfiguren ska ha
    private int playergift;

// När vi börjar sätter vi värdet "true" på vår variabel "sad" - Alltså att det är sannt att vår mottagare är ledsen (har ju inte fått någon present)
    void Start()
    {
        sad = true;
    }

// När en trigger rör vår figur händer följande
    void OnTriggerEnter(Collider collider)
    {
// Vi hämtar variabeln giftcount från scriptet "Gift" hos Spelarfiguren och tilldelar det värdet till vår privata variabel "playergift". 
//Det gör vi för att kunna använda det värdet i beräkningar här i vårt script
        GameObject ThirdPersonController = GameObject.Find("ThirdPersonController");
        Gift playerScript = ThirdPersonController.GetComponent<Gift>();
        playergift = playerScript.giftcount;

// Om private-variabeln sad=true (Mottagarefiguren är ledsen och har inte fått någon present)  
		if (sad)
		{
// OCH OM den/det som krockar med vår mottagarfigur har taggen "Player" OCH variabeln playergift > 0, DÅ kör vi funktion "BeHappy"
            if (collider.gameObject.CompareTag("Player") && playergift > 0)
	        {
	            BeHappy(collider);
	        }
		}
    }

// Här är funktionen "BeHappy" - Vi ska se vad den gör... :)
    void BeHappy(Collider collider)
    {
// Vi sätter variabeln "sad" till "false" (Eftersom mottagaren ju inte är ledsen längre om hen får en present)
        sad = false;

// Vi minskar värdet på variabeln "giftcount" (Eftersom Spelarfiguren har en present mindre att ge bort när vi fått en)
        playergift-- ;

// Hämta variabeln giftcount från scriptet "Gift" hos PC och sätt den till värdet av vår plokala variabel "playergift" 
// (Så att Spelarfiguren vet att han har blivit av med en present)
        GameObject ThirdPersonController = GameObject.Find("ThirdPersonController");
        Gift playerScript = ThirdPersonController.GetComponent<Gift>();
        playerScript.giftcount = playergift;

// Hämtar parametern anim_sad från vår animation controller 
        var anim = GetComponent<Animator>();
// Vi ger parametern värdet från vår lokala variabel "sad" (false alltså) så att vår figur kör en annan animering
        anim.SetBool("anim_sad", sad);
    }

}
