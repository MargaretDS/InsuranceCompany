using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using InsuranceCompany.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;

using iTextSharp.text.pdf.parser;
using System.Collections;
using System.Windows.Controls.Primitives;
using Microsoft.Win32;
using System;
using Aspose.Pdf.Facades;
using System.Text;
using System.IO;

namespace InsuranceCompany.Windows
{
    static class InterfaceClass 
    {
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj)
    where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }
                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        /// <summary>
        /// Интерфейс, предназначенный для извлечения элементов из childitem, в нашем случае из конкретных строк DataGrid
        /// </summary>
        /// <param name="obj">Параметр, из которого будут извлекаться данные, допустим, строка DataGrid row</param>
        /// <returns></returns>
        public static childItem FindVisualChild<childItem>(DependencyObject obj)
        where childItem : DependencyObject
        {
            foreach (childItem child in FindVisualChildren<childItem>(obj))
            {
                return child;
            }
            return null;
        }
    }


    /// <summary>
    /// Логика взаимодействия для ContractsWindow.xaml
    /// </summary>
    public partial class ContractsWindow : Window
    {


        public static Accounting_of_insurance_contractsEntities1 _context = new Accounting_of_insurance_contractsEntities1();

        public ContractsWindow()
        {
            InitializeComponent();
            DataGridContractsInfo.ItemsSource = _context.Сontract.ToList();
        }

        private void ReturnMain_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();

        }

        private void ExportToPdf(DataGrid grid)
        {
            PdfPTable table = new PdfPTable(grid.Columns.Count);

            Document doc = new Document(PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter writer = PdfWriter.GetInstance(doc, new System.IO.FileStream("Contracts.pdf", System.IO.FileMode.Create));

            BaseFont baseFont = BaseFont.CreateFont("C:\\Windows\\Fonts\\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 10);
            doc.Open();

            Phrase phrase = new Phrase();
            Chunk headch = new Chunk("Информация о заключенных договорах");
            doc.Add(headch);


            for (int j = 0; j < grid.Columns.Count; j++)
            {
                table.AddCell(new Phrase(grid.Columns[j].Header.ToString(), font));
            }
            table.HeaderRows = 1;
            IEnumerable itemsSource = grid.ItemsSource as IEnumerable;
            if (itemsSource != null)
            {
                foreach (var item in itemsSource)
                {
                    DataGridRow row = grid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                    if (row != null)
                    {
                        DataGridCellsPresenter presenter = FindVisualChild<DataGridCellsPresenter>(row);
                        for (int i = 0; i < grid.Columns.Count; ++i)
                        {
                            DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(i);
                            TextBlock txt = cell.Content as TextBlock;
                            if (txt != null)
                            {
                                table.AddCell(new Phrase(txt.Text, font));
                            }
                        }
                    }
                }

                doc.Add(table);
                doc.Close();
                MessageBox.Show("Do magic");
                
            }
        }

        private T FindVisualChild<T>(DependencyObject obj) where T : DependencyObject
        {

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is T)
                    return (T)child;
                else
                {
                    T childOfChild = FindVisualChild<T>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }



        private void ExportWord_Click(object sender, RoutedEventArgs e)
        {
            ExportToPdf(DataGridContractsInfo);
            //DataGridContractsInfo
        }

        
        private void OpenFiles_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
        }
    }
    }
