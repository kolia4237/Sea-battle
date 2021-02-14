using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp18
{
    public partial class Form1 : Form
    {
        public const int mapSize = 10;
        public int cellSize = 30;
        public string alphabet = "ABCDEFGHIJ";

        public int[,] myMap = new int[mapSize, mapSize];
        public int[,] enemyMap = new int[mapSize, mapSize];

        public Button[,] myButtons = new Button[mapSize, mapSize];
        public Button[,] enemyButtons = new Button[mapSize, mapSize];

        public bool isPlaying = false;

        public Comp comp;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Игра -------------------------------------------- Морской бой ------------------------";
            Init(); MessageBox.Show("--------------Компьютерная игра морской бой !-----------\n----------------------------------------------------------------------------\nправила игры с левой стороны находится Ваше поле на котором нужно раставить корабли от 1-й до 6-ти палуб после окончания растановки кораблей необходимо нажать на кнопку (начало-игры) игра происходит с компьютером с правой стороны находится поле Вашего противника наводите курсором на этом поле по координатам противника и играйте \n\n                        Желаем Вам победить!");
        }

        public void Init() //инициализируем
        {
            isPlaying = false;
            CreativeMapse();
            comp = new Comp(enemyMap, myMap, enemyButtons, myButtons);
            enemyMap = comp.ConfigureShips();
        }


        //игрок
        public void CreativeMapse()
        {
            this.Width = mapSize * 2 * cellSize + 50;
            this.Height = (mapSize + 5) * cellSize + 40;
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    myMap[i, j] = 0;

                    Button button = new Button();
                    button.Location = new Point(j * cellSize, i * cellSize);
                    button.Size = new Size(cellSize, cellSize);
                    button.BackColor = Color.Chocolate;
                    if (j == 0 || i == 0)
                    {
                        button.BackColor = Color.Gray;
                        if (i == 0 && j > 0)
                            button.Text = alphabet[j - 1].ToString();
                        if (j == 0 && i > 0)
                            button.Text = i.ToString();
                    }
                    else
                    {
                        button.Click += new EventHandler(Configureishen);
                    }
                    myButtons[i, j] = button;
                    this.Controls.Add(button);
                }
            }
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    myMap[i, j] = 0;
                    enemyMap[i, j] = 0;
                    //компьютер
                    Button button = new Button();
                    button.Location = new Point(320 + j * cellSize, i * cellSize);
                    button.Size = new Size(cellSize, cellSize);
                    button.BackColor = Color.Green;
                    if (j == 0 || i == 0)
                    {
                        button.BackColor = Color.Gray;
                        if (i == 0 && j > 0)
                            button.Text = alphabet[j - 1].ToString();
                        if (j == 0 && i > 0)
                            button.Text = i.ToString();
                    }
                    else
                    {
                        button.Click += new EventHandler(PlayerGeim);
                    }
                    enemyButtons[i, j] = button;
                    this.Controls.Add(button);
                }
            }
            Label map1 = new Label();
            map1.Text = "Игровое-поле-игрока";
            map1.Location = new Point(mapSize * cellSize / 5, mapSize * cellSize + 12);
            map1.Size = new Size(200, 20);
            this.Controls.Add(map1);

            Label map2 = new Label();
            map2.Text = "Игровое-поле-противника";
            map2.Location = new Point(300 + mapSize * cellSize / 4, mapSize * cellSize + 12);
            map2.Size = new Size(200, 20);
            this.Controls.Add(map2);

            Button startButton = new Button();
            startButton.Text = "Начать-игру";
            startButton.Click += new EventHandler(Start);
            startButton.Location = new Point(250, mapSize * cellSize + 50);
            startButton.Size = new Size(120, 25);
            this.Controls.Add(startButton);
        }

        public void Start(object sender, EventArgs e)
        {
            isPlaying = true;

        }
    }
}
