﻿using System;
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
        private int[] coordinatesSecretGold = { 0, 0 };
        private bool isDeadA = false;
        private bool isDeadB = false;
        private bool isDeadC = false;
        private bool isDeadD = false;
        private void button1_Click(object sender, EventArgs e)
        {
            tourManagement = 3;
            if (tourManagement == 1)
            {
                PlayA();
                aGoldText.Text = ("Altın: " + aGoldAmount);
            }
            else if (tourManagement == 2)
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
        private int movement = 0;
        private int objectA = 0;
        private int objectB = MainMenu.mapWidth - 1;

        private int objectC = (MainMenu.mapWidth * MainMenu.mapHeight) - MainMenu.mapWidth;
        private int objectD = ((MainMenu.mapWidth * MainMenu.mapHeight) - 1);


        private void PlayA()
        {
            if (targetA[0] == 0 && targetA[1] == 0)
            {
                aGoldAmount -= MainMenu.aTargetCost;
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
            while (targetA[0] != positionA[0])
            {
                if (movement == 3)
                {
                    movement = 0;
                    break;
                }
                gamesSquares[objectA].UseVisualStyleBackColor = true;
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
                    if ((positionA[0] + 1 == positionB[0] || positionA[1] == positionB[1]) && (positionA[0] + 1 == positionC[0] || positionA[1] == positionC[1]) && (positionA[0] + 1 == positionD[0] || positionA[1] == positionD[1]))
                    {
                        Debug.WriteLine("Kaza önlendi");
                    }
                    else
                    {
                        positionA[0]++;
                        movement++;
                        aGoldAmount -= MainMenu.aMovementCost;
                    }
                }
                else if (targetA[0] < positionA[0])
                {
                    if ((positionA[0] - 1 == positionB[0] || positionA[1] == positionB[1]) && (positionA[0] - 1 == positionC[0] || positionA[1] == positionC[1]) && (positionA[0] - 1 == positionD[0] || positionA[1] == positionD[1]))
                    {
                        Debug.WriteLine("Kaza önlendi");
                    }
                    else
                    {
                        positionA[0]--;
                        movement++;
                        aGoldAmount -= MainMenu.aMovementCost;
                    }
                }
                objectA = positionA[0] + (mapWidth * positionA[1]);
                gamesSquares[objectA].BackColor = Color.Blue;
                CheckSecretGold(positionA, objectA);
            }
            while (targetA[1] != positionA[1])
            {
                if (movement == 3)
                {
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
                    if ((positionA[0] == positionB[0] || positionA[1] + 1 == positionB[1]) && (positionA[0] == positionC[0] || positionA[1] + 1 == positionC[1]) && (positionA[0] == positionD[0] || positionA[1] + 1 == positionD[1]))
                    {
                        Debug.WriteLine("Kaza önlendi");
                    }
                    else
                    {
                        positionA[1]++;
                        movement++;
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
                        aGoldAmount -= MainMenu.aMovementCost;
                    }
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
                aGoldText.Text = ("Altın: " + aGoldAmount);
                goldMapMatris[positionA[1], positionA[0]] = 0;
                gamesSquares[(positionA[1] * mapWidth) + positionA[0]].Text = "";
                distanceMatris[positionA[1], positionA[0]] = 0;
            }
        }
        int cost;
        private void PlayB()
        {
            if (targetB[0] == 0 && targetB[1] == 0)
            {
                bGoldAmount -= MainMenu.bTargetCost;
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
                            gainMatris[i, j] = cost;
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
                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 0; j < mapWidth; j++)
                    {
                        Debug.Write(" " + gainMatris[i, j]);
                    }
                    Debug.WriteLine("");
                }
                Debug.WriteLine("Hedef Belirlendi X:" + targetB[0] + " Y:" + targetB[1]);
            }
            while (targetB[0] != positionB[0])
            {
                if (movement == 3)
                {
                    movement = 0;
                    break;
                }
                gamesSquares[objectB].UseVisualStyleBackColor = true;
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
                    if ((positionB[0] + 1 == positionA[0] || positionB[1] == positionA[1]) && (positionB[0] + 1 == positionC[0] || positionB[1] == positionC[1]) && (positionB[0] + 1 == positionD[0] || positionB[1] == positionD[1]))
                    {
                        Debug.WriteLine("Kaza önlendi");
                    }
                    else
                    {
                        positionB[0]++;
                        movement++;
                        bGoldAmount -= MainMenu.bMovementCost;
                    }
                }
                else if (targetB[0] < positionB[0])
                {
                    if ((positionB[0] - 1 == positionA[0] || positionB[1] == positionA[1]) && (positionB[0] - 1 == positionC[0] || positionB[1] == positionC[1]) && (positionB[0] - 1 == positionD[0] || positionB[1] == positionD[1]))
                    {
                        Debug.WriteLine("Kaza önlendi");
                    }
                    else
                    {
                        positionB[0]--;
                        movement++;
                        bGoldAmount -= MainMenu.bMovementCost;
                    }
                }
                objectB = positionB[0] + (mapWidth * positionB[1]);
                gamesSquares[objectB].BackColor = Color.Red;
                CheckSecretGold(positionB, objectB);
            }
            while (targetB[1] != positionB[1])
            {
                if (movement == 3)
                {
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
                    if ((positionB[0] == positionA[0] || positionB[1] + 1 == positionA[1]) && (positionB[0] == positionC[0] || positionB[1] + 1 == positionC[1]) && (positionB[0] == positionD[0] || positionB[1] + 1 == positionD[1]))
                    {
                        Debug.WriteLine("Kaza önlendi");
                    }
                    else
                    {
                        positionB[1]++;
                        movement++;
                        bGoldAmount -= MainMenu.bMovementCost;
                    }
                }
                if (targetB[1] < positionB[1])
                {
                    if ((positionB[0] == positionA[0] || positionB[1] - 1 == positionA[1]) && (positionB[0] == positionC[0] || positionB[1] - 1 == positionC[1]) && (positionB[0] == positionD[0] || positionB[1] - 1 == positionD[1]))
                    {
                        Debug.WriteLine("Kaza önlendi");
                    }
                    else
                    {
                        positionB[1]--;
                        movement++;
                        bGoldAmount -= MainMenu.bMovementCost;
                    }
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
                bGoldText.Text = ("Altın: " + bGoldAmount);
                goldMapMatris[positionB[1], positionB[0]] = 0;
                gamesSquares[(positionB[1] * mapWidth) + positionB[0]].Text = "";
                gainMatris[positionB[1], positionB[0]] = 0;
            }
        }
        private void PlayC()
        {
            cSuperPower(positionC);
            if (targetC[0] == 0 && targetC[1] == 0)
            {
                cGoldAmount -= MainMenu.cTargetCost;
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
                            gainMatris[i, j] = cost;
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
            while (targetC[0] != positionC[0])
            {
                if (movement == 3)
                {
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
                    if ((positionC[0] + 1 == positionA[0] || positionC[1] == positionA[1]) && (positionC[0] + 1 == positionB[0] || positionC[1] == positionB[1]) && (positionC[0] + 1 == positionD[0] || positionC[1] == positionD[1]))
                    {
                        Debug.WriteLine("Kaza önlendi");
                    }
                    else
                    {
                        positionC[0]++;
                        movement++;
                        cGoldAmount -= MainMenu.cMovementCost;
                    }
                }
                else if (targetC[0] < positionC[0])
                {
                    if ((positionC[0] - 1 == positionA[0] || positionC[1] == positionA[1]) && (positionC[0] - 1 == positionB[0] || positionC[1] == positionB[1]) && (positionC[0] - 1 == positionD[0] || positionC[1] == positionD[1]))
                    {
                        Debug.WriteLine("Kaza önlendi");
                    }
                    else
                    {
                        positionC[0]--;
                        movement++;
                        cGoldAmount -= MainMenu.cMovementCost;
                    }
                }
                objectC = positionC[0] + (mapWidth * positionC[1]);
                gamesSquares[objectC].BackColor = Color.Green;
                CheckSecretGold(positionC, objectC);
            }
            while (targetC[1] != positionC[1])
            {
                if (movement == 3)
                {
                    movement = 0;
                    break;
                }
                gamesSquares[objectC].UseVisualStyleBackColor = true;
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
                    if ((positionC[0] == positionA[0] || positionC[1] + 1 == positionA[1]) && (positionC[0] == positionB[0] || positionC[1] + 1 == positionB[1]) && (positionC[0] == positionD[0] || positionC[1] + 1 == positionD[1]))
                    {
                        Debug.WriteLine("Kaza önlendi");
                    }
                    else
                    {
                        positionC[1]++;
                        movement++;
                        cGoldAmount -= MainMenu.cMovementCost;
                    }
                }
                if (targetC[1] < positionC[1])
                {
                    if ((positionC[0] == positionA[0] || positionC[1] - 1 == positionA[1]) && (positionC[0] == positionB[0] || positionC[1] - 1 == positionB[1]) && (positionC[0] == positionD[0] || positionC[1] - 1 == positionD[1]))
                    {
                        Debug.WriteLine("Kaza önlendi");
                    }
                    else
                    {
                        positionC[1]--;
                        movement++;
                        cGoldAmount -= MainMenu.cMovementCost;
                    }
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
                cGoldText.Text = ("Altın: " + cGoldAmount);
                goldMapMatris[positionC[1], positionC[0]] = 0;
                gamesSquares[(positionC[1] * mapWidth) + positionC[0]].Text = "";
                gainMatris[positionC[1], positionC[0]] = 0;
            }
        }
        private void PlayD()
        {

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
