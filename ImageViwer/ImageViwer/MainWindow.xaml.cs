using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ImageViwer
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<BitmapImage> imageCollection = new ObservableCollection<BitmapImage>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            RecoverWindowSettings();
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveWindowSettings();
            Properties.Settings.Default.Save();
        }

        private void RecoverWindowSettings()
        {
            //設定値を復元する
            Width               = Properties.Settings.Default.windowWidthSetting;
            Height              = Properties.Settings.Default.windowHeightSetting;
            Top                 = Properties.Settings.Default.windowLocationXSetting;
            Left                = Properties.Settings.Default.windowLocationYSetting;
            WindowState         = Properties.Settings.Default.windowStateSetting;
            textFilePath.Text   = Properties.Settings.Default.textFilePathSetting;
        }

        private void SaveWindowSettings()
        {
            //設定値を保存する
            Properties.Settings.Default.windowWidthSetting      = Width;
            Properties.Settings.Default.windowHeightSetting     = Height;
            Properties.Settings.Default.windowLocationXSetting  = Top;
            Properties.Settings.Default.windowLocationYSetting  = Left;
            Properties.Settings.Default.windowStateSetting      = WindowState;
            Properties.Settings.Default.textFilePathSetting     = textFilePath.Text;
        }

        private void buttonOpen_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog browser = new FolderBrowserDialog();
            //List<ImageSource> list = new List<ImageSource>();
            if (browser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(browser.SelectedPath);
                FileInfo[] fileInfos = directoryInfo.GetFiles("*.jpg");
                
                imageCollection.Clear();
                textFilePath.Text = browser.SelectedPath;
                //選択したフォルダ下の画像ファイルを取得
                foreach(FileInfo fileInfo in fileInfos)
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    int decodePixelWidth = 100;

                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.DecodePixelWidth = decodePixelWidth;
                    bitmapImage.UriSource = new Uri(fileInfo.FullName);
                    imageCollection.Add(bitmapImage);

                    //リソース解放
                    bitmapImage.EndInit();
                    bitmapImage.Freeze();
                }
                //バインド
                this.DataContext = imageCollection;
            }
        }
    }
}
