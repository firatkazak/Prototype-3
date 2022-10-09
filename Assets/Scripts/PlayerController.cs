using UnityEngine;
public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;//Ana karakterin RigidBody'sine erişmek için.
    private Animator playerAnim;//Ana karakterin Animasyon işleri için.(Zıplama, Koşma ve Ölme)
    public ParticleSystem explosionParticle;//Engele çarpınca Patlama efekti için.
    public ParticleSystem dirtParticle;//Koşarken ayağından toz çıkması için.
    public AudioClip jumpSound;//Zıplama sesi.
    public AudioClip crashSound;//Carpışma sesi.
    private AudioSource playerAudio;//AudioSource
    private float jumpForce = 600;//Zıplama gücü.
    private float gravityModifier = 2.0f;//Yer çekimi. Arttırırsan yer çekimi de artar. Azaltırsan azaltır.
    private bool isOnGround = true;//Oyuncunun yere temas edip etmediğini sorguladığımız değişken.
    public bool gameOver;//Oyunun bitip bitmediğini sorguladığımız değişken.
    private void Start() 
    {
     playerRb = GetComponent<Rigidbody>();//playerRb değişkenine Rigidbody komponentini atadık.
     playerAnim = GetComponent<Animator>();//playerAnim değişkenine Animator komponentini atadık.
     playerAudio = GetComponent<AudioSource>();//playerAudio değişkenine AudioSource komponentini atadık.
     Physics.gravity *= gravityModifier;//Physics.gravity(yer çekimi fonksiyonunu) gravityModifier ile çarpıp eşitle.
     //Physics.gravity = Physics.gravity * gravityModifier; Yukarıdaki ile aynı. Yukarıdaki daha kolay yazılıyor *= ile.
     //Yukarıda yaptığımız şey = Physics.gravity fonksiyonuna, yer çekiminin kaç olacağını tanıttık. Burada 2 yaptık.
     //Eğer 5 yapsaydık yer çekimi 5 kat artacak haliyle karakter daha AZ zıplayacaktı. 1 yapsaydık daha FAZLA zıplayacaktı.
    }
    private void Update()
    {
     if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
     //Eğer Space'e basıldıysa VE oyuncu yere temas ediyorsa VE oyun bitmediyse
     {
      playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);//Rigidbody'ye güç uygula.
      isOnGround = false;//Zıplayınca yere temas etmez. Bunu tanıttık.
      playerAnim.SetTrigger("Jump_trig");//Zıplama animasyonunu oynat.
      dirtParticle.Stop();//Havadayken ayağından koşma izi çıkmayacak bu yüzden onu durdurduk.
      playerAudio.PlayOneShot(jumpSound, 1.0f);//Zıplama sesini 1 saniye çal.
     }
    }
    private void OnCollisionEnter(Collision collision)
    {
     if(collision.gameObject.CompareTag("Ground"))//Player Ground(Zemin) ile temas ediyorsa
     {
      isOnGround = true;//Yerde mi? Evet
      dirtParticle.Play();//Koşarken ayağının arkasından çıkardığı toz efekti çalışsın.
     }
     else if(collision.gameObject.CompareTag("Obstacle"))//Player Duvar ile temas ediyorsa(Duvara çarpmışsa)
     {  
      gameOver = true;//Oyunu bitir.
      Debug.Log("Game Over!");//Konsola Game Over! yazdır.
      playerAnim.SetBool("Death_b", true);//Ölme animasyonunu etkinleştir.
      playerAnim.SetInteger("DeathType_int", 1);//
      explosionParticle.Play();//Patlama efektini oynat.
      dirtParticle.Stop();//Toz efektini durdur.
      playerAudio.PlayOneShot(crashSound, 1.0f);//Çarpma sesini 1 saniye çalıştır.
     }
    }
}
