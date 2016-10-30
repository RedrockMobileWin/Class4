using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class4
{
    class Program : Vehicle
    {
        static void Main(string[] args)
        {
            #region 装箱和拆箱操作
            double a = 49;
            object obj1 = a;//将double类型装箱
            double b = (double)obj1;//将double类型拆箱,拆箱时必须进行强制转换，如果是类类型拆箱为确保安全必须使用is或者是as操作符
            Console.WriteLine("a成功拆箱为b={0}", b);

            Circle circle = new Circle();
            object obj2 = circle;
            Rectangle rectangle1 = obj2 as Rectangle;//返回值为null
            if (obj2 is Rectangle)
            {
                Rectangle rectangle2 = (Rectangle)obj2;
                Console.WriteLine("Circle拆箱为Rectangle成功");
            }
            else
            {
                Console.WriteLine("Circle拆箱为Rectangle失败");
            }
            Console.ReadKey();
            #endregion

            #region 装拆箱性能损耗
            Unbox.RunUnbox();
            Unbox.RunNoBox();
            Console.ReadKey();
            #endregion

            #region 交通工具的继承
            Car car1 = new Car();
            car1.StartEngine();
            car1.StopEngine();
            car1.Accelerate();
            car1.Brake();
            Airplane airplane1 = new Airplane();
            airplane1.StartEngine();
            airplane1.StopEngine();
            airplane1.TakeOff();
            airplane1.Land();
            Console.ReadKey();
            #endregion

            #region 类的赋值
            Car car2 = new Car();
            Vehicle vehicle1;
            vehicle1 = car2;
            #endregion

            #region virtual方法
            Console.WriteLine("{0}", car1.ToString());
            Console.ReadKey();
            #endregion

            #region override方法，多态
            Car car3 = new Car();
            Airplane airplane2 = new Airplane();
            CRH crh = new CRH();
            car3.GetTypeName();
            airplane2.GetTypeName();
            crh.GetTypeName();
            Console.ReadKey();
            #endregion
        }
    }
    public class Circle
    {
        //此处一堆代码
    }
    public class Rectangle
    {
        //此处一堆代码
    }
    public class Unbox
    {
        public static void RunUnbox()
        {
            int count;
            DateTime startTime = DateTime.Now;
            ArrayList MyArrayList = new ArrayList();
            for (int i = 0; i < 5; i++)
            {
                MyArrayList.Clear();
                for (count = 0; count < 5000000; count++)
                {
                    MyArrayList.Add(count);//装箱
                }
                int j;
                for (count = 0; count < 5000000; count++)
                {
                    j = (int)MyArrayList[count];//拆箱
                }
            }
            DateTime endTime = DateTime.Now;
            Console.WriteLine("使用装箱和拆箱共花时间：{0}", endTime - startTime);
        }
        public static void RunNoBox()
        {
            int count;
            DateTime startTime = DateTime.Now;
            List<int> MyTList = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                MyTList.Clear();
                for (count = 0; count < 5000000; count++)
                {
                    MyTList.Add(count);
                }
                int j;
                for (count = 0; count < 5000000; count++)
                {
                    j = MyTList[count];
                }
            }
            DateTime endTime = DateTime.Now;
            Console.WriteLine("使用泛型共花时间：{0}", endTime - startTime);
        }
    }
    public class Vehicle : System.Object
    {
        public void StartEngine()
        {
            Console.WriteLine("启动引擎");
        }
        public void StopEngine()
        {
            Console.WriteLine("关闭引擎");
        }
        public virtual void GetTypeName()
        {
            Console.WriteLine("这是一个交通工具");
        }
    }
    public class Car : Vehicle
    {
        public void Accelerate()
        {
            Console.WriteLine("汽车在加速");
        }
        public void Brake()
        {
            Console.WriteLine("汽车在刹车");
        }
        public override void GetTypeName()
        {
            Console.WriteLine("这是一辆汽车");
        }
    }
    public class Airplane : Vehicle
    {
        public void TakeOff()
        {
            Console.WriteLine("飞机在起飞");
        }
        public void Land()
        {
            Console.WriteLine("飞机在着陆");
        }
        public override void GetTypeName()
        {
            Console.WriteLine("这是一架飞机");
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
    public class CRH : Vehicle
    {
        //我就是不重写GetTypeName这个方法
    }

    #region protect访问
    class BaseTest
    {
        public int a = 10;
        protected int b = 2;
    }
    class ChildTest : BaseTest
    {
        int c;
        int d;
        public void PrintTest()
        {
            BaseTest baseTest = new BaseTest();
            c = baseTest.a;
            ChildTest childTest = new ChildTest();
            d = childTest.b;
            //d = baseTest.b;
        }
    }
    #endregion
}
