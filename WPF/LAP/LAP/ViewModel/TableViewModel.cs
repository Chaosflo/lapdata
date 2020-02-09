using Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace LAP.ViewModel
{
    public class TableViewModel
    {
        #region Fields
        private ObservableCollection<Car> mainList;
        #endregion

        #region Props
        public ObservableCollection<Car> MainList
        {
            get => mainList; set { mainList = value; OnPropertyChanged(); }
        }
        #endregion


        #region Public
        public void GetMainList()
        {
            try
            {
                using (var db = new MydbDB())
                {
                    var carcam = db.Cars.Join(db.Carmodels,
                                 car => car.CamId, cam => cam.CamId,
                                 (car, cam) => new Tuple<Car, Carmodel>(car, cam)
                                );

                    var result = carcam.Join(db.Carbrands,
                                res => res.Item2.CabId, cab => cab.CabId,
                                (res, cab) => new Tuple<Car, Carmodel, Carbrand>(res.Item1, res.Item2, cab)).ToList();

                    foreach (var item in result)
                    {
                        item.Item2.Cab = item.Item3;
                        item.Item1.Cam = item.Item2;
                    }

                    var list = result.Select(x => x.Item1).ToList();


                    MainList = new ObservableCollection<Car>(list);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Unhandled exception:" + e.Message, "Exception");
            }
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
