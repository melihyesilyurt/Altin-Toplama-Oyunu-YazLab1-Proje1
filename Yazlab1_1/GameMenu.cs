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
    public partial class Form1 : System.Windows.Forms.Form
    {
        private int mapWidth;
        private int mapHeight;
        private int goldRate;
        private int secretGoldRate;
        private int startGold;
        private int maxMovement;
        private int aTargetCost;
        private int bTargetCost;
        private int cTargetCost;
        private int dTargetCost;
        private int aMovementCost;
        private int bMovementCost;
        private int cMovementCost;
        private int dMovementCost;
        private int cOpenSecretGold;
        public Form1()
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
