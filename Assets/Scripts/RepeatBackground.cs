using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;//Başlangıç pozisyonu.
    private float repeatWidth;//Tekrar genişliği.
    private void Start()
    {
     startPos = transform.position;//Background'un mevcut pozisyonunu, başlangıç pozisyonuna ata.
     repeatWidth = GetComponent<BoxCollider>().size.x/2;
     //Background'un(arkadaki şehir resminin) X düzlemindeki size'ının yarısını repeatWidth'e ata.
    }
    private void Update()
    {
     if(transform.position.x < startPos.x - repeatWidth)
     //Eğer startPos'un X'inden repeatWidth çıkarıldığında Background'un X'inden büyük oluyorsa
     {
      transform.position = startPos;//startPos'u ana pozisyona getir.
     }
    }
    //Burada yaptığımız işlem şudur. Aslında 1 parça olarak aynı resimden 2 tane var.
    //Tam ortasına gelincce başlangıç pozisyonuna geri dönüyor. Böylece sonsuz bir arka plan oluşuyor.
    //Gözü yormuyor, mantık hatası olmuyor.(Mesela dondurmacının ortasında kesip otelden başlatsa mantıksız olur.)
}
