using IKM1.Models;
using IKM1.View;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace IKM1.ViewModel
{
    internal class DataManageVM
    {
        //Вся недвижимость
        private List<Property> allProperties = DataHND.GetAllProperties();
        public List<Property> AllProperties
        {
            get { return allProperties; }
            set
            {
                allProperties = value;
            }
        }

        //Все покупатели
        private List<Buyer> allBuyers = DataHND.GetAllBuyers();
        public List<Buyer> AllBuyers
        {
            get { return allBuyers; }
            set
            {
                allBuyers = value;
            }
        }

        //Все риелторы
        private List<Realtor> allRealtors = DataHND.GetAllRealtors();
        public List<Realtor> AllRealtors
        {
            get { return allRealtors; }
            set
            {
                allRealtors = value;
            }
        }





        //Окна добавления
        private void OpenAddNewPropertyWindowMethod()
        {
            AddNewPropertyWindow newPropertyWindow = new AddNewPropertyWindow();
            SetCenterPositionAndOpen(newPropertyWindow);
        }

        private void OpenAddNewBuyerWindowMethod()
        {
            AddNewBuyerWindow newBuyerWindow = new AddNewBuyerWindow();
            SetCenterPositionAndOpen(newBuyerWindow);
        }
        private void OpenAddNewRealtorWindowMethod()
        {
            AddNewRealtorWindow newRealtorWindow = new AddNewRealtorWindow();
            SetCenterPositionAndOpen(newRealtorWindow);
        }

        //Команды добавления

        public int PropertyID{ get; set; }
        public string PropertyAdress { get; set; }
        public decimal PropertyPrice { get; set; }
        public string Propertytype { get; set; }
        public int Propertyrealtorid { get; set; }
        public int Propertybuyerid { get; set; }

        private RelayCommand addNewProperty;
        public RelayCommand AddNewProperty
        {
            get { return addNewProperty ?? new RelayCommand(x => 
                    {


                        string result = DataHND.AddProperty(PropertyAdress, PropertyPrice, Propertytype, Propertyrealtorid, Propertybuyerid);
                        ShowMessageToUser(result);
                        UpdateAllDateView();
                    }
                ); 
            }
        }

        public int BuyerID { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public decimal Budget { get; set; }

        private RelayCommand addNewBuyer;
        public RelayCommand AddNewBuyer
        {
            get
            {
                return addNewBuyer ?? new RelayCommand(x =>
                {
  
                    string result = DataHND.AddBuyer(FullName, Phone, Budget);
                    ShowMessageToUser(result);
                    UpdateAllDateView();
                }
                );
            }
        }
        public int RealtorID { get; set; }
        public decimal Comission { get; set; }
        private RelayCommand addNewRealtor;
        public RelayCommand AddNewRealtor
        {
            get
            {
                return addNewRealtor ?? new RelayCommand(x =>
                {
                    string result = DataHND.AddRealtor(FullName, Phone, Comission);
                    ShowMessageToUser(result);
                    UpdateAllDateView();
                }
                );
            }
        }


        //Окна Редактирования
        private void OpenEditPropertyWindowMethod()
        {
            EditPropertyWindow editPropertyWindow = new EditPropertyWindow();
            SetCenterPositionAndOpen(editPropertyWindow);
        }

        private void OpenEditBuyerWindowMethod()
        {
            EditBuyerWindow editBuyerWindow = new EditBuyerWindow();
            SetCenterPositionAndOpen(editBuyerWindow);
        }
        private void OpenEditRealtorWindowMethod()
        {
            EditRealtorWindow editRealtorWindow = new EditRealtorWindow();
            SetCenterPositionAndOpen(editRealtorWindow);
        }

        //Команды редактирования
        private RelayCommand editProperty;
        public RelayCommand EditProperty
        {
            get
            {
                return editProperty ?? new RelayCommand(x =>
                {

                        string result = DataHND.EditProperty(SelectedProperty.PropertyId, PropertyAdress, PropertyPrice, Propertytype, RealtorID, BuyerID);
                        UpdateAllDateView();
                        ShowMessageToUser(result);
 
                    
                }
                );
            }
        }

        public RelayCommand editBuyer;
        public RelayCommand EditBuyer
        {
            get
            {
                return editBuyer ?? new RelayCommand(x =>
                {
                    string result = DataHND.EditBuyer(SelectedBuyer.BuyerId, FullName, Phone, Budget);
                    UpdateAllDateView();
                    ShowMessageToUser(result);
                }
                );
            }
        }

        public RelayCommand editRealtor;
        public RelayCommand EditRealtor
        {
            get
            {
                return editRealtor ?? new RelayCommand(x =>
                {
                    try
                    {
                        string result = DataHND.EditRealtor(SelectedRealtor.RealtorId, FullName, Phone, Comission);
                        UpdateAllDateView();
                        ShowMessageToUser(result);
    
                    }
                    catch (Exception ex)
                    {
                        ShowMessageToUser(ex.ToString());
                    }
                    }
                );
            }
        }
        //Обновление таблиц приложения

        private void UpdateAllDateView() 
        {
            UpdateAllPropertiesView();
            UpdateAllBuyersView();
            UpdateAllRealtorsView();
        }
        private void UpdateAllPropertiesView()
        {
            AllProperties = DataHND.GetAllProperties();
            MainWindow.AllPropertiesView.ItemsSource = null;
            MainWindow.AllPropertiesView.Items.Clear();
            MainWindow.AllPropertiesView.ItemsSource = AllProperties;
            MainWindow.AllPropertiesView.Items.Refresh();
        }

        private void UpdateAllBuyersView()
        {
            AllBuyers= DataHND.GetAllBuyers();
            MainWindow.AllBuyersView.ItemsSource = null;
            MainWindow.AllBuyersView.Items.Clear();
            MainWindow.AllBuyersView.ItemsSource = AllBuyers;
            MainWindow.AllBuyersView.Items.Refresh();
        }

        private void UpdateAllRealtorsView()
        {
            AllRealtors = DataHND.GetAllRealtors();
            MainWindow.AllRealtorsView.ItemsSource = null;
            MainWindow.AllRealtorsView.Items.Clear();
            MainWindow.AllRealtorsView.ItemsSource = AllRealtors;
            MainWindow.AllRealtorsView.Items.Refresh();
        }

        //Выделение элементов
        public static Property SelectedProperty { get; set; }
        public static Buyer SelectedBuyer { get; set; }
        public static Realtor SelectedRealtor { get; set; }
        public int SelectedTab { get; set; }

        //Добавление элементов
        private RelayCommand addItem;
        public RelayCommand AddItem
        {
            get
            {
                return addItem ?? new RelayCommand(x =>
                {

                    if (SelectedTab == 0 )
                    {

                        OpenAddNewPropertyWindowMethod();
                    }
                    else if (SelectedTab == 1)
                    {
                        OpenAddNewBuyerWindowMethod();
                    }
                    else if (SelectedTab == 2)
                    {
                        OpenAddNewRealtorWindowMethod();
                    }
                }
                );
            }
        }
        //Удаление элементов
        private RelayCommand deleteItem;
        public RelayCommand DeleteItem
        { 
            get 
            {
                return deleteItem ?? new RelayCommand(x =>
                {
                    string result ="Не выбран элемент";
                    if (SelectedTab == 0 && SelectedProperty != null)
                    {
                        result = DataHND.DelProperty(SelectedProperty);
                    }
                    else if (SelectedTab == 1 && SelectedBuyer != null)
                    {
                        result = DataHND.DelBuyer(SelectedBuyer);
                    }
                    else if (SelectedTab == 2 && SelectedRealtor != null)
                    {
                        result = DataHND.DelRealtor(SelectedRealtor);
                    }

                    UpdateAllDateView();
                    ShowMessageToUser(result);
                }
                    );
            } 
        }

        //Редактирование элементов
        private RelayCommand editItem;
        public RelayCommand EditItem
        {
            get
            {
                return editItem ?? new RelayCommand(x =>
                {
  
                    if (SelectedTab == 0 && SelectedProperty != null)
                    {

                        OpenEditPropertyWindowMethod();
                    }
                    else if (SelectedTab == 1 && SelectedBuyer != null)
                    {
                        OpenEditBuyerWindowMethod();
                    }
                    else if (SelectedTab == 2 && SelectedRealtor != null)
                    {
                        OpenEditRealtorWindowMethod();
                    }
                }
                );
            }
        }
        private void ShowMessageToUser(string message)
        {
            ErrorMessageWindow msg = new ErrorMessageWindow(message);
            SetCenterPositionAndOpen(msg);
        }

        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }

    }
}
