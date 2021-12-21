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
        int numObj = 0;
        Storage storage = new Storage(40);
        Graphics gr;
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
            private int x;
            private int y;
            private int rad;
            bool selected = false;
            private Pen pen;

            public CCircle(int x,int y)
            {
                this.x = x;
                this.y = y;
                this.rad = 40;
                selected = true;
            }

            public int getX()
            {
                return x;
            }
            public int getY()
            {
                return y;
            }
            public void setSelectedTrue()
            {
               selected = true;
            }
            public void setSelectedFalse()
            {
                selected = false;
            }

            public bool isSelected()
            {
                return selected;
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
                this.storage = new Item[size];
                for(int i = 0; i < size; i++)
                {
                    storage[i] = null;
                }
            }
            int getCount()
            {
                return size;
            }
            public void addObj(Item newObj,int q)
            {
                

            }

            public Item getObj(int k)
            {
                return storage[k];
            }

            public bool isObj(int k)
            {
                if (storage[k] != null)
                {
                    return true;
                }
                else return false;
            }

            public void removeObj(int k)
            {
                storage[k] = null;
            }

			public void setAllFalse()
            {
                for(int i = 0; i < size; i++)
                {
                    if (storage[i] != null)
                    {
                        storage[i] = null ;
                    }
                }
            }

           

		}

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
          

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            int xc = e.X;
            int yc = e.Y;
            gr = pictureBox1.CreateGraphics();
            Pen pen = new Pen(Color.Red, 2);
            gr.DrawEllipse(pen, xc, yc,20,20);
            

        }
    }
}
