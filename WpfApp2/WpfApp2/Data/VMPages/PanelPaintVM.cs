using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Helpers;

namespace WpfApp2.Data.VMPages
{
    public class PanelPaintVM : BaseVM
    {
        private WpfApp2.Data.VMPages.CompilarVM CompilarVM;
        private IEnumerable<VMDataName.DataUser> NewDataUser;

        private string nameMess = "Авторизуйтесь";
        public string NameMess
        {
            get { return nameMess; }
            set { nameMess = value; NotifyPropertyChanged(); }
        }


        private IEnumerable<VMDataName.DataUser> registrations;
        public IEnumerable<VMDataName.DataUser> Registrations
        {
            get { return registrations; }
            set { registrations = value; NotifyPropertyChanged("DataUsers"); }
        }

        public PanelPaintVM()
        {
            //db.Registrations.Where(t => t.Id == 1).Load();
            CompilarVM = new WpfApp2.Data.VMPages.CompilarVM();

            db.DataUsers.Load();
            Registrations = db.DataUsers.Local.ToBindingList();
        }

        private VMDataName.DataUser selectedName;
        public VMDataName.DataUser SelectedName
        {
            get { return selectedName; }
            set
            {
                if (selectedName == value)
                    return;
                selectedName = value;
                NameMess = value.Name;
                Cash.id = value.Id;
                CompilarVM.SetCompilar(value.Id);
            }
        }


        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(async obj =>
                    {
                        Pages.Registratios registrationPage = new Pages.Registratios(new VMDataName.DataUser());
                        if (registrationPage.ShowDialog() == true)
                        {
                            VMDataName.DataUser reg = registrationPage.DataUsers;
                            db.DataUsers.Add(reg);
                            db.SaveChanges();

                            NewDataUser = db.DataUsers.Where(t => t.Name == reg.Name && t.Password == reg.Password);
                            
                            db.ItemsHeader.Add(new VMDataName.ItemHeader()
                            {
                                Header="1",
                                Id_User = NewDataUser.First().Id
                            });
                            db.ItemsHeader.Add(new VMDataName.ItemHeader()
                            {
                                Header = "2",
                                Id_User = NewDataUser.First().Id
                            });

                            db.SaveChanges();
                        }
                    }));
            }

        }
    }
}
