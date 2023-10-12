using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ArrayList : List
    {
        private int cap;
        private int SIZE;
        private object[] data;

        public ArrayList(int cap)
        {
            this.cap = cap;
            data = new object[cap];
        }
        public void add(int index, object e)
        {
            ensureCapacity();
            for (int i = SIZE; i > index; i--)
                data[i] = data[i - 1];
            data[index] = e;
            SIZE++;
        }

        public void add(object e)
        {
            add(SIZE, e);
        }

        public bool contains(object e)
        {
            return indexOf(e) != -1;
        }

        public object get(int index)
        {
            return data[index];
        }

        public int indexOf(object e) // อะไรที่ใช้ medthod ซ้ำ นำออกมาเขียน private แยกไว้
        {
            for (int i = 0; i < SIZE; i++)
                if (e.Equals(data[i]))
                    return i;
            return -1;
        }

        public bool isEmpty()
        {
            return SIZE == 0;
        }

        public void remove(int index)
        {
            if (index >= SIZE) return; //ดักค่าที่นำเข้ามาแปลกๆ
            for (int i = index + 1; i < SIZE; i++)
                data[i - 1] = data[i];
            data[--SIZE] = null; //ไม่ทำอะไรเลย
        }

        public void remove(object e)
        {
            int i = indexOf(e);
            if (i > -1)
                remove(i);
        }

        public void set(int index, object e)
        {
            data[index] = e;
        }

        public int size()
        {
            return SIZE;
        }
        private void ensureCapacity()
        {
            if (SIZE + 1 > data.Length) //เช็คว่าถ้าเพิ่มSIZE แล้วมันจะเกิน cap ที่ user ใส่ไหม 
            {
                object[] tempdata = new object[SIZE * 2]; //ถ้าเกิน ก็สร้าง cap ใหม่แล้วเอาข้อมูลใส่ที่ cap ใหม่แทน
                for (int i = 0; i < SIZE; i++)
                    tempdata[i] = data[i];
                data = tempdata;
            }

        }
    }
}
