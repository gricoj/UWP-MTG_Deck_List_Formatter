using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.ApplicationModel.DataTransfer;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace mtg
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private string cleanLine(string l) {
            if (!l.Contains("("))
                return l;
            return l.Split('(')[0];
        }

        private void cleanLines(ref string[] text) {
            for (int i = 0; i < text.Length; i++) {
                text[i] = cleanLine(text[i]);
            }
        }

        public MainPage()
        {
            this.InitializeComponent();
        }

    private void ParseButton_Click(object sender, RoutedEventArgs e)
        {
            string[] inputA = input.Text.Split(Environment.NewLine.ToCharArray());
            cleanLines(ref inputA);
            output.Text = string.Join("\n", inputA);
        }

        private void cpToCB_Click(object sender, RoutedEventArgs e)
        {
            DataPackage dP = new DataPackage();
            dP.SetText(output.Text);
            Clipboard.SetContent(dP);
        }

        private void nuke_Click(object sender, RoutedEventArgs e)
        {
            input.Text = "";
            output.Text = "";
        }

        private async void pFromCB_Click(object sender, RoutedEventArgs e)
        {
            DataPackageView dP = Clipboard.GetContent();
            input.Text = await  dP.GetTextAsync();
        }
    }
}
