/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:MVVMLight_20200524"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
//using Microsoft.Practices.ServiceLocation;
using CommonServiceLocator;

namespace MVVMLight_20200524.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<WelcomeViewModel>();
            SimpleIoc.Default.Register<UserInfoViewModel>();
            SimpleIoc.Default.Register<ComplexInfoViewModel>();


            SimpleIoc.Default.Register<ValidateExceptionViewModel>();
            SimpleIoc.Default.Register<ValidationRuleViewModel>(); 
            SimpleIoc.Default.Register<BindingFormViewModel>();
            SimpleIoc.Default.Register<BindDataAnnotationsViewModel>();
        }
        #region สตภýปฏ
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }


        public WelcomeViewModel Welcome
        {
            get
            {
                return ServiceLocator.Current.GetInstance<WelcomeViewModel>();
            }
        }

        public UserInfoViewModel UserInfo
        {
            get
            {
                return ServiceLocator.Current.GetInstance<UserInfoViewModel>();
            }
        }

        public ComplexInfoViewModel Complex
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ComplexInfoViewModel>();
            }
        }

        public ValidateExceptionViewModel ValidateException
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ValidateExceptionViewModel>();
            }
        }

        public ValidationRuleViewModel ValidationRule
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ValidationRuleViewModel>();
            }
        }
        public BindingFormViewModel BindingForm
        {
            get
            {
                return ServiceLocator.Current.GetInstance<BindingFormViewModel>();
            }
        }
        public BindDataAnnotationsViewModel BindDataAnnotations
        {
            get
            {
                return ServiceLocator.Current.GetInstance<BindDataAnnotationsViewModel>();
            }
        }
        
        #endregion


        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}