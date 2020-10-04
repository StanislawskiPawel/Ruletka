using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Program2
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        List<Button> buttons;
        List<Button> blackButtons;
        List<Button> redButtons;
        List<Button> evenButtons;
        List<Button> oddButtons;
        List<Button> oneToEighteen;
        List<Button> nineteenToThirtySix;
        List<Button> oneToTwelve;
        List<Button> thirteenToTwentyfour;
        List<Button> twentyfiveToThirtysix;
        List<Button> verse1;
        List<Button> verse2;
        List<Button> verse3;
        List<Button> clickedButtons = new List<Button>();
        Player p = null;
        int bet;
        int multiply = 0;
        int c = 0;
       
        public Window1(string nazwa, int liczba)
        {
            InitializeComponent();
            p = new Player(nazwa, liczba);
            Database.instance.sendResult(p);
            buttons = table.Children.OfType<Button>().ToList();
            redButtons = buttons.Where(x => x.Background == Brushes.Red).ToList();
            blackButtons = buttons.Where(x => x.Background == Brushes.Black).ToList();
            evenButtons = buttons.Where(x => Int32.Parse((string)x.Content) % 2 == 0).ToList();   
            oddButtons = buttons.Where(x => Int32.Parse((string)x.Content) % 2 == 1).ToList();   
            oneToEighteen = buttons.Where(x => (Int32.Parse((string)x.Content)<19) && (Int32.Parse((string)x.Content) > 0)).ToList();   
            nineteenToThirtySix = buttons.Where(x => (Int32.Parse((string)x.Content) < 37) && (Int32.Parse((string)x.Content) > 18)).ToList();
            oneToTwelve = buttons.Where(x => (Int32.Parse((string)x.Content) < 13) && (Int32.Parse((string)x.Content) > 0)).ToList();
            thirteenToTwentyfour = buttons.Where(x => (Int32.Parse((string)x.Content) < 25) && (Int32.Parse((string)x.Content) > 12)).ToList();
            twentyfiveToThirtysix = buttons.Where(x => (Int32.Parse((string)x.Content) < 37) && (Int32.Parse((string)x.Content) > 24)).ToList();
            verse1 = buttons.Where(x => Int32.Parse((string)x.Content)%3  == 0).ToList();
            verse2 = buttons.Where(x => Int32.Parse((string)x.Content)%3  == 2).ToList();
            verse3 = buttons.Where(x => Int32.Parse((string)x.Content)%3  == 1).ToList();

            foreach (var item in buttons)
            {
                item.Click += btn1_Click;
            }

            slider.Maximum = p.Money;
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            clickedButtons.Add(button);
            text1.Text += button.Content + ", ";
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            multiply = 16;
            text1.Text = ("Wybierz numer (0-36):  ");
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            int es = rand.Next(0, 36);
            bool result = clickedButtons.Where(x => Int32.Parse((string)x.Content) == es).Any();
            bool result1 = blackButtons.Where(x => Int32.Parse((string)x.Content) == es).Any();
            bool result2 = redButtons.Where(x => Int32.Parse((string)x.Content) == es).Any();
            bool result3 = evenButtons.Where(x => Int32.Parse((string)x.Content) == es).Any();
            bool result4 = oddButtons.Where(x => Int32.Parse((string)x.Content) ==es).Any();
            bool result5 = oneToEighteen.Where(x => Int32.Parse((string)x.Content) == es).Any();
            bool result6 = nineteenToThirtySix.Where(x => Int32.Parse((string)x.Content)== es).Any(); 
            bool result7 = oneToTwelve.Where(x => Int32.Parse((string)x.Content)==es).Any();
            bool result8 = thirteenToTwentyfour.Where(x => Int32.Parse((string)x.Content)==es).Any();
            bool result9 = twentyfiveToThirtysix.Where(x => Int32.Parse((string)x.Content)== es).Any();
            bool result10 = verse1.Where(x => Int32.Parse((string)x.Content) == es).Any();
            bool result11 = verse2.Where(x => Int32.Parse((string)x.Content) == es).Any();
            bool result12 = verse3.Where(x => Int32.Parse((string)x.Content) == es).Any();

            if (p.Money > 0)
            {
                if (multiply == 16)
                {
                    if (result == true)
                    {
                        text1.Text = ("Gratulacje! Szukaną liczbą była liczba: " + es);

                        p.Money += (bet / clickedButtons.Count) * multiply;
                    }

                    else
                    {
                        p.Money -= bet;
                        text1.Text = ("Niestety, szukana liczba to: " + es);

                        p.Money = bet * multiply;

                    }
                }

                else if (multiply == 2)
                {
                    if (c == 1)
                    {
                        if (result1 == true)
                        {
                            p.Money += bet * multiply;
                            text1.Text = ("Gratulacje! Szukaną liczbą była liczba: " + es);
                        }

                        else
                        {
                            p.Money -= bet;
                            text1.Text = ("Niestety, szukana liczba to: " + es);
                        }

                    } if (c == 2)
                    {
                        if (result2 == true)
                        {
                            p.Money += bet * multiply;
                            text1.Text = ("Gratulacje! Szukaną liczbą była liczba: " + es);
                        }

                        else
                        {
                            p.Money -= bet;
                            text1.Text = ("Niestety, szukana liczba to: " + es);
                        }

                    } if (c == 3)
                    {
                        if (result3 == true)
                        {
                            p.Money += bet * multiply;
                            text1.Text = ("Gratulacje! Szukaną liczbą była liczba: " + es);
                        }

                        else
                        {
                            p.Money -= bet;
                            text1.Text = ("Niestety, szukana liczba to: " + es);
                        }

                    } if (c == 4)
                    {
                        if (result4 == true)
                        {
                            p.Money += bet * multiply;
                            text1.Text = ("Gratulacje! Szukaną liczbą była liczba: " + es);
                        }

                        else
                        {
                            p.Money -= bet;
                            text1.Text = ("Niestety, szukana liczba to: " + es);
                        }

                    } if (c == 5)
                    {
                        if (result5 == true)
                        {
                            p.Money += bet * multiply;
                            text1.Text = ("Gratulacje! Szukaną liczbą była liczba: " + es);
                        }

                        else
                        {
                            p.Money -= bet;
                            text1.Text = ("Niestety, szukana liczba to: " + es);
                        }

                    } if (c == 6)
                    {
                        if (result6 == true)
                        {
                            p.Money += bet * multiply;
                            text1.Text = ("Gratulacje! Szukaną liczbą była liczba: " + es);
                        }

                        else
                        {
                            p.Money -= bet;
                            text1.Text = ("Niestety, szukana liczba to: " + es);
                        }

                    }


                }
                else if (multiply == 3)
                {
                    if (c == 7)
                    {
                        if (result7 == true)
                        {
                            p.Money += bet * multiply;
                            text1.Text = ("Gratulacje! Szukaną liczbą była liczba: " + es);
                        }

                        else
                        {
                            p.Money -= bet;
                            text1.Text = ("Niestety, szukana liczba to: " + es);
                        }

                    }
                    if (c == 8)
                    {
                        if (result8 == true)
                        {
                            p.Money += bet * multiply;
                            text1.Text = ("Gratulacje! Szukaną liczbą była liczba: " + es);
                        }

                        else
                        {
                            p.Money -= bet;
                            text1.Text = ("Niestety, szukana liczba to: " + es);
                        }

                    }
                    if (c == 9)
                    {
                        if (result9 == true)
                        {
                            p.Money += bet * multiply;
                            text1.Text = ("Gratulacje! Szukaną liczbą była liczba: " + es);
                        }

                        else
                        {
                            p.Money -= bet;
                            text1.Text = ("Niestety, szukana liczba to: " + es);
                        }

                    }
                    if (c == 10)
                    {
                        if (result10 == true)
                        {
                            p.Money += bet * multiply;
                            text1.Text = ("Gratulacje! Szukaną liczbą była liczba: " + es);
                        }

                        else
                        {
                            p.Money -= bet;
                            text1.Text = ("Niestety, szukana liczba to: " + es);
                        }

                    }
                    if (c == 11)
                    {
                        if (result11 == true)
                        {
                            p.Money += bet * multiply;
                            text1.Text = ("Gratulacje! Szukaną liczbą była liczba: " + es);
                        }

                        else
                        {
                            p.Money -= bet;
                            text1.Text = ("Niestety, szukana liczba to: " + es);
                        }

                    }
                    if (c == 12)
                    {
                        if (result12 == true)
                        {
                            p.Money += bet * multiply;
                            text1.Text = ("Gratulacje! Szukaną liczbą była liczba: " + es);
                        }

                        else
                        {
                            p.Money -= bet;
                            text1.Text = ("Niestety, szukana liczba to: " + es);
                        }

                    }
                }
            }
            else
            {
                text1.Text = ("Niestety, nie masz już pieniędzy");
            }

            clickedButtons.Clear();
            slider.Maximum = p.Money;
            Database.instance.Refresh(p);

            textbox2.Text = p.Money.ToString() + "$";

        }



        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            c = 3;
            multiply = 2;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            c = 1;
            multiply = 2;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            multiply = 2;
            c = 2;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            c = 4;
            multiply = 2;
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            c = 5;
            multiply = 2;
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            c = 6;
            multiply = 2;
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            c = 7;
            multiply = 3;
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            c = 11;
            multiply = 3;

        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            c = 12;
            multiply = 3;
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            c = 10;
            multiply = 3;
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            c = 8;
            multiply = 3;
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            c = 9;
            multiply = 3;
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void slider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.Title = "Value: " + slider.Value.ToString("0000") + "/" + slider.Maximum;
            bet = (int)slider.Value;
        }
    }
}
