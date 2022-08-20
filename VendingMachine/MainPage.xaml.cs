using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace VendingMachine
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        static Manager manager;
        //static List<Button> buttons;
        public MainPage()
        {
            this.InitializeComponent();
            manager = new Manager();
            CreateButtons();
        }

        private void Btn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            double money;
            Button btn = sender as Button;
            int tag = (int)btn.Tag;

            if (!double.TryParse(payTbx.Text, out money))
            {
                payTbx.Text = "";
                ScreenTbl.Text = $"Please insert {manager.Machine.listOfBeverage[tag].Price:c}";
                return;
            }
            payTbx.Text = "";

            ScreenTbl.Text = manager.Preper(tag, money);
        }

        private void ReStockBtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (payTbx.Text != "1234")
            {
                ScreenTbl.Text = "Manager Area:\nOnly manager can Restock\nPassword is InCorrect.\nTry Again";
                payTbx.Text = "";
                return;
            }
            payTbx.Text = "";
            ScreenTbl.Text = $"Password is Correct\n{manager.ReStockIngredients()}";

        }

        private void CreateButtons()
        {
            for (int i = 0; i < manager.Machine.CountBev; i++)
            {
                Image photo = new Image();
                Button btn1 = new Button();
                TextBlock textBlock = new TextBlock();
                StackPanel stackPanel = new StackPanel();

                photo.Source = manager.Machine.AddPhotoToBtn(i);// => from machine, bev- prop bitMap
                photo.Height = 30;

                stackPanel.HorizontalAlignment = HorizontalAlignment.Stretch;
                stackPanel.VerticalAlignment = VerticalAlignment.Stretch;

                textBlock.Text = manager.Machine.listOfBeverage[i].ToString();
                textBlock.FontSize = 11;

                Grid.SetColumn(btn1, i);
                Grid.SetRow(btn1, 0);
                btn1.HorizontalAlignment = HorizontalAlignment.Stretch;
                btn1.Margin = new Thickness(1);
                btn1.Tag = i;
                btn1.Tapped += Btn_Tapped;

                buttonGrid.Children.Add(btn1);
                btn1.Content = stackPanel;
                stackPanel.Children.Add(textBlock);
                stackPanel.Children.Add(photo);
            }
        }
    }
}
