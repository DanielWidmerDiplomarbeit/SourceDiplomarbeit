using System;
using System.Collections.Generic;
using Xamarin.Forms;
using ZeusMobile.ViewModels;

namespace ZeusMobile
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class ViewTypeAttribute : Attribute
    {
        public Type ViewType { get; private set; }

        public ViewTypeAttribute(Type viewType)
        {
            ViewType = viewType;
        }
    }
    // Can be replaced by all sorts of complexity and auto loading BS but this keeps it simple and loose
    static class ViewFactory
    {
        static Dictionary<Type, Type> typeDictionary = new Dictionary<Type, Type>();
        public static void Register<TView, TViewModel>()
            where TView : Page
            where TViewModel : BaseViewModel
        {
            typeDictionary[typeof(TViewModel)] = typeof(TView);
        }

        public static Page CreatePage(Type viewModelType)
        {
            Type viewType;

            if (typeDictionary.ContainsKey(viewModelType))
            {
                viewType = typeDictionary[viewModelType];
            }
            else
            {
                throw new InvalidOperationException("Unknown View for ViewModelType");
            }

            var page = (Page)Activator.CreateInstance(viewType);
            var viewModel = (BaseViewModel)Activator.CreateInstance(viewModelType);

            viewModel.Navigation = new ViewModelNavigation(page);
            page.BindingContext = viewModel;

            return page;
        }

        public static Page CreatePage(BaseViewModel viewModel)
        {
            Type viewType;
            if (typeDictionary.ContainsKey(viewModel.GetType()))
            {
                viewType = typeDictionary[viewModel.GetType()];
            }
            else
            {
                throw new InvalidOperationException("Unknown View for ViewModel object");
            }

            var page = (Page)Activator.CreateInstance(viewType);

            viewModel.Navigation = new ViewModelNavigation(page);
            page.BindingContext = viewModel;

            return page;
        }


        public static Page CreatePage<TViewModel>()
            where TViewModel : BaseViewModel
        {
            var viewModelType = typeof(TViewModel);
            return CreatePage(viewModelType);
        }
    }
}

