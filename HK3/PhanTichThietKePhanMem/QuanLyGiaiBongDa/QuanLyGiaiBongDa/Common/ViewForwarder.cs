/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 21/03/2017 - ViewForwarder.cs
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace QuanLyGiaiBongDa.Common
{
    //Class support change View
    public static class ViewForwarder
    {
        /// <summary>
        /// Application to be screen transitioned. Since individual applications can not be seen from the framework, it is necessary to set this property in advance.
        /// </ summary>
        /// <remarks>
        /// You can set this property only once at application startup.
        /// <para> [Example of usage code] </ para>
        /// <para>
        /// ViewForwarder.Application = App.Current;
        /// ViewForwarder.Forward ("MenuVM");
        /// </ para>
        /// </ remarks>
        public static Application Application { get; set; }

        static string _viewModelFolderName = "ViewModels";

        /// <summary>
        /// Folder name of the view model. The default value is [ViewModel].
        /// </ summary>
        /// <remarks>
        ///Used for interpretation of /// namespace. Let namespace be "[application's namespace]. [Value of this property]".
        /// Set this property only if the folder name is not the default value.
        /// If the namespace is the same as [application namespace], set it to null.
        /// </ remarks>
        public static string ViewModelFolderName
        {
            get { return _viewModelFolderName; }
            set { _viewModelFolderName = value; }
        }

        static string _viewFolderName = "Views";
        /// <summary>
        /// Folder name of the view. The default value is [View].
        /// </ summary>
        /// <remarks>
        /// Used for interpretation of /// namespace. Let namespace be "[application's namespace]. [Value of this property]".
        /// Set this property only if the folder name is not the default value.
        /// If the namespace is the same as [application namespace], set it to null.
        /// </ remarks>
        public static string ViewFolderName
        {
            get { return _viewFolderName; }
            set { _viewFolderName = value; }
        }

         /// Screen transition by modeless.
         /// </ summary>
         /// <param name = "viewModelName"> View model class name </ param>
         /// <param name = "args"> View model constructor argument </ param>
         /// <remarks>
         /// For the class name of the view, apply the standard naming convention based on the class name of the view model (eg HogeVM => HogeV).
        /// </remarks>
        public static void ForwardModeless(string viewModelName, params object[] args)
        {
            Forward(viewModelName, null, false, args);
        }

        /// <summary>
        /// Screen transition by modal.
        /// </ summary>
        /// <param name = "viewModelName"> View model class name </ param>
        /// <param name = "args"> View model constructor argument </ param>
        /// <remarks>
        /// For the class name of the view, apply the standard naming convention based on the class name of the view model (eg HogeVM => HogeV).
        /// </ remarks>
        public static void ForwardModal(string viewModelName, params object[] args)
        {
            Forward(viewModelName, null, true, args);
        }

        static void Forward(string viewModelName, string viewName, bool isModal, params object[] args)
        {
            Type viewModelType;
            Type viewType;
            if ((viewModelType = GetViewModelType(viewModelName)) == null ||
                (viewType = GetViewType(viewModelName, viewName)) == null)
            {
                MessageBox.Show(string.Join(Environment.NewLine, "viewModelName=" + viewModelName, "viewName=" + viewName, "isModal=" + isModal, "args=" + string.Join(", ", args)));
                return;
            }

            //if (viewType.IsSubclassOf(typeof(Page)))
            //{
            //    ForwardNavigation(viewModelName, viewName, isModal, false, args);
            //    return;
            //}
            var viewModel = (BaseViewModel)CreateInstance(viewModelType, args);

            var view = (Window)CreateInstance(viewType, null);
            new WindowEventManager(view).SetEventHandlers();
            view.DataContext = viewModel;
            if (viewModel.ShowDialogBox == null) viewModel.ShowDialogBox = () => { if (isModal) view.ShowDialog(); else view.Show(); };
            if (viewModel.CloseDialogBox == null) viewModel.CloseDialogBox = view.Close;
            viewModel.ShowDialogBox();
        }

        //static void ForwardNavigation(string viewModelName, string viewName, bool isModal, bool isSaveHistory, params object[] args)
        //{
        //    Type viewModelType;
        //    Type viewType;
        //    if ((viewModelType = GetViewModelType(viewModelName)) == null ||
        //        (viewType = GetViewType(viewModelName, viewName)) == null)
        //    {
        //        MessageBox.Show(string.Join(Environment.NewLine, "viewModelName=" + viewModelName, "viewName=" + viewName, "isModal=" + isModal, "args=" + string.Join(", ", args)));
        //        return;
        //    }

        //    if (!viewType.IsSubclassOf(typeof(Page)))
        //    {
        //        if (IsDebugBuild)
        //        {
        //            MessageBox.Show(string.Join(Environment.NewLine, "Not NavigationWindow!", "viewModelName=" + viewModelName, "viewName=" + viewName, "isModal=" + isModal, "args=" + string.Join(", ", args)));
        //            return;
        //        }
        //    }

        //    var viewModel = (BaseViewModel)CreateInstance(viewModelType, args);

        //    var view = (Page)CreateInstance(viewType, null);
        //    var baseWindow = new MainWindow();
        //    new WindowEventManager(baseWindow).SetEventHandlers();
        //    view.DataContext = viewModel;

        //    view.WindowHeight = view.Height + 40;
        //    view.WindowWidth = view.Width + 15;
        //    view.WindowTitle = view.Title;

        //    view.ShowsNavigationUI = false;

        //    var navi = baseWindow.NavigationService;

        //    NavigationObject navigateElements = new NavigationObject();
        //    navigateElements.ShowDialogBox = () => { baseWindow.ShowDialog(); };
        //    navigateElements.Show = () => { baseWindow.Show(); };
        //    navigateElements.CloseDialogBox = () => { baseWindow.Close(); };
        //    navigateElements.Navigate = (obj) => { navi.Navigate(obj); };
        //    navigateElements.RemoveBackEntry = () => { navi.RemoveBackEntry(); };
        //    string navigationName = NavigationController.MakeNavigationName();
        //    NavigationController.AddNavigateElements(navigationName, navigateElements);

        //    navi.LoadCompleted += (sender, param) => { navi.RemoveBackEntry(); };

        //    ((BasePageViewModel)viewModel).NavigationName = navigationName;
        //    navi.Navigate(view);

        //    baseWindow.NavigationName = navigationName;

        //    if (isModal) baseWindow.ShowDialog();
        //    else baseWindow.Show();
        //}

        static Type GetViewModelType(string viewModelName)
        {
            Type _viewModelType;
            try
            {
                _viewModelType = GetType(ViewModelFolderName, viewModelName);
            }
            catch (Exception)
            {
                if (IsDebugBuild)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return _viewModelType;
        }

        static Type GetViewType(string viewModelName, string viewName)
        {
            var _viewName = viewName ?? viewModelName.Replace("VM", "V");
            Type viewType;
            try
            {
                viewType = GetType(ViewFolderName, _viewName);
            }
            catch (Exception)
            {
                if (IsDebugBuild)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return viewType;
        }

        static bool IsDebugBuild
        {
            get
            {
                try
                {
                    var debuggableAttributes = Application.ResourceAssembly.GetCustomAttributes(typeof(DebuggableAttribute), true);
                    if (debuggableAttributes.Length > 0 && ((DebuggableAttribute)debuggableAttributes[0]).IsJITTrackingEnabled)
                        return true;
                    return false;
                }
                catch (Exception)
                {
                    return true;
                }
            }
        }

        static Type GetType(string folderName, string name)
        {
            return Application.GetType().Assembly.GetType(FullName(folderName, name), true);
        }

        const string Separator = ".";

        static string FullName(string folderName, string name)
        {
            if (folderName == null) return string.Join(Separator, Application.GetType().Namespace, name);
            return string.Join(Separator, Application.GetType().Namespace, folderName, name);
        }
        const string MemberName = "VALUE";
        static object CreateInstance(Type type, params object[] args)
        {
            return type.InvokeMember(MemberName, BindingFlags.CreateInstance, null, null, args);
        }
    }
}
