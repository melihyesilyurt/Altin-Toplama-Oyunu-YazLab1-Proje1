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
        int distance = 0;
        private int mapWidth = MainMenu.mapWidth;
        private int mapHeight = MainMenu.mapHeight;
        List<Button> gamesSquares = new List<Button>();
        private int[] positionA = { 0, 0 };
        private int[] positionB = { 0, MainMenu.mapWidth - 1 };
        private int[] positionC = { MainMenu.mapHeight - 1, 0 };
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
        List<string> map = new List<string>();
        string[,] mapMatris = new string[MainMenu.mapHeight, MainMenu.mapWidth];
        int[,] distanceMatris = new int[MainMenu.mapHeight, MainMenu.mapWidth];
        string satirad = "";
        //Game t = new Game();
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
                //Debug.WriteLine("num1: "+num1+ " num2:"+num2);            
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
            ////////////////////////////////////////////////////////////////////////////
          
           

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
        private void button1_Click(object sender, EventArgs e)
        {
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
        private int objectA;
        private void PlayA()
        {
            if (targetA[0] == 0 && targetA[1] == 0)
            {
                //targetA[0] = 3;
                //targetA[1] = 2;
                aGoldAmount -= MainMenu.aTargetCost;
                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        mapMatris[i, j] = "0";
                        distanceMatris[i, j] = 0;
                    }
                }
                mapMatris[positionA[1], positionA[0]] = "A";
                for (int i = 0; i < mapHeight; i++)
                {
                    for (int j = 1; j < mapWidth; j++)
                    {
                        if (goldMapMatris[i, j] != 0 && goldMapMatris[i, j] != -1)
                        {
                            mapMatris[i, j] = "B";
                            string satirad = "";
                            for (int k = 0; i < 20; i++)
                            {
                                for (int l = 0; j < 20; j++)
                                {
                                    satirad += string.Join("", mapMatris[k, l]);
                                }
                                // Console.Write( satirad + "\n");
                                map.Add(satirad);
                                satirad = "";
                            }

                            var start = new Tile();

                            start.Y = map.FindIndex(x => x.Contains("A"));
                            start.X = map[start.Y].IndexOf("A");


                            var finish = new Tile();
                            finish.Y = map.FindIndex(x => x.Contains("B"));
                            finish.X = map[finish.Y].IndexOf("B");

                            start.SetDistance(finish.X, finish.Y);

                            var activeTiles = new List<Tile>();
                            activeTiles.Add(start);
                            var visitedTiles = new List<Tile>();

                            while (activeTiles.Any())
                            {
                                var checkTile = activeTiles.OrderBy(x => x.CostDistance).First();

                                if (checkTile.X == finish.X && checkTile.Y == finish.Y)
                                {
                                    //We found the destination and we can be sure (Because the the OrderBy above)
                                    //That it's the most low cost option. 
                                    var tile = checkTile;
                                    Console.WriteLine("Retracing steps backwards...");

                                    while (true)
                                    {
                                        //Console.WriteLine($"{tile.X} : {tile.Y}");
                                        Console.WriteLine("X:" + tile.X + " Y:" + tile.Y);
                                        if (distance < tile.X + tile.Y)
                                        {
                                            distance = tile.X + tile.Y;
                                            distanceMatris[i, j] = distance;
                                        }

                                        if (map[tile.Y][tile.X] == ' ')
                                        {
                                            var newMapRow = map[tile.Y].ToCharArray();
                                            newMapRow[tile.X] = '*';
                                            map[tile.Y] = new string(newMapRow);
                                        }
                                        tile = tile.Parent;
                                        if (tile == null)
                                        {
                                            Console.WriteLine("Map looks like :");
                                            map.ForEach(x => Console.WriteLine(x));
                                            Console.WriteLine("Done!");
                                            Console.WriteLine("Distance: " + distance);
                                            return;
                                        }
                                    }

                                }

                                visitedTiles.Add(checkTile);
                                activeTiles.Remove(checkTile);

                                var walkableTiles = GetWalkableTiles(map, checkTile, finish);

                                foreach (var walkableTile in walkableTiles)
                                {
                                    //We have already visited this tile so we don't need to do so again!
                                    if (visitedTiles.Any(x => x.X == walkableTile.X && x.Y == walkableTile.Y))
                                        continue;

                                    //It's already in the active list, but that's OK, maybe this new tile has a better value (e.g. We might zigzag earlier but this is now straighter). 
                                    if (activeTiles.Any(x => x.X == walkableTile.X && x.Y == walkableTile.Y))
                                    {
                                        var existingTile = activeTiles.First(x => x.X == walkableTile.X && x.Y == walkableTile.Y);
                                        if (existingTile.CostDistance > checkTile.CostDistance)
                                        {
                                            activeTiles.Remove(existingTile);
                                            activeTiles.Add(walkableTile);
                                        }
                                    }
                                    else
                                    {
                                        //We've never seen this tile before so add it to the list. 
                                        activeTiles.Add(walkableTile);
                                    }
                                }
                            }

                            Console.WriteLine("No Path Found!");


                            ////////////////////////////////////////////////////////////////////////
                        }
                    }
                }
                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        if(distance> distanceMatris[i, j] && distanceMatris[i, j]!= 0)
                        {
                            distance = distanceMatris[i, j];
                        }
                    }
                }
                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        if (distance== distanceMatris[i,j])
                        {
                            targetA[0] = j;
                            targetA[1] = i;
                        }
                    }
                }











                ////////////////////////////////////////////////////////////////
            }
            while (targetA[0] != positionA[0])
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
        private void CheckSecretGold(int[] coordinates, int objectA)
        {
            countBlock = 0;
           // MessageBox.Show("gold " + goldMapMatris[coordinates[0], coordinates[1]]);
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
                Debug.WriteLine("countblock:" + objectA);
                gamesSquares[objectA].Text = "" + goldMapMatris[coordinates[1], coordinates[0]];
            }
        }
        private static List<Tile> GetWalkableTiles(List<string> map, Tile currentTile, Tile targetTile)
        {
            var possibleTiles = new List<Tile>()
            {
                new Tile { X = currentTile.X, Y = currentTile.Y - 1, Parent = currentTile, Cost = currentTile.Cost + 1 },
                new Tile { X = currentTile.X, Y = currentTile.Y + 1, Parent = currentTile, Cost = currentTile.Cost + 1},
                new Tile { X = currentTile.X - 1, Y = currentTile.Y, Parent = currentTile, Cost = currentTile.Cost + 1 },
                new Tile { X = currentTile.X + 1, Y = currentTile.Y, Parent = currentTile, Cost = currentTile.Cost + 1 },
            };

            possibleTiles.ForEach(tile => tile.SetDistance(targetTile.X, targetTile.Y));

            var maxX = map.First().Length - 1;
            var maxY = map.Count - 1;

            return possibleTiles
                    .Where(tile => tile.X >= 0 && tile.X <= maxX)
                    .Where(tile => tile.Y >= 0 && tile.Y <= maxY)
                    .Where(tile => map[tile.Y][tile.X] == '0' || map[tile.Y][tile.X] == 'B')
                    .ToList();
        }
    }
    class Tile
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Cost { get; set; }
        public int Distance { get; set; }
        public int CostDistance => Cost + Distance;
        public Tile Parent { get; set; }

        //The distance is essentially the estimated distance, ignoring walls to our target. 
        //So how many tiles left and right, up and down, ignoring walls, to get there. 
        public void SetDistance(int targetX, int targetY)
        {
            this.Distance = Math.Abs(targetX - X) + Math.Abs(targetY - Y);
        }
    }
}
