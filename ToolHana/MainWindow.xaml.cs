using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using KAutoHelper;
using System.Threading;
using System.Drawing;

namespace ToolHana
{
    public partial class MainWindow : Window
    {
        #region Data
        Bitmap Like;
        Bitmap likefb;
        Bitmap likepost;
        Bitmap fanpage;
        Bitmap person;
        Bitmap follow;
        Bitmap mbasic;
        Bitmap success;
        #endregion
        public MainWindow()
        {
            InitializeComponent();
        }

       void LoadData()
       {
            Like = (Bitmap)Bitmap.FromFile("Data//Like.png");
            likefb = (Bitmap)Bitmap.FromFile("Data//likefb.png");
            likepost = (Bitmap)Bitmap.FromFile("Data//likepost.png");
            fanpage = (Bitmap)Bitmap.FromFile("Data//fanpage.png");
            person = (Bitmap)Bitmap.FromFile("Data//person.png");
            mbasic = (Bitmap)Bitmap.FromFile("Data//mbasic.png");
            success = (Bitmap)Bitmap.FromFile("Data//success.png");

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Task t = new Task(() => {
                isStop = false;
                Auto();
            });
            t.Start();
        }

        bool isStop = false;
        void Fanpage()
        {
            // code logic
        }
        
        void Person()
        {
            // code logic
        }

        void Post()
        {
            // code logic
        }
        
        void Auto()
        {
            // lấy ra danh sách devices id để dùng
            List<string> devices = new List<string>();
            devices = KAutoHelper.ADBHelper.GetDevices();

            // chạy từng device để điều khiển theo kịch bản bên trong
            foreach (var deviceID in devices)
            {
                // tạo ra một luồng xử lý riêng biệt để xử lý cho device này
                Task t = new Task(() => {
                    // lặp kịch bản quài quài
                    while (true)
                    {
                        // nếu có lệnh stop thì dừng toàn bộ luồng chạy
                        if (isStop)
                            return;
                        // click vào hana
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 13.1, 29.6);
                        Delay(4);

                        // nếu có lệnh stop thì dừng toàn bộ luồng chạy
                        if (isStop)
                            return;
                        // click viec lam
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 30.0, 95.9);
                        Delay(4);

                        // nếu có lệnh stop thì dừng toàn bộ luồng chạy
                        if (isStop)
                            return;
                        // click vào facebook
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 25.9, 14.5);
                        Delay(4);


                        foreach (Bitmap in Bitmap)
                        {
                            var screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                            var Clicktap = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, likepost);
                            if (Clicktap = likefb)
                                Post();
                            else if (Clicktap = person)
                                Person();
                            else if (Clicktap = fanpage)
                                Fanpage();
                            return;
                        }

                        if (isStop)
                            return;
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 8.6, 48.1);
                        Delay(4);

                        if (isStop)
                            return;
                        KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_HOME);
                        Delay(2);

                        if (isStop)
                            return;
                        // click vào hana
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 13.1, 29.6);
                        Delay(2);

                        if (isStop)
                            return;
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 8.6, 62.0);
                        Delay(3);

                        if (isStop)
                            return;
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 88.6, 53.3);
                        Delay(3);

                        if (isStop)
                            return;
                        KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_HOME);
                        Delay(1);

                        if (isStop)
                            return;
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 95.2, 30.8);
                        Delay(2);

                    }
                });
                t.Start();
            }
        }

        void Delay(int delay)
        {
            while (delay > 0)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                delay--;
                if (isStop)
                    break;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            isStop = true;
        }
    }
}