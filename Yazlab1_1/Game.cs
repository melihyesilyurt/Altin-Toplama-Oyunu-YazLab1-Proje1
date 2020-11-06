using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yazlab1_1
{
    public partial class Game : Form
    {
        List<Button> gamesSquares = new List<Button>();
        private int aGoldAmount;
        private int bGoldAmount;
        private int cGoldAmount;
        private int dGoldAmount;
        private int goldCount;
        private int secretGoldCount;
        private int xPosition = 380;
        private int yPosition = 60;
        private int btnName = 0;
        int rowCount = 0;
        public Game()
        {
            InitializeComponent();
        }

        private void Game_Load(object sender, EventArgs e)
        {
            aGoldAmount = MainMenu.startGold;
            bGoldAmount = MainMenu.startGold;
            cGoldAmount = MainMenu.startGold;
            dGoldAmount = MainMenu.startGold;
            aGoldText.Text = ("Altın: " +aGoldAmount);
            bGoldText.Text = ("Altın: " + bGoldAmount);
            cGoldText.Text = ("Altın: " + cGoldAmount);
            dGoldText.Text = ("Altın: " + dGoldAmount);
            goldCount = (MainMenu.mapWidth * MainMenu.mapHeight * MainMenu.goldRate) / 100;
            secretGoldCount = (goldCount * MainMenu.secretGoldRate) / 100;
            goldCount -= secretGoldCount;
               for(int i=0;i< MainMenu.mapHeight; i++)
               {
                   for(int j=0;j< MainMenu.mapWidth; j++)
                   {
                    gamesSquares.Add(createButton(btnName, xPosition, yPosition, gamesSquares));
                    addNewButtons(gamesSquares, this);
                    xPosition += 30;
                    
                }
                   xPosition =380;
                   yPosition += 30;
               }
            gamesSquares[0].BackColor = Color.Blue;
            gamesSquares[MainMenu.mapWidth-1].BackColor = Color.Red;
            gamesSquares[(MainMenu.mapWidth * MainMenu.mapHeight)-MainMenu.mapWidth].BackColor = Color.Green;
            gamesSquares[(MainMenu.mapWidth*MainMenu.mapHeight)-1].BackColor = Color.Magenta;

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
        private void button1_Click(object sender, EventArgs e)
        {
           // MessageBox.Show("SecretGold"+ secretGoldCount+"Gold"+goldCount);
        }
    }
}
