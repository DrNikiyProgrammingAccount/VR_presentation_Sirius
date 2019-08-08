using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Map_RCast : MonoBehaviour
{

    public SphereCollider MODEL_Collider;
    public GameObject MODEL;

    public GameObject MODEL_WithAnimation;

    public GameObject Korobka3D;
    public GameObject Exit;
    public BoxCollider ExitCol;
    public GameObject CamerMap;
    public GameObject UP;
    [Header("озвучка моделек")]
    public AudioSource audioOpenUP; //звук сюда
    public AudioSource audioCloseUp;
    public AudioSource audioOpenPanel;
    public AudioSource audioClosePanel;

    [Header("Экраны")]
    public BoxCollider ViColKor;
    public BoxCollider ViColRight;
    public BoxCollider ViColLeft;   

    // public VideoPlayer videoPlayer;
    
    public GameObject ViRight;
    public GameObject ViLeft;
    public GameObject ViKor;

    //public GameObject ViRightActive;
    //public GameObject ViLeftActive;
    //public GameObject ViKorActive;



    [Header("голос за кадром")]
    public AudioSource GolosIntro;
    public AudioSource GolosOpenMap;
    public AudioSource GolosMap;
    public AudioSource GolosEkran;


    bool OpenUp = false;
    int opentime = 0;
    [Header("для крыжки")]

    //Для КРЫЖКИ
    public GameObject KorColliderMODEL;
    public BoxCollider KorCollider;
    bool OpenUp2 = false;
    int opentime2 = 0;

    bool openUP3 = true;

    [Space]
    public BoxCollider Collid_Krusha; // крыша сцены
    bool SeeKrusha = false;

    void Start()
    {
        MODEL.SetActive(false); //отключил шар справа
        GolosIntro.Play();


    }

    void FixedUpdate()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, fwd, out hit))
        {
            if ((hit.collider == MODEL_Collider) && (opentime == 0) && (!OpenUp) && (!GolosIntro.isPlaying) && (!GolosEkran.isPlaying))
            {

                Debug.Log("достал карту(да), передвинул камеру(да), расставил фишки");
               
                CloseGolos(); // закадровый голос СТОП
                GolosMap.Play(); // закадровый голос

                MODEL_WithAnimation.GetComponent<Animator>().SetBool("openPH", true);
                audioOpenPanel.Play();
                Korobka3D.GetComponent<Animator>().SetBool("open", true);
                audioOpenUP.Play();
                CamerMap.GetComponent<Animator>().SetBool("map", true);
                OpenUp = true;
                UP.GetComponent<BoxCollider>().enabled = false;
                opentime = 100;
                Exit.SetActive(true);


            }


            if (hit.collider == Collid_Krusha)
            {
                SeeKrusha = true;
                Debug.Log("СМОТРЮ НА КРЫШКУ");
                CloseGolos();

                GolosIntro.Play();
            }

            if (SeeKrusha)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Debug.Log("перезагрузил сценку");
                SeeKrusha = false;
            }






            if (opentime > 0)
            {

                opentime--;
            }
            if ((OpenUp) && (opentime == 0) && (hit.collider == ExitCol) && (!GolosIntro.isPlaying))
            {
                CloseGolos();
                GolosEkran.Play(); //об экранах, где видосы

                Debug.Log("вернул всё на место");
                MODEL_WithAnimation.GetComponent<Animator>().SetBool("openPH", false);
                Korobka3D.GetComponent<Animator>().SetBool("open", false);
                audioCloseUp.Play();
                CamerMap.GetComponent<Animator>().SetBool("map", false);
                audioClosePanel.Play();
                OpenUp = false;
                UP.GetComponent<BoxCollider>().enabled = true;
                Exit.SetActive(false);
                opentime = 100;
                KorColliderMODEL.GetComponent<BoxCollider>().enabled = false;
                MODEL.SetActive(false);
                //ViRightActive.SetActive(true);
                //ViLeftActive.SetActive(true);
                //ViKorActive.SetActive(true);  //сразу активные
                openUP3 = false;
            }                        


            //ВСЁ ЧТО НИЖЕ - для крыжки
            if ((hit.collider == KorCollider) && (opentime2 == 0) && (!OpenUp2) && (!GolosIntro.isPlaying) && (!GolosEkran.isPlaying)&&(!GolosOpenMap.isPlaying))
            {
                if (openUP3)
                {
                    CloseGolos();
                    GolosOpenMap.Play(); //врубил закадровый "сделайте оборот..."
                    MODEL.SetActive(true);
                }
                Debug.Log("открыл крыжку");
                Korobka3D.GetComponent<Animator>().SetBool("open", true);
                audioOpenUP.Play();
                OpenUp2 = true;
                opentime2 = 100;
            }
            if (opentime2 > 0)
            {
                opentime2--;
            }
            if ((OpenUp2) && (opentime2 == 0) && (hit.collider != KorCollider))
            {
                //для крыжки
                Debug.Log("закрываю крыжку");
                Korobka3D.GetComponent<Animator>().SetBool("open", false);
                OpenUp2 = false;
                opentime2 = 100;
                audioCloseUp.Play();
            }



            if (hit.collider == ViColKor)
            {
                EcranNOTactiv();
                ViKor.SetActive(true);

            }
            if (hit.collider == ViColRight)
            {
                EcranNOTactiv();
                ViRight.SetActive(true);
            }
            if (hit.collider == ViColLeft)
            {
                EcranNOTactiv();
                ViLeft.SetActive(true);
            }





        }

        void CloseGolos()  //вырубаем голос
        {
            //GolosIntro.Stop();
            GolosOpenMap.Stop();
            GolosMap.Stop();
            GolosEkran.Stop();
        }



        void EcranNOTactiv()
        {
            ViKor.SetActive(false);
            ViRight.SetActive(false);
            ViLeft.SetActive(false);
        }
    }
}


