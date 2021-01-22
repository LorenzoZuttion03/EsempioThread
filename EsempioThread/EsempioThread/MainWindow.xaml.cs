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
        Random rnd = new Random(); //Creo dei numeri random da mettere nel range dei valori che possono assumere 
                                   // posDelfino e posSqualo nei rispettivi metodi di muoviDelfino e muoviSqualo
        bool vittoria = false; //Mi serve per conteggiare la vittoria o del delfino o dello squalo
        public MainWindow()
        {
            InitializeComponent();
            
            Thread t1 = new Thread(new ThreadStart(muoviDelfino)); //Un thread rappresenta l'immagine del delfino
            Thread t2 = new Thread(new ThreadStart(muoviSqualo));//L'altro thread rappresenta l'immagine dello squalo
            ImageSource imm = new BitmapImage(uriDelfino);
            ImageSource imm1 = new BitmapImage(uriSqualo);
            imgDelfino.Source = imm; //Dò i nomi alle immagini
            imgSqualo.Source = imm1;

            t1.Start(); //faccio la Join 
            t2.Start();
        }

        public void muoviDelfino () //Questo metodo fa muovere l'immagine del Delfino
        {
            
            while (posDelfino<500)
            {
                posDelfino += rnd.Next(5,50);

                Thread.Sleep(TimeSpan.FromMilliseconds(500));

                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    imgDelfino.Margin = new Thickness(posDelfino, 100, 0, 0);
                }));


            }
            if(vittoria == false) //conteggio vittoria del delfino
            {
                vittoria = true;
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    lbl1.Content = "primo delfino";
                }));
            }
            else
            {
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    lbl2.Content = "secondo delfino";
                }));
            }

            
        }
        public void muoviSqualo() //Questo metodo fa muovere l'immagine dello Squalo.
        {
            
            while (posSqualo < 500)
            {
                posSqualo += rnd.Next(5,50);

                Thread.Sleep(TimeSpan.FromMilliseconds(500));

                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    imgSqualo.Margin = new Thickness(posSqualo, 201, 0, 0);
                }));


            }
            if (vittoria == false) //conteggio vittoria dello squalo
            {
                vittoria = true;
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    lbl1.Content = "primo squalo";
                }));
            }
            else
            {
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    lbl2.Content = "secondo squalo";
                }));
            }


        }
    }
}
