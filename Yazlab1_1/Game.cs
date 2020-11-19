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
using System.IO;

namespace Yazlab1_1
{
    public partial class Game : Form
    {       
        int distance = 0;
        private int mapWidth = MainMenu.mapWidth;
        private int mapHeight = MainMenu.mapHeight;
        List<Button> gamesSquares = new List<Button>();
        private int[] positionA = { 0, 0 };
        private int[] positionB = { MainMenu.mapWidth - 1,0 };
        private int[] positionC = {0 , MainMenu.mapHeight - 1 };
        private int[] positionD = { MainMenu.mapWidth - 1, MainMenu.mapHeight - 1 };
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
        int[,] distanceMatris = new int[MainMenu.mapHeight, MainMenu.mapWidth];
        int[,] gainMatris = new int[MainMenu.mapHeight, MainMenu.mapWidth];
        int[,] secretGoldMatrisC = new int[MainMenu.mapHeight, MainMenu.mapWidth];
        public Game()
        {
            InitializeComponent();
        }
        private void Game_Load(object sender, EventArgs e)
        {
            using (System.IO.StreamWriter aOyuncusu = new System.IO.StreamWriter(@"..\\aOyuncusu.txt", false))
                aOyuncusu.WriteLine("X:" + positionA[0] + " Y:" + positionA[1]);
            using (System.IO.StreamWriter bOyuncusu = new System.IO.StreamWriter(@"..\\bOyuncusu.txt", false))
                bOyuncusu.WriteLine("X:" + positionB[0] + " Y:" + positionB[1]);
            using (System.IO.StreamWriter cOyuncusu = new System.IO.StreamWriter(@"..\\cOyuncusu.txt", false))
                cOyuncusu.WriteLine("X:" + positionC[0] + " Y:" + positionC[1]);
            using (System.IO.StreamWriter dOyuncusu = new System.IO.StreamWriter(@"..\\dOyuncusu.txt", false))
                dOyuncusu.WriteLine("X:" + positionD[0] + " Y:" + positionD[1]);
            using (System.IO.StreamWriter oyunOzet = new System.IO.StreamWriter(@"..\\OyunOzet.txt", false))
                oyunOzet.WriteLine("Oyun Ozeti");
            int goldBlock = 0;
            goldCount = (mapWidth * mapHeight * MainMenu.goldRate) / 100;
            secretGoldCount = (goldCount * MainMenu.secretGoldRate) / 100;
            goldCount -= secretGoldCount;
            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    goldMapMatris[i, j] = 0;
                }
            }
            while (goldBlock != secretGoldCount)
            {
                int num1 = rnd.Next(mapHeight);//uzunluk ilk
                int num2 = rnd.Next(mapWidth);//genişlik 2            
                if (goldMapMatris[num1, num2] == 0)
                {
                    if ((num1 == 0 && num2 == 0) || (num1 == 0 && num2 == mapWidth - 1) || (num1 == mapHeight - 1 && num2 == 0) || (num1 == mapHeight - 1 && num2 == mapWidth - 1))
                    {

                    }
                    else
                    {
                        goldMapMatris[num1, num2] = -1;
                        goldBlock++;
                    }
                }
            }
            goldBlock = 0;
            while (goldBlock != goldCount)
            {
                int num1 = rnd.Next(mapHeight);//uzunluk ilk
                int num2 = rnd.Next(mapWidth);//genişlik 2        
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
            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    gamesSquares.Add(createButton(btnName, xPosition, yPosition, gamesSquares));
                    addNewButtons(gamesSquares, this);
                    xPosition += 30;
                }
                xPosition = 380;
                yPosition += 30;
            }
            gamesSquares[0].BackColor = Color.Blue;
            gamesSquares[mapWidth - 1].BackColor = Color.Red;
            gamesSquares[(mapWidth * mapHeight) - mapWidth].BackColor = Color.Green;
            gamesSquares[(mapWidth * mapHeight) - 1].BackColor = Color.Magenta;
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
        private int[] targetA = { 0, 0 };
        private int[] targetB = { 0, 0 };
        private int[] targetC = { 0, 0 };
        private int[] targetD = { 0, 0 };
        private int aStep = 0;
        private int bStep = 0;
        private int cStep = 0;
        private int dStep = 0;
        private int spentGoldA = 0;
        private int spentGoldB = 0;
        private int spentGoldC = 0;
        private int spentGoldD = 0;
        private int collectedGoldA = 0;
        private int collectedGoldB = 0;
        private int collectedGoldC = 0;
        private int collectedGoldD = 0;
        private int[] coordinatesSecretGold = { 0, 0 };
        private bool isDeadA = false;
        private bool isDeadB = false;
        private bool isDeadC = false;
        private bool isDeadD = false;
        private bool gameOver = false;
        private bool firstTargetA = false;
        private bool firstTargetB = false;
        private bool firstTargetC = false;
        private void button1_Click(object sender, EventArgs e)
        {
                if (tourManagement == 1)
                {
                    if (isDeadA == false)
                    {
                        PlayA();
                    }
                    if (isDeadB == false)
                    {
                        tourManagement = 2;
                    }
                    else if (isDeadC == false)
                    {
                        tourManagement = 3;
                    }
                    else if (isDeadD == false)
                    {
                        tourManagement = 4;
                    }
                    aGoldText.Text = ("Altın: " + aGoldAmount);
                }
                else if (tourManagement == 2)
                {
                    if (isDeadB == false)
                    {
                        PlayB();
                    }
                    if (isDeadC == false)
                    {
                        tourManagement = 3;
                    }
                    else if (isDeadD == false)
                    {
                        tourManagement = 4;
                    }
                    else if (isDeadA == false)
                    {
                        tourManagement = 1;
                    }
                    bGoldText.Text = ("Altın: " + bGoldAmount);
                }
                else if (tourManagement == 3)
                {
                    if (isDeadC == false)
                    {
                        PlayC();
                    }
                    if (isDeadD == false)
                    {
                        tourManagement = 4;
                    }
                    else if (isDeadA == false)
                    {
                        tourManagement = 1;
                    }
                    else if (isDeadB == false)
                    {
                        tourManagement = 2;
                    }
                    cGoldText.Text = ("Altın: " + cGoldAmount);
                }
                else if (tourManagement == 4)
                {
                    if (isDeadD == false)
                    {
                        PlayD();
                    }
                    if (isDeadA == false)
                    {
                        tourManagement = 1;
                    }
                    else if (isDeadB == false)
                    {
                        tourManagement = 2;
                    }
                    else if (isDeadC == false)
                    {
                        tourManagement = 3;
                    }
                    dGoldText.Text = ("Altın: " + dGoldAmount);
                }
            if (gameOver == false)
            {
                gameOver = true;
                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 0; j < mapWidth; j++)
                    {
                        if (goldMapMatris[i, j] != 0 && goldMapMatris[i, j] != -1)
                        {
                            gameOver = false;
                        }
                    }
                }
            }
            if (isDeadA == true && isDeadB == true && isDeadC == true && isDeadD == true)
            {
                gameOver = true;
            }
            if ((isDeadA == false && isDeadB == true && isDeadC == true && isDeadD == true) || (isDeadA == true && isDeadB == false && isDeadC == true && isDeadD == true) || (isDeadA == true && isDeadB == true && isDeadC == false && isDeadD == true) || (isDeadA == true && isDeadB == true && isDeadC == true && isDeadD == false))
            {
                gameOver = true;
            }
            if (gameOver==true)
                {
                    tourManagement = 9;
                    MessageBox.Show("Oyun Bitti");
                if (aGoldAmount>bGoldAmount && aGoldAmount > cGoldAmount && aGoldAmount > dGoldAmount)
                {
                    MessageBox.Show("A oyuncusu kazandı");
                }
                else if (bGoldAmount > aGoldAmount && bGoldAmount > cGoldAmount && bGoldAmount > dGoldAmount)
                {
                    MessageBox.Show("B oyuncusu kazandı");
                }
                else if (cGoldAmount > bGoldAmount && cGoldAmount > aGoldAmount && cGoldAmount > dGoldAmount)
                {
                    MessageBox.Show("C oyuncusu kazandı");
                }
                else if (dGoldAmount > bGoldAmount && dGoldAmount > cGoldAmount && dGoldAmount > aGoldAmount)
                {
                    MessageBox.Show("D oyuncusu kazandı");
                }
                using (System.IO.StreamWriter oyunOzet = new System.IO.StreamWriter(@"..\\OyunOzet.txt", true))
                {
                    oyunOzet.WriteLine("");
                    oyunOzet.WriteLine("A Oyuncusu: ");
                    oyunOzet.WriteLine("Toplam Adım Sayısı: "+aStep);
                    oyunOzet.WriteLine("Harcanan Altın miktarı: "+spentGoldA);
                    oyunOzet.WriteLine("Kasadaki Altın miktarı: "+aGoldAmount);
                    oyunOzet.WriteLine("Toplanan Altın miktarı: "+collectedGoldA);
                    oyunOzet.WriteLine("");
                    oyunOzet.WriteLine("");
                    oyunOzet.WriteLine("B Oyuncusu: ");
                    oyunOzet.WriteLine("Toplam Adım Sayısı: "+bStep);
                    oyunOzet.WriteLine("Harcanan Altın miktarı: "+spentGoldB);
                    oyunOzet.WriteLine("Kasadaki Altın miktarı: "+bGoldAmount);
                    oyunOzet.WriteLine("Toplanan Altın miktarı: "+collectedGoldB);
                    oyunOzet.WriteLine("");
                    oyunOzet.WriteLine("");
                    oyunOzet.WriteLine("C Oyuncusu: ");
                    oyunOzet.WriteLine("Toplam Adım Sayısı: "+cStep);
                    oyunOzet.WriteLine("Harcanan Altın miktarı: "+spentGoldC);
                    oyunOzet.WriteLine("Kasadaki Altın miktarı: "+cGoldAmount);
                    oyunOzet.WriteLine("Toplanan Altın miktarı: "+collectedGoldC);
                    oyunOzet.WriteLine("");
                    oyunOzet.WriteLine("");
                    oyunOzet.WriteLine("D Oyuncusu: ");
                    oyunOzet.WriteLine("Toplam Adım Sayısı: "+dStep);
                    oyunOzet.WriteLine("Harcanan Altın miktarı: "+spentGoldD);
                    oyunOzet.WriteLine("Kasadaki Altın miktarı: "+dGoldAmount);
                    oyunOzet.WriteLine("Toplanan Altın miktarı: "+collectedGoldD);
                }
            }   
        }
        private int movement = 0;
        private int objectA = 0;
        private int objectB = MainMenu.mapWidth - 1;
        private int objectC = (MainMenu.mapWidth * MainMenu.mapHeight) - MainMenu.mapWidth;
        private int objectD = ((MainMenu.mapWidth * MainMenu.mapHeight) - 1);
        private bool turnOver = false;
        private void PlayA()
        {
            if (firstTargetA == false)
            {
                firstTargetA = true;
                aGoldAmount -= MainMenu.aTargetCost;
                spentGoldA += MainMenu.aTargetCost;
                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 0; j < mapWidth; j++)
                    {
                        distanceMatris[i, j] = 0;
                    }
                }
                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 0; j < mapWidth; j++)
                    {
                        if (goldMapMatris[i, j] != 0 && goldMapMatris[i, j] != -1)
                        {
                            distance = Math.Abs(i - positionA[1]) + Math.Abs(j - positionA[0]);
                            distanceMatris[i, j] = distance;
                        }
                    }
                }
                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 0; j < mapWidth; j++)
                    {
                        if(distance> distanceMatris[i, j] && distanceMatris[i, j]!= 0)
                        {
                            distance = distanceMatris[i, j];
                        }
                    }
                }
                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 0; j < mapWidth; j++)
                    {
                        if (distance== distanceMatris[i,j])
                        {
                            targetA[0] = j;
                            targetA[1] = i;
                        }
                    }
                }
                distance = 0;
                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 0; j < mapWidth; j++)
                    {
                        Debug.Write(" " + distanceMatris[i, j]);
                    }
                    Debug.WriteLine("");
                }
                Debug.WriteLine("Hedef Belirlendi X:" + targetA[0] + " Y:" + targetA[1]);
            }
            movement = 0;
            turnOver = false;
            while (targetA[0] != positionA[0])
            {
                if (aGoldAmount <= 0)
                {
                    isDeadA = true;
                    break;
                }
                if (movement == 3 || turnOver== true)
                {
                    turnOver = true;
                    movement = 0;
                    break;
                }
                gamesSquares[objectA].UseVisualStyleBackColor = true;
                if(positionA[0]==positionB[0] && positionA[1] == positionB[1])
                {
                    gamesSquares[objectA].BackColor = Color.Red;
                }
                else if(positionA[0] == positionC[0] && positionA[1] == positionC[1])
                {
                    gamesSquares[objectA].BackColor = Color.Green;
                }
                else if (positionA[0] == positionD[0] && positionA[1] == positionD[1])
                {
                    gamesSquares[objectA].BackColor = Color.Magenta;
                }
                countBlock = 0;
                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 0; j < mapWidth; j++)
                    {
                        if (goldMapMatris[i, j] != 0 && goldMapMatris[i, j] != -1)//y,x
                        {
                            gamesSquares[countBlock].BackColor = Color.Yellow;
                        }
                        countBlock++;
                    }
                }
                if (targetA[0] > positionA[0])
                {           
                        positionA[0]++;
                        movement++;
                        aGoldAmount -= MainMenu.aMovementCost;
                    spentGoldA += MainMenu.aMovementCost;
                    aStep++;
                    using (System.IO.StreamWriter aOyuncusu = new System.IO.StreamWriter(@"..\\aOyuncusu.txt", true))
                        aOyuncusu.WriteLine("X:"+positionA[0]+" Y:"+positionA[1]);
                }
                else if (targetA[0] < positionA[0])
                {         
                        positionA[0]--;
                        movement++;
                        aGoldAmount -= MainMenu.aMovementCost;
                    spentGoldA += MainMenu.aMovementCost;
                    aStep++;
                    using (System.IO.StreamWriter aOyuncusu = new System.IO.StreamWriter(@"..\\aOyuncusu.txt", true))
                        aOyuncusu.WriteLine("X:" + positionA[0] + " Y:" + positionA[1]);
                }
                objectA = positionA[0] + (mapWidth * positionA[1]);
                gamesSquares[objectA].BackColor = Color.Blue;
                CheckSecretGold(positionA, objectA);
            }
            while (targetA[1] != positionA[1])
            {
                if (aGoldAmount <= 0)
                {
                    isDeadA = true;
                    break;
                }
                if (movement == 3 || turnOver == true)
                {
                    turnOver = true;
                    movement = 0;
                    break;
                }
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
                        positionA[1]++;
                        movement++;
                        aGoldAmount -= MainMenu.aMovementCost;
                    spentGoldA += MainMenu.aMovementCost;
                    aStep++;
                    using (System.IO.StreamWriter aOyuncusu = new System.IO.StreamWriter(@"..\\aOyuncusu.txt", true))
                        aOyuncusu.WriteLine("X:" + positionA[0] + " Y:" + positionA[1]);
                }
                if (targetA[1] < positionA[1])
                {
                        positionA[1]--;
                        movement++;
                        aGoldAmount -= MainMenu.aMovementCost;
                    spentGoldA += MainMenu.aMovementCost;
                    aStep++;
                    using (System.IO.StreamWriter aOyuncusu = new System.IO.StreamWriter(@"..\\aOyuncusu.txt", true))
                        aOyuncusu.WriteLine("X:" + positionA[0] + " Y:" + positionA[1]);
                }
                objectA = positionA[0] + (mapWidth * positionA[1]);
                gamesSquares[objectA].BackColor = Color.Blue;
                CheckSecretGold(positionA, objectA);
            }
            if (targetA[0] == positionA[0] && targetA[1] == positionA[1])
            {
                targetA[0] = 0;
                targetA[1] = 0;
                aGoldAmount += goldMapMatris[positionA[1], positionA[0]];
                collectedGoldA+= goldMapMatris[positionA[1], positionA[0]];
                aGoldText.Text = ("Altın: " + aGoldAmount);
                goldMapMatris[positionA[1], positionA[0]] = 0;
                gamesSquares[(positionA[1] * mapWidth) + positionA[0]].Text = "";
                distanceMatris[positionA[1], positionA[0]] = 0;
            }
            if ((targetA[0] == 0 && targetA[1] == 0) || goldMapMatris[targetA[1], targetA[0]] == 0)
            {
                aGoldAmount -= MainMenu.aTargetCost;
                spentGoldA += MainMenu.aTargetCost;
                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 0; j < mapWidth; j++)
                    {
                        distanceMatris[i, j] = 0;
                    }
                }
                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 0; j < mapWidth; j++)
                    {
                        if (goldMapMatris[i, j] != 0 && goldMapMatris[i, j] != -1)
                        {
                            distance = Math.Abs(i - positionA[1]) + Math.Abs(j - positionA[0]);
                            distanceMatris[i, j] = distance;
                        }
                    }
                }
                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 0; j < mapWidth; j++)
                    {
                        if (distance > distanceMatris[i, j] && distanceMatris[i, j] != 0)
                        {
                            distance = distanceMatris[i, j];
                        }
                    }
                }
                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 0; j < mapWidth; j++)
                    {
                        if (distance == distanceMatris[i, j])
                        {
                            targetA[0] = j;
                            targetA[1] = i;
                        }
                    }
                }
                distance = 0;
                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 0; j < mapWidth; j++)
                    {
                        Debug.Write(" " + distanceMatris[i, j]);
                    }
                    Debug.WriteLine("");
                }
                Debug.WriteLine("Hedef Belirlendi X:" + targetA[0] + " Y:" + targetA[1]);
            }
        }
        int cost;
        private void PlayB()
        {
            if (firstTargetB==false)
            {
                firstTargetB = true;
                bGoldAmount -= MainMenu.bTargetCost;
                spentGoldB += MainMenu.bTargetCost;
                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 0; j < mapWidth; j++)
                    {
                        gainMatris[i, j] = 0;
                    }
                }
                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 0; j < mapWidth; j++)
                    {
                        if (goldMapMatris[i, j] != 0 && goldMapMatris[i, j] != -1)
                        {
                            cost = (Math.Abs(i - positionB[1]) + Math.Abs(j - positionB[0]))*MainMenu.bMovementCost;
                            cost -= goldMapMatris[i, j];
                            gainMatris[i, j] = cost+1;
                        }
                    }
                }
                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 0; j < mapWidth; j++)
                    {
                        if (cost > gainMatris[i, j] && gainMatris[i, j] != 0)
                        {
                            cost = gainMatris[i, j];
                        }
                    }
                }
                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 0; j < mapWidth; j++)
                    {
                        if (cost == gainMatris[i, j])
                        {
                            targetB[0] = j;
                            targetB[1] = i;
                        }
                    }
                }
                cost = 0;
                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 0; j < mapWidth; j++)
                    {
                        Debug.Write(" " + gainMatris[i, j]);
                    }
                    Debug.WriteLine("\n");
                }
                Debug.WriteLine("Hedef Belirlendi X:" + targetB[0] + " Y:" + targetB[1]);
            }
            movement = 0;
            turnOver = false;
            while (targetB[0] != positionB[0])
            {
                if (bGoldAmount <= 0)
                {
                    isDeadB = true;
                    break;
                }
                if (movement == 3 || turnOver == true)
                {
                    turnOver = true;
                    movement = 0;
                    break;
                }
                gamesSquares[objectB].UseVisualStyleBackColor = true;
                if (positionB[0] == positionA[0] && positionB[1] == positionA[1])
                {
                    gamesSquares[objectB].BackColor = Color.Blue;
                }
                else if (positionB[0] == positionC[0] && positionB[1] == positionC[1])
                {
                    gamesSquares[objectB].BackColor = Color.Green;
                }
                else if (positionB[0] == positionD[0] && positionB[1] == positionD[1])
                {
                    gamesSquares[objectB].BackColor = Color.Magenta;
                }
                countBlock = 0;
                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 0; j < mapWidth; j++)
                    {
                        if (goldMapMatris[i, j] != 0 && goldMapMatris[i, j] != -1)//y,x
                        {
                            gamesSquares[countBlock].BackColor = Color.Yellow;
                        }
                        countBlock++;
                    }
                }
                if (targetB[0] > positionB[0])
                {
                        positionB[0]++;
                        movement++;
                        bGoldAmount -= MainMenu.bMovementCost;
                    spentGoldB += MainMenu.bMovementCost;
                    bStep++;
                    using (System.IO.StreamWriter bOyuncusu = new System.IO.StreamWriter(@"..\\bOyuncusu.txt", true))
                        bOyuncusu.WriteLine("X:" + positionB[0] + " Y:" + positionB[1]);
                }
                else if (targetB[0] < positionB[0])
                {
                        positionB[0]--;
                        movement++;
                        bGoldAmount -= MainMenu.bMovementCost;
                    spentGoldB += MainMenu.bMovementCost;
                    bStep++;
                    using (System.IO.StreamWriter bOyuncusu = new System.IO.StreamWriter(@"..\\bOyuncusu.txt", true))
                        bOyuncusu.WriteLine("X:" + positionB[0] + " Y:" + positionB[1]);
                }
                objectB = positionB[0] + (mapWidth * positionB[1]);
                gamesSquares[objectB].BackColor = Color.Red;
                CheckSecretGold(positionB, objectB);
            }
            while (targetB[1] != positionB[1])
            {
                if (bGoldAmount <= 0)
                {
                    isDeadB = true;
                    break;
                }
                if (movement == 3 || turnOver == true)
                {
                    turnOver = true;
                    movement = 0;
                    break;
                }
                gamesSquares[objectB].UseVisualStyleBackColor = true;
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
                if (targetB[1] > positionB[1])
                {
                        positionB[1]++;
                        movement++;
                        bGoldAmount -= MainMenu.bMovementCost;
                    spentGoldB += MainMenu.bMovementCost;
                    bStep++;
                    using (System.IO.StreamWriter bOyuncusu = new System.IO.StreamWriter(@"..\\bOyuncusu.txt", true))
                        bOyuncusu.WriteLine("X:" + positionB[0] + " Y:" + positionB[1]);
                }
                if (targetB[1] < positionB[1])
                {
                        positionB[1]--;
                        movement++;
                        bGoldAmount -= MainMenu.bMovementCost;
                    spentGoldB += MainMenu.bMovementCost;
                    bStep++;
                    using (System.IO.StreamWriter bOyuncusu = new System.IO.StreamWriter(@"..\\bOyuncusu.txt", true))
                        bOyuncusu.WriteLine("X:" + positionB[0] + " Y:" + positionB[1]);
                }
                objectB = positionB[0] + (mapWidth * positionB[1]);
                gamesSquares[objectB].BackColor = Color.Red;
                CheckSecretGold(positionB, objectB);
            }
            if (targetB[0] == positionB[0] && targetB[1] == positionB[1])
            {
                targetB[0] = 0;
                targetB[1] = 0;
                bGoldAmount += goldMapMatris[positionB[1], positionB[0]];
                collectedGoldB += goldMapMatris[positionB[1], positionB[0]];
                bGoldText.Text = ("Altın: " + bGoldAmount);
                goldMapMatris[positionB[1], positionB[0]] = 0;
                gamesSquares[(positionB[1] * mapWidth) + positionB[0]].Text = "";
                gainMatris[positionB[1], positionB[0]] = 0;
            }
            if ((targetB[0] == 0 && targetB[1] == 0) || goldMapMatris[targetB[1], targetB[0]] == 0)
            {
                bGoldAmount -= MainMenu.bTargetCost;
                spentGoldB += MainMenu.bTargetCost;
                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 0; j < mapWidth; j++)
                    {
                        gainMatris[i, j] = 0;
                    }
                }
                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 0; j < mapWidth; j++)
                    {
                        if (goldMapMatris[i, j] != 0 && goldMapMatris[i, j] != -1)
                        {
                            cost = (Math.Abs(i - positionB[1]) + Math.Abs(j - positionB[0])) * MainMenu.bMovementCost;
                            cost -= goldMapMatris[i, j];
                            gainMatris[i, j] = cost + 1;
                        }
                    }
                }
                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 0; j < mapWidth; j++)
                    {
                        if (cost > gainMatris[i, j] && gainMatris[i, j] != 0)
                        {
                            cost = gainMatris[i, j];
                        }
                    }
                }
                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 0; j < mapWidth; j++)
                    {
                        if (cost == gainMatris[i, j])
                        {
                            targetB[0] = j;
                            targetB[1] = i;
                        }
                    }
                }
                cost = 0;
                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 0; j < mapWidth; j++)
                    {
                        Debug.Write(" " + gainMatris[i, j]);
                    }
                    Debug.WriteLine("\n");
                }
                Debug.WriteLine("Hedef Belirlendi X:" + targetB[0] + " Y:" + targetB[1]);
            }
        }
        private void PlayC()
        {
            cSuperPower(positionC);
            if (firstTargetC == false)
            {
                firstTargetC = true;
                cGoldAmount -= MainMenu.cTargetCost;
                spentGoldC += MainMenu.cTargetCost;
                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 0; j < mapWidth; j++)
                    {
                        gainMatris[i, j] = 0;
                    }
                }
                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 0; j < mapWidth; j++)
                    {
                        if (goldMapMatris[i, j] != 0 && goldMapMatris[i, j] != -1)
                        {
                            cost = (Math.Abs(i - positionC[1]) + Math.Abs(j - positionC[0])) * MainMenu.cMovementCost;
                            cost -= goldMapMatris[i, j];
                            gainMatris[i, j] = cost + 1;
                        }
                    }
                }
                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 0; j < mapWidth; j++)
                    {
                        if (cost > gainMatris[i, j] && gainMatris[i, j] != 0)
                        {
                            cost = gainMatris[i, j];
                        }
                    }
                }
                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 0; j < mapWidth; j++)
                    {
                        if (cost == gainMatris[i, j])
                        {
                            targetC[0] = j;
                            targetC[1] = i;
                        }
                    }
                }
                cost = 0;
                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 0; j < mapWidth; j++)
                    {
                        Debug.Write(" " + gainMatris[i, j]);
                    }
                    Debug.WriteLine("");
                }
                Debug.WriteLine("Hedef Belirlendi X:" + targetC[0] + " Y:" + targetC[1]);
            }
            movement = 0;
            turnOver = false;
            while (targetC[0] != positionC[0])
            {
                if (cGoldAmount <= 0)
                {
                    isDeadC = true;
                    break;
                }
                if (movement == 3 || turnOver == true)
                {
                    turnOver = true;
                    movement = 0;
                    break;
                }
                gamesSquares[objectC].UseVisualStyleBackColor = true;
                countBlock = 0;
                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 0; j < mapWidth; j++)
                    {
                        if (goldMapMatris[i, j] != 0 && goldMapMatris[i, j] != -1)//y,x
                        {
                            gamesSquares[countBlock].BackColor = Color.Yellow;
                        }
                        countBlock++;
                    }
                }
                if (targetC[0] > positionC[0])
                {
                        positionC[0]++;
                        movement++;
                        cGoldAmount -= MainMenu.cMovementCost;
                    spentGoldC += MainMenu.cMovementCost;
                    cStep++;
                    using (System.IO.StreamWriter cOyuncusu = new System.IO.StreamWriter(@"..\\cOyuncusu.txt", true))
                        cOyuncusu.WriteLine("X:" + positionC[0] + " Y:" + positionC[1]);
                }
                else if (targetC[0] < positionC[0])
                {
                        positionC[0]--;
                        movement++;
                        cGoldAmount -= MainMenu.cMovementCost;
                    spentGoldC += MainMenu.cMovementCost;
                    cStep++;
                    using (System.IO.StreamWriter cOyuncusu = new System.IO.StreamWriter(@"..\\cOyuncusu.txt", true))
                        cOyuncusu.WriteLine("X:" + positionC[0] + " Y:" + positionC[1]);
                }
                objectC = positionC[0] + (mapWidth * positionC[1]);
                gamesSquares[objectC].BackColor = Color.Green;
                CheckSecretGold(positionC, objectC);
            }
            while (targetC[1] != positionC[1])
            {
                if (cGoldAmount <= 0)
                {
                    isDeadC = true;
                    break;
                }
                if (movement == 3 || turnOver == true)
                {
                    turnOver = true;
                    movement = 0;
                    break;
                }
                gamesSquares[objectC].UseVisualStyleBackColor = true;
                if (positionC[0] == positionB[0] && positionC[1] == positionB[1])
                {
                    gamesSquares[objectC].BackColor = Color.Red;
                }
                else if (positionC[0] == positionA[0] && positionC[1] == positionA[1])
                {
                    gamesSquares[objectC].BackColor = Color.Blue;
                }
                else if (positionC[0] == positionD[0] && positionC[1] == positionD[1])
                {
                    gamesSquares[objectC].BackColor = Color.Magenta;
                }
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
                if (targetC[1] > positionC[1])
                {
                        positionC[1]++;
                        movement++;
                        cGoldAmount -= MainMenu.cMovementCost;
                    spentGoldC += MainMenu.cMovementCost;
                    cStep++;
                    using (System.IO.StreamWriter cOyuncusu = new System.IO.StreamWriter(@"..\\cOyuncusu.txt", true))
                        cOyuncusu.WriteLine("X:" + positionC[0] + " Y:" + positionC[1]);
                }
                if (targetC[1] < positionC[1])
                {
                        positionC[1]--;
                        movement++;
                        cGoldAmount -= MainMenu.cMovementCost;
                    spentGoldC += MainMenu.cMovementCost;
                    cStep++;
                    using (System.IO.StreamWriter cOyuncusu = new System.IO.StreamWriter(@"..\\cOyuncusu.txt", true))
                        cOyuncusu.WriteLine("X:" + positionC[0] + " Y:" + positionC[1]);
                }
                objectC = positionC[0] + (mapWidth * positionC[1]);
                gamesSquares[objectC].BackColor = Color.Green;
                CheckSecretGold(positionC, objectC);
            }
            if (targetC[0] == positionC[0] && targetC[1] == positionC[1])
            {
                targetC[0] = 0;
                targetC[1] = 0;
                cGoldAmount += goldMapMatris[positionC[1], positionC[0]];
                collectedGoldC += goldMapMatris[positionC[1], positionC[0]];
                cGoldText.Text = ("Altın: " + cGoldAmount);
                goldMapMatris[positionC[1], positionC[0]] = 0;
                gamesSquares[(positionC[1] * mapWidth) + positionC[0]].Text = "";
                gainMatris[positionC[1], positionC[0]] = 0;
            }
            if ((targetC[0] == 0 && targetC[1] == 0) || goldMapMatris[targetC[1], targetC[0]] == 0)
            {
                cGoldAmount -= MainMenu.cTargetCost;
                spentGoldC += MainMenu.cTargetCost;
                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 0; j < mapWidth; j++)
                    {
                        gainMatris[i, j] = 0;
                    }
                }
                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 0; j < mapWidth; j++)
                    {
                        if (goldMapMatris[i, j] != 0 && goldMapMatris[i, j] != -1)
                        {
                            cost = (Math.Abs(i - positionC[1]) + Math.Abs(j - positionC[0])) * MainMenu.cMovementCost;
                            cost -= goldMapMatris[i, j];
                            gainMatris[i, j] = cost + 1;
                        }
                    }
                }
                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 0; j < mapWidth; j++)
                    {
                        if (cost > gainMatris[i, j] && gainMatris[i, j] != 0)
                        {
                            cost = gainMatris[i, j];
                        }
                    }
                }
                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 0; j < mapWidth; j++)
                    {
                        if (cost == gainMatris[i, j])
                        {
                            targetC[0] = j;
                            targetC[1] = i;
                        }
                    }
                }
                cost = 0;
                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 0; j < mapWidth; j++)
                    {
                        Debug.Write(" " + gainMatris[i, j]);
                    }
                    Debug.WriteLine("");
                }
                Debug.WriteLine("Hedef Belirlendi X:" + targetC[0] + " Y:" + targetC[1]);
            }
        }
        private void PlayD()
        {
            if ((targetD[0] == 0 && targetD[1] == 0) || goldMapMatris[targetD[1], targetD[0]] == 0)
            {
                dGoldAmount -= MainMenu.dTargetCost;
                spentGoldD += MainMenu.dTargetCost;
                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 0; j < mapWidth; j++)
                    {
                        gainMatris[i, j] = 0;
                    }
                }
                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 0; j < mapWidth; j++)
                    {
                        if (goldMapMatris[i, j] != 0 && goldMapMatris[i, j] != -1)
                        {
                            cost = (Math.Abs(i - positionD[1]) + Math.Abs(j - positionD[0])) * MainMenu.dMovementCost;
                            cost -= goldMapMatris[i, j];
                            gainMatris[i, j] = cost + 1;
                        }
                    }
                }
                cost = 100000;
                if ((Math.Abs(targetA[1] - positionD[1]) + Math.Abs(targetA[0] - positionD[0])) >= (Math.Abs(targetA[1] - positionA[1]) + Math.Abs(targetA[0] - positionA[0])))
                {
                    gainMatris[targetA[1], targetA[0]] = 0;
                }
                if ((Math.Abs(targetB[1] - positionD[1]) + Math.Abs(targetB[0] - positionD[0]))>= (Math.Abs(targetB[1] - positionB[1]) + Math.Abs(targetB[0] - positionB[0])))
                {
                    gainMatris[targetB[1],targetB[0]]= 0;
                }
                if ((Math.Abs(targetC[1] - positionD[1]) + Math.Abs(targetC[0] - positionD[0])) >= (Math.Abs(targetC[1] - positionC[1]) + Math.Abs(targetC[0] - positionC[0])))
                {
                    gainMatris[targetC[1], targetC[0]] = 0;
                }


                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 0; j < mapWidth; j++)
                    {
                        if (cost > gainMatris[i, j] && gainMatris[i, j] != 0)
                        {
                            cost = gainMatris[i, j];
                        }
                    }
                }
                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 0; j < mapWidth; j++)
                    {
                        if (cost == gainMatris[i, j])
                        {
                            targetD[0] = j;
                            targetD[1] = i;
                        }
                    }
                }
                cost = 0;
                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 0; j < mapWidth; j++)
                    {
                        Debug.Write(" " + gainMatris[i, j]);
                    }
                    Debug.WriteLine("");
                }
                Debug.WriteLine("Hedef Belirlendi X:" + targetD[0] + " Y:" + targetD[1]);
            }
            movement = 0;
            turnOver = false;
            while (targetD[0] != positionD[0])
            {
                if (dGoldAmount <= 0)
                {
                    isDeadD = true;
                    break;
                }
                if (movement == 3 || turnOver == true)
                {
                    turnOver = true;
                    movement = 0;
                    break;
                }
                gamesSquares[objectD].UseVisualStyleBackColor = true;
                if (positionD[0] == positionB[0] && positionD[1] == positionB[1])
                {
                    gamesSquares[objectD].BackColor = Color.Red;
                }
                else if (positionD[0] == positionC[0] && positionD[1] == positionC[1])
                {
                    gamesSquares[objectD].BackColor = Color.Green;
                }
                else if (positionD[0] == positionA[0] && positionD[1] == positionA[1])
                {
                    gamesSquares[objectD].BackColor = Color.Blue;
                }
                countBlock = 0;
                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 0; j < mapWidth; j++)
                    {
                        if (goldMapMatris[i, j] != 0 && goldMapMatris[i, j] != -1)//y,x
                        {
                            gamesSquares[countBlock].BackColor = Color.Yellow;
                        }
                        countBlock++;
                    }
                }
                if (targetD[0] > positionD[0])
                {
                    positionD[0]++;
                    movement++;
                    dGoldAmount -= MainMenu.dMovementCost;
                    spentGoldD += MainMenu.dMovementCost;
                    dStep++;
                    using (System.IO.StreamWriter dOyuncusu = new System.IO.StreamWriter(@"..\\dOyuncusu.txt", true))
                        dOyuncusu.WriteLine("X:" + positionD[0] + " Y:" + positionD[1]);
                }
                else if (targetD[0] < positionD[0])
                {
                    positionD[0]--;
                    movement++;
                    dGoldAmount -= MainMenu.dMovementCost;
                    spentGoldD += MainMenu.dMovementCost;
                    dStep++;
                    using (System.IO.StreamWriter dOyuncusu = new System.IO.StreamWriter(@"..\\dOyuncusu.txt", true))
                        dOyuncusu.WriteLine("X:" + positionD[0] + " Y:" + positionD[1]);
                }
                objectD = positionD[0] + (mapWidth * positionD[1]);
                gamesSquares[objectD].BackColor = Color.Magenta;
                CheckSecretGold(positionD, objectD);
            }
            while (targetD[1] != positionD[1])
            {
                if (dGoldAmount <= 0)
                {
                    isDeadD = true;
                    break;
                }
                if (movement == 3 || turnOver == true)
                {
                    turnOver = true;
                    movement = 0;
                    break;
                }
                gamesSquares[objectD].UseVisualStyleBackColor = true;
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
                if (targetD[1] > positionD[1])
                {
                    positionD[1]++;
                    movement++;
                    dGoldAmount -= MainMenu.dMovementCost;
                    spentGoldD += MainMenu.dMovementCost;
                    dStep++;
                    using (System.IO.StreamWriter dOyuncusu = new System.IO.StreamWriter(@"..\\dOyuncusu.txt", true))
                        dOyuncusu.WriteLine("X:" + positionD[0] + " Y:" + positionD[1]);
                }
                if (targetD[1] < positionD[1])
                {
                    positionD[1]--;
                    movement++;
                    dGoldAmount -= MainMenu.dMovementCost;
                    spentGoldD += MainMenu.dMovementCost;
                    dStep++;
                    using (System.IO.StreamWriter dOyuncusu = new System.IO.StreamWriter(@"..\\dOyuncusu.txt", true))
                        dOyuncusu.WriteLine("X:" + positionD[0] + " Y:" + positionD[1]);
                }
                objectD = positionD[0] + (mapWidth * positionD[1]);
                gamesSquares[objectD].BackColor = Color.Magenta;
                CheckSecretGold(positionD, objectD);
            }
            if (targetD[0] == positionD[0] && targetD[1] == positionD[1])
            {
                targetD[0] = 0;
                targetD[1] = 0;
                dGoldAmount += goldMapMatris[positionD[1], positionD[0]];
                collectedGoldD += goldMapMatris[positionD[1], positionD[0]];
                dGoldText.Text = ("Altın: " + dGoldAmount);
                goldMapMatris[positionD[1], positionD[0]] = 0;
                gamesSquares[(positionD[1] * mapWidth) + positionD[0]].Text = "";
                gainMatris[positionD[1], positionD[0]] = 0;
            }
        }
        private void cSuperPower(int [] positions)
        {
            for (int t=0;t<MainMenu.cOpenSecretGold ;t++)
            {
                int distanceSecretGold = 0;
                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 0; j < mapWidth; j++)
                    {
                        secretGoldMatrisC[i, j] = 0;
                    }
                }
                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 0; j < mapWidth; j++)
                    {
                        if (goldMapMatris[i, j] == -1)
                        {
                            distanceSecretGold = (Math.Abs(i - positions[1]) + Math.Abs(j - positions[0]));
                            secretGoldMatrisC[i, j] = distanceSecretGold;
                        }
                    }
                }
                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 0; j < mapWidth; j++)
                    {
                        if (distanceSecretGold > secretGoldMatrisC[i, j] && secretGoldMatrisC[i, j] != 0)
                        {
                            distanceSecretGold = secretGoldMatrisC[i, j];
                        }
                    }
                }
                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 0; j < mapWidth; j++)
                    {
                        if (distanceSecretGold == secretGoldMatrisC[i, j])
                        {
                            coordinatesSecretGold[0] = j;
                            coordinatesSecretGold[1] = i;
                        }
                    }
                }
                int buttonNumber = ((coordinatesSecretGold[0]) + (coordinatesSecretGold[1] * mapWidth));
                CheckSecretGold(coordinatesSecretGold, buttonNumber);
            }     
        }
        private void CheckSecretGold(int[] coordinates, int objectPlayer)
        {
            countBlock = 0;
            if (goldMapMatris[coordinates[1], coordinates[0]] == -1)
            {
                int num3 = rnd.Next(100);
                if (num3 < 25)
                {
                    goldMapMatris[coordinates[1], coordinates[0]] = 5;
                    Debug.WriteLine("5");
                }
                else if (num3 < 50)
                {
                    goldMapMatris[coordinates[1], coordinates[0]] = 10;
                    Debug.WriteLine("10");
                }
                else if (num3 < 75)
                {
                    goldMapMatris[coordinates[1], coordinates[0]] = 15;
                    Debug.WriteLine("15");
                }
                else if (num3 < 100)
                {
                    goldMapMatris[coordinates[1], coordinates[0]] = 20;
                    Debug.WriteLine("20");
                }
                Debug.WriteLine("countblock:" + objectPlayer);    
                gamesSquares[objectPlayer].Text = "" + goldMapMatris[coordinates[1], coordinates[0]];
            }
        }
    }
}
