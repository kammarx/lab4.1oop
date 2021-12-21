using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4._1oop
{
    public partial class Form1 : Form
    {
        int coun = 0;
        Storage storage = new Storage(40);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
         
        }

        class Item
        {

        }

        class CCircle: Item
        {
            private int x, y;
            public bool ispicked = false;
            public int rad = 10;

            public CCircle(int x,int y)
            {
                this.x = x;
                this.y = y;
                ispicked = true;
            }




        }





		class Storage
		{
            private int size;
            private Item[] storage;
            public Storage()
            {
                size = 0;
            }
            public Storage(int size)
            {
                this.size = size;
                storage = new Item[size];
            }

            public void addObj(int k,Item newObj)
            {
                storage[k] = newObj;

            }
			

		}
        


        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
          
        }
    }
}
