using E_Thievet_WPFApp.Models;
using SimpleBinding;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace E_Thievet_WPFApp.ViewModels
{
    internal class ViewModel1 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #region HelloWorld
        private string _test = "Hello World !";
        public string Test
        {
            get { return _test; }
            set
            {
                _test = value;
                OnPropertyChanged("Test"); // Notifie la vue que la propriété "Test" a été modifié
            }
        }
        #endregion

        #region EditItem
        public ICommand EditItem
        {
            get
            {
                return new RelayCommand(param =>
                {
                    Test = "Texte mis à jour ! (Incroyable)";
                });
            }
        }
        #endregion

        #region BindingListBox
        // Faire une liste de String et l’afficher en binding dans une listebox
        private ObservableCollection<string> _myList = new() { "Earl Grey", "Thym menthe", "Sencha" };
        public ObservableCollection<string> MyList
        {
            get
            {
                return _myList;
            }
        }
        #endregion

        #region AjouterModifierSupprimer
        //Faire 3 boutons avec des commandes : Ajouter élément / Modifier le premier élément / supprimer le premier élément
        public ICommand AddItem
        {
            get
            {
                return new RelayCommand(param =>
                {
                    MyList.Add(Test.ToString());
                });
            }
        }

        public ICommand UpdateItem
        {
            get
            {
                return new RelayCommand(param =>
                {
                    MyList[0] = Test.ToString();
                });
            }
        }

        public ICommand DeleteItem
        {
            get
            {
                return new RelayCommand(param =>
                {
                    MyList.RemoveAt(0);
                }, param =>

                    MyList.Count > 0
                );
            }
        }
        #endregion

        #region ListeMessages
        // Faire une liste d’objets de type Message

        public ObservableCollection<Message> MessageList { get; set; }


        public ObservableCollection<Message> FillList()
        {
            return MessageList;
        }

        public ViewModel1() //construtor
        {
            MessageList = new ObservableCollection<Message>();
            Message m1 = new() { Content = "Mon premier message", Emitter = "Elsa", Date = DateTime.Now };
            Message m2 = new() { Content = "Mon deuxième message", Emitter = "Guilhèm", Date = DateTime.Now };
            Message m3 = new() { Content = "Mon troisième message", Emitter = "Kai", Date = DateTime.Now };
            MessageList.Add(m1);
            MessageList.Add(m2);
            MessageList.Add(m3);
        }
        #endregion

        #region AjouterModifierSupprimerMessage

        private string _inputContent = "Entrez votre message";
        public string InputContent
        {
            get
            {
                return _inputContent;
            }
            set
            {
                _inputContent = value;
                OnPropertyChanged("InputContent");
            }
        }

        private string _inputEmitter = "Entrez votre nom d'émetteur";
        public string InputEmitter
        {
            get
            {
                return _inputEmitter;
            }
            set
            {
                _inputEmitter = value;
                OnPropertyChanged("InputEmitter");
            }
        }

        public ICommand AddMessage
        {
            get
            {
                return new RelayCommand(param =>
                {
                    Message message = new() { Content = InputContent, Emitter = InputEmitter, Date = DateTime.Now };
                    MessageList.Add(message);
                });
            }
        }

        public ICommand DeleteMessage
        {
            get
            {
                return new RelayCommand(param =>
                {
                    MessageList.RemoveAt(0);
                }, param => MessageList.Count > 0);
            }
        }
        #endregion

        #region Bonus1

        public int SelectedItem { get; set; }

        public ICommand DeleteSelected
        {
            get
            {
                return new RelayCommand(param =>
                {
                    MessageList.RemoveAt(SelectedItem);
                });
            }
        }
        #endregion

        #region Bonus2
        private int _number;
        public int Number
        {
            get { return _number; }
            set
            {
                _number = value;
                OnPropertyChanged("Number");
            }
        }

        public ICommand ReplaceNumber
        {
            get
            {
                return new RelayCommand(param =>
                {

                    Number = Random.Shared.Next(0, 100);
                });
            }
        }
        #endregion

        #region TemplateDeleteMessageBtn

        public RelayCommand DeleteOnMessage
        {
            get
            {
                return new RelayCommand(param =>
                {
                    MessageList.Remove((Message)param);
                });
            }
        }
        #endregion

        #region CheminsImages

        public ObservableCollection<string> ImagePathList { get; set; } = ["Resources/bulbasaur.png", "Resources/charmander.png", "Resources/pikachu.png", "Resources/psykokwak.png"];
        
        #endregion
    }
}
