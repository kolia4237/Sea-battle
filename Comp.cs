using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
public class Comp   // комп. управление в игре 
{
    // компьютер
    public int[,] myMap = new int[Form1.mapSize, Form1.mapSize];
    // игрок
    public int[,] enemyMap = new int[Form1.mapSize, Form1.mapSize];

    public Button[,] myButtons = new Button[Form1.mapSize, Form1.mapSize];
    public Button[,] enemyButtons = new Button[Form1.mapSize, Form1.mapSize];

    public Comp(int[,] myMap, int[,] enemyMap, Button[,] myButtons, Button[,] enemyButtons)
    {
        this.myMap = myMap;
        this.enemyMap = enemyMap;
        this.enemyButtons = enemyButtons;
        this.myButtons = myButtons;
    }

    public bool IsInsideMap(int i, int j)
    {
        if (i < 0 || j < 0 || i >= Form1.mapSize || j >= Form1.mapSize)
        {
            return false;
        }
        return true;
    }

    public bool IsEmpty(int i, int j, int length)
    {
        bool isEmpty = true;

        for (int k = j; k < j + length; k++)
        {
            if (myMap[i, k] != 0)
            {
                isEmpty = false;

                break;
            }
        }

        return isEmpty;

    }
}
