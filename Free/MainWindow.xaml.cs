using System;
using System.Windows;
using System.Windows.Controls;

namespace Free
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        double valueCaptured = 0, valueCatch2nd = 0, total = 0;
        string capture = null, prev = null, next = "";
        bool start= true;
        private void On_Click(object sender, RoutedEventArgs e)
        {
            string label = (string)((Button)sender).Content;
            if(label == "+" || label == "-" || label == "/" || label == "*" || label == "=")
            {
                next = label;
                if (start)
                {
                    valueCaptured = Double.Parse(capture);
                    start = false;
                }
                else
                {
                    try { valueCatch2nd = Double.Parse(capture); }
                    catch { MessageBox.Show("Invalid"); return; }
                    
                }
                if (prev == null) { prev = next; }
                else
                {
                    switch (prev)
                    {
                        case "+":
                            total = valueCaptured + valueCatch2nd;
                            DisplayTotal();
                            break;
                        case "/":
                            total = valueCaptured / valueCatch2nd;
                            DisplayTotal();
                            break;
                        case "*":
                            total = valueCaptured * valueCatch2nd;
                            DisplayTotal();
                            break;
                        case "-":
                            total = valueCaptured - valueCatch2nd;
                            DisplayTotal();
                            break;
                        default:
                            break;
                    }
                    if (next == "=")
                    {
                        DisplayTotal();
                        this.butt.Text = "";
                    }
                    else
                    {
                        prev = next;
                    }
                }
                capture = "";
            }
            else { capture += label; }
            if(next == "=") { Total_Click(sender, e); }
            else { this.butt.Text += label; }
        }
        private void DisplayTotal()
        {
            valueCaptured = total;
            this.answer.Text = total.ToString();
        }
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            this.butt.Text = "";
            this.answer.Text = "0";
            valueCaptured = 0;
            valueCatch2nd = 0;
            capture = null;
            total = 0;
            prev = null;
            next = "";
            start = true;
        }
        private void Total_Click(object sender, RoutedEventArgs e)
        {
            string ans = (string)this.answer.Text;
            Reset_Click(sender,e);
            this.answer.Text = ans;
        }
    }
}
