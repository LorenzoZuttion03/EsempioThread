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
using System.Threading;

namespace EsempioThread
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly Uri uriDelfino = new Uri("delfino.jpg", UriKind.Relative);
        readonly Uri uriSqualo = new Uri("squalo-salmone.jpg", UriKind.Relative);
        int posDelfino = 100;
        int posSqualo = 131;
        public MainWindow()
        {
            InitializeComponent();
            
            Thread t1 = new Thread(new ThreadStart(muoviDelfino));
            Thread t2 = new Thread(new ThreadStart(muoviSqualo));
            ImageSource imm = new BitmapImage(uriDelfino);
            ImageSource imm1 = new BitmapImage(uriSqualo);
            imgDelfino.Source = imm;
            imgSqualo.Source = imm1;

            t1.Start();
            t2.Start();
        }

        public void muoviDelfino ()
        {
            while (posDelfino<500)
            {
                posDelfino += 10;

                Thread.Sleep(TimeSpan.FromMilliseconds(500));

                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    imgDelfino.Margin = new Thickness(posDelfino, 100, 0, 0);
                }));


            }

            
        }
        public void muoviSqualo()
        {
            while (posSqualo < 500)
            {
                posSqualo += 10;

                Thread.Sleep(TimeSpan.FromMilliseconds(500));

                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    imgSqualo.Margin = new Thickness(posSqualo, 201, 0, 0);
                }));


            }


        }
    }
}
