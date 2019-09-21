using System;
using ToDoList_Application.Models;
using Unity;

namespace ToDoList_Application
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });
       
        public static IUnityContainer Container => container.Value;
        #endregion
              
        public static void RegisterTypes(IUnityContainer container)
        {            
             container.RegisterType<I_Todo, Helpers>();
        }
    }
}