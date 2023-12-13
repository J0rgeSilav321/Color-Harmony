using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    private Color color;
    private SpriteRenderer renderer;
    private bool hasBeenPlayed;
    public int handIndex;

     // Keep track of selected cards
    private GameManager gameManager;
    // Maximum number of allowed selected cards
    //private const int maxSelectedCards = 3;
    public bool isSelected = false;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        
        gameManager = FindObjectOfType<GameManager>(); // Find the GameManager in the scene
       // color = renderer.color;
    }

    
   

 private void OnMouseDown()
    {
        // Toggle the selection status
        bool isSelected = !gameManager.IsCardSelected(this);

             // Manage selected cards list in GameManager
        gameManager.SelectCard(this, isSelected);
        
       //   int cardIndex = gameManager.GetCardIndex(this);

        // Use the card index as needed
        
        if (hasBeenPlayed == false){
           
            hasBeenPlayed = true;
            gameManager.availableCardSlots[handIndex] = true;
            


        }
        // Update the appearance based on selection status
        UpdateAppearance();
    
        
       
        
    
    }



   
   void UpdateAppearance()
    {
        // Change color based on selection status
        if (gameManager.IsCardSelected(this))
        {
            renderer.material.color = Color.green; // or any selected color
        }
        else
        {
            renderer.material.color = Color.white; // or the default color
        }
    }
     public void Deactivate()
    {
        gameObject.SetActive(false);
    }


 
    

    private Color blendColor(Color cubeColor){
        Color ret = new Color(cubeColor.r*color.r, cubeColor.g*color.g, cubeColor.b*color.b); 
        Debug.Log(ret.ToString());
        return ret;
    }

    private Color blendColor2(Color cubeColor){
        Color ret = new Color((cubeColor.r+color.r)/2, (cubeColor.g+color.g)/2, (cubeColor.b+color.b)/2); 
        Debug.Log(ret.ToString());
        return ret;
    }
}
