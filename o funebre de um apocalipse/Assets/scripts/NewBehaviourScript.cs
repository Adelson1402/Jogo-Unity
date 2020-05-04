using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float forcaPulo;
    public float velMax;
    private bool pulando;
    private bool ataqueMovimentado;

    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        float movimento = Input.GetAxis("Horizontal"); 

        Rigidbody2D rigi = GetComponent<Rigidbody2D>();
        Animator anima = GetComponent<Animator>();

         rigi.velocity = new Vector2(movimento * velMax,rigi.velocity.y);

       //a partir daqui começam os comandos com animações

        if(pulando == true && Input.GetKeyDown(KeyCode.Z)){
            anima.SetBool("atkWjump", true);
            
           

                         
        }else{
           anima.SetBool("atkWjump", false);   //ataque com pulo, a tag é -atkWjump- (attack with jump) ou (ataque com pulo).

        }




       //-----------------------------------------------------------------------------//
       if(Input.GetKeyDown(KeyCode.X)){

           anima.SetTrigger("atkEnemy");



       }

       //----------------------------------------------------------------------------//

       if(Input.GetKeyDown(KeyCode.Z) && pulando == false){

           anima.SetBool("atk", true);
           
           



       } else {
           anima.SetBool("atk", false); //ataque comum, setado com valor booleano para que ataque apenas uma vez para cada pressionada no botão.
           

           
       }


       //---------------------------------------------------------------------------//

        if(Input.GetKeyDown(KeyCode.Space) && !pulando){

            rigi.AddForce(new Vector2(0, forcaPulo));

            pulando = true;

            
        } 
           if(pulando == true){

               anima.SetBool("pula", true);

           }else {
                
                anima.SetBool("pula", false);

           }
       //---------------------------------------------------------------------------//
         if(movimento < 0 || movimento > 0){
             
             anima.SetBool("correr", true);
             


         }else{
            anima.SetBool("correr", false);

                                                        // movimento no eixo X do personagem
         }
        

        if(movimento < 0){
               
             GetComponent<SpriteRenderer>().flipX = true;  

        } else if(movimento > 0){
 
             GetComponent<SpriteRenderer>().flipX = false;
        }

       //----------------------------------------------------------------------------//
          

    }
    // metodo foda do "UPDATE"
    void OnCollisionEnter2D(Collision2D collision2D){
              if(collision2D.gameObject.CompareTag("piso")){

                 pulando = false;

                 


             }


          }

          
        
}
