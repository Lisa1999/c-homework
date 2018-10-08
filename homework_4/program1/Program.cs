using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    //1.声明参数类型
    public class ClockAlarmEventArgs : EventArgs
    {

    }
    //2.声明委托类型
    public delegate void ClockAlarmEventHandler(object sender, ClockAlarmEventArgs e);

    //定义事件源(闹表)
    public class ClockAlarm
    {
        //3.声明事件 
        public event ClockAlarmEventHandler Clocking; //在该类中对事件进行调用
        public void DoClock()
        {
            //4.发生一个事件,通知外界
            if (Clocking != null)
            {
                ClockAlarmEventArgs args = new ClockAlarmEventArgs();
                Clocking(this, args);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入所需闹钟时间小时数: ");
            string h = Console.ReadLine();
            try
            {
                while (Int32.Parse(h) > 23 || Int32.Parse(h) < 0)
                {
                    Console.WriteLine("输入不合理,请重新输入:");
                    h = Console.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("输入不合理,请重新输入:");
            }
            Console.WriteLine("请输入所需闹钟时间分钟数: ");
            string m = Console.ReadLine();
            try
            {
                if (m.Length == 1) m = "0" + m;
                while (Int32.Parse(m) > 59 || Int32.Parse(m) < 0)
                {
                    Console.WriteLine("输入不合理,请重新输入: ");
                    m = Console.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("输入不合理,请重新输入: ");
            }
            string s = h + ":" + m;
            //注册一个闹钟
            var clockAlarm = new ClockAlarm();
            string nowTime = DateTime.Now.ToShortTimeString().ToString();
            Console.WriteLine("现在是: " + nowTime);
            while (nowTime != s)
            {
                //逐渐求当前时间以延迟一分钟代替
                System.Threading.Thread.Sleep(60000);
                nowTime = DateTime.Now.ToShortTimeString().ToString();
                Console.WriteLine("现在是: " + nowTime);
            }
            //5.注册事件
            clockAlarm.Clocking += Ring;
            clockAlarm.DoClock();
        }
        //6.事件处理方法
        static void Ring(object sender, ClockAlarmEventArgs e)
        {
            Console.WriteLine("---------闹钟时刻到了，响铃啦响铃啦--------");
        }

    }
}
