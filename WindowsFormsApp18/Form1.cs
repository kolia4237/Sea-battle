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
    }
}
