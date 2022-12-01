using Download_Calculator.Services;
using System;
using System.Diagnostics;
using Wpf.Ui.Common.Interfaces;

namespace Download_Calculator.Views.Pages
{
    /// <summary>
    /// Interaction logic for DashboardPage.xaml
    /// </summary>
    public partial class DashboardPage : INavigableView<ViewModels.DashboardViewModel>
    {
        public ViewModels.DashboardViewModel ViewModel
        {
            get;
        }

        public static double? size { get; set; } = null;
        public static double? speed { get; set; } = null;
        public static string? sizeType { get; set; } = null; 
        public static string? speedType { get; set; } = null; 

        public DashboardPage(ViewModels.DashboardViewModel viewModel)
        {
            ViewModel = viewModel;

            InitializeComponent();
            speed = Convert.ToDouble(TSpeed.Text);
            speedType =  ComboBoxSpeed.SelectionBoxItem.ToString();
            sizeType =  ComboBoxSize.SelectionBoxItem.ToString();




        }

        private void TSpeed_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            speed = Convert.ToDouble(TSpeed.Text) ;
            CalcualteTimeLeft();
        }



        private void TSize_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            size = Convert.ToDouble(TSize.Text);
            CalcualteTimeLeft();
        }



        private void ComboBox_SizeChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            sizeType = ComboBoxSize.SelectedValue.ToString();
            Debug.WriteLine($"ComboBox_SizeChanged:: {sizeType}");
            CalcualteTimeLeft();
        }



        private void ComboBox_SpeedChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            speedType=  ComboBoxSpeed.SelectedValue.ToString();
            Debug.WriteLine($"ComboBox_SpeedChanged:: {speedType}");
            CalcualteTimeLeft();
        }


        private void CalcualteTimeLeft() {


            if (size == null || speed == null || sizeType == null  || speedType ==null)
                return;
            
            

          var result =   CalculatorService.GetTimeLeft((double)size, (double)speed,sizeType,speedType);

            resultText.Text = result;   
        }


    }
}