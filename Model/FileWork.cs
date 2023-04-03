using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;
using AirDispetcher.Data;
using ExcelDataReader;
using Microsoft.Office.Interop;
using Microsoft.Office.Interop.Excel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;


namespace AirDispetcher.Model
{
    internal class FileWork
    {
        //private static FileWork instance;
        //public string FileName { get; private set; }
        public static string? DataFile { get; set; }
        private List<Passenger> PassengersList { get; set; }
        private int LastPassengerId { get; set; }
        private List<Flight> FlightsList { get; set; }
        private int LastFlightsId { get; set; }
        private List<VTFlightPassenger> VTFlightPassengerList { get; set; }


        public FileWork()
        {
            if (string.IsNullOrEmpty(DataFile))
            {
                DataFile = GetDataFile();
            }
        }

        protected FileWork(string dataFile)
        {
            DataFile = dataFile;
        }

        protected string GetDataFile()
        {
            string dataFile = string.Empty;

            // Проверка есть ли ссылка на файл данных в настройках
            FormSettings formSettings = new FormSettings();
            var formSettingsList = formSettings.GetFormSettingList();
            if (formSettingsList.Count() > 0)
            {
                if (!string.IsNullOrEmpty(formSettingsList[0]))
                {

                    dataFile = formSettingsList[0];
                }
            }

            if (string.IsNullOrEmpty(dataFile))
            {
                using (OpenFileDialog dialog = new OpenFileDialog()
                {
                    Filter = "Excel file|*.xlsx|Excel 97-2003|*.xls",
                    ValidateNames = true
                })
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        dataFile = dialog.FileName;
                    }
                }
            }
            return dataFile;
        }

        //private string SetInstance(string fileName)
        //{
        //    if(string.IsNullOrEmpty(DataFile))
        //    {
        //        DataFile = fileName;
        //        //instance = new FileWork (fileName, passengersList);
        //    }
        //    return DataFile;
        //}

        //public List<Passenger> GetPassengersList()
        //{
        //    return PassengersList;
        //}

        public List<Flight> GetFlightList()
        {
            return FlightsList;
        }

        public MainData LoadeData()
        {
            PassengersList = new List<Passenger>();
            FlightsList = new List<Flight>();
            VTFlightPassengerList = new List<VTFlightPassenger>();

            if (string.IsNullOrEmpty(DataFile))
            {
                MessageBox.Show("Ошибка в LoadeData: ошибка загрузки главного файла!!!");
            }
            else
            {
                try
                {
                    Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                    _Workbook ExcelWorkBook = ExcelApp.Workbooks.Open(DataFile, 0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

                    for (int Worksheet = 1; Worksheet <= 3; Worksheet++)
                    {
                        Worksheet ExcelWorksheet = (Worksheet)ExcelWorkBook.Worksheets.get_Item(Worksheet);
                        Microsoft.Office.Interop.Excel.Range ExcelRange = ExcelWorksheet.UsedRange;

                        if (ExcelRange.Rows.Count != 1)
                        {
                            for (int i = 1; i <= ExcelRange.Rows.Count; i++)
                            {
                                switch (Worksheet)
                                {
                                    case 1:
                                        VTFlightPassengerList.Add(new VTFlightPassenger()
                                        {
                                            FlightId = ((ExcelRange.Cells[i, 1] as Microsoft.Office.Interop.Excel.Range).Value2 == null) ? 0 : (int)(ExcelRange.Cells[i, 1] as Microsoft.Office.Interop.Excel.Range).Value2,
                                            PassengerId = ((ExcelRange.Cells[i, 2] as Microsoft.Office.Interop.Excel.Range).Value2 == null) ? 0 : (int)(ExcelRange.Cells[i, 2] as Microsoft.Office.Interop.Excel.Range).Value2
                                        });
                                        break;
                                    case 2:
                                        string isDelet = ((ExcelRange.Cells[i, 5] as Microsoft.Office.Interop.Excel.Range).Value2 == null) ? "false" : (ExcelRange.Cells[i, 5] as Microsoft.Office.Interop.Excel.Range).Value2.ToString();
                                        FlightsList.Add(
                                            new Flight(
                                                ((ExcelRange.Cells[i, 1] as Microsoft.Office.Interop.Excel.Range).Value2 == null) ? 0 : (int)(ExcelRange.Cells[i, 1] as Microsoft.Office.Interop.Excel.Range).Value2,
                                                ((ExcelRange.Cells[i, 2] as Microsoft.Office.Interop.Excel.Range).Value2 == null) ? string.Empty : (ExcelRange.Cells[i, 2] as Microsoft.Office.Interop.Excel.Range).Value2.ToString(),
                                                ((ExcelRange.Cells[i, 3] as Microsoft.Office.Interop.Excel.Range).Value2 == null) ? DateTime.Now : DateTime.Parse((ExcelRange.Cells[i, 3] as Microsoft.Office.Interop.Excel.Range).Value2),
                                                ((ExcelRange.Cells[i, 4] as Microsoft.Office.Interop.Excel.Range).Value2 == null) ? DateTime.Now : DateTime.Parse((ExcelRange.Cells[i, 4] as Microsoft.Office.Interop.Excel.Range).Value2),
                                                Boolean.Parse(isDelet)
                                                ));
                                        break;
                                    case 3:
                                        isDelet = ((ExcelRange.Cells[i, 4] as Microsoft.Office.Interop.Excel.Range).Value2 == null) ? "false" : (ExcelRange.Cells[i, 4] as Microsoft.Office.Interop.Excel.Range).Value2.ToString();
                                        PassengersList.Add(
                                        new Passenger(
                                            ((ExcelRange.Cells[i, 1] as Microsoft.Office.Interop.Excel.Range).Value2 == null) ? 0 : (int)(ExcelRange.Cells[i, 1] as Microsoft.Office.Interop.Excel.Range).Value2,
                                            ((ExcelRange.Cells[i, 2] as Microsoft.Office.Interop.Excel.Range).Value2 == null) ? string.Empty : (ExcelRange.Cells[i, 2] as Microsoft.Office.Interop.Excel.Range).Value2.ToString(),
                                            ((ExcelRange.Cells[i, 3] as Microsoft.Office.Interop.Excel.Range).Value2 == null) ? string.Empty : (ExcelRange.Cells[i, 3] as Microsoft.Office.Interop.Excel.Range).Value2.ToString(),
                                            Boolean.Parse(isDelet)
                                            )
                                        );
                                        break;
                                }
                            }
                        }
                        releaseObject(ExcelRange);
                        releaseObject(ExcelWorksheet);
                        Marshal.ReleaseComObject(ExcelRange);
                        Marshal.ReleaseComObject(ExcelWorksheet);
                    }

                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    ExcelWorkBook.Close();
                    releaseObject(ExcelWorkBook);
                    Marshal.ReleaseComObject(ExcelWorkBook);
                    //ExcelWorkBook.Close(true, null, null);
                    ExcelApp.Quit();
                    releaseObject(ExcelApp);
                    Marshal.ReleaseComObject(ExcelApp);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка в SaveData" + ex.Message.ToString());
                }


                //if (PassengersList.Count == 0)
                //{
                //    LastPassengerId = 0;
                //}
                //else
                //{
                //    LastPassengerId = PassengersList.Max(x => x.Id);
                //}

                //if (FlightsList.Count == 0)
                //{
                //    LastFlightsId = 0;
                //}
                //else
                //{
                //    LastFlightsId = FlightsList.Max(x => x.Id);
                //}
            }
            return new MainData(VTFlightPassengerList, FlightsList, PassengersList);
        }

        public List<Passenger> LoadPassengers()
        {
            List<Passenger> passengersList = new List<Passenger>();
            if (string.IsNullOrEmpty(DataFile))
            {
                MessageBox.Show("Ошибка в LoadPassengers: ошибка при загрузке данных!!!");
            }
            else
            {
                try
                {
                    Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                    _Workbook ExcelWorkBook = ExcelApp.Workbooks.Open(DataFile, 0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                    Worksheet ExcelWorksheet = (Worksheet)ExcelWorkBook.Worksheets.get_Item(3);
                    Microsoft.Office.Interop.Excel.Range ExcelRange = ExcelWorksheet.UsedRange;

                    if (ExcelRange.Rows.Count != 1)
                    {
                        for (int i = 1; i <= ExcelRange.Rows.Count; i++)
                        {
                            string isDelet = ((ExcelRange.Cells[i, 4] as Microsoft.Office.Interop.Excel.Range).Value2 == null) ? "false" : (ExcelRange.Cells[i, 4] as Microsoft.Office.Interop.Excel.Range).Value2.ToString();
                            passengersList.Add(
                            new Passenger(
                                ((ExcelRange.Cells[i, 1] as Microsoft.Office.Interop.Excel.Range).Value2 == null) ? 0 : (int)(ExcelRange.Cells[i, 1] as Microsoft.Office.Interop.Excel.Range).Value2,
                                ((ExcelRange.Cells[i, 2] as Microsoft.Office.Interop.Excel.Range).Value2 == null) ? string.Empty : (ExcelRange.Cells[i, 2] as Microsoft.Office.Interop.Excel.Range).Value2.ToString(),
                                ((ExcelRange.Cells[i, 3] as Microsoft.Office.Interop.Excel.Range).Value2 == null) ? string.Empty : (ExcelRange.Cells[i, 3] as Microsoft.Office.Interop.Excel.Range).Value2.ToString(),
                                Boolean.Parse(isDelet)
                                )
                            );
                        }
                    }

                    releaseObject(ExcelRange);
                    releaseObject(ExcelWorksheet);
                    Marshal.ReleaseComObject(ExcelRange);
                    Marshal.ReleaseComObject(ExcelWorksheet);
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    ExcelWorkBook.Close();
                    releaseObject(ExcelWorkBook);
                    Marshal.ReleaseComObject(ExcelWorkBook);
                    ExcelApp.Quit();
                    releaseObject(ExcelApp);
                    Marshal.ReleaseComObject(ExcelApp);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка в SaveData" + ex.Message.ToString());
                }
            }
            return passengersList;
        }

        public void SaveData()
        {
            if(!string.IsNullOrEmpty(DataFile) && PassengersList != null)
            {
                try
                {
                    FormSettings formSettings = new FormSettings();
                    formSettings.AutoSave(new string[] { DataFile });

                    Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                    Workbook ExcelWorkbook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);

                    //Сохраняем виртуальню таблицу связи рейсов и пасажиров
                    Worksheet ExcelWorksheet = ExcelWorkbook.Worksheets[1];
                    for (int i = 1; i < VTFlightPassengerList.Count; i++)
                        {
                        ExcelWorksheet.Cells[i, 1] = VTFlightPassengerList[i].FlightId;
                        ExcelWorksheet.Cells[i, 2] = VTFlightPassengerList[i].PassengerId;
                    }

                    //Сохраняем список рейсов
                    ExcelWorksheet = ExcelWorkbook.Worksheets[2];
                    for(int i=1; i< FlightsList.Count; i++)
                    {
                        ExcelWorksheet.Cells[i, 1] = FlightsList[i].Id;
                        ExcelWorksheet.Cells[i, 2] = FlightsList[i].Name.ToString();
                        ExcelWorksheet.Cells[i, 3] = DateTime.Now.ToString();
                        ExcelWorksheet.Cells[i, 4] = DateTime.Now.ToString();
                        ExcelWorksheet.Cells[i, 5] = FlightsList[i].IsDelet;
                    }

                    //Сохраняем список пасажиров
                    ExcelWorksheet = ExcelWorkbook.Worksheets[3];
                    for (int i = 1; i < PassengersList.Count; i++)
                    {
                        ExcelWorksheet.Cells[i, 1] = PassengersList[i].Id;
                        ExcelWorksheet.Cells[i, 2] = PassengersList[i].FIO.ToString();
                        ExcelWorksheet.Cells[i, 3] = PassengersList[i].Passport.ToString();
                        ExcelWorksheet.Cells[i, 4] = PassengersList[i].IsDelet;
                    }

                    ExcelApp.DisplayAlerts = false;
                    ExcelApp.AlertBeforeOverwriting = false;
                    ExcelWorkbook.SaveAs(DataFile);

                    ExcelApp.Quit();
                    releaseObject(ExcelWorksheet);
                    releaseObject(ExcelWorkbook);
                    releaseObject(ExcelApp);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Ошибка в SaveData" + ex.Message.ToString());
                }

            }
        }

        private void releaseObject(object obj)
        {
            try
            {
                Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        internal void AddPassenger(string FIO, string passport)
        {
            LastPassengerId++;
            PassengersList.Add(new Passenger(LastPassengerId, FIO, passport));
        }
    }
}
