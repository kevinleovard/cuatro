
using UnityEngine;
using UnityEngine.SceneManagement;
public class Grid2D : MonoBehaviour
{

    private int pendejada;
    private int otraPendejada = 6;
    public Color jugador1;                        
    public Color jugador2;                         
    private bool primerturno;                    
    public Color colorfondo;                     
    private GameObject[,] grid;                  
    private int height=10;                           
    private int width=10;                            
    bool ganador;
    public Color colorPowerUp;
    private int specialRoundCounter = 0;
    private readonly int specialRound = 2; //La propiedad readonly significa que esta variable no se puede modificar en el codigo.
    void Start()

    {
        grid = new GameObject[width, height];                                               //el objeto se ubica en una posicion en altura y ancho
        for (int i = 0; i < width; i++)                                                     //se inicia el siclo de poner esferas a lo ancho
        {
            
            for (int j = 0; j < height; j++)                                                //se inicia el siclo de ponera esferas a lo alto
            {
                var go = GameObject.CreatePrimitive(PrimitiveType.Sphere);                  //se almacena una un objeto tipo esfera
                go.transform.position= new Vector3(i,j,0);                                  //la esfera almacenada se ubica enuna pocicion en el vector 3
                grid[i,j]=go;                                                               //coordenadas del objeto en x ,y

                go.GetComponent<Renderer>().material.color = colorfondo;                    //se crea un material de tipo color

                grid[i, j] = go;                                                            //el objeto grid es igual al a la variable go
            }

        }
    }

    void Update()
    {
        Vector3 mPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);           //posicion del la camara en vector 3
        

