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

        Storage storage = new Storage(0);
        int numberofobjects = 0;
        public Graphics gr;
        public bool prevSel=false;
        int coun=0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        class Item
        {

            protected int x;
            protected int y;
            public bool selected = false;
            public bool coloured = false;
            public int rad = 20;
            public int numObj = 0;


            public void setCoords(int x_, int y_)
            {
                this.x = x_;
                this.y = y_;
            }

            public bool CheckClickOnObject(int x1, int y1)
            {
                
                if (((x1 - rad) < x) && (x1 +rad > x) && ((y1 - rad) < y) && (y1+rad > y))
                    return true;
                else
                    return false;
            }

            public virtual void printFigureRed()
            {
                Console.WriteLine("figure");
            }
            public virtual void printFigureBlack()
            {
                Console.WriteLine("figure");
            }


            public bool isSelected()
            {
                return selected;
            }


        }

        class CCircle : Item
        {

            public CCircle()
            {
                this.x = 0;
                this.y = 0;
                this.rad = 20;
                selected = true;
            }
            public CCircle(int x, int y)
            {
                this.x = x;
                this.y = y;
                this.rad = 20;
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

            public override void printFigureRed()
            {

                Pen myPen = new Pen(Color.Red);
                Graphics formGraphics;
                formGraphics = Form.ActiveForm.CreateGraphics();

                Rectangle ellipse = new Rectangle(x-rad, y-rad, rad*2, rad*2);
                formGraphics.DrawEllipse(myPen, ellipse);
                myPen.Dispose();
                formGraphics.Dispose();
            }
            public override void printFigureBlack()
            {
                Pen myPen = new Pen(Color.Black);
                Graphics formGraphics;
                formGraphics = Form.ActiveForm.CreateGraphics();

                Rectangle ellipse = new Rectangle(x-rad, y-rad, rad*2, rad*2);
               
                formGraphics.DrawEllipse(myPen, ellipse);
                myPen.Dispose();
                formGraphics.Dispose();
            }


        }





        class Storage
        {
            private int size;
            Item[] storage;
            public Storage()
            {
                size = 0;
            }
            public Storage(int size)
            {
                this.size = size;
                this.storage = new Item[size];
                for (int i = 0; i < size; i++)
                {
                    storage[i] = null;
                }
            }
            public int getCount()
            {
                return size;
            }
            public void addObj(Item newObj)
            {
                Array.Resize(ref storage, storage.Length + 1);
                storage[size] = newObj;
                for (int i = 0; i < storage.Length; i++)
                {
                    storage[i].selected = false;
                }
                storage[size].selected = true;
                size++;



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
                if (size > 0 && k < size)
                {
                    Item[] storage2 = new Item[size - k-1];
                    for (int i = k + 1, j = 0; i < size; i++, j++)
                    {
                        storage2[j] = storage[i];
                    }
                    for (int i = k, j = 0; i < size - 1; i++, j++)
                    {
                        storage[i] = storage2[j];
                    }
                    size--;
                    Array.Resize(ref storage, size);
                    

                }
            }


          



        }



        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                for(int i = 0; i < storage.getCount(); i++)
                { 

                    if (storage.getObj(i).selected)
                    {
                        storage.removeObj(i);
                        
                        prevSel = true;
                        numberofobjects--;
                        coun++;
                    }
                    else if (!storage.getObj(i).selected) prevSel = false;
                    if (prevSel && i!=storage.getCount()) i--;
                    Invalidate();
                }
                
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < storage.getCount(); i++)
            {

                if (storage.getObj(i).selected)
                {
                    storage.getObj(i).printFigureRed();
                }
                else storage.getObj(i).printFigureBlack();


            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

            for (int i = 0; i < storage.getCount(); i++)
            {

                if (storage.getObj(i).CheckClickOnObject(e.X, e.Y))
                {
                    return;
                }

            }
            storage.addObj(new CCircle());
            storage.getObj(numberofobjects).setCoords(e.X, e.Y);
            numberofobjects++;
            Invalidate();
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < storage.getCount(); i++)
            {
                if (e.Button == MouseButtons.Left && Control.ModifierKeys == Keys.Control)
                {
                    if (storage.getObj(i).CheckClickOnObject(e.X, e.Y))
                    {
                        storage.getObj(i).selected = true;
                    }
                    Invalidate();
                }
                else if (e.Button == MouseButtons.Left)
                {
                    if (storage.getObj(i).CheckClickOnObject(e.X, e.Y))
                    {
                        storage.getObj(i).selected = true;
                    }
                    else storage.getObj(i).selected = false;
                    Invalidate();
                }
            }
        }
    }
}