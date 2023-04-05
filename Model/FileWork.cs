using System.Runtime.InteropServices;
using AirDispetcher.Data;
using AirDispetcher.Enum;
using Microsoft.Office.Interop.Excel;

namespace AirDispetcher.Model
{
    internal class FileWork
    {
        public static string? DataFile { get; set; }

        public FileWork()
        {
            if (string.IsNullOrEmpty(DataFile))
            {
                DataFile = GetDataFile();
            }
        }

        public FileWork(string dataFile)
        {
            DataFile = dataFile;
        }

        protected string GetDataFile()
        {
            string dataFile = string.Empty;

            // Проверка есть ли ссылка на даные в файле настроек
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

        public MainData LoadeData()
        {
            List<Passenger> PassengersList = new List<Passenger>();
            List<Flight> FlightsList = new List<Flight>();
            List<VTFlightPassenger> VTFlightPassengerList = new List<VTFlightPassenger>();

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
                                    case (int)ExelWorksheet.VirtualTable:
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
                    ExcelApp.Quit();
                    releaseObject(ExcelApp);
                    Marshal.ReleaseComObject(ExcelApp);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка в SaveData" + ex.Message.ToString());
                }
            }
            return new MainData(VTFlightPassengerList, FlightsList, PassengersList);
        }

        public bool SaveData(MainData mainData)
        {
            if(!string.IsNullOrEmpty(DataFile) && mainData != null)
            {
                try
                {
                    FormSettings formSettings = new FormSettings();
                    formSettings.AutoSave(new string[] { DataFile });

                    Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                    Workbook ExcelWorkbook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);

                    //Сохраняем виртуальню таблицу связи рейсов и пасажиров
                    var VTFlightPassengerList = mainData.GetVTFlightPassengerList();
                    Worksheet ExcelWorksheet = ExcelWorkbook.Worksheets[1];
                    for (int i = 1; i < VTFlightPassengerList.Count + 1; i++)
                    {
                        ExcelWorksheet.Cells[i, 1] = VTFlightPassengerList[i - 1].FlightId;
                        ExcelWorksheet.Cells[i, 2] = VTFlightPassengerList[i - 1].PassengerId;
                    }

                    //Сохраняем список рейсов
                    var FlightsList = mainData.GetFlightList();
                    ExcelWorksheet = ExcelWorkbook.Worksheets[2];
                    for(int i=1; i< FlightsList.Count+1; i++)
                    {
                        ExcelWorksheet.Cells[i, 1] = FlightsList[i - 1].Id;
                        ExcelWorksheet.Cells[i, 2] = FlightsList[i - 1].Name.ToString();
                        ExcelWorksheet.Cells[i, 3] = FlightsList[i - 1].DepartureTime.ToString();
                        ExcelWorksheet.Cells[i, 4] = FlightsList[i - 1].ArrivalTime.ToString();
                        ExcelWorksheet.Cells[i, 5] = FlightsList[i - 1].IsDelet;
                    }

                    //Сохраняем список пасажиров
                    var PassengersList = mainData.GetPassengersList();
                    ExcelWorksheet = ExcelWorkbook.Worksheets[3];
                    for (int i = 1; i < PassengersList.Count+1; i++)
                    {
                        ExcelWorksheet.Cells[i, 1] = PassengersList[i - 1].Id;
                        ExcelWorksheet.Cells[i, 2] = PassengersList[i - 1].FIO.ToString();
                        ExcelWorksheet.Cells[i, 3] = PassengersList[i - 1].Passport.ToString();
                        ExcelWorksheet.Cells[i, 4] = PassengersList[i - 1].IsDelet;
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
                return true;
            }
            else 
            { 
                return false; 
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
    }
}