        if (Input.GetKey(KeyCode.Mouse0) && ganador==false )                                                   
        {
		UpdatePickedPiece(mPosition);
        }
    }


    void UpdatePickedPiece(Vector3 position)
    {
        int i = (int)(position.x + 0.5f);                                                   //variable i se ubica en una pocicion x
        int j = (int)(position.y + 0.5f);                                                   //variable j se ubica en una pocicion y

        if (Input.GetButtonDown("Fire1"))
        {
            if (i >= 0 && j >= 0 && i < width && j< height)                                 //variable i y variable j se ubican alo ancho y a lo alto
            {
                GameObject go=grid[i,j];                                                    //el objeto se pone en el espacio i y en el j
                if (go.GetComponent<Renderer>().material.color == colorfondo)               //se renderisa el color del fondo
                {
                    Color colorAUsar = Color.clear;
                    if (primerturno)
                    colorAUsar = jugador1;

                    else
                    colorAUsar = jugador2;

                    go.GetComponent<Renderer>().material.color = colorAUsar;
                    primerturno = !primerturno;
                    VerificadorX(i, j, colorAUsar);
                    VerificadorY(i, j, colorAUsar);
                    DiagonalPositiva(i, j, colorAUsar);
                    DiagonalNegativa(i, j, colorAUsar);
                  

                }
            }
        }
    }
      public void VerificadorX(int x, int y, Color colorVerificar)
    {
        int contador = 0;
        for (int i = x-3; i <= x+3; i++)
        {
            if (i < 0 || i >= width)
                continue;

            GameObject go = grid[i, y];

            if (go.GetComponent<Renderer>().material.color == colorVerificar)
            {
                contador++;
                if (contador == 4 && colorVerificar==jugador1)
                {
                    Debug.Log("felicidades ganaste jugador 2");
			        ganador=true;
                    SceneManager.LoadScene(3);
                }

                else if(contador == 4 && colorVerificar==jugador2)
                {

                    Debug.Log("felicidades ganaste jugador 1");
			        ganador=true;
                    SceneManager.LoadScene(2);
                }


                
            }
            else
                contador = 0;
        }
    }

    public void VerificadorY(int x, int y, Color colorVerificar)
    {
        int contador = 0;
        for (int j = y - 3; j <= y + 3; j++)
        {
            if (j < 0 || j >= height)
                continue;

            GameObject go = grid[x, j];

            if (go.GetComponent<Renderer>().material.color == colorVerificar)
            {
                contador++;
                if (contador == 4  && colorVerificar==jugador1)
                {
                    Debug.Log("felicidades ganaste jugador 2");
			        ganador=true;
                    SceneManager.LoadScene(3);
                }

                else if(contador == 4 && colorVerificar==jugador2)
                {

                    Debug.Log("felicidades ganaste jugador 1");
			        ganador=true;
                    SceneManager.LoadScene(2);
                }
                    
            }
            else
                contador = 0;
        }
    }

    public void DiagonalPositiva(int x, int y, Color colorVerificar)
    {
        int contador = 0;
        int j = y - 4;


        for (int i = x - 3; i <= x + 3; i++ )
        {
            j++;
            if (j < 0 || j >= height || i < 0 || i >= width)
                continue;

                GameObject go =grid[i, j];
               
               // Debug.Log(go.GetComponent<Renderer>().material.color);
                // Debug.Log(colorAVerificando);
                if (go.GetComponent<Renderer>().material.color == colorVerificar)
                {
                    contador++;
                    

                    if (contador == 4  && colorVerificar==jugador1)
                {
                    Debug.Log("felicidades ganaste jugador 2");
			        ganador=true;
                    SceneManager.LoadScene(3);
                }

                else if(contador == 4 && colorVerificar==jugador2)
                {

                    Debug.Log("felicidades ganaste jugador 1");
			        ganador=true;
                    SceneManager.LoadScene(2);
                }

                }
                else
                    contador = 0;
           // Debug.Log(contador);
        }
    }


    public void DiagonalNegativa(int x, int y, Color colorVerificar)
    {
        int contador = 0;
        int j = y + 4;


        for (int i = x - 3; i <= x + 3; i++)
        {
            j--;

            if (j < 0 || j >= height || i < 0 || i >= width)
                continue;

            GameObject go = grid[i, j];

            if (go.GetComponent<Renderer>().material.color == colorVerificar)
            {
                contador++;
                
                if (contador == 4 && colorVerificar==jugador1)
                {
                    Debug.Log("felicidades ganaste jugador 2");
			        ganador=true;
                    SceneManager.LoadScene(3);
                }

                else if(contador == 4 && colorVerificar==jugador2)
                {

                    Debug.Log("felicidades ganaste jugador 1");
			        ganador=true;
                    SceneManager.LoadScene(2);
                }
            }
            else
                contador = 0;

        }
    }
    /*private void CheckSpecialRound()
    {
        specialRoundCounter++;
        if (specialRoundCounter >= specialRound)
        {
            PowerUp();
            specialRoundCounter = 0;
        }
    }
    public void PowerUp()
    {
        int rx = Random.Range(0, width);
        int ry = Random.Range(0, height);

        GameObject selectedGO = grid[rx, ry];
        Color colorToUse = colorPowerUp;
        Color materialColor = selectedGO.GetComponent<Renderer>().material.color;
        
        if (materialColor == colorfondo)
        {
            int r = Random.Range(0, 2); //Elige entre 0 y 1, ya que el 2 es excluido

            if (r == 0)
            {
                colorToUse = colorPowerUp;
            }
            else
            {
                colorToUse = colorPowerUp;
            }
        }
        else if (materialColor == jugador1)
        {
            colorToUse = colorPowerUp; //Si la bola aleatoriamente elegida ya fue coloreada
        }
        else if (materialColor == jugador2)
        {
            colorToUse = colorPowerUp;
        }

        selectedGO.GetComponent<Renderer>().material.color = colorToUse;

        //revisar si algún jugador ganó cuando sucede lo random
        VerificadorX(rx, ry, colorToUse);
        VerificadorY(rx, ry, colorToUse);
        DiagonalPositiva(rx, ry, colorToUse);
        DiagonalNegativa(rx, ry, colorToUse);
    }
    public void Regla()
    {
        if (pendejada == otraPendejada)
        {
            GameObject go = grid[height = Random.RandomRange(0, 9), width = Random.RandomRange(0, 9)];
            if (go.GetComponent<Renderer>().material.color == Color.cyan)
            {
                go.GetComponent<Renderer>().material.color = Color.grey;
            }
            otraPendejada = otraPendejada + 2;
        }
        height = 10;
        width = 10;
    }
    */



    }

  


     
     


    


  