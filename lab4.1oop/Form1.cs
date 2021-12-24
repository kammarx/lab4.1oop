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
        int num = 0;
        Storage storage = new Storage(0);
       public Graphics gr;
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

            protected int x;
            protected int y;
            public bool selected = false;
            public bool coloured = false;
            public int numofObj=0;
            private int size = 30;
            public bool CheckClickOnObject(int x, int y)
            {
                if (((x - size) < x) && (x + size > x) && ((y - size) < y) && (y + size > y))
                    return true;
                else
                    return false;
            }
            public void setCoords(int x_, int y_)
            {
                this.x = x_;
                this.y = y_;
            }
            public virtual void printFigureRed(Graphics gr)
            {
                Console.WriteLine("figure");
            }
            public virtual void printFigureBlack(Graphics gr)
            {
                Console.WriteLine("figure");
            }


            public bool isSelected()
            {
                return selected;
            }

        }

        class CCircle: Item
        {
            
            private int rad;
          
            private Pen pen;
            public CCircle()
            {
                this.x = 0;
                this.y = 0;
                this.rad = 0;
            }
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

            public override void printFigureRed(Graphics g)
            {
                    pen = new Pen(Color.Red, 3);
                
                g.DrawEllipse(pen, x, y, rad + rad, rad + rad);
            }
            public override void printFigureBlack(Graphics g)
            {
                pen = new Pen(Color.Black, 3);

                g.DrawEllipse(pen, x, y, rad + rad, rad + rad);
            }


            public void setSelectedTrue()
            {
               selected = true;
            }
            public void setSelectedFalse()
            {
                selected = false;
            }

    


        }





		class Storage
		{
            private int size;
            public Item[] storage;
            //public Storage()
            //{
            //    size = 0;
            //}
            public Storage(int size)
            {
                this.size = size;
                this.storage = new Item[size];
                for(int i = 0; i < size; i++)
                {
                    storage[i] = null;
                }
            }
            public int getCount()
            {
                return size;
            }
            public void addObj(Item newObj,int num)
            {
                Array.Resize(ref storage, size + 1);
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
            public void printFigures(Graphics gr)
            {
                for(int i = 0; i < size; i++)
                {
                    storage[i].printFigureRed(gr);
                }
            }

            public void deleteSelectedObj()
            {
                for (int i = 0; i < size; i++) {
                    if (storage[i].isSelected())
                    {
                        removeObj(i);
                    }
                }
            }

           

		}

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < storage.getCount(); i++)
            {
                
                    if (storage.getObj(i).CheckClickOnObject(e.X, e.Y))
 
          
                storage.addObj(new CCircle(),num);
            storage.getObj(num).setCoords(e.X, e.Y);
            num++;
            Invalidate();

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
           

            //for (int i = 0; i < storage.getCount(); i++)
            //{

            //    if (Control.ModifierKeys == Keys.Control && e.Button == MouseButtons.Left)
            //    {
            //        if (storage.getObj(i).CheckClickOnObject(e.X, e.Y))
            //        {
            //            storage.getObj(i).selected = true;
            //            Invalidate();
            //        }
            //    }
            //    else if (e.Button == System.Windows.Forms.MouseButtons.Left)
            //    {

            //        if (storage.getObj(i).CheckClickOnObject(e.X, e.Y))
            //            storage.getObj(i).selected = true;
            //        else
            //            storage.getObj(i).selected= false;
            //        Invalidate();

            //    }
            //}


        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < storage.getCount(); i++)
            {
                if (storage.isObj(i)){
                    if (storage.getObj(i).selected)
                        storage.getObj(i).printFigureRed(e.Graphics);
                    else storage.getObj(i).printFigureBlack(e.Graphics);

                } 
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //if(e.KeyData == Keys.Delete)
            //{
            //    storage.deleteSelectedObj();
            //    gr.Clear(Color.Gray);
            //    storage.printFigures(gr);
                
            //}
        }
    }
}
