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
        Storage storage = new Storage();
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
            public bool selected = false;
            public int numofObj=0;
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
            public Item[] storage;
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
            public void addObj(Item newObj)
            {
                Array.Resize(ref storage, size + 1);
                storage[size] = newObj;
                for (int i = 0; i < storage.Length; i++)
                {
                        storage[i].selected = false;
                }
                storage[size].selected = true;



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
               if(size>1 && k < size)
                {
                    Item[] storage2 = new Item[size - k];
                    for (int i = k + 1,j=0; i < size; i++,j++)
                    {
                        storage2[j] = storage[i];
                    }
                    for(int i = k,j=0; i < size - 1; i++,j++)
                    {
                        storage[i] = storage2[j];
                    }
                  
                    Array.Resize(ref storage,storage.Length -1);


                }
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
