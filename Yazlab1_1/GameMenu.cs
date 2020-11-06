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
    public partial class MainMenu : System.Windows.Forms.Form
    {
        public static int mapWidth;
        public static int mapHeight;
        public static int goldRate;
        public static int secretGoldRate;
        public static int startGold;
        public static int maxMovement;
        public static int aTargetCost;
        public static int bTargetCost;
        public static int cTargetCost;
        public static int dTargetCost;
        public static int aMovementCost;
        public static int bMovementCost;
        public static int cMovementCost;
        public static int dMovementCost;
        public static int cOpenSecretGold;
        public MainMenu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            if(gameMapWidthTextBox.Text == "" || gameMapHeightTextBox.Text==""  || goldRateTextBox.Text == "" || secretGoldRateTextBox.Text == "" || startGoldTextBox.Text == "" || maxMoveTextBox.Text == "" || ATargetCostTextBox.Text == "" || BTargetCostTextBox.Text == "" || CTargetCostTextBox.Text == "" || DTargetCostTextBox.Text == "" || AMoveCostTextBox.Text == "" || BMoveCostTextBox.Text == "" || CMoveCostTextBox.Text == "" || DMoveCostTextBox.Text == "" || COpenSecretGoldTextBox.Text == "")
            {
                MessageBox.Show("Bütün Boşlukları Doldurunuz");
            }
            else
            {
                mapWidth = int.Parse(gameMapWidthTextBox.Text);
                mapHeight = int.Parse(gameMapHeightTextBox.Text);
                goldRate = int.Parse(goldRateTextBox.Text);
                secretGoldRate = int.Parse(secretGoldRateTextBox.Text);
                startGold = int.Parse(startGoldTextBox.Text);
                maxMovement = int.Parse(maxMoveTextBox.Text);
                aTargetCost = int.Parse(ATargetCostTextBox.Text);
                bTargetCost = int.Parse(BTargetCostTextBox.Text);
                cTargetCost = int.Parse(CTargetCostTextBox.Text);
                dTargetCost = int.Parse(DTargetCostTextBox.Text);
                aMovementCost = int.Parse(AMoveCostTextBox.Text);
                bMovementCost = int.Parse(BMoveCostTextBox.Text);
                cMovementCost = int.Parse(CMoveCostTextBox.Text);
                dMovementCost = int.Parse(DMoveCostTextBox.Text);
                cOpenSecretGold = int.Parse(COpenSecretGoldTextBox.Text);
                this.Hide();
                Game GameScreen = new Game();
                GameScreen.ShowDialog();    
                this.Show();
            }
        }   
    }
}
