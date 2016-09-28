/// DETTA SCRIPT SKA KOPPLAS SOM EN KOMPONENT TILL SPELARFIGUREN
/// FÖR ATT ALLT SKA FUNKA BEHÖVER OCKSÅ SPELARFIGUREN FÅ EN TRIGGER-COLLIDER FÖR ATT KÄNNA NÄR DEN ÄR NÄR ANDRA SAKER.
 
using UnityEngine;
using System.Collections;

public class Gift : MonoBehaviour
{
//Först skapar vi en variabel som ska hålla reda på hur många gåvor spelaren har att ge bort
//Vi skapar den som en publik variabel eftersom vi vill kunna komma åt den från vårt andra script
    public int giftcount;

// Från början sätter vi variabelns värde till noll, eftersom spelaren inte har några gåvor förrän han plockat upp någon.
    void Start()
    {
        giftcount = 0;
    }

//När vi kommer nära något känner vår Trigger det
    void OnTriggerEnter(Collider collider)
    {
// OM objektet triggern känner av har taggen "Gift" så körs funktion "CollectGift" 
        if (collider.gameObject.CompareTag("Gift"))
        {
            CollectGift(collider);
        }
    }

// Funktionen CollectGift - Räknar upp gift-räknaren och utplånar presenten vi spelaren hittat
// (körs alltså bara om vi hittat ett objekt som har taggen "Gift")
    void CollectGift(Collider collider)
    {
        giftcount++;
        Destroy(collider.gameObject);
    }


// Till GUI - Skapar en label-rektangel och skriver ut hur många gåvor spelaren har att dela ut
// - Alltså värdet på variabeln "giftcount" som en sträng 
    void OnGUI()
    {
      GUIStyle style = new GUIStyle();
        style.fontSize = 20;
        style.fontStyle = FontStyle.Bold | FontStyle.Italic;
        style.normal.textColor = Color.black;
        Rect labelRect = new Rect(100, 45, 60, 20);
        GUI.Label(labelRect, "Gåvor att ge bort: " +giftcount.ToString()+"st", style);  
    }
}
