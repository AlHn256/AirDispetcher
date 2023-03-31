using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;
using ExcelDataReader;
using Microsoft.Office.Interop;
using Microsoft.Office.Interop.Excel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;


namespace AirDispetcher.Model
{
    internal class FileWork
    {
        private static FileWork instance;
        public string FileName { get; private set; }
        private List<Passenger> PassengersList { get; set; }
        private int LastPassengerId { get; set; }
        private List<Flight> FlightsList { get; set; }
        private int LastFlightsId { get; set; }
        private List<VTFlightPassenger> VTFlightPassengerList { get; set; }


        public FileWork()
        {
            if (instance == null)
            {
                LoadeData();
            }
        }

        protected FileWork(string fileName)
        {
            FileName = fileName;
        }

        public static FileWork SetInstance(string fileName)
        {
            if(instance == null)
            {
                instance = new FileWork (fileName);
            }
            return instance;
        }

        public List<Passenger> GetPassengersList()
        {
            return PassengersList;
        }


        public void LoadeData()
        {
            // Проверка есть ли ссылка на файл данных настройках
            FormSettings formSettings = new FormSettings();
            var formSettingsList = formSettings.GetFormSettingList();
            if (formSettingsList.Count() > 0)
            {
                if (!string.IsNullOrEmpty(formSettingsList[0]))
                {
                    SetInstance(formSettingsList[0]);
                }
            }

            if (instance == null)
            {
                using (OpenFileDialog dialog = new OpenFileDialog()
                {
                    Filter = "Excel file|*.xlsx|Excel 97-2003|*.xls",
                    ValidateNames = true
                })
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        SetInstance(dialog.FileName);
                    }
                }
            }

            if (instance == null)
            {
                MessageBox.Show("Ошибка в LoadeData: ошибка загрузки главного файла!!!");
            }
            else
            {



                try
                {
                    Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                    _Workbook ExcelWorkBook = ExcelApp.Workbooks.Open(instance.FileName, 0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

                    PassengersList = new List<Passenger>();
                    FlightsList = new List<Flight>();
                    VTFlightPassengerList = new List<VTFlightPassenger>();

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
                                        FlightsList.Add(
                                            new Flight(
                                                ((ExcelRange.Cells[i, 1] as Microsoft.Office.Interop.Excel.Range).Value2 == null) ? 0 : (int)(ExcelRange.Cells[i, 1] as Microsoft.Office.Interop.Excel.Range).Value2,
                                                ((ExcelRange.Cells[i, 2] as Microsoft.Office.Interop.Excel.Range).Value2 == null) ? string.Empty : (ExcelRange.Cells[i, 1] as Microsoft.Office.Interop.Excel.Range).Value2.ToString(),
                                                DateTime.Now,
                                                DateTime.Now,
                                                false
                                                ));
                                        break;
                                    case 3:

                                        string isDelet = ((ExcelRange.Cells[i, 4] as Microsoft.Office.Interop.Excel.Range).Value2 == null) ? "false" : (ExcelRange.Cells[i, 4] as Microsoft.Office.Interop.Excel.Range).Value2.ToString();
                                        PassengersList.Add(
                                        new Passenger(
                                            ((ExcelRange.Cells[i, 1] as Microsoft.Office.Interop.Excel.Range).Value2 == null) ? 0 : (int)(ExcelRange.Cells[i, 1] as Microsoft.Office.Interop.Excel.Range).Value2,
                                            ((ExcelRange.Cells[i, 2] as Microsoft.Office.Interop.Excel.Range).Value2 == null) ? string.Empty : (ExcelRange.Cells[i, 2] as Microsoft.Office.Interop.Excel.Range).Value2.ToString(),
                                            ((ExcelRange.Cells[i, 3] as Microsoft.Office.Interop.Excel.Range).Value2 == null) ? string.Empty : (ExcelRange.Cells[i, 3] as Microsoft.Office.Interop.Excel.Range).Value2.ToString(),
                                            Boolean.Parse(isDelet)
                                            //((ExcelRange.Cells[i, 5] as Microsoft.Office.Interop.Excel.Range).Value2 == null) ? DateTime.Now : DateTime.Parse((ExcelRange.Cells[i, 5] as Microsoft.Office.Interop.Excel.Range).Value2)
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


                if (PassengersList.Count == 0)
                {
                    LastPassengerId = 0;
                }
                else
                {
                    LastPassengerId = PassengersList.Max(x => x.Id);
                }

                if (FlightsList.Count == 0)
                {
                    LastFlightsId = 0;
                }
                else
                {
                    LastFlightsId = FlightsList.Max(x => x.Id);
                }
            }
        }

        public void SaveData()
        {
            if(instance!= null && PassengersList != null)
            {
                try
                {
                    FormSettings formSettings = new FormSettings();
                    formSettings.AutoSave(new string[] { instance.FileName });

                    Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                    Workbook ExcelWorkbook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);





                    int i = 1;
                    Worksheet ExcelWorksheet = ExcelWorkbook.Worksheets[1];
                    foreach (var elem in VTFlightPassengerList)
                    {
                        ExcelWorksheet.Cells[i, 1] = elem.FlightId;
                        ExcelWorksheet.Cells[i, 2] = elem.PassengerId;
                        i++;
                    }

                    i = 1;
                    ExcelWorksheet = ExcelWorkbook.Worksheets[3];
                    foreach (var elem in PassengersList)
                    {
                        ExcelWorksheet.Cells[i,1] = elem.Id;
                        ExcelWorksheet.Cells[i,2] = elem.FIO.ToString();
                        ExcelWorksheet.Cells[i,3] = elem.Passport.ToString();
                        ExcelWorksheet.Cells[i,4] = elem.IsDelet;
                        //ExcelWorksheet.Cells[i, 4] = elem.IsDelet;
                        //ExcelWorksheet.Cells[i++,5] = elem.DateTime.ToString();
                        i++;
                    }

                    ExcelApp.DisplayAlerts = false;
                    ExcelApp.AlertBeforeOverwriting = false;
                    ExcelWorkbook.SaveAs(instance.FileName);

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
