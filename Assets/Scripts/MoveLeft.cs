using UnityEngine;
public class MoveLeft : MonoBehaviour
{
    private PlayerController playerControllerScript;//Player Controller Script'indeki gameOver değişkenine erişmek için.
    private float leftBound = -15.0f;//Sol sınır. sol olduğu için - oluyor. -15'i geçtiği an yok ediyoruz nesneyi.
    private float speed = 30.0f;//Duvarın kayma hızı.
    private void Start()
    {
     playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
     //Player isimli game objesindeki(Ana Karakter) Player Controller komponentini bu değişkene atadık.
     //Böylece Player Controller'daki gameOver değişkenine erişip onda işlem yapabildik.
    }
    private void Update()
    {
     if(playerControllerScript.gameOver == false)//Eğer Player Controller Script'indeki Game Over değişkeni false ise.(Oyun devam ediyor.)
     {
      transform.Translate(Vector3.left* Time.deltaTime * speed);//Duvar sola doğru speed hızında kayacak.
     }
     if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
     //Eğer Obstacle'ın X'teki pozisyonu -15'ten küçük(-15.1) ve Game Objesinin Tag'ı Obstacle ise
     {
      Destroy(gameObject);//Oyun Objesini yok et.(Engel -15'i geçtiğinde yok olacak, yani sahnede kalmayacak sürekli.)
     }
    }
}
