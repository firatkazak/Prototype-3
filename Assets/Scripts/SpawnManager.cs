using UnityEngine;
public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;//Obstacle prefabını sürükle bırak yaparak tanıtmak için.
    private Vector3 spawnPos = new Vector3(30,0,0);//X'te 30'da Obstacle'ı yaratacak.
    private PlayerController playerControllerScript;//Player Controller Script'ine eriştik.
    private float startDelay = 2.0f;//Oyun başladıktan 2 saniye sonra üretmeye başlayacak.
    private float repeatRate = 2.0f;//2 saniye aralıkla Obstacle üretecek.
    private void Start()
    {
     InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
     //Tekrarla(SpawnObstacle fonksiyonunu, 2 saniye gecikme ile 2 saniye aralıkla.)
     playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
     //Player isimli game objesindeki(Ana Karakter) Player Controller komponentini bu değişkene atadık.
     //Böylece Player Controller'daki gameOver değişkenine erişip onda işlem yapabildik.
    }
    private void SpawnObstacle()
    {
     if(playerControllerScript.gameOver == false)//Player Controller Script'indeki gameOver değişkeni false ise(Oyun devam ediyorsa)
     {
      Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
      //Üret(Obstacle Prefabından, Spawn Pozisyonunda, Obstacle'nın standart açısında.)
     }
    }
}
