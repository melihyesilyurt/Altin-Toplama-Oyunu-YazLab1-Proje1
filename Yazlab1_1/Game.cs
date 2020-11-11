using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yazlab1_1
{
    public partial class Game : Form
    {
        private int mapWidth = MainMenu.mapWidth;
        private int mapHeight = MainMenu.mapHeight;
        List<Button> gamesSquares = new List<Button>();
        private int[] positionA = {0,0};
        private int[] positionB = {0,MainMenu.mapWidth-1};
        private int[] positionC = {MainMenu.mapHeight-1,0};
        private int[] positionD = { MainMenu.mapHeight - 1, MainMenu.mapWidth - 1 };
        int countBlock = 0;
        private int tourManagement = 1;
        private int aGoldAmount;
        private int bGoldAmount;
        private int cGoldAmount;
        private int dGoldAmount;
        private int goldCount;
        private int secretGoldCount;
        private int xPosition = 380;
        private int yPosition = 60;
        private int btnName = 0;
        Random rnd = new Random();
        int[,] goldMapMatris = new int[MainMenu.mapHeight, MainMenu.mapWidth];
        public Game()
        {
            InitializeComponent();
        }
        
       
        private void Game_Load(object sender, EventArgs e)
        {           
            int goldBlock = 0;     
           // MessageBox.Show("" + goldMapMatris.Length);
            goldCount = (mapWidth * mapHeight * MainMenu.goldRate) / 100;
            secretGoldCount = (goldCount * MainMenu.secretGoldRate) / 100;
            goldCount -= secretGoldCount;
            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    goldMapMatris[i,j] = 0;
                }
            }
            while(goldBlock!= secretGoldCount)
            {              
                int num1 = rnd.Next(mapWidth);//uzunluk ilk
                int num2 = rnd.Next(mapHeight);//genişlik 2
                //Debug.WriteLine("num1: "+num1+ " num2:"+num2);            
                if(goldMapMatris[num1,num2] == 0 )
                {
                    if ((num1 == 0 && num2 == 0) || (num1 == 0 && num2 == mapWidth - 1) || (num1 == mapHeight - 1 && num2 == 0) || (num1 == mapHeight - 1 && num2 == mapWidth - 1))
                    {
                       
                    }
                    else
                    {              
                        goldMapMatris[num1, num2] =-1;
                        goldBlock++;
                    }
                }
            }
            goldBlock = 0;
            while (goldBlock != goldCount)
            {
                int num1 = rnd.Next(mapWidth);//uzunluk ilk
                int num2 = rnd.Next(mapHeight);//genişlik 2        
                if (goldMapMatris[num1, num2] == 0)
                {
                    if ((num1 == 0 && num2 == 0) || (num1 == 0 && num2 == mapWidth - 1) || (num1 == mapHeight - 1 && num2 == 0) || (num1 == mapHeight - 1 && num2 == mapWidth - 1))
                    {

                    }
                    else
                    {
                        int num3 = rnd.Next(100);
                        if (num3 < 25)
                        {
                            goldMapMatris[num1, num2] = 5;
                        }
                        else if (num3 < 50)
                        {
                            goldMapMatris[num1, num2] = 10;
                        }
                        else if (num3 < 75)
                        {
                            goldMapMatris[num1, num2] = 15;
                        }
                        else if (num3 < 100)
                        {
                            goldMapMatris[num1, num2] = 20;
                        }
                        goldBlock++;
                    }
                }
            }
            aGoldAmount = MainMenu.startGold;
            bGoldAmount = MainMenu.startGold;
            cGoldAmount = MainMenu.startGold;
            dGoldAmount = MainMenu.startGold;
            aGoldText.Text = ("Altın: " + aGoldAmount);
            bGoldText.Text = ("Altın: " + bGoldAmount);
            cGoldText.Text = ("Altın: " + cGoldAmount);
            dGoldText.Text = ("Altın: " + dGoldAmount);  
               for(int i=0;i< mapHeight; i++)
               {
                   for(int j=0;j< mapWidth; j++)
                   {
                    gamesSquares.Add(createButton(btnName, xPosition, yPosition, gamesSquares));
                    addNewButtons(gamesSquares, this);
                    xPosition += 30;          
                }
                   xPosition =380;
                   yPosition += 30;
               }
            gamesSquares[0].BackColor = Color.Blue;
            gamesSquares[mapWidth - 1].BackColor = Color.Red;
            gamesSquares[(mapWidth * mapHeight) - mapWidth].BackColor = Color.Green;
            gamesSquares[(mapWidth * mapHeight) -1].BackColor = Color.Magenta;
            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    if (goldMapMatris[i, j] != 0)
                    {
                         gamesSquares[countBlock].BackColor = Color.Yellow;
                        gamesSquares[countBlock].Text = "" + goldMapMatris[i, j];
                    }
                    countBlock++;
                }
            }
            countBlock = 0;
            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    if (goldMapMatris[i, j] == -1)
                    {
                        gamesSquares[countBlock].BackColor = Color.Black;
                        gamesSquares[countBlock].Text = "" + goldMapMatris[i, j];
                    }
                    countBlock++;
                }
            }
        }
        private static Button createButton(int btnNbr, int xPosition, int yPosition, List<Button> button)
        {
            Button btn = new Button();
            btn.Name = "btn" + btnNbr.ToString();
            btn.Location = new Point(xPosition, yPosition);
            btn.Size = new Size(30, 30);
            return btn;
        }
        private static void addNewButtons(List<Button> allButtons, Form mainForm)
        {
            foreach (Button value in allButtons)
            {
                mainForm.Controls.Add(value);
            }
        }
        private int[] targetA=  { 0, 0 };
        private int[] targetB = { 0, 0 };
        private int[] targetC = { 0, 0 };
        private int[] targetD = { 0, 0 };
        private void button1_Click(object sender, EventArgs e)
        {
            if (tourManagement == 1)
            {
                PlayA();
                aGoldText.Text = ("Altın: " + aGoldAmount);
            }
            else if(tourManagement == 2)
            {
                PlayB();
                bGoldText.Text = ("Altın: " + bGoldAmount);
            }
            else if (tourManagement == 3)
            {
                PlayC();
                cGoldText.Text = ("Altın: " + cGoldAmount);
            }
            else if (tourManagement == 4)
            {
                PlayD();
                dGoldText.Text = ("Altın: " + dGoldAmount);
                tourManagement = 0;
            }          
            tourManagement++;
        }
        private int movement=0;
        private int objectA;
        private void PlayA()
        {
            if(targetA[0]==0 || targetA[1]==0)
            {
                targetA[0] = 3;
                targetA[1] = 2;
                aGoldAmount -= MainMenu.aTargetCost;
            }
                while(targetA[0]!=positionA[0])
                {
                    if (movement == 3)
                    {
                        movement = 0;
                        break;
                    }
                    MessageBox.Show("2");
                gamesSquares[objectA].UseVisualStyleBackColor = true;
                countBlock = 0;
                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 0; j < mapWidth; j++)
                    {
                        if (goldMapMatris[i, j] != 0 && goldMapMatris[i, j] != -1)
                        {
                            gamesSquares[countBlock].BackColor = Color.Yellow;
                        }
                        countBlock++;
                    }
                }
                if (targetA[0]>positionA[0])
                {
                    if((positionA[0]+1==positionB[0] || positionA[1]== positionB[1])&& (positionA[0] + 1 == positionC[0] || positionA[1] == positionC[1]) && (positionA[0] + 1 == positionD[0] || positionA[1] == positionD[1]))
                    {
                        Debug.WriteLine("Kaza önlendi");
                    }
                    else
                    {
                        positionA[0]++;
                        movement++;
                        CheckSecretGold(positionA);
                        aGoldAmount -= MainMenu.aMovementCost;
                    }
                      
                }
                  else if (targetA[0] < positionA[0])
                    {
                    if ((positionA[0] -1 == positionB[0] || positionA[1] == positionB[1]) && (positionA[0] - 1 == positionC[0] || positionA[1] == positionC[1]) && (positionA[0] - 1 == positionD[0] || positionA[1] == positionD[1]))
                    {
                        Debug.WriteLine("Kaza önlendi");
                    }
                    else
                    {
                        positionA[0]--;
                        movement++;
                        CheckSecretGold(positionA);
                        aGoldAmount -= MainMenu.aMovementCost;
                    }
                      
                }
                    objectA = positionA[0] + (mapWidth*positionA[1]);        
                    gamesSquares[objectA].BackColor = Color.Blue;
                    
                }
            while (targetA[1] != positionA[1])
            {
                if (movement == 3)
                {
                    movement = 0;
                    break;
                }
                MessageBox.Show("2");
                gamesSquares[objectA].UseVisualStyleBackColor = true;
                countBlock = 0;
                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 0; j < mapWidth; j++)
                    {
                        if (goldMapMatris[i, j] != 0 && goldMapMatris[i, j] != -1)
                        {
                            gamesSquares[countBlock].BackColor = Color.Yellow;
                        }
                        countBlock++;
                    }
                }
                if (targetA[1] > positionA[1])
                {
                    if ((positionA[0] == positionB[0] || positionA[1]+1 == positionB[1]) && (positionA[0] == positionC[0] || positionA[1]+1 == positionC[1]) && (positionA[0] == positionD[0] || positionA[1]+1 == positionD[1]))
                    {
                        Debug.WriteLine("Kaza önlendi");
                    }
                    else
                    {
                        positionA[1]++;
                        movement++;
                        CheckSecretGold(positionA);
                        aGoldAmount -= MainMenu.aMovementCost;
                    }
                }
                if (targetA[1] < positionA[1])
                {
                    if ((positionA[0] == positionB[0] || positionA[1] - 1 == positionB[1]) && (positionA[0] == positionC[0] || positionA[1] - 1 == positionC[1]) && (positionA[0] == positionD[0] || positionA[1] - 1 == positionD[1]))
                    {
                        Debug.WriteLine("Kaza önlendi");
                    }
                    else
                    {
                        positionA[1]--;
                        movement++;
                        CheckSecretGold(positionA);
                        aGoldAmount -= MainMenu.aMovementCost;
                    }
                }
                objectA = positionA[0] + (mapWidth * positionA[1]);
                gamesSquares[objectA].BackColor = Color.Blue;
            }
        }
        private void PlayB()
        {

        }
        private void PlayC()
        {

        }
        private void PlayD()
        {

        }
        private void CheckSecretGold(int[] coordinates)
        {
          /*  bool check = false;
            countBlock = 0;
              for (int i = 0; i < mapHeight; i++)
              {
                  for (int j = 0; j < mapWidth; j++)
                  {
                      if (goldMapMatris[i, j] == -1)//y,x
                      {
                          if ((j==coordinates[0] || i==coordinates[1])||check==false)
                          {
                              gamesSquares[countBlock].BackColor = Color.Yellow;
                              int num3 = rnd.Next(100);
                              if (num3 < 25)
                              {
                                  goldMapMatris[i, j] = 5;
                              }
                              else if (num3 < 50)
                              {
                                  goldMapMatris[i, j] = 10;
                              }
                              else if (num3 < 75)
                              {
                                  goldMapMatris[i, j] = 15;
                              }
                              else if (num3 < 100)
                              {
                                  goldMapMatris[i, j] = 20;
                              }
                              gamesSquares[countBlock].Text = "" + goldMapMatris[i, j];
                              check = true;
                              break;
                          }
                      }
                      countBlock++;
                  }
                if (check == true)
                {
                    break;
                }
            }*/
        }
    }
}
